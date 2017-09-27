using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_assignVehicleToExistingAccount : Settingsfields_File
    {
        private static Boolean accountClosed = false;

        [TestInitialize]
        public void setUp()
        {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void assigningVehcleToExistingAccountInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\assigningVehicleToAccount\\attachments\\");
            assigningVehcleToExistingAccount();
            System.Threading.Thread.Sleep(1000);
		    CAC_accountCreationWithVehicle.accountCreationWithVehicle();
            System.Threading.Thread.Sleep(200);
		    if (accountClosed){
			    Console.WriteLine("No se puede asignar un Vehículo a la cuenta "+accountNumbr.Substring(7, 16)+" porque está cerrada");
                Assert.Fail("No se puede asignar un Vehículo a la cuenta "+accountNumbr.Substring(7, 16)+" porque está cerrada");
		    }
            System.Threading.Thread.Sleep(1000);
		    Console.WriteLine("Se le asignado el vehículo con la matrícula " +matriNu+" a la cuenta "+accountNumbr.Substring(7, 16)+" correctamente");
		    Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
	    }

        public static void assigningVehcleToExistingAccount()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\assigningVehicleToAccount\\attachments\\", "loginPage",".jpeg");
            driver.FindElement(By.Id(loginField)).SendKeys("00001");
            driver.FindElement(By.Id(passField)).SendKeys("00001");
            driver.FindElement(By.Id(loginButton)).Click();
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\assigningVehicleToAccount\\attachments\\","homeCACCVHPage",".jpeg");
            BOVersion = driver.FindElement(By.Id("ctl00_statusRight")).Text;
            System.Threading.Thread.Sleep(2000);					
	        action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
	        driver.FindElement(By.LinkText("Seleccionar cuenta")).Click();
            System.Threading.Thread.Sleep(2000);
            elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
            IWebElement tableres = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
            IList<IWebElement> table = tableres.FindElements(By.TagName("tr"));
            int selectAccount = ranNumbr(2, table.Count);
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
	        accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            System.Threading.Thread.Sleep(1000);
	        if(driver.PageSource.Contains("CUENTA CERRADA")){
		        accountClosed = true;
		        return;
	        }
            System.Threading.Thread.Sleep(500);
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}
