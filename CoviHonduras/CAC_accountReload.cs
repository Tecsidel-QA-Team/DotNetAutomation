using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_accountReload : Settingsfields_File
    {
        private static Boolean accountClosed = false;
        private static string Saldo;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void accountReloadInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\");
            accountReload();
            System.Threading.Thread.Sleep(1000);
		    if (accountClosed){
			    Console.WriteLine("No se puede hacer Recarga a la cuenta "+accountNumbr.Substring(7, 9)+" porque está cerrada");
                Assert.Fail("No se puede hacer Recarga a la cuenta "+accountNumbr.Substring(7, 9)+" porque está cerrada");
		    }
            System.Threading.Thread.Sleep(1000);
		    Console.WriteLine("Se Recargado la cuenta "+accountNumbr.Substring(7, 9)+" correctamente y posee un saldo de: "+Saldo);
		    Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
	        }

        public static void accountReload()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","loginCACCVHPage",".jpeg");
            loginPage("00001", "00001");
            takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","homeCACCVHPage",".jpeg");
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
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","accountSearchPage",".jpeg");
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
	        accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","accountPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
	        if(driver.PageSource.Contains("CUENTA CERRADA")){
		        accountClosed = true;
		        return;
	        }	
            elementClick("ctl00_ContentZone_BtnLoads");
            System.Threading.Thread.Sleep(1000);	
	        int optionclick = ranNumbr(0, 3);
            elementClick("ctl00_ContentZone_CtType_radioButtonList_payBy_"+optionclick);
            int optionclick1 = ranNumbr(0, 1);
	        if (optionclick1==1){
                elementClick("ctl00_ContentZone_CtType_chk_present");
	        }
            System.Threading.Thread.Sleep(1000);
	        driver.FindElement(By.Id("ctl00_ContentZone_CtType_text_total_txt_formated")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_CtType_text_total_txt_formated")).SendKeys(ranNumbr(100000,900000)+"");
            System.Threading.Thread.Sleep(500);
            takeScreenShot("E:\\Selenium\\","accountReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","accountReloadPage",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
            System.Threading.Thread.Sleep(3000);
            takeScreenShot("E:\\Selenium\\","accountReloadConfirmationPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","accountReloadConfirmationPage",".jpeg");
	        switch (optionclick){
		        case 0:				elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
							        break;
		        case 1:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyCard_BoxAuthCode_box_data")).SendKeys(ranNumbr(100000,999999)+"");
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
							        break;
		        case 2:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyCheque_txt_number_box_data")).SendKeys(ranNumbr(10000000,9999999)+"");
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
							        break;
		        case 3:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyDepoBancario_BoxReference_box_data")).SendKeys("REF. "+ranNumbr(100000,99999));
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
							        break;
	        }
            System.Threading.Thread.Sleep(3000);
            takeScreenShot("E:\\Selenium\\","accountReloadInvoicePage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountReload\\attachments\\","accountReloadInvoicePage",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnBack_IB_Label");
            System.Threading.Thread.Sleep(2000);
	        Saldo = driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountNotes_label_balance_pounds")).Text;
		}

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
