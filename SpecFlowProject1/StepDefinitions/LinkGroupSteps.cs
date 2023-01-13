using LinkGroup.DemoTests.Pages;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;


namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LinkGroupSteps
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        LinkPages lp;
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
            lp = new LinkPages(driver);
            lp.checkTitle();
        }


        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            lp.allowCookies();
        }

        [When(@"I select Contact")]
        public void WhenISelectContact()
        {
             lp.selectContact();
        }
        [Then(@"the Contact page is displayed")]

        public void ThenTheContactPageIsDisplayed()
        {
             lp.verifyContactPage();
        }

    }
}
