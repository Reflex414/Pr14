using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pr14;

namespace UnitTestProject2
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void RegTestSuccess()
        {
            var page = new RegisterPage();
            Assert.IsTrue(page.Register("АД", "AD@gmai.com", "new@mail.ru", "123", "123"));

        }
        [TestMethod]
        public void RegTestFail()
        {
            var page = new RegisterPage();
            Assert.IsFalse(page.Register("", "", "", "", ""));
            Assert.IsFalse(page.Register("Тест", "test_user", "test@mail.ru", "123", "321"));
            Assert.IsFalse(page.Register("Петр", "petr777", "petr@mail.ru", "12345", "54321"));
            Assert.IsFalse(page.Register("Коля", "nick99", "nick@mail.ru", "1", "1"));
        }
    }
}
