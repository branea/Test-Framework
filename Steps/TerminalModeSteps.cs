using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Test_Framework.PageObjects;

namespace Test_Framework.Steps
{
    [Binding, Scope(Feature = "TerminalMode")]
    public sealed class TerminalModeSteps
    {
        private readonly Navigator _navigator;
        private BasePage _mainPage;
        private TimeTrackingPage _timeTrackingPage;
        private TimeTrackingHeaderPage _timeTrackingHeaderPage;
        private TerminalMode4Page _terminalMode4;


        public TerminalModeSteps(Navigator navigator)
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

        [Given(@"I click on the ""([^""]*)"" button")]
        public void GivenIClickOnTheButton(string p0)
        {
            _timeTrackingPage.ClickOnSwitchToTerminalModeButton();
        }

        [Given(@"I select ""([^""]*)"" option")]
        public void GivenISelectOption(string p0)
        {
            _timeTrackingPage.ChooseOption4();
        }

        [Given(@"I click on the ""([^""]*)"" button on modal")]
        public void GivenIClickOnTheButtonOnModal(string p0)
        {
            _timeTrackingPage.ClickOnSwitchToTerminalModeButtonFromModal();
        }

        [Given(@"I confirm by clicking on the ""([^""]*)"" button")]
        public void GivenIConfirmByClickingOnTheButton(string p0)
        {
            _terminalMode4 = _timeTrackingPage.ConfirmSwitch();
        }

        [When(@"I move ""([^""]*)"" user to ""([^""]*)"" for ""([^""]*)"" seconds")]
        public void WhenIMoveUserToForSeconds(string user, string area, int time)
        {
            _terminalMode4.MoveUserToClockArea(area, user, time);
        }

        [When(@"I move ""([^""]*)"" user to ""([^""]*)""")]
        public void WhenIMoveUserTo(string user, string area)
        {
            _terminalMode4.MoveUserToClockArea(area, user);
        }



        [Then(@"I should see the ""([^""]*)"" message on the right corner popup")]
        public void ThenIShouldSeeTheMessageOnTheRightCornerPopup(string p0)
        {
            Assert.True(_terminalMode4.ClockedOutStatusMessageIsDisplayed());
        }

    }
}
