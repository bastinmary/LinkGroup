using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace LinkGroup.DemoTests.Pages
{
    [Binding]
    public class LinkFundPages
    {

        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public LinkFundPages(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement fund => driver.FindElement(By.Id("navbarDropdown"));
        public IWebElement fundTitle => driver.FindElement(By.XPath("//h3[contains(text(),'Funds')]"));

        public IWebElement ukmanager => driver.FindElement(By.XPath("//h4[text()='Investment Manager']//following::a[1]"));
        public IWebElement irismanager => driver.FindElement(By.XPath("//h4[text()='Investment Manager']//following::a[2]"));
        public IWebElement swissmanager => driver.FindElement(By.XPath("//h4[text()='Investment Manager']//following::a[3]"));


        public void navigateTo(string url)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        public void checkTitle()
        {
            Assert.AreEqual(driver.Title, "Link Fund Solutions");
        }
        public void selectFund()
        {
            fund.Click();
            Assert.That(fundTitle.Displayed, Is.True);
        }

        public void selectInvestmentManagers(string manager)
        {
            if (manager == "UK")
            {
                ukmanager.Click();
                Assert.IsTrue(driver.Title.Contains("UK"));

            }
            else if (manager == "Irish")
            {
                irismanager.Click();
                Assert.IsTrue(driver.Title.Contains("Iris"));

            }
            else

            {
                swissmanager.Click();
                Assert.IsTrue(driver.Title.Contains("Swiss"));

            }


        }

    }
}
