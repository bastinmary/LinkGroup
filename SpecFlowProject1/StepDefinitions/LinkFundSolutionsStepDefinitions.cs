using LinkGroup.DemoTests.Pages;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace LinkGroup.DemoTests.StepDefinitions
{
    [Binding]
    public class LinkFundSolutionsStepDefinitions
    {

        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        LinkFundPages lfp;
        public LinkFundSolutionsStepDefinitions(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I have opened the Found Solutions page ""([^""]*)""")]
        public void GivenIHaveOpenedTheFoundSolutionsPage(string url)
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        }

        [When(@"I view Funds")]
        public void WhenIViewFunds()
        {
            lfp = new LinkFundPages(driver);
            lfp.checkTitle();
            lfp.selectFund();
        }

        [Then(@"I can select the investment managers for ""([^""]*)"" investors")]
        public void ThenICanSelectTheInvestmentManagersForInvestors(string manager)
        {

            lfp.selectInvestmentManagers(manager);

        }

    }
}
