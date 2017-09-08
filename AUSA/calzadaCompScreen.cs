using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AUSA
{
    public class calzadaCompScreen : AusaFieldsConfiguration
    {
        public static void ibCalzada()
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(roadLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);        
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_txt_Title_box_data")).SendKeys("Calzada"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlRoadway_cmb_status_cmb_dropdown");
            System.Threading.Thread.Sleep(100);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_mc_roadCleaning_img_expand")).Click();
            ranSelection("ctl00_ContentZone_ctrlRoadway_mc_roadCleaning_ctl",51);
            ranClick("ctl00_ContentZone_ctrlRoadway_mc_roadCleaning_ctl","0", ad, caMer);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_txt_road_free_box_data")).SendKeys(ranNumbr(1,9)+"");
	        driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_txt_numRoadClose_box_data")).SendKeys(ranNumbr(1,20)+"");
	        driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_mc_highwayDamage_img_expand")).Click();
            System.Threading.Thread.Sleep(100);	        
            ranSelection("ctl00_ContentZone_ctrlRoadway_mc_highwayDamage_ctl",52);
            ranClick("ctl00_ContentZone_ctrlRoadway_mc_highwayDamage_ctl","0", ad, caMer);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlRoadway_txt_comment_box_data")).SendKeys("This was created by QA Automation Script");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Calzada",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Calzada",timet);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
			Console.WriteLine("El Componente Calzada ha sido creado para la Parte No. "+partText);
    }

}
    class infoCompScreen : AusaFieldsConfiguration
{

        public static void ibInformation() 
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(infoLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInsideInformation_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInsideInformation_txt_Title_box_data")).SendKeys("Información Interna"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInsideInformation_txt_comment_box_data")).SendKeys("This was created by QA Automation Script");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Information",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Information",timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("El Componente Información ha sido creado para la Parte No. "+partText);
        }

    }

    class inconCompScreen : AusaFieldsConfiguration
    {

        public static void ibInconveniente()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(inconLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_txt_Title_box_data")).SendKeys("Información Interna"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_check_has_congestion")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_check_has_rushHour")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_check_has_laneCut")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_checkWorks")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_txt_works_area_box_data")).SendKeys("This was created by QA Automation Script");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_txt_not_determined_box_data")).SendKeys("This was created by QA Automation Script");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_CheckComment")).Click();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlInconvenientShedule_txt_comment_box_data")).SendKeys("This was created by QA Automation Script");;
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Inconveniente",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Inconveniente",timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("El Componente Inconveniente ha sido creado para la Parte No. "+partText);


}
	
}
    }

