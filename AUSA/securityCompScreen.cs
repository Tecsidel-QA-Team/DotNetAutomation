using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AUSA
{
    public class securityCompScreen : AusaFieldsConfiguration
    {
        private static String comment = "_txt_comments_box_data";

        public static void ibSecurity() 
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(securLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_Title_box_data")).SendKeys("Seguridad Vial"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(2000);
            selectDropDownClick("ctl00_ContentZone_ctrlSecurity_cmb_type_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_responsible_box_data")).SendKeys(personsT[ranYearNumbr(0, personsT.Length - 1)]+"");;
            selectDropDownClick("ctl00_ContentZone_ctrlSecurity_cmb_mean_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_legajo_box_data")).SendKeys(+ranNumbr(10000,90000000)+"");
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_vehid_box_data")).SendKeys(+ranNumbr(600000000,699999999)+"");					
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_txt_phone_box_data")).SendKeys(ranYearNumbr(910000000,980000000)+"");			
            ocupantesSection();
            System.Threading.Thread.Sleep(1000);
			Console.WriteLine("El Componente Seguridad ha sido creado para la Parte No. "+partText);
    }
    public static void ocupantesSection()
    {	  		
	  		int ocuPant = ranYearNumbr(1,4);
	  		for (int ocu = 1; ocu<= ocuPant; ocu++){
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_BtnAddOccupants")).Click();
                System.Threading.Thread.Sleep(500);
            }

            string ocuPants = driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ContentZone_ctrlSecurity_Security')]")).GetAttribute("id");
	  		int ocuPantNumber = Int32.Parse(ocuPants.Substring(39, 41));
	  		int totalOcupant = ocuPantNumber + ocuPant;	
	  		if (ocuPant == 1){
            int nameGender = ranYearNumbr(0, personsT.Length - 1);
                selectDropDownClick("ctl00_ContentZone_ctrlSecurity_Security" + ocuPantNumber + typeT);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocuPantNumber + nameLast)).SendKeys(personsT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocuPantNumber + DNI)).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocuPantNumber + comment)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);

        }else{
            for (int ocup = ocuPantNumber; ocup < totalOcupant; ocup++)
            {
                    int nameGender = ranYearNumbr(0, personsT.Length - 1);
                    selectDropDownClick("ctl00_ContentZone_ctrlSecurity_Security" + ocup + typeT);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocup + nameLast)).SendKeys(personsT[nameGender]);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocup + DNI)).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlSecurity_Security" + ocup + comment)).SendKeys("QA TESTER TECSIDEL");
                    System.Threading.Thread.Sleep(2500);
            }
        }
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Security",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Security",timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(3000);
    }

}
    
}
