using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace LinkGroup.DemoTests.Pages
{
    [Binding]
    public class LinkPages
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public LinkPages(IWebDriver _driver)
        {
            driver = _driver;
        }
       
        public IWebElement cookies => driver.FindElement(By.XPath("//a[contains(text(),'Allow cookies')]"));
        public IWebElement contact => driver.FindElement(By.XPath("/html/body/div[3]/header/div/div[1]/nav[1]/ul[2]/li[5]/a"));

        public IWebElement contactpagetitle => driver.FindElement(By.XPath("//h1[contains(text(),'Contact')]"));

        
        public void navigateTo(string url)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void checkTitle()
        {
            Assert.AreEqual(driver.Title, "Link Group");
        }
        public void allowCookies()
        {
            cookies.Click();
        }
        public void selectContact()
        {
            contact.Click();
        }
        public void verifyContactPage()
        {
            Assert.That(contactpagetitle.Displayed, Is.True);
        }
    }
}
