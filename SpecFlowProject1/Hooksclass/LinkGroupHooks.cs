
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.Hooksclass
{
    [Binding]
    public sealed class LinkGroupHooks
    {
       
        private readonly ScenarioContext _scenarioContext;
       
        public LinkGroupHooks(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("webDriver").Quit();
        }
    }
}