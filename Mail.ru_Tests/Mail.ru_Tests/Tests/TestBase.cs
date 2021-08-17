﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Mail.ru_Tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max) //Генератор случайных строк, длина которых 
                                                           //длина которых не будет превышать max
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65))); // коды символов в ASCII 
            }
            return builder.ToString();
        }
    }
}
