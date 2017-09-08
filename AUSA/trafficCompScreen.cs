using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AUSA
{
    public class trafficCompScreen : AusaFieldsConfiguration
    {
        public static void ibTraffic()
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(traffLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ContentZone_ctrlTraffic_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlTraffic_txt_Title_box_data")).SendKeys("Tiempo"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlTraffic_cmb_traffic_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_ctrlTraffic_cmb_vehicles_hour_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlTraffic_txt_comment_box_data")).SendKeys("This was created by QA Automation Script");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Traffic",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Traffic", timet);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
			Console.WriteLine("El Componente Tráfico ha sido creado para la Parte No. "+partText);
    }
}
}
