using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Mail.ru_Tests
{
    public class EmailHelper : HelperBase
    {
        public EmailHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void SendEmail(EmailData email)
        {
            driver.FindElement(By.CssSelector("a[title='Написать письмо'")).Click();
            driver.FindElement(By.CssSelector("div[data-type='to']")).SendKeys(email.Whom);
            driver.FindElement(By.CssSelector("input[name='Subject']")).SendKeys(email.Theme);
            driver.FindElement(By.CssSelector("div[@role='textbox']")).SendKeys(email.BodyEmail);
            driver.FindElement(By.CssSelector("span[@title='Отправить']")).Click();
        }
    }
}
