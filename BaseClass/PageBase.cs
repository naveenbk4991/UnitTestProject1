using UnitTestProject1.Componenthelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace UnitTestProject1.BaseClass
{
    public class PageBase
    {

        private IWebDriver driver;

        // Change this to non-page factory implementation
        public PageBase(IWebDriver _driver)
        {
           // PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }
        public void Logout()
        {
            if (GenricHelper.IsElementPresent(By.XPath("//a[@id='logoutLink']")))
            {
                InputActionsHelper.Click(By.XPath("//a[@id='logoutLink']"));
            }


        }
    }

}
