using UnitTestProject1.Interfac;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObject;

namespace UnitTestProject1.Settingss
{
    public class Objectrepository

    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }

        public static LoginPage LoginPage;

        //public static LoginPage lgin;
    }
}
