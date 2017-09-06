using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUSA
{
    [TestClass]
    public class ausaModificarPartes : AusaFieldsConfiguration
    {

        // 'ausaModificarPartes.mPartes' oculta el miembro heredado 'ausaFieldsConfiguration.mPartes'. Use la palabra clave new si su intención era ocultarlo.
        public static new string mPartes;
        // 'ausaModificarPartes.mPartes' oculta el miembro heredado 'ausaFieldsConfiguration.mPartes'. Use la palabra clave new si su intención era ocultarlo.
        public static int i;
        public static int xll;
        public static int selComp;
        public static string compT;


    [TestInitialize]
        public void setUp()
        {

            driver = new ChromeDriver("C:\\Selenium");
            driver.Manage().Window.Maximize();

        }
     
    [TestMethod]
        public void ausaIssuesUpdate()
        {
            try
            {
                Actions action = new Actions(driver);
                driver.Navigate().GoToUrl(baseUrl);
                if (driver.PageSource.Contains("No se puede acceder a este sitio web") || driver.PageSource.Contains("Service Unavailable"))
                {
                    Console.WriteLine("ITS NO ESTA DISPONIBLE");
                    return;
                }
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("ausaLoginPage.jpeg");
                driver.FindElement(By.Id("BoxLogin")).SendKeys("calidad");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("calidad");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("AusamP.jpeg");
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;
                System.Threading.Thread.Sleep(1000);
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(2000);
                string mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();
                System.Threading.Thread.Sleep(8000);
                takeScreenShot("AusapP.jpeg");

                if (lPartes.Equals("Issues"))
                {
                    Types = "All";
                }
                else
                {
                    Types = "Todos";
                }
                string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
                var newTab = driver.SwitchTo().Window(newHandle);
                var tabExpected = "#Parte";
                Assert.AreEqual(tabExpected, newTab.Title);
                System.Threading.Thread.Sleep(3000);
                elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
                System.Threading.Thread.Sleep(6000);
                if (isElementPresent(By.Id("tableIssues")))
                {

                    IWebElement table = driver.FindElement(By.CssSelector("tbody tr td table#tableIssues.generalTable"));
                    IList<IWebElement> tableCount = table.FindElements(By.TagName("tr"));
                    if (tableCount.Count == 1)
                    {
                        Console.WriteLine("Ningún parte encontrado para los criterios de selección introducidos");
                        return;
                    }
                    else
                    {
                        BuscarElement();
                    }
                }
                else
                {
                    Console.WriteLine("No hubo Elementos Encontrados");
                    return;
                }

            }
            catch (Exception e)
            {
                //e.getCause();
                Console.WriteLine(e.StackTrace);
                //Exception a = new Exception ("No Such Element Found");
                return;
            }
        }
        
        public static void BuscarElement()
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement table = driver.FindElement(By.CssSelector("tbody tr td table#tableIssues.generalTable"));
            IList<IWebElement> tableCount = table.FindElements(By.TagName("tr"));
            do
            {
                Random xl = new Random();
                for (i = 1; i < tableCount.Count; i++)
                {
                    xll = xl.Next(i) + 1;
                    if (xll > i)
                    {
                        xll = xll - 1;
                    }
                }
                String buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr" + "[" + xll + "]")).GetAttribute("id");
                String editClick = buscar1.Substring(5);
                driver.FindElement(By.Id("edit" + editClick)).Click();
                System.Threading.Thread.Sleep(5000);
            } while (i < tableCount.Count);
            System.Threading.Thread.Sleep(2000);
            updatePartes();
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(1000);
        }
        

        public static void updatePartes()
        {
            System.Threading.Thread.Sleep(2000);
            string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
            var newTab = driver.SwitchTo().Window(newHandle);
            var tabExpected = "#Parte";
            Assert.AreEqual(tabExpected, newTab.Title);
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_cmb_parent_cmb_dropdown");
            selectDropDownClick("ctl00_ContentZone_cmb_status_cmb_dropdown");
            System.Threading.Thread.Sleep(400);
            IWebElement statusSel = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_status_cmb_dropdown"))).SelectedOption;
            String statusSelT = statusSel.Text;
            if (statusSelT.Equals("Abierto") || statusSelT.Equals("Re-Abierto"))
            {
                selectDropDownClick("ctl00_ContentZone_cmb_template_cmb_dropdown");
                System.Threading.Thread.Sleep(500);
            }
            if (driver.FindElements(By.Id("popup_ok")).Count != 0)
            {
                driver.FindElement(By.Id("popup_ok")).Click();
                System.Threading.Thread.Sleep(100);
            }
            tipoSel = driver.FindElement(By.Id("ctl00_ContentZone_txt_type_box_data")).GetAttribute("value");
            selectDropDownClick(prioritySel);
            //Filling out all data
            selectDropDownClick(gravedadT);//Gravedad
            selectDropDownClick(asignadoT);//Asignado            
            if (driver.FindElements(By.Id(supervisorT)).Count != 0)
            {
                selectDropDownClick(supervisorT);//Supervisor            	
            }
            System.Threading.Thread.Sleep(3000);
            selectDropDownClick(tValoresT);//Tramo Lista Valores
            System.Threading.Thread.Sleep(2000);
            notEmptyDropDown(direcT);
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).SendKeys(ranNumbr(10, 900) + "");
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).SendKeys(ranNumbr(1, 900) + "");
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown(ramalsT);
            driver.FindElement(By.Id(locationT)).Clear();
            driver.FindElement(By.Id(locationT)).SendKeys("Modified Argentina");
            driver.FindElement(By.Id(observaT)).SendKeys("     ___QA issue Modifyed by Automation Script");
            System.Threading.Thread.Sleep(500);
            DatosSection();
            System.Threading.Thread.Sleep(1000);
            ranclickOption(dOption, 1, dOption.Length);
            System.Threading.Thread.Sleep(3000);
            if (driver.FindElement(By.Id(dOption[4])).Selected)
            {
                driver.FindElement(By.Id(vVolcado)).Clear();
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
                        driver.FindElement(By.Id(vOptionT[i])).Clear();
                        driver.FindElement(By.Id(vOptionT[i])).SendKeys(ranNumbr(1, 99) + ""); ;
                    }
                }
            }
            System.Threading.Thread.Sleep(500);
            infoComponents();
        }

        public static void DatosSection()
        {
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id(datoBtn)).Click();
            System.Threading.Thread.Sleep(1000);
            if (tipoSel.Equals("Incidente") || tipoSel.Equals("Accidente"))
            {
                if (driver.FindElements(By.Id(typeAccidentes)).Count != 0)
                {
                    driver.FindElement(By.Id(typeAccidentes)).Click();
                    ranSelection("ctl00_ContentZone_mc_typeOfAccident_ctl", "ctl00_ContentZone_mc_typeOfAccident_ctl".Length);
                    ranClick("ctl00_ContentZone_mc_typeOfAccident_ctl", "0", ad, caMer);
                    System.Threading.Thread.Sleep(400);
                }
                if (driver.FindElements(By.Id(typeImpacto)).Count != 0)
                {
                    driver.FindElement(By.Id(typeImpacto)).Click();
                    ranSelection("ctl00_ContentZone_mc_causal_ctl", "ctl00_ContentZone_mc_causal_ctl".Length);
                    ranClick("ctl00_ContentZone_mc_causal_ctl", "0", ad, caMer);
                    System.Threading.Thread.Sleep(500);
                }

            }
            driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).SendKeys("This was modified by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).SendKeys("This was modified by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).SendKeys("This was modified by automation scrript for Test Purpose");
            driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).SendKeys("This was modified by automation scrript for Test Purpose");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id(cameraSel)).Click();
            System.Threading.Thread.Sleep(1000);
            ranSelection("ctl00_ContentZone_mcCameras_ctl", "ctl00_ContentZone_mcCameras_ctl".Length);
            ranClick("ctl00_ContentZone_mcCameras_ctl", "0", ad, caMer);
            System.Threading.Thread.Sleep(2000);
        }

        
        public static void infoComponents()
        {
            System.Threading.Thread.Sleep(3000);
            IList<IWebElement> infoComp = driver.FindElements(By.XPath("//span[contains(@id,'ctl00_ContentZone_BtnAdd')]"));
            for (int i = 1; i <= infoComp.Count; i++)
            {
                selComp = ranNumbr(1, infoComp.Count);
            }
            compT = driver.FindElement(By.XPath("//div" + "[" + selComp + "]/a/div/span[contains(@id,'ctl00_ContentZone_BtnAdd')]")).GetAttribute("class");
            //compT = "IB_weather";
    /*        switch (compT)
            {
                case "IB_comunication":
                    System.Threading.Thread.Sleep(1000);
// El tipo o el nombre del espacio de nombres 'communicationCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.communicationCompScreen.ibCommunication();
// El tipo o el nombre del espacio de nombres 'communicationCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_vehicle":
                    System.Threading.Thread.Sleep(1000);
// El tipo o el nombre del espacio de nombres 'vehicleCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.vehicleCompScreen.ibVehicle();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'vehicleCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_person":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'personCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.personCompScreen.ibPerson();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'personCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_patrol":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'patrolCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.patrolCompScreen.ibPatrol();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'patrolCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_security":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'securityCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.securityCompScreen.ibSecurity();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'securityCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_ambulance":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'ambulanceCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.ambulanceCompScreen.ibAmbulance();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'ambulanceCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_crane":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'craneCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.craneCompScreen.ibCrane();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'craneCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_weather":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'weatherCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.weatherCompScreen.ibWeather();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'weatherCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_trafic":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'trafficCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.trafficCompScreen.ibTraffic();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'trafficCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_roadway":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'calzadaCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.calzadaCompScreen.ibCalzada();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'calzadaCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_insideInformation":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'infoCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.infoCompScreen.ibInformation();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'infoCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                case "IB_inconvenientShedule":
                    System.Threading.Thread.Sleep(1000);
#pragma warning disable CS0234 // El tipo o el nombre del espacio de nombres 'inconCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    AUSA.inconCompScreen.ibInconveniente();
#pragma warning restore CS0234 // El tipo o el nombre del espacio de nombres 'inconCompScreen' no existe en el espacio de nombres 'AUSA' (¿falta alguna referencia de ensamblado?)
                    break;
                default:
                    Console.WriteLine(compT + " No está implementado");
                    break;
            }
            */

        }


        private static Boolean isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();

                return true;
            }
#pragma warning disable CS0168 // La variable 'e' se ha declarado pero nunca se usa
            catch (NoAlertPresentException e)
#pragma warning restore CS0168 // La variable 'e' se ha declarado pero nunca se usa
            {
                return false;
            }
        }




    [TestCleanup]
        public static void tearDown()
        {
            driver.Quit();
        }
    }
}