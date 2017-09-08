using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AUSA
{
    public class vehicleCompScreen : AusaFieldsConfiguration
    {
        private static string located = "_cmb_city_cmb_dropdown";
        private static string gender = "_cmb_gender_cmb_dropdown";
        private static string age = "_txt_age_box_data";
        private static string status = "_cmb_status_cmb_dropdown";         
        private static string DNI = "_txt_nif_box_data";        
        private static string description = "_txt_description_box_data";


        public static void ibVehicle()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(vehLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_Title_box_data")).SendKeys("Vehicle" + " - " + ranNumbr(1, 99) + " QA");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_type_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_year_box_data")).SendKeys(+ranNumbr(2000, 2017) + "");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_brake_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_covers_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_mc_part_damage_img_expand")).Click();
            ranSelection("ctl00_ContentZone_ctrlVehicle_mc_part_damage_ctl", 48);
            ranClick("ctl00_ContentZone_ctrlVehicle_mc_part_damage_ctl", "0", ad, caMer);
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_maker_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_plate_box_data")).SendKeys(ranNumbr(1, 900000000) + "");
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_direction_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_headlights_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_model_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_status_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_referredTo_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_isurance_policy_box_data")).SendKeys("Mafre");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_company_cmb_dropdown");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_isurance_cover_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_dt_isurance_expiry_box_date")).SendKeys(dateSel(new DateTime(2007, 1, 1), new DateTime(2008, 12, 31)).ToString("dd/MM/yyyy"));
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_check_towedUnit")).Click();
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_coupled_type_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_coupled_company_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_dt_coupled_expiry_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2019, 12, 31)).ToString("dd/MM/yyyy"));
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_mc_coupled_pd_img_expand")).Click();
            ranSelection("ctl00_ContentZone_ctrlVehicle_mc_coupled_pd_ctl", 47);
            ranClick("ctl00_ContentZone_ctrlVehicle_mc_coupled_pd_ctl", "0", ad, caMer);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_coupled_chassis_box_data")).SendKeys("HOME");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_coupled_policy_box_data")).SendKeys(ranYearNumbr(100000, 800000) + "");
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_coupled_cover_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_check_material")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_no_picto_box_data")).SendKeys(ranYearNumbr(10000, 900000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_check_orangePlate")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_top_number_box_data")).SendKeys(ranYearNumbr(1000, 40000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_buttom_number_box_data")).SendKeys(ranYearNumbr(1000, 40000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_check_spilled")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_injured_tras_owmeans_box_data")).SendKeys(ranYearNumbr(10, 999) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_injured_tras_helicopter_box_data")).SendKeys(ranYearNumbr(10, 999) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_injured_tras_ambulance_box_data")).SendKeys(ranYearNumbr(10, 999) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_deceased_box_data")).SendKeys(ranYearNumbr(10, 999) + "");
            int nameGender = ranYearNumbr(0, personsT.Length - 1);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_driver_name_box_data")).SendKeys(personsT[nameGender]);
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_driver_city_cmb_dropdown");           
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_driver_licenseid_box_data")).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
            selectDropDownClick("ctl00_ContentZone_ctrlVehicle_cmb_relationship_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_driver_address_box_data")).SendKeys("HOMETOWN");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_driver_dni_box_data")).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_txt_driver_phone_box_data")).SendKeys(ranYearNumbr(910000000, 980000000) + "");
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_apparent_status_cmb_dropdown");
            new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_cmb_driver_gender_cmb_dropdown"))).SelectByIndex(genderT[nameGender]);
            selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_cmb_driver_gender_cmb_dropdown");
            System.Threading.Thread.Sleep(500); 
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_dt_driver_birthdate_box_date")).SendKeys(dateSel(new DateTime(1970, 1, 1), new DateTime(1980, 12, 31)).ToString("dd/MM/yyyy"));
            System.Threading.Thread.Sleep(1000);
            ocupantesSection();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("El Componente Vehiculo ha sido creado para la Parte No. " + partText);

        }
        public static void ocupantesSection()
        {

            int ocuPant = ranYearNumbr(1, 4);
	        for (int ocu = 1; ocu<= ocuPant; ocu++){
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_BtnAddOccupants")).Click();
                System.Threading.Thread.Sleep(500);
	  		}
            string ocuPants = driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ContentZone_ctrlVehicle_Vehicle')]")).GetAttribute("id");
            int ocuPantNumber = Int32.Parse(ocuPants.Substring(37, 39));
            int totalOcupant = ocuPantNumber + ocuPant;	
	  		if (ocuPant == 1){
	  			int nameGender = ranYearNumbr(0, personsT.Length - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+nameLast)).SendKeys(personsT[nameGender]);
                selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+located);
                new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+gender))).SelectByIndex(genderT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+age)).SendKeys(ranYearNumbr(30,45)+"");
                selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+status);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+home)).SendKeys("ESPAÑA");
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+DNI)).SendKeys(dniLetra(ranYearNumbr(10000000,40000000)));
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+phone)).SendKeys(ranYearNumbr(900000000,980000000)+"");
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocuPantNumber+description)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);
	  		}else{
	  		    for (int ocup = ocuPantNumber; ocup<totalOcupant; ocup++){
	  			int nameGender = ranYearNumbr(0, personsT.Length - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+nameLast)).SendKeys(personsT[nameGender]);
                selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+located);
                new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+gender))).SelectByIndex(genderT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+age)).SendKeys(ranYearNumbr(30,45)+"");
                selectDropDownClick2("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+status);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+home)).SendKeys("ESPAÑA");
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+DNI)).SendKeys(dniLetra(ranYearNumbr(10000000,40000000)));
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+phone)).SendKeys(ranYearNumbr(900000000,980000000)+"");
	  			driver.FindElement(By.Id("ctl00_ContentZone_ctrlVehicle_Vehicle"+ocup+description)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);
	  			}
	  		}
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","VehicleComp_",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","VehicleComp_",timet);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ContentZone_BtnPnlConfirm")).Click();
            System.Threading.Thread.Sleep(3000);
        }
    }
}
