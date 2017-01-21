using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1.SeleniumTest_Class
{
    class FairsailWX_Selenium
    {
        private IWebDriver driver;
        //NgWebDriver ngDriver;
        public IWebElement IwebElement { get; set; }

        public FairsailWX_Selenium(IWebDriver driver)

        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        /// <summary>
        /// This will click on Time drop down and select PTO requests
        /// </summary>
        /// 
        public void ClickTime()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.XPath("//li[@id='/services/a2z580000008uXXAAY/processes']/a")));
            
            driver.FindElement(By.XPath("//li[@id='/services/a2z580000008uXXAAY/processes']/a"), 5).Click();


        }

        
        /// <summary>
        /// This will Click PTO requests
        /// </summary>
        /// 
        public void ClickPTO_Requests()
        {
            driver.FindElement(By.XPath("(//a[contains(text(),'PTO Requests')])[6]")).Click();
            Thread.Sleep(8000);

        }
        // Click new

        /// <summary>
        /// This will click New Absense to enter details
        /// </summary>
        /// 
        public void ClickNewAbsense()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(12));
            driver.FindElement(By.XPath("(//button[@type='button'])[17]")).Click();

            Thread.Sleep(5000);
         
        }


        /// <summary>
        /// This will eneter start date
        /// </summary>
        /// 
        public void ClickStartDate()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            // var startdate = driver.FindElement(By.XPath("select-arrow.date-focus"));
            //var selectElement = new SelectElement(startdate);
            driver.FindElement(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[2]/datepicker-directive/div/label/div")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[2]/datepicker-directive/div/label/div")).SendKeys("01/04/2016");
            // driver.FindElement(By.XPath(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[2]/datepicker-directive/div/label/input").SelectByValue("23");


            // driver.FindElement(By.CssSelector("div.arrow-container.date-blur")).Click();
            //driver.FindElement(By.("div.arrow-container.date-blur")).Click();


            Thread.Sleep(5000);

        }

        /// <summary>
        /// This will enter End date 
        /// </summary>
        /// 
        public void ClickEndate()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            //var enddate = driver.FindElement(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[3]/datepicker-directive/div/label/input"));
           // var selectElement = new SelectElement(enddate);
            driver.FindElement(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[3]/datepicker-directive/div/label/div")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("html/body/div[6]/div/div/form/div/div[2]/div[3]/datepicker-directive/div/label/div")).SendKeys("23/03/2016");
            //selectElement.SelectByValue("23");

        }

        //reason
        /// <summary>
        /// This will click on Workforce Experience Tab 
        /// </summary>
        /// 
        public void SelectReason()
        {
            new SelectElement(driver.FindElement(By.Name("reason"))).SelectByText("Sickness");
           // driver.FindElement(By.XPath("(//button[@type='button'])[143]")).Click(); ;
            Thread.Sleep(2000);

        }

        /// <summary>
        /// This will click on Next
        /// </summary>
        /// 
        public void ClickOnNext()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("//div[@class='modal-footer-buttons']")).Click();
            

            Thread.Sleep(2000);

        }



        /// <summary>
        // enter text in notes section - Had fever 
        /// </summary>
        /// 
        public void EnterNotes()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(12));
            driver.FindElement(By.XPath("//textarea[@name='textarea']")).Click();
            driver.FindElement(By.XPath("//textarea[@name='textarea']")).SendKeys("Having fever");
            

        }

        // 
        /// <summary>
        /// This will click on 
        /// </summary>
        /// 
        public void ClickSave()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("(//button[@class='btn modal-save ng-binding']")).Click();
            Thread.Sleep(2000);

        }

        /// <summary>
        /// Click current absense tab and assert that absense is present
        /// </summary>
        /// 
        public void ClickCurrentAbsenseTab()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            driver.FindElement(By.XPath("//li[contains(.,' Current Absences')]")).Click();           
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This will assert that absense date is present
        /// </summary>
        /// 
        public void AssertAbsenseDatePresent()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(8));
            Assert.IsTrue(driver.FindElement(By.XPath("//b[contains(.,'Period: 23 Mar 2016 - 23 Mar 2016')]")).Displayed);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// This will serch the name in the organisation field
        /// </summary>
        public void ClickSearchOrganisation(String Name)
        {
            
            driver.FindElement(By.XPath("//input[@class='form-control search-input ng-valid ng-dirty']")).SendKeys(Name);

        }
        























































    }
}
