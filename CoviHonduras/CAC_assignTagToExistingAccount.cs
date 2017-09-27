using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_assignTagToExistingAccount : Settingsfields_File
    {
        public static Boolean accountClosed = false;
        public static Boolean NumbVehC = false;
        public static Boolean TagAssigned = false;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void assignTagToExistingAccountInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\assigningTagToAccount\\attachments\\");
            assignTagToExistingAccount();
            System.Threading.Thread.Sleep(1000);
		    if (accountClosed==true){
			    Console.WriteLine("No se puede asignar un Tag a la cuenta "+accountNumbr.Substring(7, 16)+" porque está cerrada");
                Assert.Fail("No se puede asignar un Tag a la cuenta "+accountNumbr.Substring(7, 16)+" porque está cerrada");
		    }
		    if (NumbVehC==true){
			    Console.WriteLine("No se puede asignar un Tag a la cuenta "+accountNumbr.Substring(7, 16)+" porque no hay vehículo asociado a la cuenta");
                Assert.Fail("No se puede asignar un Tag a la cuenta "+accountNumbr.Substring(7, 16)+" porque no hay vehículo asociado a la cuenta");
		    }
		    if (TagAssigned==true){
				Console.WriteLine("ERROR AL ASIGNAR TAG a la cuenta: "+accountNumbr.Substring(7, 16)+", "+confirmationMessage);
                Assert.Fail("ERROR AL ASIGNAR TAG a la cuenta: "+accountNumbr.Substring(7, 16)+", "+confirmationMessage);
		    }
            System.Threading.Thread.Sleep(1000);
		    Console.WriteLine("Se le asignado el el tag No."+tagIdNmbr+" a la cuenta "+accountNumbr.Substring(7, 16)+" correctamente");
		    Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
	    }

        public static void assignTagToExistingAccount()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\", "loginCACCVHPage", timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\assigningTagToAccount\\attachments\\", "loginCACCVHPage", "");
            driver.FindElement(By.Id(loginField)).SendKeys("00001");
            driver.FindElement(By.Id(passField)).SendKeys("00001");
            driver.FindElement(By.Id(loginButton)).Click();
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\", "homeCACCVHPage", timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\assigningTagToAccount\\attachments\\", "homeCACCVHPage", "");
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
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr[" + selectAccount + "]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
            accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            System.Threading.Thread.Sleep(1000);
            if (driver.PageSource.Contains("CUENTA CERRADA"))
            {
                accountClosed = true;
                return;
            }
            string numberVehicles = driver.FindElement(By.Id("ctl00_ContentZone_lbl_vehicles")).Text;
            int NumbVeh = Int32.Parse(numberVehicles);
            if (NumbVeh == 0)
            {
                NumbVehC = true;
                return;
            }
            else
            {
                driver.FindElement(By.Id("ctl00_ContentZone_BtnTags")).Click();
                takeScreenShot("E:\\Selenium\\", "tagAssignmentMainPage", timet);
                takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\", "tagAssignmentMainPage", "");
                System.Threading.Thread.Sleep(1000);
                int vehCheck = ranNumbr(0, NumbVeh - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_chk_" + vehCheck)).Click();
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_btn_token_assignment")).Click();
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_txt_pan_token_txt_token_box_data")).SendKeys(ranNumbr(1, 99999) + "");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_btn_init_tag")).Click();
                System.Threading.Thread.Sleep(1500);
                confirmationMessage = driver.FindElement(By.Id("ctl00_ContentZone_lbl_information")).Text;
                if (confirmationMessage.Contains("ya tiene un título asignado") || confirmationMessage.Contains("Este tag no está operativo") || confirmationMessage.Contains("Este tag ya está asignado") || confirmationMessage.Contains("Luhn incorrecto"))
                {
                    TagAssigned = true;
                    takeScreenShot("E:\\Selenium\\", "tagAssignmentPageErr", timet);
                    takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\", "tagAssignmentPageErr", "");
                    return;
                }
                else
                {
                    int tabVeh = vehCheck + 2;
                    tagIdNmbr = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_m_table_members']/tbody/tr[" + tabVeh + "]/td[6]")).Text;
                    takeScreenShot("E:\\Selenium\\", "tagAssignmentPage", timet);
                    takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\", "tagAssignmentPage", "");
                }
            }
        }
	    
        [TestCleanup]
	    public void tearDown()
        {
            driver.Quit();
        }
	
	}

}
