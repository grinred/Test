using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using Test.Pages;

namespace Test.Steps
{
    [Binding]
    public sealed class AquaSteps 
    {
       
        WebDriver driver = new ChromeDriver();
        HomePageGoogle hpg = new HomePageGoogle();
        SearchPage searchpage = new SearchPage();
       

        [Given(@"Open Google")]
        public void GivenOpenGoogle()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        }
        
        [Given(@"Fill search field as")]
        public void GivenFillSearchFieldAs()
        {
            
            driver.FindElement(By.XPath(hpg.searchField)).SendKeys("Чак Норрис");
        }
        
        [Given(@"Click on search button")]
        public void GivenClickOnSearchButton()
        {
            driver.FindElement(By.XPath(hpg.searchField)).SendKeys(Keys.Enter);
        }
        
        [Then(@"Verify result")]
        public void ThenVerifyResult()
        {
            var element = driver.FindElement(By.XPath(searchpage.str));
            Assert.IsTrue(element.Displayed);
            driver.Quit();
        }
    }
}
