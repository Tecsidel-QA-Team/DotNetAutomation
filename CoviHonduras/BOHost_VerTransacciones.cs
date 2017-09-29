using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class BOHost_VerTransacciones : Settingsfields_File
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void verTransaccionesInit()
        {
            dateverTransacciones = "01/09/2017";
            verTransacciones();
			string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
            System.Threading.Thread.Sleep(1500);
			Console.WriteLine("Busqueda Completa: "+ elementsFound);
            System.Threading.Thread.Sleep(1000);	
		}

        public static void verTransacciones()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\BOHost_VerTranscciones\\attachments\\");
			try{
			    driver.Navigate().GoToUrl(BoHostUrl);
				System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","loginBOCVHPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_VerTranscciones\\attachments\\","loginBOCVHPage",".jpeg");
                loginPage("00001", "00001");
                takeScreenShot("E:\\Selenium\\","homeHostCVHPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_VerTranscciones\\attachments\\","homeHostCVHPage",".jpeg");
                System.Threading.Thread.Sleep(2000);					
				action.ClickAndHold(driver.FindElement(By.LinkText("Transacciones"))).Build().Perform();
                action.MoveToElement(driver.FindElement((By.LinkText("Consolidación de revisiones")))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				driver.FindElement(By.LinkText("Ver transacciones")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","verTransaccionesPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_VerTranscciones\\attachments\\","verTransaccionesPage",".jpeg");
                System.Threading.Thread.Sleep(500);
				driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).SendKeys(dateverTransacciones);
                System.Threading.Thread.Sleep(1000);		
				driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSearch_IB_Button")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","verTransaccionesResults",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_VerTranscciones\\attachments\\","verTransaccionesRetults",".jpeg");
                System.Threading.Thread.Sleep(1000);
			}catch(Exception e){
                Console.WriteLine(e.GetBaseException());
                Assert.Fail();
			}
		}		
        
        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}