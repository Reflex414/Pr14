using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pr14;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new LoginPage();
            Assert.IsTrue(page.Auth("ruslan", "1234"));
            Assert.IsFalse(page.Auth("user1", "12345"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
        }
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new LoginPage();
            Assert.IsTrue(page.Auth("ruslan", "1234"));
            Assert.IsTrue(page.Auth("GMO", "12345"));
            Assert.IsTrue(page.Auth("ivan123", "password123"));
            Assert.IsTrue(page.Auth("maria456", "qwerty456"));
            Assert.IsTrue(page.Auth("petr789", "12345678"));
            Assert.IsTrue(page.Auth("1", "111"));
            Assert.IsTrue(page.Auth("2", "111"));
            Assert.IsTrue(page.Auth("3", "333"));
            Assert.IsTrue(page.Auth("Adam@gmai.com", "123"));
        }
        [TestMethod]
        public void AuthTestFail()
        {
            var page = new LoginPage();
            Assert.IsFalse(page.Auth("ivan123", "wrong_password"));
            Assert.IsFalse(page.Auth("", ""));
        }
    }
}