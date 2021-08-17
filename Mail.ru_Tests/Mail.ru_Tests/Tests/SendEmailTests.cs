using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Mail.ru_Tests.Tests
{
    public class SendEmailTests : AuthTestBase
    {
        [Test]
        public void SendEmailTest()
        {
            EmailData newemail = new EmailData()
            {
                Whom = "ayaz.imamov.99@mail.ru",
                Theme = GenerateRandomString(10),
                BodyEmail = GenerateRandomString(100)
            };
            app.Email.SendEmail(newemail);
            Assert.IsTrue(app.Email.IsElementPresent(By.XPath("//a[text()='Письмо отправлено')")));
        }

    }
}
