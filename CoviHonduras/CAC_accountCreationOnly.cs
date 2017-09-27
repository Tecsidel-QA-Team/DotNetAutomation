using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_accountCreationOnly : Settingsfields_File
    {

        [TestInitialize]
        public void setUp() 
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();       
        }
   
        [TestMethod]
        public void accountCreationInit()
        {
            accountCreation();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Se ha creado la cuenta: "+accountNumbr.Substring(7,16)+" correctamente");
            Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
        }

        public static void accountCreation()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\CAC_accountCreationAlone\\attachments\\");
			try{
				driver.Navigate().GoToUrl(CaCUrl);
                takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet);
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_accountCreationAlone\\attachments\\","loginCACCVHPage",".jpeg");
                loginPage("00001", "00001");
                takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet);
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_accountCreationAlone\\attachments\\","homeCACCVHPage",".jpeg");
                BOVersion = driver.FindElement(By.Id("ctl00_statusRight")).Text;
                System.Threading.Thread.Sleep(2000);					
				action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				action.MoveToElement(driver.FindElement(By.LinkText("Seleccionar cuenta")));
				action.ClickAndHold(driver.FindElement(By.LinkText("Crear cuenta"))).Build().Perform();
                System.Threading.Thread.Sleep(500);
				driver.FindElement(By.LinkText("Prepago")).Click();
                System.Threading.Thread.Sleep(1000);
				accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                takeScreenShot("E:\\Selenium\\","accountCreationPage_",timet);
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_accountCreationAlone\\attachments\\","accountCreation","");
                int selOpt = ranNumbr(0, 1);
                int selOp = ranNumbr(0, 8);
                int selOp2 = ranNumbr(0, 8);
				if (selOpt==0){
					driver.FindElement(By.Id(infoCuenta0)).Click();
                    System.Threading.Thread.Sleep(1000);
					driver.FindElement(By.Id(RUCid)).SendKeys(ranNumbr(10000000,90000000)+""+ranNumbr(100000,9000000)+"");
					new SelectElement(driver.FindElement(By.Id(titulofield))).SelectByText(sexSelc[selOp]);
                    driver.FindElement(By.Id(namef)).SendKeys(nameOp[selOp]);
                    driver.FindElement(By.Id(surnamef)).SendKeys(lastNameOp[selOp]);
                    driver.FindElement(By.Id(addressf)).SendKeys(addressTec[selOp]);
                    driver.FindElement(By.Id(cpf)).SendKeys(cpAdress[selOp]);
                    driver.FindElement(By.Id(countryf)).SendKeys("España");
                    driver.FindElement(By.Id(emailf)).SendKeys(nameOp[selOp].ToLower()+"."+lastNameOp[selOp].ToLower()+"@tecsidel.es");
                    driver.FindElement(By.Id(phoneCel)).SendKeys(ranNumbr(600000000,699999999)+"");
					driver.FindElement(By.Id(workPhone)).SendKeys(workPhone1[selOp]);
                    driver.FindElement(By.Id(perPhone)).SendKeys(ranNumbr(900000000,999999999)+"");
					driver.FindElement(By.Id(faxPhone)).SendKeys(workPhone1[selOp]);
                    System.Threading.Thread.Sleep(4000);
				}else{
					driver.FindElement(By.Id(infoCuenta1)).Click();
                    driver.FindElement(By.Id(RUCid)).SendKeys(ranNumbr(10000000,90000000)+""+ranNumbr(100000,9000000)+"");
                    System.Threading.Thread.Sleep(1000);
					driver.FindElement(By.Id(companyf)).SendKeys("Tecsidel, S.A");
                    driver.FindElement(By.Id(contactf)).SendKeys(nameOp[selOp]+" "+lastNameOp[selOp]+", "+nameOp[selOp2]+" "+lastNameOp[selOp2]);
                    driver.FindElement(By.Id(addressf)).SendKeys(addressTec[2]);
                    driver.FindElement(By.Id(cpf)).SendKeys(cpAdress[2]);
                    driver.FindElement(By.Id(countryf)).SendKeys("España");
                    driver.FindElement(By.Id(emailf)).SendKeys("info@tecsidel.es");
                    driver.FindElement(By.Id(phoneCel)).SendKeys(ranNumbr(600000000,699999999)+"");
					driver.FindElement(By.Id(workPhone)).SendKeys(workPhone1[2]);
                    driver.FindElement(By.Id(perPhone)).SendKeys(ranNumbr(900000000,999999999)+"");
					driver.FindElement(By.Id(faxPhone)).SendKeys(workPhone1[selOp]);
                    System.Threading.Thread.Sleep(1000);								
				}
                selectDropDown("ctl00_ContentZone_ctrlAccountData_cmb_groupFare_cmb_dropdown");
                System.Threading.Thread.Sleep(1000);		
                takeScreenShot("E:\\Selenium\\","dataFilled",timet);
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_accountCreationAlone\\attachments\\","dataFilled","");
                elementClick("ctl00_ButtonsZone_BtnSave_IB_Label");
                System.Threading.Thread.Sleep(3000);
				string nextPage = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                System.Threading.Thread.Sleep(3000);
                Assert.AreEqual("Detalles del pago", nextPage);
                elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
                System.Threading.Thread.Sleep(2000);				
			}catch(Exception e){
			    Console.WriteLine(e.GetBaseException());
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
