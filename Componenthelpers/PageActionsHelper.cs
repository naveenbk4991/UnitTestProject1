
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Settingss;

namespace UnitTestProject1.Componenthelpers
{
    public class PageActionsHelper
    {

        public static string GetTitle()
        {
            return Objectrepository.Driver.Title;
        }

        public static void NavigateToUrl(string url)
        {
            try
            {
                Objectrepository.Driver.Navigate().GoToUrl(url);
                // Logger.Info("Navigating to : " + url);
            }
            catch (Exception exception)
            {
                //Logger.Error("There was an issue navigating to : " + url);
                throw exception;
            }
        }

        /// <summary>
        /// Waits for an element to be diplayed and then scrolls to it
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static IWebElement ScrollToElement(By locator, int timeInMilliseconds = 10000)
        {
            try
            {
                GenricHelper.WaitforElementToBeDisplayed(locator, timeInMilliseconds);
                Actions actions = new Actions(Objectrepository.Driver);
                IWebElement element = Objectrepository.Driver.FindElement(locator);
                actions.MoveToElement(element);
                actions.Perform();
                //Logger.Info("Scrolling to element : " + element.ToString());
                return element;
            }
            catch (Exception exception)
            {
                //Logger.Error("There was an issue scrolling to the element : " + locator.ToString());
                throw exception;
            }
        }

        /// <summary>
        /// Waits for an element to be diplayed and then scrolls to it
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <param name="minutes"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static void ScrollToElement(IWebElement element, int timeInMilliseconds = 10000)
        {
            try
            {
                GenricHelper.WaitforElementToBeDisplayed(element, timeInMilliseconds);
                Actions actions = new Actions(Objectrepository.Driver);
                actions.MoveToElement(element);
                actions.Perform();
                // Logger.Info("Scrolling to element");
            }
            catch (Exception exception)
            {
                //Logger.Error("There was an issue scrolling to the element");
                throw exception;
            }
        }

        #region Frame Switching helper methods

        /// <summary>
        /// Switches to Default DOM scope
        /// </summary>
        public static void SwitchToDefaultContent()
        {
            try
            {
                Objectrepository.Driver.SwitchTo().DefaultContent();
                // Logger.Debug("Switching to default content");
            }
            catch (Exception exception)
            {
                //Logger.Debug("Failed to switch to default content");
                throw exception;
            }
        }

        /// <summary>
        /// Helper method for switching into a frame or iframe.  Can be used with IWebelemnt or By
        /// </summary>
        /// <param name="frame"></param>
        public static void SwitchToFrame(IWebElement frame)
        {
            try
            {
                Objectrepository.Driver.SwitchTo().Frame(frame);
                //Logger.Debug("Switching to default content");
            }
            catch (Exception exception)
            {
                // Logger.Error("Could not switch to iframe");
                throw exception;
            }
        }

        /// <summary>
        /// Helper method for switching into a frame or iframe.  Can be used with IWebelemnt or By 
        /// </summary>
        /// <param name="frame"></param>
        public static void SwitchToFrame(By frame)
        {
            try
            {
                Objectrepository.Driver.SwitchTo().Frame(Objectrepository.Driver.FindElement(frame));
                //Logger.Debug("Switched to iframe  : " + frame);
            }
            catch (Exception exception)
            {
                // Logger.Error("Could not switch to iframe : " + frame.ToString());
                throw exception;
            }
        }

        /// <summary>
        /// Helper method for switching from a frame or iframe to another frame or iframe
        /// </summary>
        /// <param name="frame"></param>
        public static void SwitchFromFrameToFrame(IWebElement frame)
        {
            try
            {
                Objectrepository.Driver.SwitchTo().DefaultContent();
                Objectrepository.Driver.SwitchTo().Frame(frame);
            }

            catch (Exception exception)
            {
                //Logger.Error("Could not switch from current frame to specified frame");
                throw exception;
            }

        }

        /// <summary>
        /// Helper method for switching from a frame or iframe to another frame or iframe
        /// </summary>
        /// <param name="frame"></param>
        public static void SwitchFromFrameToFrame(By frame)
        {
            //TODO - Refactoring - Can refine frame switching methods once we see the application, Logging is not as ood as it could be
            try
            {
                // TODO - Framework testing - This needs to be tested
                Objectrepository.Driver.SwitchTo().DefaultContent();
                Objectrepository.Driver.SwitchTo().Frame(Objectrepository.Driver.FindElement(frame));
            }
            catch (Exception exception)
            {
                //Logger.Error("Could not switch from current frame to : " + frame);
                throw exception;
            }
        }

        #endregion

        public static void SwitchToNewTab()
        {
            try
            {
                Objectrepository.Driver.SwitchTo().NewWindow(WindowType.Tab);
                //Logger.Info("Opening new Tab");
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }
    }

}
