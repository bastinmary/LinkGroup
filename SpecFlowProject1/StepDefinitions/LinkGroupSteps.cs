using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using System;
using TechTalk.SpecFlow;


namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LinkGroupSteps
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;

        public LinkGroupSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;
       
               
        [When(@"I open the home page ""([^""]*)""")]
        public void WhenIOpenTheHomePage(string url)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Then(@"the page is displayed")]
        public void ThenThePageIsDisplayed()
        {
            Console.WriteLine(driver.Title);
            Assert.AreEqual(driver.Title, "Link Group");
        }

        
        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Allow cookies')]")).Click();
        }
        
        [When(@"I select Contact")]
        public void WhenISelectContact()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[3]/header/div/div[1]/nav[1]/ul[2]/li[5]/a")).Click();
        }
        public IWebElement contactpagetitle => driver.FindElement(By.XPath("//h1[contains(text(),'Contact')]"));

        [Then(@"the Contact page is displayed")]
        
        public void ThenTheContactPageIsDisplayed()
        {
           Assert.That(contactpagetitle.Displayed, Is.True);
        }
        
    }
}
