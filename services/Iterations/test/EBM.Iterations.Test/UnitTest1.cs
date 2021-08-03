using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EBM.Iterations.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, "example name"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
            new Claim("custom-claim", "example claim value"),
            }, "mock"));

            IdentityController identityController = new IdentityController();
            identityController.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            var result = identityController.Get();
            Assert.NotNull(result);

            var JsonResult = result as JsonResult;
            Assert.NotNull(JsonResult);

            IEnumerable<Object> messages = JsonResult.Value as IEnumerable<Object>;
            Assert.NotNull(messages);


            List<Object> listMessages = messages.ToList();
            Assert.AreEqual(listMessages.Count, 3);
        }
    }
}