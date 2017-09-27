using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_operatorCreation : Settingsfields_File
    {
        private static string lastcreated;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void crearOperadores()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\");
	        try{
		        driver.Navigate().GoToUrl(CaCUrl);
                takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","loginCACCVHPage",".jpeg");
                loginPage("00001", "00001");
                takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","homeCACCVHPage",".jpeg");
                BOVersion = driver.FindElement(By.Id("ctl00_statusRight")).Text;
                System.Threading.Thread.Sleep(2000);					
		        action.ClickAndHold(driver.FindElement(By.LinkText("Configuración sistema"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
		        action.MoveToElement(driver.FindElement(By.LinkText("Parámetros de cuenta")));
		        action.ClickAndHold(driver.FindElement(By.LinkText("Operadores"))).Build().Perform();
                System.Threading.Thread.Sleep(500);
		        driver.FindElement(By.LinkText("Gestión de operadores")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","gestionOperadoresPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","gestionOperadoresPage",".jpeg");
                System.Threading.Thread.Sleep(500);		
                elementClick("ctl00_ContentZone_BtnCreate");
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","crearOperadoresPage",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","crearOperadoresPage",",.jpeg");
                int userSel = ranNumbr(0, nameOp.Length - 1);
                new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_title_cmb_dropdown"))).SelectByText(sexSelc[userSel]);
                System.Threading.Thread.Sleep(100);
		        new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_gender_cmb_dropdown"))).SelectByText(genderS[userSel]);
                driver.FindElement(By.Id("ctl00_ContentZone_forename_box_data")).SendKeys(nameOp[userSel]);
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_surname_box_data")).SendKeys(lastNameOp[userSel]);
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_txt_address_box_data")).SendKeys(addressTec[userSel]);
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_txt_postcode_box_data")).SendKeys(cpAdress[userSel]);
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_txt_city_box_data")).SendKeys(townC[userSel]);
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_txt_country_box_data")).SendKeys("España");
                System.Threading.Thread.Sleep(100);
		        driver.FindElement(By.Id("ctl00_ContentZone_email_box_data")).SendKeys(nameOp[userSel].ToLower()+lastNameOp[userSel].ToLower()+"@tecsidel.es");
                driver.FindElement(By.Id("ctl00_ContentZone_txt_phone_box_data")).SendKeys(workPhone1[userSel]);
                selectDropDown("ctl00_ContentZone_group_cmb_dropdown");
                System.Threading.Thread.Sleep(1000);
		        IWebElement operatorGroup = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_group_cmb_dropdown"))).SelectedOption;
                string operatorG = operatorGroup.Text;
                driver.FindElement(By.Id("ctl00_ContentZone_dt_birth_box_date")).Clear();
                driver.FindElement(By.Id("ctl00_ContentZone_dt_birth_box_date")).SendKeys(dateSel(new DateTime(1970, 1, 1), new DateTime(1980, 12, 31)).ToString("dd/MM/yyyy"));
                System.Threading.Thread.Sleep(3000);
		        driver.FindElement(By.Id("ctl00_ContentZone_password_box_data")).SendKeys("00001");
                driver.FindElement(By.Id("ctl00_ContentZone_password2_box_data")).SendKeys("00001");
                System.Threading.Thread.Sleep(5000);
                takeScreenShot("E:\\Selenium\\","allfilleddata",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","allfilleddata",".jpeg");
                elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","userCreated",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","userCreated",".jpeg");
                IWebElement tableResult = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
                IList<IWebElement> userResults = tableResult.FindElements(By.TagName("tr"));
                if (userResults.Count < 14)
                {
                    for (int i = 1; i <= userResults.Count; i++)
                    {
                        if (i == userResults.Count)
                        {
                            lastcreated = driver.FindElement(By.XPath("//table[@id='ctl00_ContentZone_TblResults']/tbody/tr[" + i + "]/td[2]")).Text;
                        }
                    }
                }
                else
                {
                    elementClick("ctl00_ContentZone_tablePager_BtnLast");
                    tableResult = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
                    userResults = tableResult.FindElements(By.TagName("tr"));
                    lastcreated = driver.FindElement(By.XPath("//table[@id='ctl00_ContentZone_TblResults']/tbody/tr[" + userResults.Count + "]/td[2]")).Text;

                }
                elementClick("ctl00_BtnLogOut");
                System.Threading.Thread.Sleep(500);
		        driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(1000);
                loginPage(lastcreated, "00001");
		        takeScreenShot("E:\\Selenium\\","userCreatedscreenHome",timet+".jpeg");
                takeScreenShot("E:\\workspace\\Maria_Repository\\CAC_crearOperadores\\attachments\\","userCreatedscreenHome",".jpeg");
                Console.WriteLine("Se ha Creado el "+lastcreated+" con la contraseaña: 00001"+ " en el grupo de "+operatorG.Substring(04));
		        Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1,16)+" y CAC Manager: "+BOVersion.Substring(17));
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
