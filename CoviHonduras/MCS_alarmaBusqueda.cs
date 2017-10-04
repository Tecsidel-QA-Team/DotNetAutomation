using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CoviHonduras
{
    [TestClass]
    public class MCS_alarmaBusqueda : Settingsfields_File
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void alarmaBusqueda()
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
                driver.FindElement(By.XPath("//div[@onclick=\"dropdownmenu(this, event, menu3, '250px')\"]")).Click();
                System.Threading.Thread.Sleep(600);
                driver.FindElement(By.LinkText("Ver alarmas")).Click();
                System.Threading.Thread.Sleep(600);
                driver.SwitchTo().Frame(0);
                takeScreenShot("E:\\Selenium\\", "verAlarmasPage" , timet + ".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_alarmaBusqueda\\attachments\\", "verAlarmasPage",".jpeg");
                new SelectElement(driver.FindElement(By.Id("cbDia1"))).SelectByText("01");
                new SelectElement(driver.FindElement(By.Id("cbMes1"))).SelectByText("ene");
                selectDropDown("cmb_type");
                System.Threading.Thread.Sleep(1000);		
		        driver.FindElement(By.Id("btn_search")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","alarmaBusquedaResults",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\MCS_application\\attachments\\","alarmaBusquedaResults",".jpeg");
                System.Threading.Thread.Sleep(1000);
		        string elementsFound = driver.FindElement(By.Id("lbl_showing")).Text;
                System.Threading.Thread.Sleep(1500);
		        Console.WriteLine("Busqueda Completa: "+ elementsFound);
                Console.WriteLine("Pruebas hechas en la versión del MCS de CoviHonduras: "+mcsVer);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail();
            }
        }

        public static Boolean isAlertPresent()
        {
            driver.SwitchTo().Alert();
            return true;
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
