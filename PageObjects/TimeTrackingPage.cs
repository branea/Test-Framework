using OpenQA.Selenium;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class TimeTrackingPage : TimeTrackingHeaderPage
    {
        public TimeTrackingPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement SwitchToTerminalModeButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(text(), 'Switch this device into terminal mode')]")));

        private IWebElement Option4 => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("page-time-tracking-terminal-mode-three-column-terminal-with-no-authentication")));

        private IWebElement SwitchToTerminalModeButtonFromModal => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-e2e-test='page-time-tracking-switch-this-device-into-terminal-mode-modal']")));
        private IWebElement ConfirmSwitchButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("page-time-tracking-switch-this-device-into-terminal-mode-modal-confirm")));

        public void ClickOnSwitchToTerminalModeButton()
        {
            _actions.MoveToElement(SwitchToTerminalModeButton);
            SwitchToTerminalModeButton.Click();
        }

        public void ChooseOption4()
        {
            _actions.MoveToElement(Option4);
            Option4.Click();
        }

        public void ClickOnSwitchToTerminalModeButtonFromModal()
        {
            _actions.MoveToElement(SwitchToTerminalModeButtonFromModal);
            SwitchToTerminalModeButtonFromModal.Click();
        }

        public TerminalMode4Page ConfirmSwitch()
        {
            _actions.MoveToElement(ConfirmSwitchButton);
            ConfirmSwitchButton.Click();
            Thread.Sleep(5000);

            return new TerminalMode4Page(_webDriver);
        }
    }
}
