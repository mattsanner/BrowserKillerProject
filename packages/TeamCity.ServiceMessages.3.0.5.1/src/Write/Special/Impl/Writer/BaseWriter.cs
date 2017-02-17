/*
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

namespace JetBrains.TeamCity.ServiceMessages.Write.Special.Impl.Writer
{
  public class BaseWriter<TProc> where TProc : IServiceMessageProcessor
  {
    protected readonly TProc myTarget;

    protected BaseWriter(TProc target)
    {
      myTarget = target;
    }

    protected BaseWriter(BaseWriter<TProc> writer) : this(writer.myTarget)
    {      
    }

    protected void PostMessage(IServiceMessage message)
    {
      myTarget.AddServiceMessage(message);
    }
  }

  public class BaseWriter : BaseWriter<IServiceMessageProcessor>
  {
    protected BaseWriter(IServiceMessageProcessor target) : base(target)
    {
    }

    protected BaseWriter(BaseWriter<IServiceMessageProcessor> writer) : base(writer)
    {
    }
  }
}
