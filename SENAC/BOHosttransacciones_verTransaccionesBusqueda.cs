using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SENAC
{
    [TestClass]
    public class BOHosttransacciones_verTransaccionesBusqueda : senacFieldsConfiguration
    {

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
            

        }

        [TestMethod]
        public void hostTransacciones()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\Host_VerTranscciones\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\", "loginHostSenacPage_", timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\Host_VerTranscciones\\attachments\\", "loginHostSenacPage","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homeHostSenacPage" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\Host_VerTranscciones\\attachments\\", "homeHostSenacPage","");
                System.Threading.Thread.Sleep(2000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Transacciones"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Ver transaciones")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "verTransaccionesPage",  timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\Host_VerTranscciones\\attachments\\", "verTransaccionesPage","");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).SendKeys("15/05/2017");
                System.Threading.Thread.Sleep(1000);
                selectDropDown("ctl00_ContentZone_cmb_vehicle_class_cmb_dropdown");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSearch")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\", "verTransaccionesResults", timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\Host_VerTranscciones\\attachments\\", "verTransaccionesRetults","");
                System.Threading.Thread.Sleep(1000);
                string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Busqueda Completa: " + elementsFound);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
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
