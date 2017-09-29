using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CoviHonduras
{
    [TestClass]
    public class BOHost_revisionTransacciones : Settingsfields_File
    {

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void revisionTransaccionesPage()
        { 
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mari_Repository\\BOHost_revisionTransacciones\\attachments\\");
			try{
                driver.Navigate().GoToUrl(BoHostUrl);
                takeScreenShot("E:\\Selenium\\","loginBOCVHPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Mari_Repository\\BOHost_revisionTransacciones\\attachments\\","loginBOCVHPage",".jpeg");
                loginPage("00001", "00001");
                takeScreenShot("E:\\Selenium\\","homepageCVH_",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Mari_Repository\\BOHost_revisionTransacciones\\attachments\\","homepageCVH",".jpeg");
                System.Threading.Thread.Sleep(2000);					
				action.ClickAndHold(driver.FindElement(By.LinkText("Transacciones"))).Build().Perform();
                action.MoveToElement(driver.FindElement(By.LinkText("Consolidación de información"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				driver.FindElement(By.LinkText("Revisión de Transacciones")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","revisionTransicionesPage_",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_revisionTransacciones\\attachments\\","revisionTransicionesPage",".jpeg");
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).SendKeys("01/01/2017");
                System.Threading.Thread.Sleep(500);
				driver.FindElement(By.Id("ctl00_ContentZone_Button_transactions")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("E:\\Selenium\\","revisionTransicionesResults_",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\BOHost_revisionTransacciones\\attachments\\","revisionTransicionesResults",".jpeg");
				if (driver.PageSource.Contains("No hay transacciones para la selección actual")){
			        Console.WriteLine("No hay transacciones para la selección actual");
                    Assert.Fail("No hay transacciones para la selección actual");
                    System.Threading.Thread.Sleep(2000);
					return;
				}
                string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
                System.Threading.Thread.Sleep(1500);
				Console.WriteLine("Busqueda Completa: "+ elementsFound);
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
