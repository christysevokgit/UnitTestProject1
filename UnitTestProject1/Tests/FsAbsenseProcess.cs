using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FairsailTest;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnitTestProject1.SeleniumTest_Class;
using System.Text;
using OpenQA.Selenium.Support.UI;
using Protractor;


namespace UnitTestProject1
{
    //Extension method to IWebDriver that adds a timeout (in seconds) parameter to the FindElement() method
    public static class WebDriverExtensions
{
    public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
        return driver.FindElement(by);
    }
}





    [TestClass]
    public class FairsailTest
    {
        private IWebDriver driver; 
        public IWebElement IwebElement { get; set; }
        public IWebDriver WebDriverInstance { get; private set; }
        private bool acceptNextAlert = true;
        private StringBuilder verificationErrors;
        private string baseURL;


        [TestInitialize]
        public void Initialize_Selenium()

        {         
            driver = new FirefoxDriver();

            //driver = new ChromeDriver(@"C:\Users\christy\Downloads\chromedriver_win32");          
            baseURL = "https://login.salesforce.com/";
            verificationErrors = new StringBuilder();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string title = (string)js.ExecuteScript("return document.title");

        }


        [TestMethod]
        [TestCategory("Regression /fairsail/Login")]
        public void FairsailLogin()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.Navigate().Refresh();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));

            FairsailLogin_Selenium Login = new FairsailLogin_Selenium(driver);
            Login.Username("trial4978@trial.fairsail.com");
            Login.Password("fairsail07");
            Login.ClickLogin();

           

        }

        [TestMethod]
        [TestCategory("Regression/fairsail/HomePage")]
        public void FairsailAbsenseTest()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/");
            
            FairsailLogin_Selenium Login = new FairsailLogin_Selenium(driver);
            Login.Username("trial4976@trial.fairsail.com");

            Login.Password("fairsail07");
            Login.ClickLogin();
            Login.EnterVerification("80625");
            Login.ClickVerify();

            FairsailHomePage_Selenium HomePage = new FairsailHomePage_Selenium(driver);
            HomePage.ClickWorkForceExperience();

            FairsailWX_Selenium WXPage = new FairsailWX_Selenium(driver);
            //WXPage.ClickTime();
           // WXPage.ClickPTO_Requests();
           // WXPage.ClickNewAbsense();
            WXPage.ClickStartDate();
            WXPage.ClickEndate();
            WXPage.SelectReason();
            WXPage.ClickOnNext();
            WXPage.EnterNotes();
            WXPage.ClickSave();
            WXPage.ClickCurrentAbsenseTab();
            WXPage.AssertAbsenseDatePresent();


        }

        [TestMethod]
        [TestCategory("Regression/fairsail/HomePage")]
        public void FairsailPTOtest2()
        { 

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseURL + "/");

            FairsailLogin_Selenium Login = new FairsailLogin_Selenium(driver);
            Login.Username("trial4976@trial.fairsail.com");

            Login.Password("fairsail07");
            Login.ClickLogin();
            Login.EnterVerification("54122");
            Login.ClickVerify();

            FairsailHomePage_Selenium HomePage = new FairsailHomePage_Selenium(driver);
            HomePage.ClickWorkForceExperience();
            HomePage.AsserTeamMemberView();

            FairsailWX_Selenium WXPage = new FairsailWX_Selenium(driver);
            WXPage.ClickSearchOrganisation("peter seargent");



            WXPage.ClickTime();
            WXPage.ClickPTO_Requests();
            WXPage.ClickNewAbsense();
            WXPage.ClickStartDate();
            WXPage.ClickEndate();
            WXPage.SelectReason();
            WXPage.ClickOnNext();
            WXPage.EnterNotes();
            WXPage.ClickSave();
            



        }






        [TestCleanup]
        public void TestCleanUpTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }







































        }
    }
}
