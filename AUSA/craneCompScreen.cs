using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AUSA
{
    public class craneCompScreen : AusaFieldsConfiguration
    {
        private static String comment = "_txt_comments_box_data";

        public static void ibCrane()
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(cranLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_txt_Title_box_data")).SendKeys("Grúa"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(2000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_txt_vehid_box_data")).SendKeys(+ranNumbr(600000000,699999999)+"");
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_txt_dni_box_data")).SendKeys(dniLetra(ranYearNumbr(10000000,40000000)));
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_txt_responsible_box_data")).SendKeys(personsT[ranYearNumbr(0, personsT.Length - 1)]+"");;
            selectDropDownClick("ctl00_ContentZone_ctrlCrane_cmb_plate_moved_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_ctrlCrane_cmb_address_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            ocupantesSection();
            System.Threading.Thread.Sleep(1000);
			Console.WriteLine("El Componente Grúa ha sido creado para la Parte No. "+partText);
    }

    public static void ocupantesSection()
    {	  		
	  		int ocuPant = ranYearNumbr(1,4);
	  		for (int ocu = 1; ocu<= ocuPant; ocu++){
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_BtnAddOccupants")).Click();
                System.Threading.Thread.Sleep(500);
            }
            string ocuPants = driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ContentZone_ctrlCrane_Crane')]")).GetAttribute("id");
	  		int ocuPantNumber = Int32.Parse(ocuPants.Substring(33, 35));
	  		int totalOcupant = ocuPantNumber + ocuPant;	
	  		if (ocuPant == 1){
                int nameGender = ranYearNumbr(0, personsT.Length - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocuPantNumber + nameLast)).SendKeys(personsT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocuPantNumber + DNI)).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocuPantNumber + comment)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);

            }else{
            for (int ocup = ocuPantNumber; ocup < totalOcupant; ocup++)
            {
                int nameGender = ranYearNumbr(0, personsT.Length - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocup + nameLast)).SendKeys(personsT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocup + DNI)).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)));
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlCrane_Crane" + ocup + comment)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);
            }
        }
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Grua",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Grua",timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(3000);
    }

    }
}
