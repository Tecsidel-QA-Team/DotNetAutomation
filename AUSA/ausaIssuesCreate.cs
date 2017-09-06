using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace AUSA  
{
    
    [TestClass]
    public class AusaIssuesCreate : AusaFieldsConfiguration
    {
        public static string beginDate;

        [TestInitialize]
        public void seTup()
        {
            driver = new ChromeDriver("C:\\Selenium");            
            driver.Manage().Window.Maximize();
        }       
        [TestMethod]
        public void ausaCreatePartes()
        {
            try
            {
                Actions action = new Actions(driver);
                if (driver.PageSource.Contains("No se puede acceder a este sitio web"))
                {                    
                    Console.WriteLine("ITS NO ESTA DISPONIBLE");
                    return;
                }
                
                driver.Navigate().GoToUrl(baseUrl);
                driver.FindElement(By.Id("BoxLogin")).SendKeys("00001");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("00001");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;                
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(1000);
                mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();                
                System.Threading.Thread.Sleep(4000);
                string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
                var newTab = driver.SwitchTo().Window(newHandle);
                var tabExpected = mPartes;
                Assert.AreEqual(tabExpected, newTab.Title);    // termina logica para enfocarse en otrotab            
                System.Threading.Thread.Sleep(3000);
                driver.FindElement(By.Id("ctl00_ContentZone_BtnCreate")).Click();
                System.Threading.Thread.Sleep(3000);
                selectDropDownClick("ctl00_ContentZone_cmb_template_cmb_dropdown");
                driver.FindElement(By.Id("ctl00_ContentZone_BtnConfirmTemplate")).Click();
                System.Threading.Thread.Sleep(4000);
                createPartes();
                System.Threading.Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void createPartes()
        {
            System.Threading.Thread.Sleep(1000);
            string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
            var newTab = driver.SwitchTo().Window(newHandle);
            var tabExpected = "#Parte";
            Assert.AreEqual(tabExpected, newTab.Title);
            selectDropDownClick("ctl00_ContentZone_cmb_priority_cmb_dropdown");
            System.Threading.Thread.Sleep(4000);
            tipoSel = driver.FindElement(By.Id("ctl00_ContentZone_txt_type_box_data")).GetAttribute("value");
            //Filling out all data
            selectDropDownClick("ctl00_ContentZone_cmb_severity_cmb_dropdown");//Gravedad
                selectDropDownClick("ctl00_ContentZone_cmb_assigned_cmb_dropdown");//Asignado
            if (driver.FindElements(By.Id(supervisorT)).Count!= 0)
            {
                selectDropDownClick(supervisorT);//Supervisor            	
            }           
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick(tValoresT);
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown(direcT);
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).SendKeys(ranNumbr(10, 900) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).SendKeys(ranNumbr(1, 900) + "");
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown(ramalsT);
            driver.FindElement(By.Id(locationT)).SendKeys("Buenos Aires");
            driver.FindElement(By.Id(observaT)).SendKeys("QA issue created by Automation Script");
            System.Threading.Thread.Sleep(2000);
            datosSection();
            System.Threading.Thread.Sleep(1000);
            ranclickOption(dOption, 1, dOption.Length);
            System.Threading.Thread.Sleep(3000);
            if (driver.FindElement(By.Id(dOption[4])).Selected)
            {
                driver.FindElement(By.Id(vVolcado)).SendKeys(ranNumbr(1, 99) + "");
            }
            System.Threading.Thread.Sleep(2000);
            if (tipoSel.Equals("Incidente") || tipoSel.Equals("Accidente"))
            {
                ranclickOption(vOption, 1, vOption.Length);
                for (int i = 1; i < vOption.Length; i++)
                {
                    if (driver.FindElement(By.Id(vOption[i])).Selected)
                    {
                        System.Threading.Thread.Sleep(1000);
                        driver.FindElement(By.Id(vOptionT[i])).SendKeys(ranNumbr(1, 99) + ""); ;
                    }
                }
            }
            System.Threading.Thread.Sleep(500);
            if (driver.FindElements(By.Id(communicationField)).Count!=0)
            {
                communicationSection();
            }
            
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id(issueCreateBtn)).Click();
            System.Threading.Thread.Sleep(2500);
        }

      
     
        public static void datosSection()
        {
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id(datoBtn)).Click();
            System.Threading.Thread.Sleep(1000);
            if (tipoSel.Equals("Incidente") || tipoSel.Equals("Accidente"))
            {
                driver.FindElement(By.Id(typeAccidentes)).Click();
                System.Threading.Thread.Sleep(500);
                ranClick("ctl00_ContentZone_mc_typeOfAccident_ctl", 19, 23);
                System.Threading.Thread.Sleep(400);
                driver.FindElement(By.Id(typeImpacto)).Click();
                System.Threading.Thread.Sleep(500);
                ranClick("ctl00_ContentZone_mc_causal_ctl", 19, 23);
                System.Threading.Thread.Sleep(500);
            }
            driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).SendKeys("This was written by automation scrript for Test Purpose");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id(cameraSel)).Click();
            System.Threading.Thread.Sleep(500);
            ranClick("ctl00_ContentZone_mcCameras_ctl", 105, 119);

        }
        public void communicationSection()
        {
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(communicationField)).Clear();
            driver.FindElement(By.Id(communicationField)).SendKeys("Communication"+" - "+ranNumbr(1,99)+" QA Automation" );
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(newCommunication);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(medioField);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(motiveField);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(originDestination);
            System.Threading.Thread.Sleep(2000);
            notEmptyDropDown(originDest);
            System.Threading.Thread.Sleep(500);
            selectDropDownClick(importanceField);
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id(subjectField)).SendKeys("Created by Automation Script");
            driver.FindElement(By.Id(commentField)).SendKeys("This Communication was created by an automation script for testing purpose");
            System.Threading.Thread.Sleep(1000);
        }

        public static void grabarDatosFichero()   {
#pragma warning disable CS1061 // 'IWebElement' no contiene una definición para 'getAttribute' ni se encuentra ningún método de extensión 'getAttribute' que acepte un primer argumento del tipo 'IWebElement' (¿falta alguna directiva using o una referencia de ensamblado?)
            beginDate = driver.FindElement(By.Id("ctl00_ContentZone_dt_opentime_box_date")).GetAttribute("value");
#pragma warning disable CS0103 // El nombre 'tempText1' no existe en el contexto actual
             tempText1 = driver.FindElement(By.Id("ctl00_ContentZone_txt_template_box_data")).GetAttribute("value");
            sevText = SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_severity_cmb_dropdown"))).getFirstSelectedOption();
            sevText1 = sevText.Text;
#pragma warning restore CS0103 // El nombre 'sevText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'sevText' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'priorText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			priorText = new Select(driver.findElement(By.id("ctl00_ContentZone_cmb_priority_cmb_dropdown"))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'priorText' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'priorText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'priorText1' no existe en el contexto actual
            priorText1 = priorText.getText();
#pragma warning restore CS0103 // El nombre 'priorText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'priorText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			typeText = driver.findElement(By.id("ctl00_ContentZone_txt_type_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'assignedText' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
            assignedText = new Select(driver.findElement(By.id(asignadoT))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'assignedText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'assignedText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'assignedText1' no existe en el contexto actual
            assignedText1 = assignedText.getText();
#pragma warning restore CS0103 // El nombre 'assignedText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'assignedText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'locateText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			locateText = driver.findElement(By.id("ctl00_ContentZone_txt_location_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'locateText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'autopistaText' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
            autopistaText = new Select(driver.findElement(By.id(tValoresT))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'autopistaText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'autopistaText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'autopistaText1' no existe en el contexto actual
            autopistaText1 = autopistaText.getText();
#pragma warning restore CS0103 // El nombre 'autopistaText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'autopistaText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'bandaText' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			bandaText = new Select(driver.findElement(By.id(direcT))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'bandaText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'bandaText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'bandaText1' no existe en el contexto actual
        bandaText1 = bandaText.getText();
#pragma warning restore CS0103 // El nombre 'bandaText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'bandaText' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'PkmText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
			PkmText = driver.findElement(By.id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).getAttribute("value");
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'PkmText' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'PkmText1' no existe en el contexto actual
        PkmText1 = driver.findElement(By.id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).getAttribute("value");
#pragma warning restore CS0103 // El nombre 'PkmText1' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'ramalsText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
        ramalsText = new Select(driver.findElement(By.id(ramalsT))).getFirstSelectedOption();
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'ramalsText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'ramalsText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'ramalsText' no existe en el contexto actual
        ramalsText1 = ramalsText.getText();
#pragma warning restore CS0103 // El nombre 'ramalsText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'ramalsText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'observacionesText' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			observacionesText = driver.findElement(By.id("ctl00_ContentZone_txt_comments_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'observacionesText' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElements' ni se encuentra ningún método de extensión 'findElements' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
			if (driver.findElements(By.id(supervisorT)).size()!=0){
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElements' ni se encuentra ningún método de extensión 'findElements' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'supervisorText' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
				supervisorText = new Select(driver.findElement(By.id("ctl00_ContentZone_cmb_assigned_cmb_dropdown"))).getFirstSelectedOption();
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'supervisorText' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'supervisorText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'supervisorText' no existe en el contexto actual
        supervisorText1 = supervisorText.getText();
#pragma warning restore CS0103 // El nombre 'supervisorText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'supervisorText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'supervT' no existe en el contexto actual
				supervT = true;
#pragma warning restore CS0103 // El nombre 'supervT' no existe en el contexto actual
          }
#pragma warning disable CS0103 // El nombre 'Thread' no existe en el contexto actual
    Thread.sleep(1000);	  					
#pragma warning restore CS0103 // El nombre 'Thread' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
			if (typeText.equals("Incidente") || typeText.equals("Accidente")){
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeAcc' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
				typeAcc = driver.findElement(By.id("ctl00_ContentZone_mc_typeOfAccident_txt_selected")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'typeAcc' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeImpact' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
    typeImpact = driver.findElement(By.id("ctl00_ContentZone_mc_causal_txt_selected")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'typeImpact' no existe en el contexto actual

}
#pragma warning disable CS0103 // El nombre 'cAparente' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
cAparente = driver.findElement(By.id("ctl00_ContentZone_txt_causes_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'cAparente' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cAparente' no existe en el contexto actual
						if (cAparente == null){
#pragma warning restore CS0103 // El nombre 'cAparente' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cAparente' no existe en el contexto actual
								cAparente = "";
#pragma warning restore CS0103 // El nombre 'cAparente' no existe en el contexto actual
						}
#pragma warning disable CS0103 // El nombre 'infoComp' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			infoComp = driver.findElement(By.id("ctl00_ContentZone_txt_information_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'infoComp' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'infoComp' no existe en el contexto actual
					if (infoComp == null){
#pragma warning restore CS0103 // El nombre 'infoComp' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'infoComp' no existe en el contexto actual
								infoComp = "";
#pragma warning restore CS0103 // El nombre 'infoComp' no existe en el contexto actual
					}
#pragma warning disable CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
			obserGenerales = driver.findElement(By.id("ctl00_ContentZone_txt_observations_box_data")).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
					if (obserGenerales == null){
#pragma warning restore CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
							obserGenerales = "";
#pragma warning restore CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
					}
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'notaCentro' no existe en el contexto actual
			notaCentro = driver.findElement(By.id("ctl00_ContentZone_txt_note_box_data")).getAttribute("value");
#pragma warning restore CS0103 // El nombre 'notaCentro' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'notaCentro' no existe en el contexto actual
					if (notaCentro == null){
#pragma warning restore CS0103 // El nombre 'notaCentro' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'notaCentro' no existe en el contexto actual
						notaCentro = "";
#pragma warning restore CS0103 // El nombre 'notaCentro' no existe en el contexto actual
					}
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElements' ni se encuentra ningún método de extensión 'findElements' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
					mcCamerasS = driver.findElements(By.xpath("//*[contains(@id, 'ctl00_ContentZone_mcCameras_ctl')]"));
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElements' ni se encuentra ningún método de extensión 'findElements' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'boolean' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
					cameraOpt  = new boolean[mcCamerasS.size()];
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'boolean' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
					cameraSelT = new String[mcCamerasS.size()];
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
					String[] del2 = new String[mcCamerasS.size()];
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
driver.findElement(By.id(cameraSel)).click();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
		            	for (i = 0; i<= mcCamerasS.size()-1;i++){		            		
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
		            		del2[i] = mcCamerasS.get(i).getAttribute("id");
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning disable CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
cameraOpt[i] = driver.findElement(By.xpath("//*[@id="+"'"+del2[i]+"'"+"]")).isSelected();
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning restore CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
		            		if (cameraOpt[i]){
#pragma warning restore CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'camCount' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'camCount' no existe en el contexto actual
		            			camCount = camCount + 1;
#pragma warning restore CS0103 // El nombre 'camCount' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'camCount' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
		            			cameraSelT[i]=driver.findElement(By.xpath("//label[@for="+"'"+del2[i]+"'"+"]")).getText();
#pragma warning restore CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
		            		}
		            	}
#pragma warning disable CS0103 // El nombre 'Thread' no existe en el contexto actual
		            	Thread.sleep(1000);
#pragma warning restore CS0103 // El nombre 'Thread' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
		            	driver.findElement(By.id(cameraSel)).click();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
			for (i = 1; i<dOption.length;i++){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'xpath'
					options[i] = driver.findElement(By.xpath("//label[@for="+"'"+dOption[i]+"'"+"]")).getText();
#pragma warning restore CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'dOptionChecked' no existe en el contexto actual
dOptionChecked[i] = driver.findElement(By.id(dOption[i])).isSelected();
#pragma warning restore CS0103 // El nombre 'dOptionChecked' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
					if (options[i].equals("Vehículos volcados")){	  									  								
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'vVolcadosT' no existe en el contexto actual
						vVolcadosT = "Vehiculos volcados";
#pragma warning restore CS0103 // El nombre 'vVolcadosT' no existe en el contexto actual
					}
				}
			
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
			if (typeText.equals("Incidente") || typeText.equals("Accidente")){
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
				for (int i = 1; i<vOption.length;i++){
#pragma warning restore CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning disable CS0103 // El nombre 'options1' no existe en el contexto actual
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
					options1[i] = driver.findElement(By.xpath("//label[@for="+"'"+vOption[i]+"'"+"]")).getText();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'options1' no existe en el contexto actual
#pragma warning restore CS0117 // 'By' no contiene una definición para 'xpath'
#pragma warning disable CS0103 // El nombre 'vOptionTSel' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
vOptionTSel[i] = driver.findElement(By.id(vOption[i])).isSelected();					
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'vOptionTSel' no existe en el contexto actual
					}
#pragma warning disable CS0103 // El nombre 'comTitle' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
				comTitle = driver.findElement(By.id(communicationField)).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'comTitle' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'newCom' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
newCom = new Select(driver.findElement(By.id(newCommunication))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'newCom' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'newCom' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'newComSel' no existe en el contexto actual
newComSel = newCom.getText();
#pragma warning restore CS0103 // El nombre 'newComSel' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'newCom' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'newComSel' no existe en el contexto actual
				 if (newComSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'newComSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'newComSel' no existe en el contexto actual
					 newComSel = "";
#pragma warning restore CS0103 // El nombre 'newComSel' no existe en el contexto actual
				 }
#pragma warning disable CS0103 // El nombre 'comMean' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
				 comMean = new Select(driver.findElement(By.id(medioField))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'comMean' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMean' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
comMeanSel = comMean.getText();
#pragma warning restore CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'comMean' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
					 if (comMeanSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
						 comMeanSel = "";
#pragma warning restore CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
					 }
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'motiveD' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
					 motiveD = new Select(driver.findElement(By.id(motiveField))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'motiveD' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'motiveSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMean' no existe en el contexto actual
motiveSel = comMean.getText();
#pragma warning restore CS0103 // El nombre 'comMean' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'motiveSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'motiveSel' no existe en el contexto actual
						 if (motiveSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'motiveSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'motiveSel' no existe en el contexto actual
							 motiveSel = "";
#pragma warning restore CS0103 // El nombre 'motiveSel' no existe en el contexto actual
						 } 
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'originC' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
				    originC = new Select(driver.findElement(By.id(originDestination))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'originC' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'originSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originC' no existe en el contexto actual
originSel = originC.getText();
#pragma warning restore CS0103 // El nombre 'originC' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'originSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originSel' no existe en el contexto actual
					 	if (originSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'originSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originSel' no existe en el contexto actual
					 		originSel = "";
#pragma warning restore CS0103 // El nombre 'originSel' no existe en el contexto actual
					 	}
#pragma warning disable CS0103 // El nombre 'originSel' no existe en el contexto actual
					 if (originSel!=null){	
#pragma warning restore CS0103 // El nombre 'originSel' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'originC_DestinaC' no existe en el contexto actual
					 	originC_DestinaC = new Select(driver.findElement(By.id(originDest))).getFirstSelectedOption();
#pragma warning restore CS0103 // El nombre 'originC_DestinaC' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originC_DestinaC' no existe en el contexto actual
originC_DestSel = originC_DestinaC.getText();
#pragma warning restore CS0103 // El nombre 'originC_DestinaC' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
					 		if (originC_DestSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
					 			originC_DestSel = "";
#pragma warning restore CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
					 		}
					 	}else{
#pragma warning disable CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
					 		originC_DestSel = "";
#pragma warning restore CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
					 	}
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'importanceC' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
					 	importanceC = new Select(driver.findElement(By.id(importanceField))).getFirstSelectedOption();
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'importanceC' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'Select' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'importanceSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'importanceC' no existe en el contexto actual
importanceSel = importanceC.getText();
#pragma warning restore CS0103 // El nombre 'importanceC' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'importanceSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'importanceSel' no existe en el contexto actual
					 			if (importanceSel.equals(null)){
#pragma warning restore CS0103 // El nombre 'importanceSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'importanceSel' no existe en el contexto actual
					 				importanceSel = "";
#pragma warning restore CS0103 // El nombre 'importanceSel' no existe en el contexto actual
					 			}
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'matterCom' no existe en el contexto actual
					 	matterCom = driver.findElement(By.id(subjectField)).getAttribute("value");
#pragma warning restore CS0103 // El nombre 'matterCom' no existe en el contexto actual
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS0103 // El nombre 'commentCom' no existe en el contexto actual
#pragma warning disable CS0117 // 'By' no contiene una definición para 'id'
#pragma warning disable CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
commentCom = driver.findElement(By.id(commentField)).getAttribute("value");
#pragma warning restore CS1061 // 'IWebDriver' no contiene una definición para 'findElement' ni se encuentra ningún método de extensión 'findElement' que acepte un primer argumento del tipo 'IWebDriver' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0117 // 'By' no contiene una definición para 'id'
#pragma warning restore CS0103 // El nombre 'commentCom' no existe en el contexto actual
					 	
					}
			
	}
		public static void crearFichero() {
#pragma warning disable CS0103 // El nombre 'errorCreate' no existe en el contexto actual
			if (errorCreate){
#pragma warning restore CS0103 // El nombre 'errorCreate' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'verFile' no existe en el contexto actual
                verFile = "crearPartesResultdosErrFile";
#pragma warning restore CS0103 // El nombre 'verFile' no existe en el contexto actual
            } else{
#pragma warning disable CS0103 // El nombre 'verFile' no existe en el contexto actual
                verFile = "crearPartesResultadosSuccess";
#pragma warning restore CS0103 // El nombre 'verFile' no existe en el contexto actual
        }
#pragma warning disable CS0103 // El nombre 'verFile' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
            File oldFile = new File("C:\\Selenium\\"+verFile+"_OLD.txt");
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'verFile' no existe en el contexto actual
			if (oldFile.exists()){
				oldFile.delete();
			}
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'verFile' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
			File result = new File("C:\\Selenium\\" + verFile + "_NEW.txt");
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'verFile' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
			if (result.exists()){
#pragma warning disable CS0103 // El nombre 'verFile' no existe en el contexto actual
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
				result.renameTo(new File("C:\\Selenium\\"+verFile+"_OLD.txt"));
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'verFile' no existe en el contexto actual
			}			
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'FileOutputStream' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'FileOutputStream' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
			    FileOutputStream fis = new FileOutputStream(new File(result.toString()));
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'FileOutputStream' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'FileOutputStream' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'File' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'StreamWriter' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'StreamWriter' no existe en el contexto actual
                StreamWriter = new StreamWriter(fis);
#pragma warning restore CS0103 // El nombre 'StreamWriter' no existe en el contexto actual
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'StreamWriter' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
#pragma warning disable CS0246 // El nombre del tipo o del espacio de nombres 'StreamWriter' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
                StreamWriter old = Console.SetOut;
#pragma warning restore CS0246 // El nombre del tipo o del espacio de nombres 'StreamWriter' no se encontró (¿falta una directiva using o una referencia de ensamblado?)
			    Console.SetOut(fis);
#pragma warning disable CS0103 // El nombre 'parteNumber' no existe en el contexto actual
			        if (parteNumber!=null){
#pragma warning restore CS0103 // El nombre 'parteNumber' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'parteNumber' no existe en el contexto actual
				        Console.WriteLine("#Parte: "+parteNumber);
#pragma warning restore CS0103 // El nombre 'parteNumber' no existe en el contexto actual
			        }
            Console.WriteLine("Fecha Inicio: "+beginDate);
#pragma warning disable CS0103 // El nombre 'tempText1' no existe en el contexto actual
            Console.WriteLine("Plantilla: "+tempText1);
#pragma warning restore CS0103 // El nombre 'tempText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'sevText1' no existe en el contexto actual
            Console.WriteLine("Gravedad: "+sevText1);
#pragma warning restore CS0103 // El nombre 'sevText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'priorText1' no existe en el contexto actual
            Console.WriteLine("Prioridad: "+priorText1);
#pragma warning restore CS0103 // El nombre 'priorText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
            Console.WriteLine("Tipo: "+typeText);
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'assignedText1' no existe en el contexto actual
            Console.WriteLine("Asignado: "+assignedText1);
#pragma warning restore CS0103 // El nombre 'assignedText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'supervT' no existe en el contexto actual
			if (supervT){
#pragma warning restore CS0103 // El nombre 'supervT' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'supervisorText1' no existe en el contexto actual
                Console.WriteLine("Supervisor: "+supervisorText1);
#pragma warning restore CS0103 // El nombre 'supervisorText1' no existe en el contexto actual
			}
#pragma warning disable CS0103 // El nombre 'autopistaText1' no existe en el contexto actual
            Console.WriteLine("Autopista: "+autopistaText1);
#pragma warning restore CS0103 // El nombre 'autopistaText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'bandaText1' no existe en el contexto actual
            Console.WriteLine("Banda: "+bandaText1);
#pragma warning restore CS0103 // El nombre 'bandaText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'PkmText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'PkmText1' no existe en el contexto actual
            Console.WriteLine("PKM(Km+m): "+PkmText+"+"+PkmText1);
#pragma warning restore CS0103 // El nombre 'PkmText1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'PkmText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'ramalsText1' no existe en el contexto actual
            Console.WriteLine("Ramales: "+ramalsText1);
#pragma warning restore CS0103 // El nombre 'ramalsText1' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'locateText' no existe en el contexto actual
            Console.WriteLine("Localización: "+locateText);
#pragma warning restore CS0103 // El nombre 'locateText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'observacionesText' no existe en el contexto actual
            Console.WriteLine("Observaciones: "+observacionesText);
#pragma warning restore CS0103 // El nombre 'observacionesText' no existe en el contexto actual
            System.Threading.Thread.Sleep(1000);	  					
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
			if (typeText.equals("Incidente") || typeText.equals("Accidente")){
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeAcc' no existe en el contexto actual
                Console.WriteLine("Tipo de Accidentes: "+ typeAcc);
#pragma warning restore CS0103 // El nombre 'typeAcc' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeImpact' no existe en el contexto actual
                Console.WriteLine("Tipo de Impacto: "+typeImpact);
#pragma warning restore CS0103 // El nombre 'typeImpact' no existe en el contexto actual
			}
#pragma warning disable CS0103 // El nombre 'cAparente' no existe en el contexto actual
            Console.WriteLine("Causas Aparentes del Hecho: "+cAparente);
#pragma warning restore CS0103 // El nombre 'cAparente' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'infoComp' no existe en el contexto actual
            Console.WriteLine("Información complementaria: "+infoComp);
#pragma warning restore CS0103 // El nombre 'infoComp' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
            Console.WriteLine("Observaciones Generales: "+obserGenerales);
#pragma warning restore CS0103 // El nombre 'obserGenerales' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'notaCentro' no existe en el contexto actual
            Console.WriteLine("Nota del centro de operaciones: "+notaCentro);
#pragma warning restore CS0103 // El nombre 'notaCentro' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'camCount' no existe en el contexto actual
    			if (camCount > 1){
#pragma warning restore CS0103 // El nombre 'camCount' no existe en el contexto actual
                Console.WriteLine("Camara/s Seleccionada/s: ");
    			}else{
                    Console.WriteLine("Camara Seleccionada: ");
    			}
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
			for (i = 0; i<= mcCamerasS.size()-1;i++){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'mcCamerasS' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
				if (cameraOpt[i]){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'cameraOpt' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'camCount' no existe en el contexto actual
						if (camCount > 1){
#pragma warning restore CS0103 // El nombre 'camCount' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
                            Console.Write(cameraSelT[i]+"; ");
#pragma warning restore CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
						}else{
#pragma warning disable CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
                            Console.Write(cameraSelT[i]);
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'cameraSelT' no existe en el contexto actual
						}
        			}
			}
            Console.WriteLine("");
            Console.WriteLine("");
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
			for (i = 1; i<dOption.length;i++){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'dOptionChecked' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
				if (dOptionChecked[i]){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'dOptionChecked' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
					if (!options[i].equals("Vehículos volcados")){
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
                        Console.Write("x"+options[i]+"    ");
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
					}
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
						if (options[i].equals("Vehículos volcados")){
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'volNumber' no existe en el contexto actual
                            Console.Write("xVehículos volcados"+ ": "+ volNumber);
#pragma warning restore CS0103 // El nombre 'volNumber' no existe en el contexto actual
						}
						}else{
#pragma warning disable CS0103 // El nombre 'i' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options' no existe en el contexto actual
                            Console.Write(options[i]+"    ");
#pragma warning restore CS0103 // El nombre 'options' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'i' no existe en el contexto actual
					}
				}
            Console.WriteLine("");
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'typeText' no existe en el contexto actual
			if (typeText.equals("Incidente") || typeText.equals("Accidente")){
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'typeText' no existe en el contexto actual
#pragma warning disable CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
				for (int i = 1; i<vOption.length;i++){
#pragma warning restore CS1061 // 'string[]' no contiene una definición para 'length' ni se encuentra ningún método de extensión 'length' que acepte un primer argumento del tipo 'string[]' (¿falta alguna directiva using o una referencia de ensamblado?)
#pragma warning disable CS0103 // El nombre 'vOptionTSel' no existe en el contexto actual
					if (vOptionTSel[i]){
#pragma warning restore CS0103 // El nombre 'vOptionTSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'vOptionNumber' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'options1' no existe en el contexto actual
                            Console.Write("x"+options1[i]+": "+vOptionNumber[i]+"    ");  			  							  			  							
#pragma warning restore CS0103 // El nombre 'options1' no existe en el contexto actual
#pragma warning restore CS0103 // El nombre 'vOptionNumber' no existe en el contexto actual
							}else{
#pragma warning disable CS0103 // El nombre 'options1' no existe en el contexto actual
                                Console.Write(options1[i]+"    ");
#pragma warning restore CS0103 // El nombre 'options1' no existe en el contexto actual
						}  			  				
				}
                Console.WriteLine("");
                Console.WriteLine("");
#pragma warning disable CS0103 // El nombre 'comTitle' no existe en el contexto actual
                Console.WriteLine("Titulo de Comunicación: "+comTitle);
#pragma warning restore CS0103 // El nombre 'comTitle' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'newComSel' no existe en el contexto actual
                Console.WriteLine("Tipo de Comunicación: "+newComSel);
#pragma warning restore CS0103 // El nombre 'newComSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
                Console.WriteLine("Medio de Comunicación: "+comMeanSel);
#pragma warning restore CS0103 // El nombre 'comMeanSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'motiveSel' no existe en el contexto actual
                Console.WriteLine("Motivo de Comunicación: "+motiveSel);
#pragma warning restore CS0103 // El nombre 'motiveSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originSel' no existe en el contexto actual
                Console.WriteLine("Tipo Origen Destion: "+originSel);
#pragma warning restore CS0103 // El nombre 'originSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
                Console.WriteLine("Origen/Destino: "+originC_DestSel);
#pragma warning restore CS0103 // El nombre 'originC_DestSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'importanceSel' no existe en el contexto actual
                Console.WriteLine("Importancia: "+importanceSel);
#pragma warning restore CS0103 // El nombre 'importanceSel' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'matterCom' no existe en el contexto actual
                Console.WriteLine("Asunto: "+matterCom);
#pragma warning restore CS0103 // El nombre 'matterCom' no existe en el contexto actual
#pragma warning disable CS0103 // El nombre 'commentCom' no existe en el contexto actual
                Console.WriteLine ("Observaciones: "+commentCom);
#pragma warning restore CS0103 // El nombre 'commentCom' no existe en el contexto actual
					}
			
				fis.close();
				Console.SetOut(old);
	    }
        

[TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}