using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CoviHonduras
{
    [TestClass]
    public class MCS_reiniciarControladorLogico : Settingsfields_File
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void reiniciarControladorLogico()
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
                driver.FindElement(By.LinkText("Reiniciar controlador lógico")).Click();
                System.Threading.Thread.Sleep(600);
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
                System.Threading.Thread.Sleep(1000);
                string confirmMessage = driver.FindElement(By.Id("lbl_message")).Text;
                takeScreenShot("E:\\Selenium\\","reiniciarControladorResults",timet+".jpeg");
		        takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\","reiniciarControladorResults",".jpeg");
                Console.WriteLine(operationWindow + ": " + confirmMessage);
                Console.WriteLine("Pruebas hechas en la versión del MCS de CoviHonduras: " + mcsVer);
                System.Threading.Thread.Sleep(1000);
            }catch (Exception e)
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
            catch (Exception)
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


