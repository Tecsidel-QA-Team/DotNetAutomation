using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SENAC
{
    [TestClass]
    public class gestionCuentas_CrearCuentaStandard : senacFieldsConfiguration
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void senacGestionCuentasPage()
        {
            Actions action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\");
            try
            {
                driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\","loginHostSenacPage",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","loginHostSenacPage.jpg","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","loginHostSenacPage",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","homeHostSenacPage","");
                System.Threading.Thread.Sleep(1000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Gestión de cuentas"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Crear cuenta"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Standard")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\","operatorCreatorPage",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","operatorCreatorPage","");
                System.Threading.Thread.Sleep(1000);
                string accountNmbr = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                accountNumbrT = accountNmbr.Substring(7, 16);
                System.Threading.Thread.Sleep(2000);
                accountCreate();
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ButtonsZone_BtnSave");
                System.Threading.Thread.Sleep(3000);
                elementClick("ctl00_ButtonsZone_BtnExecute");
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ButtonsZone_BtnValidate");
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ContentZone_BtnVehicles");
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ContentZone_BtnCreate");
                System.Threading.Thread.Sleep(1000);
                crearVehiculo();
                System.Threading.Thread.Sleep(2000);
                vehicleFieldsfill(matriNu, vehtypeModel, vehtypeKind, colorS[ranNumbr(0, colorS.Length - 1)]);
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSubmit")).Click();
                System.Threading.Thread.Sleep(1500);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnBack")).Click();
                System.Threading.Thread.Sleep(1500);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnValidate")).Click();
                System.Threading.Thread.Sleep(2500);
                tagAssignment();
                    if (errorTagAssignment)
                    {
                        Console.WriteLine("ERROR AL ASIGNAR TAG a la cuenta: " + accountNumbrT + ", " + confirmationMessage);
                        Assert.Fail("Tag Invalido: No se puede asignar un Tag al Vehiculo " + matriNu + " de la cuenta " + accountNumbrT);
                        return;
                    }
                Console.WriteLine("Se ha creado la cuenta: " + accountNumbrT + " con un Vehiculo con la matricula " + matriNu + " y el tag asignado No.: " + tagIdNmbr);
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        public static void accountCreate()
        {
            Actions action = new Actions(driver);
            System.Threading.Thread.Sleep(1000);
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int selOpt = ranNumbr(0, 1);
            int selOp = ranNumbr(0, 8);
            int selOp2 = ranNumbr(0, 8);
			if (selOpt==0){
				driver.FindElement(By.Id(infoCuenta0)).Click();
                System.Threading.Thread.Sleep(1000);
				new SelectElement(driver.FindElement(By.Id(titulofield))).SelectByText(sexSelc[selOp]);
                driver.FindElement(By.Id(namef)).SendKeys(nameOp[selOp]);
                driver.FindElement(By.Id(surnamef)).SendKeys(lastNameOp[selOp]);
                driver.FindElement(By.Id(addressf)).SendKeys(addressTec[selOp]);
                driver.FindElement(By.Id(cpf)).SendKeys(cpAdress[selOp]);
                driver.FindElement(By.Id(townf)).SendKeys(townC[selOp]);
                driver.FindElement(By.Id(countryf)).SendKeys("España");
                driver.FindElement(By.Id(emailf)).SendKeys(nameOp[selOp].ToLower()+"."+lastNameOp[selOp].ToLower()+"@tecsidel.es");
                driver.FindElement(By.Id(phoneCel)).SendKeys(ranNumbr(600000000,699999999)+"");
				driver.FindElement(By.Id(workPhone)).SendKeys(workPhone1[selOp]);
                driver.FindElement(By.Id(perPhone)).SendKeys(ranNumbr(900000000,999999999)+"");
				driver.FindElement(By.Id(faxPhone)).SendKeys(workPhone1[selOp]);
                System.Threading.Thread.Sleep(4000);			
			}else{
				driver.FindElement(By.Id(infoCuenta1)).Click();
                System.Threading.Thread.Sleep(1000);
				driver.FindElement(By.Id(companyf)).SendKeys("Tecsidel, S.A");
                driver.FindElement(By.Id(contactf)).SendKeys(nameOp[selOp]+" "+lastNameOp[selOp]+", "+nameOp[selOp2]+" "+lastNameOp[selOp2]);
                driver.FindElement(By.Id(addressf)).SendKeys(addressTec[2]);
                driver.FindElement(By.Id(cpf)).SendKeys(cpAdress[2]);
                driver.FindElement(By.Id(townf)).SendKeys(townC[2]);
                driver.FindElement(By.Id(emailf)).SendKeys("info@tecsidel.es");
                driver.FindElement(By.Id(phoneCel)).SendKeys(ranNumbr(600000000,699999999)+"");
				driver.FindElement(By.Id(workPhone)).SendKeys(workPhone1[2]);
                driver.FindElement(By.Id(perPhone)).SendKeys(ranNumbr(900000000,999999999)+"");
				driver.FindElement(By.Id(faxPhone)).SendKeys(workPhone1[selOp]);
                System.Threading.Thread.Sleep(1000);								
			}
            selOpt = ranNumbr(0,1);
			if (selOpt==0){
				driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_discount_0")).Click();
			}else{
		        driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_discount_1")).Click();
                selOpt = ranNumbr(0,1);
				if (selOpt==0){
			        driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_typeOfDiscount_0")).Click();
                    selOpt = ranNumbr(0,1);
					if (selOpt == 0){
					    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_for_0")).Click();
							}else{
								driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_for_1")).Click();
							}
					}else{
						driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_rd_typeOfDiscount_1")).Click();
					}
			}
			System.Threading.Thread.Sleep(2000);
            selectDropDown("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMode_cmb_dropdown");
            System.Threading.Thread.Sleep(3000);
			IWebElement PayMode = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMode_cmb_dropdown"))).SelectedOption;
            string PayModeT = PayMode.Text;		
		    if (PayModeT.Equals("Prepago")){
				selOpt = ranNumbr(0,1);
				if (selOpt > 0){
                    System.Threading.Thread.Sleep(1000);
                        elementClick("ctl00_ContentZone_ctrlAccountStandard_chk_show_low_in_lane");
				}
                System.Threading.Thread.Sleep(1000);
                selectDropDown("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMethod_cmb_dropdown");
                System.Threading.Thread.Sleep(1500);
				IWebElement PayMethod = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMethod_cmb_dropdown"))).SelectedOption;
                string PayMetthodT = PayMethod.Text;
                if (PayMetthodT.Equals("preautorizado")){
                    System.Threading.Thread.Sleep(1000);
                    action.Click(driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_topup_txt_formated"))).Build().Perform();
                    action.SendKeys(driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_topup_txt_formated")), ranNumbr(1000, 200000) + "").Build().Perform();
					System.Threading.Thread.Sleep(1000);
					selOpt = ranNumbr(0,1);
			        if (selOpt > 0)
                    {
                        elementClick("ctl00_ContentZone_ctrlAccountStandard_chk_fixed");
					}else{
                        selectDropDown("ctl00_ContentZone_ctrlAccountStandard_cmb_topupDay_cmb_dropdown");
					}
					System.Threading.Thread.Sleep(1000);
					driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_bankAccount_box_data")).SendKeys("ES0"+ranNumbr(10,200)+"-"+ranNumbr(1000,3000)+"-"+ranNumbr(100,200)+"-"+ranNumbr(1000,5000)+"-"+ranNumbr(50000,90000));
                    System.Threading.Thread.Sleep(1000);
					driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_holderName_box_data")).SendKeys(nameOp[selOp]+" "+lastNameOp[selOp]);
				}
                System.Threading.Thread.Sleep(5000);
							
			}
            if (PayModeT.Equals("Postpago")){
                selectDropDown("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMethod_cmb_dropdown");
                System.Threading.Thread.Sleep(1500);						
				IWebElement PayMethod = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_cmb_paymentMethod_cmb_dropdown"))).SelectedOption;
                string PayMetthodT = PayMethod.Text;						
				if (PayMetthodT.Equals("preautorizado")){
					driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_bankAccount_box_data")).SendKeys("ES0"+ranNumbr(10,200)+"-"+ranNumbr(1000,3000)+"-"+ranNumbr(100,200)+"-"+ranNumbr(1000,5000)+"-"+ranNumbr(50000,90000));
                    System.Threading.Thread.Sleep(1000);
				    driver.FindElement(By.Id("ctl00_ContentZone_ctrlAccountStandard_txt_holderName_box_data")).SendKeys(nameOp[selOp]+" "+lastNameOp[selOp]);
                    System.Threading.Thread.Sleep(5000);
					}
			}
			if (ranNumbr(0,1)>0){
                        elementClick("ctl00_ContentZone_ctrlAccountNotes_check_itemised_billing"); //factura detallada click
			}
            System.Threading.Thread.Sleep(1000);
            selectDropDown("ctl00_ContentZone_ctrlAccountNotes_combo_statement_date");
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_check_statement_email_notice"); //enviar por email click
			}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_check_statement_post_notice");//enviar por correo click
			}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_radio_notification_1");//enviar notificación por
			}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_chk_receive_info");//Recibir info click
			}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_chk_receive_ads");//Rec. Publi. click
			}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_check_suspension_state");//Suspendida click
					}
            System.Threading.Thread.Sleep(1000);
			if (ranNumbr(0,1)>0){
                elementClick("ctl00_ContentZone_ctrlAccountNotes_chk_internet_access");//Habilitada click
			}
            System.Threading.Thread.Sleep(1000);
			takeScreenShot("E:\\Selenium\\","accountDataFill_",timet);
			takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","accountDataFill","");
            System.Threading.Thread.Sleep(5000);
		}

		public static void crearVehiculo() 
        {
            System.Threading.Thread.Sleep(2000);
			int matNum = ranNumbr(5000,9999);
			int matlet = ranNumbr(1, NIF_STRING_ASOCIATION.Length);
			int matlet1 = ranNumbr(1, NIF_STRING_ASOCIATION.Length);
			int matlet2 = ranNumbr(1, NIF_STRING_ASOCIATION.Length);
            matriNu = (matNum + NIF_STRING_ASOCIATION.Substring(matlet, matlet + 1) + NIF_STRING_ASOCIATION.Substring(matlet1, matlet1 + 1) + NIF_STRING_ASOCIATION.Substring(matlet2, matlet2 + 1));            
            selectDropDown("ctl00_ContentZone_cmb_vehicle_type");
            System.Threading.Thread.Sleep(1000);
            IWebElement vehtype = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_vehicle_type"))).SelectedOption;
            string vehtypeT = vehtype.Text;
		    if (vehtypeT.Equals("Coche")){
			    carSel = ranNumbr(0,3);
                carModel = ranNumbr(1,2);
				if (cocheModels[0,carSel].Equals("Seat")){
				    carModelSel = 0;
				}
				if (cocheModels[0,carSel].Equals("Volkswagen")){
					carModelSel = 1;
				}
				if (cocheModels[0,carSel].Equals("Ford")){
					carModelSel = 2;
				}
				if (cocheModels[0,carSel].Equals("Fiat")){
					carModelSel = 3;
				}
                   vehtypeModel = cocheModels[0, carSel];
                   vehtypeKind = cocheModels[carModel, carModelSel];	
			}
			if (vehtypeT.Equals("Ciclomotor")){
				carSel = ranNumbr(0,1);
                carModel = ranNumbr(1,2);
				if (cicloModels[0,carSel].Equals("Yamaha")){
				    carModelSel = 0;
				}
				if (cicloModels[0,carSel].Equals("Honda")){
					carModelSel = 1;
				}			
				vehtypeModel = cicloModels[0,carSel];
				vehtypeKind = cicloModels[carModel,carModelSel];
			}
			if (vehtypeT.Equals("Autobús")){
				carSel = ranNumbr(0,1);
                carModel = ranNumbr(1,2);
			    if (autoBusModels[0,carSel].Equals("DAIMLER-BENZ")){
				    carModelSel = 0;
				}
				if (autoBusModels[0,carSel].Equals("VOLVO")){
					carModelSel = 1;
				}
				vehtypeModel = autoBusModels[0,carSel];
				vehtypeKind = autoBusModels[carModel,carModelSel];
			}
			if (vehtypeT.Equals("Camión")){
				carSel = ranNumbr(0,1);
                carModel = ranNumbr(1,2);
				if (camionModels[0,carSel].Equals("Mercedes-Benz")){
					carModelSel = 0;
				}
				if (camionModels[0,carSel].Equals("Scania")){
					carModelSel = 1;
				}
				vehtypeModel = camionModels[0,carSel];
				vehtypeKind = camionModels[carModel,carModelSel];
			}
			if (vehtypeT.Equals("Furgoneta")){
				carSel = ranNumbr(0,1);
                carModel = ranNumbr(1,2);
			    if (furgonetaModels[0,carSel].Equals("Mercedes-Benz")){
				    carModelSel = 0;
			    }
			    if (furgonetaModels[0,carSel].Equals("Fiat")){
					carModelSel = 1;
				}
				vehtypeModel = furgonetaModels[0,carSel];
				vehtypeKind = furgonetaModels[carModel,carModelSel];
			}
			takeScreenShot("E:\\Selenium\\","vehiculeCreatePage_",timet);
			takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","vehiculeCreatePage","");
			
		}
		public static void vehicleFieldsfill(string Matricul, string vehtypeM, string vehtypeK, string ColorT)
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_text_plate_number")).SendKeys(Matricul);
            driver.FindElement(By.Id("ctl00_ContentZone_text_make")).SendKeys(vehtypeM);
            driver.FindElement(By.Id("ctl00_ContentZone_text_model")).SendKeys(vehtypeK);
            driver.FindElement(By.Id("ctl00_ContentZone_text_colour")).SendKeys(ColorT);
        }

        public static void tagAssignment()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_BtnTags")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_chk_0")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_btn_tag_assignment")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_btn_tag_assignment")).Click();
			if (ranNumbr(0,1)>0){
                driver.FindElement(By.Id("ctl00_ContentZone_radio_dist_how_0")).Click();
            }
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_txt_pan_tag")).SendKeys(ranNumbr(1,99999)+"");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_btn_init_tag")).Click();
            System.Threading.Thread.Sleep(500);
            confirmationMessage = driver.FindElement(By.Id("ctl00_ContentZone_lbl_information")).Text;
			if (confirmationMessage.Contains("ya tiene un tag asignado") || confirmationMessage.Contains("Este tag no está operativo") || confirmationMessage.Contains("Este tag ya está asignado al vehículo") || confirmationMessage.Contains("Luhn incorrecto")){
                errorTagAssignment = true;
                takeScreenShot("E:\\Selenium\\","tagAssignmentPageErr",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","tagAssignmentPageErr","");
            }else{
                tagIdNmbr = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_m_table_vehicles']/tbody/tr[2]/td[6]")).Text;
                takeScreenShot("E:\\Selenium\\","tagAssignmentPage_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionCuentas_CrearCuenta\\attachments\\","tagAssignmentPage","");
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
