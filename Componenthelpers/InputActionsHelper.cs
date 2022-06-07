using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Componenthelpers
{
    public class InputActionsHelper
    {

        #region Click helper methods

        /// <summary>
        /// Uses Webdriver explicit wait with a lambda function which waits for the element to be enabled before clicking for a maximum amount of time.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static void Click(By locator, int timeInMilliseconds = 10000)
        {
            GenricHelper.WaitforElementToBeEnabled(locator, timeInMilliseconds);
            GenricHelper.GetElement(locator).Click();
        }

        /// <summary>
        /// Uses Webdriver explicit wait with a lambda function which waits for the element to be enabled before clicking for a maximum amount of time.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static void Click(IWebElement element, int timeInMilliseconds = 10000)
        {
            GenricHelper.WaitforElementToBeEnabled(element, timeInMilliseconds);
            element.Click();
        }

        /// <summary>
        /// Waits for an element to be visible, scrolls to that element then waits for that element to be clickable and clicks
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void ScrollToElementAndClick(By locator, int timeInMilliseconds = 10000)
        {
            var element = PageActionsHelper.ScrollToElement(locator, timeInMilliseconds);
            Click(element, timeInMilliseconds);
        }

        /// <summary>
        /// Waits for an element to be visible, scrolls to that element then waits for that element to be clickable and clicks
        /// </summary>
        /// <param name="element"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void ScrollToElementAndClick(IWebElement element, int timeInMilliseconds = 10000)
        {
            PageActionsHelper.ScrollToElement(element, timeInMilliseconds);
            Click(element, timeInMilliseconds);
        }

        #endregion

        #region Data Entry helper methods

        /// <summary>
        /// Waits for an element to be displayed, clears any exisiting data and then used the SendKeys method to enter data.  Can be used with By or IWebelement
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="data"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void EnterData(By locator, string data, int timeInMilliseconds = 10000)
        {
            // TODO - framework testing - needs to be tested
            GenricHelper.WaitforElementToBeDisplayed(locator, timeInMilliseconds);
            var element = GenricHelper.GetElement(locator);
            element.Clear();
            //Logger.Info("Clearing element of data");
            element.SendKeys(data);
            //Logger.Debug("Entered data : " + data + " into : " + locator.ToString());
        }

        /// <summary>
        /// Waits for an element to be displayed, clears any exisiting data and then used the SendKeys method to enter data.  Can be used with By or IWebelement
        /// </summary>
        /// <param name="element"></param>
        /// <param name="data"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void EnterData(IWebElement element, string data, int timeInMilliseconds = 10000)
        {
            // TODO - framework testing - needs to be tested
            GenricHelper.WaitforElementToBeDisplayed(element, timeInMilliseconds);
            element.Clear();
            //Logger.Info("Clearing element of data");
            element.SendKeys(data);
            //Logger.Debug("Entered data : " + data);
        }

        #endregion

        #region Dropdown Helper methods
        /// <summary>
        /// Helper method that selects a dropdown value by Text
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="option"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void SelectDropdownOptionByText(By locator, string option, int timeInMilliseconds = 10000)
        {
            GenricHelper.WaitforElementToBeDisplayed(locator, timeInMilliseconds);
            var selectElement = new SelectElement(GenricHelper.GetElement(locator));
            selectElement.SelectByText(option);
        }

        /// <summary>
        /// Helper method that selects a dropdown value by value
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="option"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void SelectDropdownOptionByValue(By locator, string option, int timeInMilliseconds = 10000)
        {
            GenricHelper.WaitforElementToBeDisplayed(locator, timeInMilliseconds);
            var selectElement = new SelectElement(GenricHelper.GetElement(locator));
            selectElement.SelectByValue(option);
        }

        /// <summary>
        /// Helper method that selects a dropdown value by index
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="option"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void SelectDropdownOptionByIndex(By locator, int index, int timeInMilliseconds = 10000)
        {
            GenricHelper.WaitforElementToBeDisplayed(locator, timeInMilliseconds);
            var selectElement = new SelectElement(GenricHelper.GetElement(locator));
            selectElement.SelectByIndex(index);
        }

        #endregion

    }
}
