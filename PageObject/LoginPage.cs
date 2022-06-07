using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UnitTestProject1.BaseClass;
using UnitTestProject1.Componenthelpers;

namespace UnitTestProject1.PageObject
{

    public  class LoginPage : PageBase
    {
        #region WebElement
        private IWebDriver driver;


        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement LoginTextBox;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement PassTextBox;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Login']")]
        private IWebElement LoginBTN;
        #endregion
        #region Actions

        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;

        }
        #endregion
        #region Navigation

        public LoginPage login(string username, string Password)
        {
            LoginTextBox.SendKeys(username);
            PassTextBox.SendKeys(Password);
            LoginBTN.Click();
            GenricHelper.WaitforElementToBeDisplayed(By.XPath("//h3[normalize-space()='Enter Time-Track for']"));
            return new LoginPage(driver);

        }

        #endregion


    }
}
