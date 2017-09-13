using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SENAC
{
    [TestClass]
    public class transacciones_revisionTransaccionesBusqueda : senacFieldsConfiguration
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void revisionBusquedaTransacciones()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\transacciones_revisiónTransacciones\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\", "loginpageSenac_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\transacciones_revisiónTransacciones\\attachments\\", "loginpageSenac","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homepageSenac_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\transacciones_revisiónTransacciones\\attachments\\", "homepageSenac","");
                System.Threading.Thread.Sleep(2000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Transacciones"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Revisión de Transacciones")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\", "revisionTransicionesPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\transacciones_revisiónTransacciones\\attachments\\", "revisionTransicionesPage","");
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dateSelector_dt_from_box_date")).SendKeys("01/01/2017");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_Button_transactions")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("E:\\Selenium\\", "revisionTransicionesResults_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\transacciones_revisiónTransacciones\\attachments\\", "revisionTransicionesResults","");
                string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("Busqueda Completa: " + elementsFound);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
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
