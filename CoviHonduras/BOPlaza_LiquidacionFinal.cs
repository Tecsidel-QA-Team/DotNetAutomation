using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CoviHonduras
{
    [TestClass]
    public class BOPlaza_LiquidacionFinal : Settingsfields_File
    {
        
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }
        [TestMethod]
        public void accountLiquidacionFinalInit() 
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\LiquidacionFinal\\attachments\\");
            accountLiquidacionFinal();
            System.Threading.Thread.Sleep(1000);	
		    Console.WriteLine("Se ha cerrado una Liquidación Final correctamente");
        }

        public static void accountLiquidacionFinal()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\","loginBOPlazaCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\LiquidacionFinal\\attachments\\","loginBOPlazaCVHPage",".jpeg");
            loginPage("00001", "00001");
            takeScreenShot("E:\\Selenium\\","homeBOPlazaCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\LiquidaciónFinal\\attachments\\","homeBOPlazaCVHPage",".jpeg");
            BOVersion = driver.FindElement(By.Id("ctl00_statusRight")).Text;
            System.Threading.Thread.Sleep(2000);					
	        action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cobrador"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
	        driver.FindElement(By.LinkText("Liquidación final")).Click();
            System.Threading.Thread.Sleep(2000);
            selectDropDown("ctl00_ContentZone_cmb_shiftGroup_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N50000_1")).SendKeys(ranNumbr(1,4)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N10000_1")).SendKeys(ranNumbr(1,4)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N5000_1")).SendKeys(ranNumbr(1,4)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N2000_1")).SendKeys(ranNumbr(1,4)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N1000_1")).SendKeys(ranNumbr(1,10)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N500_1")).SendKeys(ranNumbr(1,20)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N200_1")).SendKeys(ranNumbr(1,50)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N100_1")).SendKeys(ranNumbr(1,100)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C50_1")).SendKeys(ranNumbr(1,200)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C20_1")).SendKeys(ranNumbr(1,500)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C10_1")).SendKeys(ranNumbr(1,1000)+"");
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C5_1")).SendKeys(ranNumbr(1,2000)+"");
            System.Threading.Thread.Sleep(1000);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCH02201")).SendKeys(ranNumbr(1,5)+"");
            System.Threading.Thread.Sleep(1000);
          /*  action.Click(driver.FindElement(By.Id("ctl00_ContentZone_NumberCH02202_txt_formated"))).Build().Perform();
            action.SendKeys(driver.FindElement(By.Id("ctl00_ContentZone_NumberCH02202_txt_formated")),ranNumbr(10000,99999)+"").Build().Perform();
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberCD201")).SendKeys(ranNumbr(1,5)+"");
            System.Threading.Thread.Sleep(500);
            action.SendKeys(driver.FindElement(By.Id("ctl00_ContentZone_NumberCH02202_txt_plain")),ranNumbr(10000,99999)+"").Build().Perform();
            System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_NumberBD201")).SendKeys(ranNumbr(1,5)+"");
	        action.SendKeys(driver.FindElement(By.Id("ctl00_ContentZone_NumberBD202_txt_formated")),ranNumbr(10000,99999)+"").Build().Perform();
            System.Threading.Thread.Sleep(1000);*/
            takeScreenShot("E:\\Selenium\\","LiquidacionFinalPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\LiquidaciónGinal\\attachments\\","LiquidacionFinalPage",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(500);
            if (isAlertPresent()) {
                driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(1000);
            }
            if (isAlertPresent())
            {
                driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(8000);
            }
            takeScreenShot("E:\\Selenium\\","LiquidacionInvoice",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\LiquidaciónFinal\\attachments\\","LiquidacionInvoice",".jpeg");
            System.Threading.Thread.Sleep(1000);
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
