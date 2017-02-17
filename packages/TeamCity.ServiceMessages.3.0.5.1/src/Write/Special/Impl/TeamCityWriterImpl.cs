﻿/*
 * Copyright 2007-2011 JetBrains s.r.o.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using JetBrains.TeamCity.ServiceMessages.Annotations;
using JetBrains.TeamCity.ServiceMessages.Write.Special.Impl.Writer;

namespace JetBrains.TeamCity.ServiceMessages.Write.Special.Impl
{
  public class TeamCityWriterImpl : TeamCityWriterFacade, ISubWriter
  {
    private readonly IEnumerable<ISubWriter> myWriteCheck;

    public TeamCityWriterImpl([NotNull] IFlowServiceMessageProcessor processor,
                              [NotNull] IDisposable dispose)
      : this(processor,
             new TeamCityFlowWriter<ITeamCityWriter>(processor, (handler, writer) => new TeamCityWriterImpl(writer, handler), DisposableNOP.Instance),
             new TeamCityBlockWriter<ITeamCityWriter>(processor, d => new TeamCityWriterImpl(processor, d)),
             new TeamCityCompilationBlockWriter<ITeamCityWriter>(processor, d => new TeamCityWriterImpl(processor, d)),
             new TeamCityTestSuiteBlock(processor, DisposableNOP.Instance),
             new TeamCityMessageWriter(processor),
             new TeamCityArtifactsWriter(processor),
             new TeamCityBuildStatusWriter(processor),             
             dispose)
    {
    }

    private TeamCityWriterImpl([NotNull] IFlowServiceMessageProcessor processor,
                               [NotNull] TeamCityFlowWriter<ITeamCityWriter> flowWriter, 
                               [NotNull] TeamCityBlockWriter<ITeamCityWriter> blockWriter,
                               [NotNull] TeamCityCompilationBlockWriter<ITeamCityWriter> compilationWriter, 
                               [NotNull] TeamCityTestSuiteBlock testsWriter, 
                               [NotNull] ITeamCityMessageWriter messageWriter, 
                               [NotNull] ITeamCityArtifactsWriter artifactsWriter, 
                               [NotNull] ITeamCityBuildStatusWriter statusWriter, 
                               [NotNull] IDisposable dispose) 
      : base(processor, blockWriter, compilationWriter, testsWriter, messageWriter, artifactsWriter, statusWriter, flowWriter, dispose)
    {
      myWriteCheck = new ISubWriter[] { blockWriter, compilationWriter, testsWriter, flowWriter };
    }

    public void AssertNoChildOpened()
    {
      foreach (var subWriter in myWriteCheck)
        subWriter.AssertNoChildOpened();
    }

    protected override void CheckConsistency()
    {
      base.CheckConsistency();
      AssertNoChildOpened();
    }

    public override void Dispose()
    {
      foreach (var subWriter in myWriteCheck)
        subWriter.Dispose();

      base.Dispose();
    }
  }
}