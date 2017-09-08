using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AUSA
{
    public class personCompScreen : AusaFieldsConfiguration
    {
        public static void ibPerson()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(perLabel)).Click();
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_Title_box_data")).SendKeys("Damnificado" + " - " + ranNumbr(1, 99) + " QA");
            System.Threading.Thread.Sleep(500);
            int nameGender = ranYearNumbr(0, personsT.Length - 1);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_name_box_data")).SendKeys(personsT[nameGender]);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_address_box_data")).SendKeys("ESPAÑA");
            selectDropDownClick("ctl00_ContentZone_ctrlPerson_cmb_city_cmb_dropdown");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_phone_box_data")).SendKeys(ranYearNumbr(910000000, 980000000) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_dni_box_data")).SendKeys(dniLetra(ranYearNumbr(10000000, 40000000)) + "");
            new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_cmb_gender_cmb_dropdown"))).SelectByIndex(genderT[nameGender]);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_age_box_data")).SendKeys(ranNumbr(35, 50) + "");
            selectDropDownClick("ctl00_ContentZone_ctrlPerson_cmb_status_cmb_dropdown");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlPerson_txt_comment_box_data")).SendKeys("Component Created by QA Automation Script");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\", "personComp",  timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaModificaPartes\\attachments\\", "personComp",  timet);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("El Componente Danmificado ha sido creado para la Parte No. " + partText);

        }
    }
}
