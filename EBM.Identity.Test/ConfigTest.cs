using System;
using System.Linq;
using NUnit.Framework;

namespace EBM.Identity.Test
{
    public class ConfigTest
    {


        [Test]
        public void ApiScopes_Should_Be_One()
        {
            Assert.That(Config.ApiScopes.Count() == 1);
        }

        [Test]
        public void ApiScopes_Should_Has_A_Specific_Item()
        {            
            Assert.That(Config.ApiScopes.First().Name.Equals("Iterations"));
        }
    }
}