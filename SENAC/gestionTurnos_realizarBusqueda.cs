using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SENAC
{
    [TestClass]
    public class gestionTurnos_realizarBusqueda : senacFieldsConfiguration
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void turnosBusqueda()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\gestionTurnos_realizarBusqueda\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\", "loginpageSenac_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionTurnos_realizarBusqueda\\attachments\\", "loginpageSenac","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homepageSenac_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionTurnos_realizarBusqueda\\attachments\\", "homepageSenac","");
                System.Threading.Thread.Sleep(2000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de turno"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("(//a[contains(text(),'Gestión de turno')])[2]")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_ContentZone_dt_from_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dt_from_box_date")).SendKeys("01/01/2017");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSearch")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\", "searchResults_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionTurnos_realizarBusqueda\\attachments\\", "searchResults","");
                System.Threading.Thread.Sleep(1000);
                string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine(elementsFound);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                e.GetBaseException();
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
