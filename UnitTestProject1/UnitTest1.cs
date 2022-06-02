using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLogin()
        {
            Username oUser = new Username();
            Assert.AreEqual(true, oUser.LoginScreen("User1", "123"), "Поля username и password не введены ");
        }
    }
}
