using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class TimeTrackingReportsPage : TimeTrackingHeaderPage
    {
        public TimeTrackingReportsPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement SearchTeam => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("page-time-tracking-reports-team-filter")));
        private IWebElement AllTeamsOptionCheckbox => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div#page-time-tracking-reports-team-filter-all-enabled-option")));
        private List<IWebElement> TableRowsCheckboxses => _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("span.MuiButtonBase-root"))).ToList();
        private List<IWebElement> TableRows => _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("table._1hdnm1a > tbody > tr > td[data-table-left='true'] > span"))).ToList();
        private IWebElement DownloadButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Download')]")));
        private IWebElement DownloadPopupMessage(string message) => _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//*[contains(text(), '{message}')]")));

        public void ClickOnSearchTeam()
        {
            _actions.MoveToElement(SearchTeam);
            SearchTeam.Click();
        }

        public void SelectAllTeamsOption()
        {
            _actions.MoveToElement(AllTeamsOptionCheckbox);
            AllTeamsOptionCheckbox.Click();
        }

        public void SelectValueFromTable(int index)
        {
            _actions.MoveToElement(TableRowsCheckboxses[index+1]);
            TableRowsCheckboxses[index + 1].Click();
        }

        public void SelectUserFromTable(string userName)
        {
            var index = 0;
            foreach(var user in TableRows)
            {
                if(user.Text.Contains(userName))
                    index = TableRows.IndexOf(user);
            }

            SelectValueFromTable(index);
        }

        public void ClickOnDownload()
        {
            _actions.MoveToElement(DownloadButton);
            DownloadButton.Click();
        }

        public bool DownloadStartedMessageIsDisplayed(string message)
        {
            return DownloadPopupMessage(message).Displayed;
        }
    }
}
