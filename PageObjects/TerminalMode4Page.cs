using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using System;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class TerminalMode4Page : BasePage
    {
        public TerminalMode4Page(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement User(string username) => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//img[@alt='{username}']")));
        private IWebElement ClockState(string clockState) => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[contains(text(), '{clockState}')]/..")));
        private IWebElement ClockedOutStatusMessage => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'You're clocked out')]")));

        public void MoveUserToClockArea(string areaName, string userName, int time)
        {
            try {
                _actions.MoveToElement(User(userName)).ClickAndHold(User(userName)).MoveToElement(ClockState(areaName)).Release().Build().Perform();
            }
            catch (StaleElementReferenceException e) {
                _webDriver.Navigate().Refresh();
                _actions.MoveToElement(User(userName)).ClickAndHold(User(userName)).MoveToElement(ClockState(areaName)).Release().Build().Perform();
            }
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        public void MoveUserToClockArea(string areaName, string userName)
        {
            try
            {
                _actions.MoveToElement(User(userName)).ClickAndHold(User(userName)).MoveToElement(ClockState(areaName)).Release().Build().Perform();
            }
            catch (StaleElementReferenceException e)
            {
                _webDriver.Navigate().Refresh();
                _actions.MoveToElement(User(userName)).ClickAndHold(User(userName)).MoveToElement(ClockState(areaName)).Release().Build().Perform();
            }
        }

        public bool ClockedOutStatusMessageIsDisplayed()
        {
            return ClockedOutStatusMessage.Displayed;
        }
    }
}
