using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace CoviHonduras
{
    [TestClass]
    public class CAC_accountCreationWithVehicle : Settingsfields_File
    {
        [TestInitialize]
        public void setUp() 
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();        
        }

        [TestMethod]
        public void accountCreationWithVehicleInit()
        {
            CAC_accountCreationOnly.accountCreation();
            System.Threading.Thread.Sleep(1000);
            elementClick("ctl00_ButtonsZone_BtnValidate_IB_Label");// Guardar Cuenta con el botón
            System.Threading.Thread.Sleep(2000);
            accountCreationWithVehicle();
            Console.WriteLine("Se ha creado la cuenta: " + accountNumbr.Substring(7, 16) + " correctamente y con el vehículo creado con la matricula: " + matriNu);
            Console.WriteLine("Se ha probado en la versión del CAC BO: " + BOVersion.Substring(1, 16) + " y CAC Manager: " + BOVersion.Substring(17));

        }

        public static void accountCreationWithVehicle()
        {
            elementClick("ctl00_ContentZone_BtnVehicles");
            System.Threading.Thread.Sleep(2000);
            takeScreenShot("E:\\Selenium\\","vehiclePage",timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationVehicle\\attachments\\","vehiclePage","");
            elementClick("ctl00_ContentZone_BtnCreate");
            System.Threading.Thread.Sleep(3000);
		    int matNum = ranNumbr(5000,9999);
		    int matlet = ranNumbr(1,matletT.Length);           
		    int matlet1 = ranNumbr(1,matletT.Length);            
            int matlet2 = ranNumbr(1,matletT.Length);            
            matriNu = (matNum + matletT.Substring(matlet1, 1) + matletT.Substring(matlet1+1, 1) + matletT.Substring(matlet2+2,1));            
            selectDropDown("ctl00_ContentZone_cmb_vehicle_type");
            System.Threading.Thread.Sleep(1000);
            IWebElement vehtype = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_vehicle_type"))).SelectedOption;
            string vehtypeT = vehtype.Text;
		    if (vehtypeT.Equals("Liviano")){
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
				vehtypeModel = cocheModels[0,carSel];
				vehtypeKind = cocheModels[carModel,carModelSel];	
		    }
		    else{
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

            vehicleFieldsfill(matriNu, vehtypeModel, vehtypeKind, colorS[ranNumbr(0, colorS.Length - 1)]);
            takeScreenShot("E:\\Selenium\\","vehicleDataFilledPage",timet);
            takeScreenShot("E:\\workspace\\Maria_Repository\\accountCreationVehicle\\attachments\\","vehicleDataFilledPage","");
            System.Threading.Thread.Sleep(2000);												
		    driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSubmit_IB_Label")).Click();
            System.Threading.Thread.Sleep(1500);
		    driver.FindElement(By.Id("ctl00_ButtonsZone_BtnBack_IB_Label")).Click();
            System.Threading.Thread.Sleep(1500);
		    driver.FindElement(By.Id("ctl00_ButtonsZone_BtnValidate_IB_Label")).Click();
            System.Threading.Thread.Sleep(2500);
	    }

	    public static void vehicleFieldsfill(string Matricul, string vehtypeM, string vehtypeK, string ColorT)
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_text_plate_number")).SendKeys(Matricul);
            driver.FindElement(By.Id("ctl00_ContentZone_text_make")).SendKeys(vehtypeM);
            driver.FindElement(By.Id("ctl00_ContentZone_text_model")).SendKeys(vehtypeK);
            driver.FindElement(By.Id("ctl00_ContentZone_text_colour")).SendKeys(ColorT);
        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
        
    }		
       
}
