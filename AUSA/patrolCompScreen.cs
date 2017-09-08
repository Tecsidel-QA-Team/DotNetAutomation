using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace AUSA
{
    public class patrolCompScreen : AusaFieldsConfiguration
    {
        private static String comment = "_txt_comments_box_data";

        public static void ibPatrol()
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(patroLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_Title_box_data")).SendKeys("Seguridad Vial"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(2000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_vehid_box_data")).SendKeys(+ranNumbr(600000000,699999999)+"");
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_legajo_box_data")).SendKeys(+ranNumbr(10000,90000000)+"");						
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_phone_box_data")).SendKeys(ranYearNumbr(910000000,980000000)+"");
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_responsible_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_responsible_box_data")).SendKeys(personsT[ranYearNumbr(0, personsT.Length - 1)]+"");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_txt_driver_box_data")).SendKeys(personsT[ranYearNumbr(0, personsT.Length - 1)]+"");
            ocupantesSection();
            System.Threading.Thread.Sleep(1000);
			Console.WriteLine("El Componente Patrulla ha sido creado para la Parte No. "+partText);

    }
    public static void ocupantesSection()
    {	  		
	  		int ocuPant = ranYearNumbr(1,4);
	  		for (int ocu = 1; ocu<= ocuPant; ocu++){
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_BtnAddOccupants")).Click();
                System.Threading.Thread.Sleep(500);
            }
            string ocuPants = driver.FindElement(By.XPath("//*[contains(@id,'ctl00_ContentZone_ctrlPatrol_Patrol')]")).GetAttribute("id");
	  		int ocuPantNumber = Int32.Parse(ocuPants.Substring(35, 37));
	  		int totalOcupant = ocuPantNumber + ocuPant;	
	  		if (ocuPant == 1){
                int nameGender = ranYearNumbr(0, personsT.Length - 1);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_Patrol" + ocuPantNumber + nameLast)).SendKeys(personsT[nameGender]);
                driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_Patrol" + ocuPantNumber + comment)).SendKeys("QA TESTER TECSIDEL");
                System.Threading.Thread.Sleep(2500);
            }else{
                for (int ocup = ocuPantNumber; ocup < totalOcupant; ocup++)
                {
                    int nameGender = ranYearNumbr(0, personsT.Length - 1);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_Patrol" + ocup + nameLast)).SendKeys(personsT[nameGender]);
                    driver.FindElement(By.Id("ctl00_ContentZone_ctrlPatrol_Patrol" + ocup + comment)).SendKeys("QA TESTER TECSIDEL");
                    System.Threading.Thread.Sleep(2500);
                }
            }
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Patrol",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Patrol",timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(3000);
        }
    }
}
