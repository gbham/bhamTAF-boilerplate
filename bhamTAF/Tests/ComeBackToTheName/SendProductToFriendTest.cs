using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;


namespace bhamTAF
{
    [TestFixture]
    public class SendProductToFriendTest : IntegrationTest
    {
        [Test]  
        public void SendProductToFriend()
        {
            var Menu = LoadSite();
            var LoginPage = Menu.GoToLoginPage();
        }
    }
}