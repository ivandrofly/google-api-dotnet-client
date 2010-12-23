/*
Copyright 2010 Google Inc

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.CodeDom;
using System.Collections.Generic;

using Google.Apis.Discovery;
using Google.Apis.Tools.CodeGen.Decorator.ResourceContainerDecorator;

namespace Google.Apis.Tools.CodeGen.Generator
{


    public class ResourceContainerGenerator
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger (typeof(ResourceContainerGenerator));

        private readonly IEnumerable<IResourceContainerDecorator> decorators;

        public ResourceContainerGenerator (IEnumerable<IResourceContainerDecorator> decorators)
        {
            this.decorators = decorators;
        }
        
        public void AddResourceContainerDecorations(IResourceContainer container, 
                                                    CodeTypeDeclaration codeClass)
        {
            logger.DebugFormat("AddResourceContainerDecorations called for {0}", container.Name);
            foreach(IResourceContainerDecorator dec in decorators)
            {
                dec.DecorateClass(container, codeClass);
            }        
        }
    }
}
