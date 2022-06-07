using UnitTestProject1.Settingss;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Componenthelpers
{
    public class GenricHelper
    {


        /// <summary>
        /// Takes a By locator and returns an IWebElement object
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement GetElement(By locator)
        {
            try
            {
                IsElementPresent(locator);
                return Objectrepository.Driver.FindElement(locator);
            }

            catch (NoSuchElementException exception)
            {
                //Logger.Error("Element Not Found : " + locator.ToString());
                throw new NoSuchElementException("Stack Trace : " + exception);
            }
        }

        #region IsElementPresent helper methods

        /// <summary>
        /// Checks if the element is displayed, can be used with By or WebElement.  Using By variable produces more details debug logs
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>bool</returns>
        public static bool IsElementPresent(By locator)
        {
            try
            {
                bool isElementDisplayed = Objectrepository.Driver.FindElement(locator).Displayed;
                //Logger.Debug(locator + " element is present");
                return isElementDisplayed;
            }

            catch (StaleElementReferenceException)
            {
                //Logger.Error("Stale Element reference to : " + locator.ToString());
                return false;
            }

            catch (Exception)
            {
                //Logger.Debug("Cannot find element using locator : " + locator.ToString() + " : element is not present");
                return false;
            }
        }

        /// <summary>
        /// Checks if the element is displayed, can be used with By or WebElement.  Using By variable produces more details debug logs
        /// </summary>
        /// <param name="locator"></param>
        /// <returns>bool</returns>
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool isElementDisplayed = element.Displayed;
                // Logger.Debug("element is present");
                return isElementDisplayed;
            }
            catch (StaleElementReferenceException)
            {
                //Logger.Error("Stale Element reference to element");
                return false;
            }

            catch (NoSuchElementException)
            {
                //Logger.Error("Cannot find element");
                return false;
            }
        }

        /// <summary>
        /// Checks if the element is enabled, can be used with By or WebElement
        /// </summary>
        /// <param name="element"></param>
        /// <returns>bool</returns>
        public static bool IsElementEnabled(By locator)
        {
            try
            {
                bool isElementDisplayed = Objectrepository.Driver.FindElement(locator).Enabled;
                //Logger.Debug(locator + " element is enabled");
                return isElementDisplayed;
            }

            catch (StaleElementReferenceException)
            {
                //Logger.Error("Stale Element reference to : " + locator.ToString());
                return false;
            }

            catch (Exception)
            {
                //Logger.Debug("Cannot find element using locator : " + locator.ToString() + " : element is not present");
                return false;
            }
        }

        /// <summary>
        /// Checks if the element is enabled, can be used with By or WebElement
        /// </summary>
        /// <param name="element"></param>
        /// <returns>bool</returns>
        public static bool IsElementEnabled(IWebElement element)
        {
            try
            {
                bool isElementEnabled = element.Enabled;
                //Logger.Debug("Element is enabled");
                return isElementEnabled;
            }
            catch (StaleElementReferenceException)
            {
                // Logger.Error("Stale Element reference");
                return false;
            }

            catch (Exception)
            {
                //Logger.Debug("Cannot find element");
                return false;
            }
        }

        #endregion

        #region WaitForElementToBeVisible helper methods

        /// <summary>
        /// Waits for an element to be displayed for a default of 10 seconds.  Can be used with By or IWebElement
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void WaitforElementToBeDisplayed(By locator, int timeInMilliseconds = 10000)
        {
            var wait = new WebDriverWait(Objectrepository.Driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            bool isElementDisplayed = wait.Until(condition =>
            {
                isElementDisplayed = IsElementPresent(locator);
                return isElementDisplayed;
            });
        }

        /// <summary>
        /// Waits for an element to be displayed for a default of 10 seconds.  Can be used with By or IWebElement
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void WaitforElementToBeDisplayed(IWebElement element, int timeInMilliseconds = 10000)
        {
            var wait = new WebDriverWait(Objectrepository.Driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            bool isElementDisplayed = wait.Until(condition =>
            {
                try
                {
                    isElementDisplayed = IsElementPresent(element);
                    return isElementDisplayed;
                }
                catch (StaleElementReferenceException)
                {
                    // Logger.Error("Stale Element reference");
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //Logger.Debug("Cannot find element using locator");
                    return false;
                }
            });
        }

        /// <summary>
        /// Waits for an element to be enabled for a default of 10 seconds.  Can be used with By or IWebElement
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void WaitforElementToBeEnabled(By locator, int timeInMilliseconds = 10000)
        {
            var wait = new WebDriverWait(Objectrepository.Driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            bool isElementEnabled = wait.Until(condition =>
            {
                try
                {
                    isElementEnabled = IsElementEnabled(locator);
                    return isElementEnabled;
                }
                catch (StaleElementReferenceException)
                {
                    // Logger.Error("Stale Element reference");
                    return false;
                }
                catch (NoSuchElementException)
                {
                    // Logger.Debug("Cannot find element using locator");
                    return false;
                }
            });
        }

        /// <summary>
        /// Waits for an element to be enabled for a default of 10 seconds.  Can be used with By or IWebElement
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        public static void WaitforElementToBeEnabled(IWebElement element, int timeInMilliseconds = 10000)
        {
            var wait = new WebDriverWait(Objectrepository.Driver, TimeSpan.FromMilliseconds(timeInMilliseconds));
            bool isElementDisplayed = wait.Until(condition =>
            {
                try
                {
                    isElementDisplayed = IsElementEnabled(element);
                    return isElementDisplayed;
                }
                catch (StaleElementReferenceException)
                {
                    //Logger.Error("Stale Element reference");
                    return false;
                }
                catch (NoSuchElementException)
                {
                    //Logger.Debug("Cannot find element using locator");
                    return false;
                }
            });
        }
        #endregion

        /// <summary>
        /// Code that takes a screenshot, takes 2 strings as arguments.  The first is the first part of the filename which has a default value of "Screen", the second is
        /// is the filepath which by default has a relative filepath value to the screenshots folder within the Resources folder in the project
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string TakeScreenShot(string filename = "Screenshot", string filePath = "..//Central.Test.Framework.CSharp//Resources//Screenshots//")
        {
            Screenshot screen = Objectrepository.Driver.TakeScreenshot();
            filename = filePath + filename + "-" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".jpeg";
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            return filename;
        }
    }
}
