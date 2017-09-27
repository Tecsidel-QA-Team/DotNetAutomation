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
    public class CAC_ReloadCreationAndAccountAssignment : Settingsfields_File
    {
        private static Boolean accountClosed = false;
        private static Boolean reloadCreated = false;
        private static string applicationType;
        private static string applicationTypeText;
        public static string reloadDescription;
        private static int optionclick;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void reloadCreationInit()
        {
            System.Threading.Thread.Sleep(1000);
            borrarArchivosTemp("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\");
            accountReload();
            System.Threading.Thread.Sleep(1000);
		    if (accountClosed){
			    Console.WriteLine("No se puede asignar un Recargo a la cuenta "+accountNumbr.Substring(7, 9)+" porque está cerrada");
                Assert.Fail("No se puede asignar un Recargo a la cuenta "+accountNumbr.Substring(7, 9)+" porque está cerrada");
                return;
		    }
		    if (reloadCreated){
			    Console.WriteLine("Se ha creado un Recargo para "+applicationType+" y se ha aplicado a la cuenta "+accountNumbr.Substring(7, 9)+" correctamente");
                System.Threading.Thread.Sleep(1000);
                return;
			}else{
                Assert.Fail("El recargo se ha creado pero no se ha podido aplicar a la cuenta "+accountNumbr.Substring(7, 9)+" por un error");
			Console.WriteLine("El recargo se ha creado pero no se ha podido aplicar a la cuenta "+accountNumbr.Substring(7, 9)+" por un error, verificar pantallazo o log de error");
		    }
		}

        public static void accountReload()
        {
            Actions action = new Actions(driver);
            driver.Navigate().GoToUrl(CaCUrl);
            takeScreenShot("E:\\Selenium\\","loginCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","loginCACCVHPage",".jpeg");
            loginPage("00001", "00001");
            takeScreenShot("E:\\Selenium\\","homeCACCVHPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","homeCACCVHPage",".jpeg");
            BOVersion = driver.FindElement(By.Id("ctl00_statusRight")).Text;
            System.Threading.Thread.Sleep(2000);					
	        action.ClickAndHold(driver.FindElement(By.LinkText("Configuración sistema"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
	        action.MoveToElement(driver.FindElement(By.LinkText("Configuraciones Globales")));
	        action.ClickAndHold(driver.FindElement(By.LinkText("Parámetros de cuenta"))).Build().Perform();
            System.Threading.Thread.Sleep(1500);
	        driver.FindElement(By.LinkText("Recargos")).Click();
            System.Threading.Thread.Sleep(2000);
            takeScreenShot("E:\\Selenium\\","ReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPage",".jpeg");
            elementClick("ctl00_ContentZone_BtnCreate");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadCreatioPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadCreatioPage",".jpeg");
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_cmb_type_cmb_dropdown");
            new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_type_cmb_dropdown"))).SelectByIndex(3);
            System.Threading.Thread.Sleep(500);
	        applicationType = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_type_cmb_dropdown"))).SelectedOption.Text;
            applicationTypeText = applicationType+"-"+timet.Substring(4, 14);
	        System.Threading.Thread.Sleep(500);
	        driver.FindElement(By.Id("ctl00_ContentZone_txt_name_box_data")).SendKeys(applicationTypeText);
            System.Threading.Thread.Sleep(2000);
	        reloadDescription = "Recargo para "+applicationType;			
	        driver.FindElement(By.Id("ctl00_ContentZone_txt_description_box_data")).SendKeys(reloadDescription);
	        if (!applicationType.Equals("Creación de cuenta")){
                selectDropDown("ctl00_ContentZone_cmb_applicationType_cmb_dropdown");
	        }
	        action.SendKeys(driver.FindElement(By.Id("ctl00_ContentZone_money_amount_txt_formated")),ranNumbr(10000,20000)+"").Build().Perform();
            System.Threading.Thread.Sleep(3000);
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(3000);
	        switch (applicationType){
		        case "Creación de cuenta":				accountCreation();
                                                        System.Threading.Thread.Sleep(500);
												        break;
		        case "Actualización de cuenta":			accountUpdate();
                                                        System.Threading.Thread.Sleep(500);
												        break;
		        case "Creación de vehículo":			vehicleCreation();
                                                        System.Threading.Thread.Sleep(500);
												        break;
		        case "Pérdida de Tag":					tagMissed();
                                                        System.Threading.Thread.Sleep(500);
												        break;
		    }

		}

	    public static void accountCreation()
        {
            Actions action = new Actions(driver);
            System.Threading.Thread.Sleep(2000);					
		    action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
		    action.MoveToElement(driver.FindElement(By.LinkText("Seleccionar cuenta")));
		    action.ClickAndHold(driver.FindElement(By.LinkText("Crear cuenta"))).Build().Perform();
            System.Threading.Thread.Sleep(500);
		    driver.FindElement(By.LinkText("Prepago")).Click();
            System.Threading.Thread.Sleep(1000);
		    accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountCreationPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountCreation",".jpeg");
            elementClick("ctl00_ContentZone_BtnFees"); //botón Recargos;
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_list_all_fees"))).SelectByText(applicationTypeText);
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_btn_add");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(100);
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
            takeScreenShot("E:\\Selenium\\","dataFilled",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","dataFilled",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnSave_IB_Label");
            reloadConfirmation();
        }

	    public static void accountUpdate()
        {
            Actions action = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
		    action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.LinkText("Seleccionar cuenta")).Click();
            System.Threading.Thread.Sleep(2000);
            elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
            IWebElement tableres = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
            IList<IWebElement> table = tableres.FindElements(By.TagName("tr"));
            int selectAccount = ranNumbr(2, table.Count);
            takeScreenShot("E:\\Selenium\\","accountSearchPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountSearchPage",".jpeg");
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
		    accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    if(driver.PageSource.Contains("CUENTA CERRADA")){
			    accountClosed = true;
			    return;
		    }
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ContentZone_BtnFees"); //botón Recargos;
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_list_all_fees"))).SelectByText(applicationTypeText);
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_btn_add");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(RUCid)).Clear();
            driver.FindElement(By.Id(RUCid)).SendKeys(ranNumbr(10000000,90000000)+""+ranNumbr(100000,9000000)+"");
		    System.Threading.Thread.Sleep(1000);		
            takeScreenShot("E:\\Selenium\\","dataChangeded",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","dataChanged",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");
            reloadConfirmation();
		}
	
	    public static void vehicleCreation()
        {
            Actions action = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
		    action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.LinkText("Seleccionar cuenta")).Click();
            System.Threading.Thread.Sleep(2000);
            elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
            IWebElement tableres = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
            IList<IWebElement> table = tableres.FindElements(By.TagName("tr"));
            int selectAccount = ranNumbr(2, table.Count);
            takeScreenShot("E:\\Selenium\\","accountSearchPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountSearchPage",".jpeg");
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
		    accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    if(driver.PageSource.Contains("CUENTA CERRADA")){
			    accountClosed = true;
			    return;
		    }
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ContentZone_BtnFees"); //botón Recargos;
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_list_all_fees"))).SelectByText(applicationTypeText);
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_btn_add");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(2000);
		    CAC_accountCreationWithVehicle.accountCreationWithVehicle();
            reloadConfirmation();
	    }
	
	    public static void tagMissed()
        {
            Actions action = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
		    action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.LinkText("Seleccionar cuenta")).Click();
            System.Threading.Thread.Sleep(2000);
            elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
            IWebElement tableres = driver.FindElement(By.Id("ctl00_ContentZone_TblResults"));
            IList<IWebElement> table = tableres.FindElements(By.TagName("tr"));
            int selectAccount = ranNumbr(2, table.Count);
            takeScreenShot("E:\\Selenium\\","accountSearchPage",timet+".jpEg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountSearchPage",".jpEg");
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblResults']/tbody/tr["+selectAccount+"]/td[1]/a")).Click();
            System.Threading.Thread.Sleep(1000);
		    accountNumbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            takeScreenShot("E:\\Selenium\\","accountPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    if(driver.PageSource.Contains("CUENTA CERRADA")){
			    accountClosed = true;
			    return;
		    }
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ContentZone_BtnFees"); //botón Recargos;
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
		    new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_list_all_fees"))).SelectByText(applicationTypeText);
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_btn_add");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ButtonsZone_BtnSubmit_IB_Label");
            System.Threading.Thread.Sleep(2000);
            string numberVehicles = driver.FindElement(By.Id("ctl00_ContentZone_lbl_vehicles")).Text;
            int NumbVeh = Int32.Parse(numberVehicles);
		    if (NumbVeh==0){
			    CAC_accountCreationWithVehicle.accountCreationWithVehicle();
		    }else{
    			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnValidate_IB_Label")).Click();
                System.Threading.Thread.Sleep(1500);
		    }
            elementClick("ctl00_ContentZone_BtnTags");
            takeScreenShot("E:\\Selenium\\","tagAssignmentMainPage",timet+".jpEg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","tagAssignmentMainPage",".jpeg");
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_chk_0");
            string tagid = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_m_table_members']/tbody/tr[2]/td[6]")).Text;
		    if (tagid.Equals("")){
                elementClick("ctl00_ContentZone_btn_token_assignment");
                System.Threading.Thread.Sleep(500);
			    driver.FindElement(By.Id("ctl00_ContentZone_txt_pan_token_txt_token_box_data")).SendKeys(ranNumbr(1,99999)+"");
			    System.Threading.Thread.Sleep(500);
                elementClick("ctl00_ContentZone_btn_init_tag");
                System.Threading.Thread.Sleep(500);
                elementClick("ctl00_ContentZone_chk_0");
		    }
            elementClick("ctl00_ContentZone_btn_token_stolen");
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ContentZone_btn_stolen");
            System.Threading.Thread.Sleep(1500);
            reloadConfirmation();		
	    }
		
	    public static void reloadConfirmation() 
        {
            System.Threading.Thread.Sleep(3000);
            string nextPage = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
            System.Threading.Thread.Sleep(3000);
            Assert.Equals("Detalles del pago", nextPage);
            IWebElement tablereload = driver.FindElement(By.Id("ctl00_ContentZone_CtNumbers_m_table_fees"));
            IList<IWebElement> tablere = tablereload.FindElements(By.TagName("tr"));
            takeScreenShot("E:\\Selenium\\","PayDetailPage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","PayDetailPage",".jpeg");
		    if (tablere.Count>1){
                string reload = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_CtNumbers_m_table_fees']/tbody/tr[2]/td[1]")).Text;
                if (reload.Contains(reloadDescription))
                {  
                    reloadCreated = true;
                }else{
                    reloadCreated = false;
                    return;
                }
            }else{
                reloadCreated = false;
                return;
            }
            elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
            System.Threading.Thread.Sleep(1000);		
		    if (!applicationTypeText.Equals("Pérdida de Tag")){
                optionclick = ranNumbr(0, 3);
            }else{
                optionclick = ranNumbr(0, 2);
            }
            elementClick("ctl00_ContentZone_CtType_radioButtonList_payBy_"+optionclick);
		    int optionclick1 = ranNumbr(0,1);
		    if (optionclick1==1){
                elementClick("ctl00_ContentZone_CtType_chk_present");
            }
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","ReloadPageDetail",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","ReloadPageDetail",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
            System.Threading.Thread.Sleep(3000);
            takeScreenShot("E:\\Selenium\\","accountReloadConfirmationPage",timet+".jpEg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadCreation\\attachments\\","accountReloadConfirmationPage",".jpEg");
		    switch (optionclick){
			    case 0:				elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
                                    break;
			    case 1:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyCard_BoxAuthCode_box_data")).SendKeys(ranNumbr(100000, 999999) + "");
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
                                    break;
			    case 2:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyCheque_txt_number_box_data")).SendKeys(ranNumbr(10000000, 9999999) + "");
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
                                    break;
			    case 3:				driver.FindElement(By.Id("ctl00_ContentZone_CtbyDepoBancario_BoxReference_box_data")).SendKeys("REF. " + ranNumbr(1000000, 9999999));
                                    System.Threading.Thread.Sleep(500);
                                    elementClick("ctl00_ButtonsZone_BtnExecute_IB_Label");
                                    break;
            }
            System.Threading.Thread.Sleep(4000);
            takeScreenShot("E:\\Selenium\\","accountReloadInvoicePage",timet+".jpeg");
            takeScreenShot("E:\\workspace\\Maria_Repository\\ReloadPage\\attachments\\","accountReloadInvoicePage",".jpeg");
            elementClick("ctl00_ButtonsZone_BtnBack_IB_Label");
            System.Threading.Thread.Sleep(2000);
        }       

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
