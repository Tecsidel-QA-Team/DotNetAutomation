using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SENAC
{
    [TestClass]
    public class gestionCuentas_seleccionarCuenta : senacFieldsConfiguration
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void cuentaSeleccionar()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\", "loginHostSenacPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\", "loginHostSenacPage","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homeSenacPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\", "homeSenacPage","");
                System.Threading.Thread.Sleep(1000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                action.Click(driver.FindElement(By.LinkText("Seleccionar cuenta"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                string tagNumbr = "68989";
                driver.FindElement(By.Id("ctl00_ContentZone_Textbox_byTag")).SendKeys(tagNumbr);
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSearch")).Click();
                System.Threading.Thread.Sleep(1000);
                string nextPageS = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                System.Threading.Thread.Sleep(200);
                if (nextPageS.Equals("Selección de cuenta"))
                {
                    string errorSearch = driver.FindElement(By.Id("ctl00_LblError")).Text;
                    if (errorSearch.Equals("Luhn incorrecto"))
                    {
                        System.Threading.Thread.Sleep(500);
                        takeScreenShot("E:\\Selenium\\", "SearchErr" , timet);
                        takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\", "SearchErr","");
                        Console.WriteLine("ERROR AL TRATAR DE BUSCAR TAG, debido a: " + errorSearch);
                        Assert.Fail("ERROR BUSQUEDA TAG: " + errorSearch);
                        return;
                    }
                }
                takeScreenShot("E:\\Selenium\\", "seleccionarCuentabyTag_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\", "seleccionarCuentabyTag","");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_ContentZone_BtnVehicles")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "vehicleandTagAssigned_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_SeleccionarCuenta\\attachments\\", "vehicleandTagAssigned","");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("La cuenta se ha visualizado correctamente consultar los archivos de images de SeleccionarCuenta y TagAssigned para su verificación");
                System.Threading.Thread.Sleep(3000);
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
