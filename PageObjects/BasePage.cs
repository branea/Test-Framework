using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace Test_Framework.PageObjects
{
    internal class BasePage
    {
        protected IWebDriver _webDriver;
        protected WebDriverWait _wait;
        protected Actions _actions;
        protected IJavaScriptExecutor _jsExecutor;
       
        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            _actions = new Actions(webDriver);
            _jsExecutor = (IJavaScriptExecutor)webDriver;
        }

        private IWebElement LogInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("user-sign-in")));
        private IWebElement UserName => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='identifier']")));
        private IWebElement Password => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@type='password']")));
        private List<IWebElement> UsernameAndPasswordLabel => _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.CssSelector("div._i8newnu"))).ToList();

        public void ClickOnLogInButton()
        {
            _actions.MoveToElement(LogInButton);
            LogInButton.Click();
        }

        public void FillTheUsername(string username)
        {
            _actions.MoveToElement(UsernameAndPasswordLabel.First());
            UsernameAndPasswordLabel.First().Click();
            UserName.SendKeys(username);
        }

        public void FillThePassword(string password)
        {
            _actions.MoveToElement(UsernameAndPasswordLabel.Last());
            UsernameAndPasswordLabel.Last().Click();
            Password.SendKeys(password);
        }

        public void JSClick(IWebElement element)
        {
            _jsExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
