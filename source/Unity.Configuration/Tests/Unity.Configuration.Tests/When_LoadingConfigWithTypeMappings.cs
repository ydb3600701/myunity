﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity.Configuration.Tests.ConfigFiles;
using Microsoft.Practices.Unity.TestSupport.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.Unity.Configuration.Tests
{
    /// <summary>
    /// Summary description for When_LoadingConfigWithTypeMappings
    /// </summary>
    [TestClass]
    public class When_LoadingConfigWithTypeMappings : SectionLoadingFixture<ConfigFileLocator>
    {
        public When_LoadingConfigWithTypeMappings() : base("BasicTypeMapping")
        {
        }

        private ContainerElement container;

        protected override void Arrange()
        {
            base.Arrange();
            container = Section.Containers.Default;
        }

        [TestMethod]
        public void Then_RegistrationsArePresentInContainer()
        {
            Assert.AreEqual(2, container.Registrations.Count);
        }

        [TestMethod]
        public void Then_TypesAreAsGivenInFile()
        {
            AssertRegistrationsAreSame(r => r.TypeName, "ILogger", "ILogger");
        }

        [TestMethod]
        public void Then_MappedNamesAreAsGivenInFile()
        {
            AssertRegistrationsAreSame(r => r.Name, "", "special");    
        }

        [TestMethod]
        public void Then_MappedToTypesAreAsGivenInFile()
        {
            AssertRegistrationsAreSame(r => r.MapToName, "MockLogger", "SpecialLogger");
        }

        private void AssertRegistrationsAreSame(Func<RegisterElement, string> selector, params string [] expectedStrings)
        {
            CollectionAssert.AreEqual(expectedStrings, container.Registrations.Select(selector).ToList());
        }
    }
}