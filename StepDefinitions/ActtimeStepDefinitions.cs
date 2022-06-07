using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using UnitTestProject1.Componenthelpers;
using UnitTestProject1.PageObject;
using UnitTestProject1.Settingss;


namespace UnitTestProject1.StepDefinitions
{
    [Binding]
    public sealed class ActtimeStepDefinitions
    {
        
        [Given(@"User is at homepage")]
        public void GivenUserIsAtHomepage()
        {
            //PageActionsHelper.NavigateToUrl(Objectrepository.Config.GetWebsite());
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("https://online.actitime.com/lgsoft/login.do");
            Objectrepository.LoginPage = new LoginPage(Objectrepository.Driver);
            Objectrepository.Driver.Navigate().GoToUrl(Objectrepository.Config.GetWebsite());
           
            //loGIN.login(Objectrepository.Config.GetUsername(), Objectrepository.Config.GetPassword());

        }
        //[When(@"user enter username and password")]
        //public void WhenUserEnterUsernameAndPassword()
        //{
            
        //}

        //[Then(@"i verfiy the home page")]
        //public void ThenIVerfiyTheHomePage()
        //{
           

        //}
    }
}