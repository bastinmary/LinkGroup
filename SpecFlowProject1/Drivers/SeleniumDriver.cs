using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {
            driver = new ChromeDriver();
            _scenarioContext.Set(driver, "webDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }

        
    }
}
