using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AUSA
{
    public class weatherCompScreen : AusaFieldsConfiguration
    {
        public static void ibWeather()
        {
            System.Threading.Thread.Sleep(1000);
		    driver.FindElement(By.Id(weaLabel)).Click();
            System.Threading.Thread.Sleep(1000);
		    driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
        	if (driver.PageSource.Contains("Únicamente está permitido añadir un componente de tipo 'Tiempo' por parte.")){
        	    driver.FindElement(By.Id("ctl00_ButtonsZone_BtnClose_IB_Label")).Click();
                Console.WriteLine("No se puede crear Componente Weather, ya que existe otro para esta Parte");
        		return;
        		
        	}
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlWeather_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlWeather_txt_Title_box_data")).SendKeys("Tiempo"+" - "+ranNumbr(1,99)+" QA" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlWeather_cmb_weather_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_ctrlWeather_cmb_lighting_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_ctrlWeather_cmb_visibility_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlWeather_txt_comment_box_data")).SendKeys("This was created by QA Automation Script");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\","Clima",timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\","Clima",timet);
            System.Threading.Thread.Sleep(1000);
			driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
			Console.WriteLine("El Componente Clima ha sido creado para la Parte No. "+partText);
}
 
    }
}
