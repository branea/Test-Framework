using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Test_Framework.PageObjects;

namespace Test_Framework.Steps
{
    [Binding, Scope(Feature = "DownloadReport")]
    public sealed class DownloadReportSteps
    {
        private readonly Navigator _navigator;
        private BasePage _mainPage;
        private TimeTrackingPage _timeTrackingPage;
        private TimeTrackingHeaderPage _timeTrackingHeaderPage;
        private TimeTrackingReportsPage _timeTrackingReportsPage;


        public DownloadReportSteps(Navigator navigator)
        {
            _navigator = navigator;
        }

        [Given(@"I am on Crewmeister time-tracking overview page")]
        public void GivenIAmOnCrewmeisterTime_TrackingOverviewPage()
        {
            _timeTrackingPage = _navigator.GoTo<TimeTrackingPage>(new Uri(Configuration.ApplicationUrl));
            _timeTrackingPage.FillTheUsername(Configuration.UserName);
            _timeTrackingPage.FillThePassword(Configuration.Password);
            _timeTrackingPage.ClickOnLogInButton();

        }

        [Given(@"I go to the time tracking reports page")]
        public void GivenIGoToTheTimeTrackingReportsPage()
        {
            _timeTrackingReportsPage = _timeTrackingPage.ClickOnTimeTrackingReports();
        }

        [Given(@"I search for the team ""([^""]*)"" in the Team dropdown")]
        public void GivenISearchForTheTeamInTheTeamDropdown(string p0)
        {
            _timeTrackingReportsPage.ClickOnSearchTeam();
            _timeTrackingReportsPage.SelectAllTeamsOption();
            _timeTrackingReportsPage.SelectValueFromTable(1);
        }

        [When(@"I select the checkbox for the user with name ""([^""]*)""")]
        public void WhenISelectTheCheckboxForTheUserWithName(string p0)
        {
            _timeTrackingReportsPage.SelectUserFromTable(p0);
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string download)
        {
            _timeTrackingReportsPage.ClickOnDownload();
        }

        [Then(@"I should see a popup with the message: '([^']*)'")]
        public void ThenIShouldSeeAPopupWithTheMessage(string p0)
        {
            Assert.True(_timeTrackingReportsPage.DownloadStartedMessageIsDisplayed(p0));
        }

    }
}
