using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Mail.ru_Tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected EmailHelper emailHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        // объект который будет устанавливать соответствие между текущим потоком и объектом типа ApplicationManager

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "https://mail.ru/";
            navigator = new NavigationHelper(this, baseURL);
            loginHelper = new LoginHelper(this);
            emailHelper = new EmailHelper(this);
        }

        ~ApplicationManager() //Деструктор, вызывается автоматический, нельзя к нему обратиться
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public EmailHelper Email
        {
            get
            {
                return emailHelper;
            }
        }
    }
}
