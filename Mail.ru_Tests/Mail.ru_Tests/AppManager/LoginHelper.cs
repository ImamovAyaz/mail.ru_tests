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
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn()) //Проверка, залогинен ли пользователь и под каким пользователем
            {
                Logout();
            }
            driver.FindElement(By.XPath("//div[@class='headline headline_white']//button[text()='Войти']")).Click();
            Thread.Sleep(3000);
           WaitForElementLoad(By.Name("username"),30);
            Type(By.Name("username"), account.Username);
            WaitForElementLoad(By.CssSelector("button[data-test-id='next-button']"), 30);
            driver.FindElement(By.CssSelector("button[data-test-id='next-button']")).Click();
            WaitForElementLoad(By.Name("password"), 30);
            Type(By.Name("password"), account.Password);
            WaitForElementLoad(By.CssSelector("button[data-test-id='submit-button']"), 30);
            driver.FindElement(By.CssSelector("button[data-test-id='submit-button']")).Click();
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//a[@rel='nofollow']//div[text()='Выйти']")).Click();
            }
        }
        public bool IsLoggedIn()  // Метод возвращающий наименование элемента,
                                  // который говорит о том что пользователь зарег-ан
        {
            return IsElementPresent(By.XPath("//div[@data-testid='whiteline - account']"));
        }
    }

}
