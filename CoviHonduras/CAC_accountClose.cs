using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_accountClose : Settingsfields_File
    {
        private static Boolean accountClosed = false;
        private static Boolean NumbVehC = false;
        private static int NumbVeh;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }
        [TestMethod]
        public void accountCloseInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\");
            accountClose();
            System.Threading.Thread.Sleep(1000);
		    if (accountClosed){
			    Console.WriteLine("No se puede cerrar la cuenta "+accountNumbr.Substring(7, 16)+" porque ya está cerrada");
                Assert.Fail("No se puede cerrar la cuenta "+accountNumbr.Substring(7, 16)+" porque ya está cerrada");
		    }
		    if (NumbVehC){
			    Console.WriteLine("No se puede cerrar la cuenta "+accountNumbr.Substring(7, 9)+" porque tiene "+NumbVeh+" vehículo/s asignado/s");
                Assert.Fail("No se puede cerrar la cuenta "+accountNumbr.Substring(7, 9)+" porque tiene "+NumbVeh+" vehículo/s asignado/s");
		    }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Se ha cerrado la cuenta "+accountNumbr.Substring(7, 16)+" correctamente");
            Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
	    }

        public static void accountClose()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","loginCACCVHPage",".jpeg");
            loginPage("00001", "00001");
            takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","homeCACCVHPage",".jpeg");
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
            takeScreenShot("E:\\Selenium\\","accountSearchPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","accountSearchPage",".jpeg");
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
	        accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","accountPage",".jpeg");
            string numberVehicles = driver.FindElement(By.Id("ctl00_ContentZone_lbl_vehicles")).Text;
            System.Threading.Thread.Sleep(1000);
	        if(driver.PageSource.Contains("CUENTA CERRADA")){
		        accountClosed = true;
		        return;
	        }
	        NumbVeh = Int32.Parse(numberVehicles);
	        if (NumbVeh>0){
		        NumbVehC = true;
		        return;
	        }else{
                elementClick("ctl00_ContentZone_BtnCloseAccount");
                System.Threading.Thread.Sleep(500);
	            driver.FindElement(By.Id("ctl00_ContentZone_txtComment")).SendKeys("Esta Cuenta se cerrará");
                takeScreenShot("E:\\Selenium\\","accountClosePage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","accountClosePage",".jpeg");
                elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
                System.Threading.Thread.Sleep(500);
	            elementClick("ctl00_ButtonsZone_BtnBack_IB_Label");
                takeScreenShot("E:\\Selenium\\","accountClosedPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\accountClose\\attachments\\","accountClosedPage",".jpeg");
                System.Threading.Thread.Sleep(1000);
	        }
        }
        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}
