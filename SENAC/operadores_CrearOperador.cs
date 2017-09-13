using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SENAC
{
    [TestClass]
    public class operadores_CrearOperador : senacFieldsConfiguration
    {
        public static string opzero = ""; //numero de operador
        
        [TestInitialize]
        public void setUp() 
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void senacOperadoresPage()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\");
			try{
				driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\","loginpageSenac_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","loginpageSenac","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","homepageSenac_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","homepageSenac","");
                System.Threading.Thread.Sleep(1000);
			    action.ClickAndHold(driver.FindElement(By.LinkText("Configuración sistema"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				action.ClickAndHold(driver.FindElement(By.LinkText("Operadores"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				driver.FindElement(By.LinkText("Gestión de operadores")).Click();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","gestionOperadoresPage_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","gestionOperadoresPage","");
                driver.FindElement(By.Id("ctl00_ContentZone_BtnCreate")).Click(); // Botón crear operador
                System.Threading.Thread.Sleep(1500);
                takeScreenShot("E:\\Selenium\\","crearOperadoresPage_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","crearOperadoresPage","");
                System.Threading.Thread.Sleep(500);
			    int opId = ranNumbr(1, 99999);
                string opIdnumbr = string.Concat(opId);
						if (opIdnumbr.Length < 5){
							int opI = 5 - opIdnumbr.Length;
                            char[] opc = new char[opI];
							for (int i = 0; i<opI; i++){
								opc[i] = '0';
								opzero = string.Concat(opc[i]);								
							}
                        opzero = string.Concat(opId);														
						}else{
							opzero = string.Concat(opId) ;
						}
                        System.Threading.Thread.Sleep(2000);
                        operatorCreate();
                driver.FindElement(By.Id("ctl00_BtnLogOut")).Click();
                System.Threading.Thread.Sleep(2000);
				driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(3000);
				driver.FindElement(By.Id(loginField)).SendKeys(opzero);
                driver.FindElement(By.Id(passField)).SendKeys(opzero);
                System.Threading.Thread.Sleep(500);
                takeScreenShot("E:\\Selenium\\","operatorLoginagain_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","operatorLoginagain","");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(4000);
                takeScreenShot("E:\\Selenium\\","operatorIn_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","operatorIn","");
                Console.WriteLine("El Operador "+opzero+" ha sido creado y entra correctamente a BackOffice");
			}catch(Exception e){
                    e.GetBaseException();
                    Assert.Fail();
			}
		}	
        
		public static void operatorCreate()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(opIdField)).SendKeys(opzero);
			int selOp = ranNumbr(0,8);
            driver.FindElement(By.Id(nameField)).SendKeys(nameOp [selOp]);
            driver.FindElement(By.Id(lastNameField)).SendKeys(lastNameOp [selOp]);
            driver.FindElement(By.Id(emailField)).SendKeys(nameOp [selOp].ToLower()+"."+lastNameOp [selOp].ToLower()+"@tecsidel.es");
            selectDropDownClick(groupOperator);
            driver.FindElement(By.Id(pwdField)).SendKeys(opzero);
            driver.FindElement(By.Id(repeatpwdField)).SendKeys(opzero);
            driver.FindElement(By.Id("ctl00_ContentZone_ChkSalde")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ChkHistorique")).Click();
            driver.FindElement(By.Id(hourNumber)).SendKeys(ranNumbr(1,999)+"");
            System.Threading.Thread.Sleep(500);
            takeScreenShot("E:\\Selenium\\","crearOperadoresPageDataFill_",timet);
            takeScreenShot("E:\\workspace\\Mavi_Repository\\operadores_CrearOperador\\attachments\\","crearOperadoresPageDataFill","");
            driver.FindElement(By.Id(submitBtn)).Click();
            System.Threading.Thread.Sleep(3000);

        }

        [TestCleanup]
        public void tearDown() 
        {
            driver.Quit();
        }

    }


}

