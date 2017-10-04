using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CoviHonduras
{
    [TestClass]
    public class MCS_cambiarBarreraVía : Settingsfields_File
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void cambiarBarreraVia()
        {
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(MCSUrl);
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "loginMCSCVHPage", timet + ".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\", "loginMCSCVHPage", ".jpeg");
                string mcsVer = driver.FindElement(By.Id(mcsVersion)).Text;
                driver.FindElement(By.Id("txt_login")).SendKeys("00001");
                driver.FindElement(By.Id("txt_password")).SendKeys("00001");
                driver.FindElement(By.Id("btn_login")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homeMCSCVHPage", timet + ".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\", "homeMCSCVHPage", ".jpeg");
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.Id("lane_name_link_26")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='lyr_menu']/div[2]")).Click();
                System.Threading.Thread.Sleep(600);
                driver.FindElement(By.LinkText("Cambiar barrera salida")).Click();
                System.Threading.Thread.Sleep(600);
                if (ranNumbr(0, 1) == 1)
                {
                    driver.FindElement(By.LinkText("Abrir barrera")).Click();
                }
                else
                {
                    driver.FindElement(By.LinkText("Cerrar barrera")).Click();
                }
                if (isAlertPresent())
                {
                    driver.SwitchTo().Alert().Accept();
                }
                takeScreenShot("E:\\Selenium\\", "DetalleViaPage", timet + ".jepg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\", "DetalleViaPage", ".jpeg");                                
                string operationWindow = driver.FindElement(By.Id("titlebar")).Text;
                operationWindow = operationWindow.Trim();
                if (operationWindow.Equals("Error"))
                {
                    string errormessage = driver.FindElement(By.Id("lbl_message")).Text;
                    Assert.Fail(errormessage);
                    return;
                }
                /*Thread.sleep(500);
		            new Select(driver.findElement(By.id("cbDia1"))).selectByVisibleText("01");
                    new Select(driver.findElement(By.id("cbMes1"))).selectByVisibleText("ene");
                    selectDropDown("cmb_type");
                    Thread.sleep(1000);		
		            driver.findElement(By.id("btn_search")).click();
                    Thread.sleep(2000);
                    takeScreenShot("E:\\Selenium\\","cerrarViaResults"+timet+".jpg");
                    takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\","cerrarViaResults.jpg");
                    Thread.sleep(1000);
		            String elementsFound = driver.findElement(By.id("lbl_showing")).getText();
                    Thread.sleep(1500);
		            System.out.println("Busqueda Completa: "+ elementsFound);
                    System.out.println("Pruebas hechas en la versión del MCS de CoviHonduras: "+mcsVer);
                    Thread.sleep(1000);	*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();
            }
        }

        public static Boolean isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}


