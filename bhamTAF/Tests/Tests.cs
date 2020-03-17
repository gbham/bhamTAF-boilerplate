using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace bhamTAF
{
    [TestFixture]
    public class Tests : IntegrationTest
    {        
        [Test]
        public void Test1()
        {
            var HomePage = LoadSite();
            
            HomePage.GoToLoginPage();

            HomePage.GoToHomePage();

            HomePage.GoToLoginPage();
        }          
    }
}