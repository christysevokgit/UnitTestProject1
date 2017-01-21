using System;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Protractor;


namespace FairsailTest

{
    public partial class FairsailLogin_Selenium

    {
        static void Main(string[] args)
        {
        }

        private IWebDriver driver;
        public IWebElement IwebElement { get; set; }

        public FairsailLogin_Selenium(IWebDriver driver)

        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        /// <summary>
        /// Enters the username in the username field
        /// </summary>
        /// <param name="username"></param>
        public void Username(string username)
        {
            Thread.Sleep(5000);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(username);
            Thread.Sleep(4000);

        }


        /// <summary>
        /// Eneters the password in password field
        /// </summary>
        /// <param name="password"></param>

        public void Password(String password)
        {
            Thread.Sleep(5000);
            //driver.FindElement(By.XPath)
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password);
            
            Thread.Sleep(4000);
        }

        /// <summary>
        /// This will click on log in button
        /// </summary>
        /// 
        public void ClickLogin()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Login")));
            driver.FindElement(By.Id("Login")).Click();
            
            


        }

        /// <summary>
        /// This will enter verification code and click verify
        /// </summary>
        /// <param name="Verification"></param>
        public void EnterVerification(String Verification)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            Thread.Sleep(5000);
            driver.FindElement(By.Id("emc")).SendKeys(Verification);
           
        }

        /// <summary>
        /// This will click on Verify
        /// </summary>
        /// 
        public void ClickVerify()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            //driver.FindElement(By.Id("Login")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("save")).Click();


        }















        /// <summary>
        /// Assert that login is successfull
        /// </summary>
        public void AssertLoginSuccess()
        {
            //Assert.IsTrue(IsElementPresent(By.XPath("//a[@title='Workforce eXperience Tab']"));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            driver.FindElement(By.XPath("//a[@title='Workforce eXperience Tab']")).Click();
           // Assert.AreEqual(true,driver.ElementIsPresent(By.XPath("//a[@title='Workforce eXperience Tab']")));
            
        }

        public void ProtractotTest()
        {
            


        }



    }

}



