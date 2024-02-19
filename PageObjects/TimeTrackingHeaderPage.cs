using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class TimeTrackingHeaderPage : BasePage
    {
        public TimeTrackingHeaderPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement TimeTrackingReports => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@data-name='Time Tracking Reports']")));
        
        public TimeTrackingReportsPage ClickOnTimeTrackingReports()
        {
            _actions.MoveToElement(TimeTrackingReports);
            TimeTrackingReports.Click();

            return new TimeTrackingReportsPage(_webDriver);
        }
    }
}
