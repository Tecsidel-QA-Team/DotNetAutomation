using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_accountCreationAssigningTag : Settingsfields_File
    {
        [TestInitialize]
        public void setUp() 
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        
        }

        [TestMethod]
        public void accountCreationAssigningTagInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\");
            CAC_accountCreationOnly.accountCreation();
            System.Threading.Thread.Sleep(2000);
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");
            System.Threading.Thread.Sleep(1000);
            CAC_accountCreationWithVehicle.accountCreationWithVehicle();
            System.Threading.Thread.Sleep(500);
            accountCreationAssigningTag();
            System.Threading.Thread.Sleep(1000);
		    if (errorTagAssignment){
                Console.WriteLine("ERROR AL ASIGNAR TAG a la cuenta: " + accountNumbr.Substring(7, 9) + ", " + confirmationMessage);
                Assert.Fail("Tag Invalido: No se puede asignar un Tag al Vehiculo " + matriNu + " de la cuenta " + accountNumbr.Substring(7, 9));
                return;
            }
            Console.WriteLine("Se ha creado la cuenta: "+accountNumbr.Substring(7, 9)+" con un Vehiculo con la matricula "+matriNu+" y el tag asignado No.: "+ tagIdNmbr);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
        }

        public static void accountCreationAssigningTag()
        {
            System.Threading.Thread.Sleep(2000);
            takeScreenShot("E:\\Selenium\\","tagAssignmentMainPage",timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\","tagAssignmentMainPage","");
            driver.FindElement(By.Id("ctl00_ContentZone_BtnTags")).Click();
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ContentZone_chk_0");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_btn_token_assignment")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_txt_pan_token_txt_token_box_data")).SendKeys(ranNumbr(1,99999)+"");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_btn_init_tag")).Click();
            System.Threading.Thread.Sleep(500);
            confirmationMessage = driver.FindElement(By.Id("ctl00_ContentZone_lbl_operation")).Text;
			if (confirmationMessage.Contains("ya tiene un tag asignado") || confirmationMessage.Contains("Este tag no está operativo") || confirmationMessage.Contains("Este tag ya está asignado") || confirmationMessage.Contains("Luhn incorrecto")){
                errorTagAssignment = true;
                takeScreenShot("E:\\Selenium\\", "tagAssignmentPageErr" , timet );
                takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\", "tagAssignmentPageErr","");
            }else{
            tagIdNmbr = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_m_table_members']/tbody/tr[2]/td[6]")).Text;
            takeScreenShot("E:\\Selenium\\", "tagAssignmentPage", timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationAssigningTag\\attachments\\", "tagAssignmentPage","");
            }
            System.Threading.Thread.Sleep(1000);
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }            

    }
}
