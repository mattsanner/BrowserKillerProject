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

using System;

namespace JetBrains.TeamCity.ServiceMessages.Write.Special.Impl.Writer
{
  /// <summary>
  /// Represents information about currently openned child blocks or tests or test suites.
  /// </summary>
  public interface ISubWriter : IDisposable
  {
    /// <summary>
    /// This method performs check if no child blocks are opennd.
    /// It is used to check if it is allowed to use current I*Writer
    /// </summary>
    void AssertNoChildOpened();
  }
}