using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace UnitTestProject1.SeleniumTest_Class
{
    class FairsailHomePage_Selenium
    { 
    private IWebDriver driver;
    public IWebElement IwebElement { get; set; }

    public FairsailHomePage_Selenium(IWebDriver driver)

    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);

    }

    /// <summary>
    /// This will click on Workforce Experience Tab 
    /// </summary>
    /// 
    public void ClickWorkForceExperience()
    {
        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
        driver.FindElement(By.XPath("//a[@title='Workforce eXperience Tab']")).Click();
        Thread.Sleep(8000);
       // Assert.AreEqual("Fairsail WX", driver.Title);

        }

        /// <summary>
        /// This will assert Team member view present
        /// </summary>
        /// 
        public void AsserTeamMemberView()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            var text = driver.FindElement(By.XPath("//span[contains(.,'Team Member View: ')]")).Text;
            Assert.AreEqual("Team Member View", text);

        }

























    }
}