using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AUSA
{

    [TestClass]
    public class Ausaverpartes : AusaFieldsConfiguration
    {
        public static int i = 0;
        public static int xll = 0;
        public static Boolean inciAcciSel = false;
        public static IWebElement supervisorText; public static string supervisorText1;
        public static Boolean supervT = false;
        public static string assignedText1; public static IWebElement assignedText;
        //private static string partText;
        public static string partPadreText;
        public static IWebElement statusText; public static string statusText1;
        public static string origenText;
        public static string beginDate;
        public static string endDate;
        public static IWebElement tempText; //public static string tempText1;
        //public static IWebElement sevText; public static string sevText1;
        public static string createdByText;
        public static string updatedByText;
        public static IWebElement priorText; public static string priorText1;
        public static string typeText;
        public static IWebElement autopistaText; public static string autopistaText1;
        public static IWebElement bandaText; public static string bandaText1;
        public static string PkmText;
        public static string PkmText1;
        public static IWebElement ramalsText; public static string ramalsText1;
        public static string locateText;
        public static string observacionesText;
        public static IWebElement tipoAccidenteText; public static string tipoAccidenteText1;
        public static IWebElement tipodeImpactoText; public static string tipodeImpactoText1;
        public static string causasText;
        public static string informacionComText;
        public static string observacionesCompText;
        public static string notadelcentroText;
        public static IWebElement camarasText; public static string camarasText1;
        public static Boolean fuegoT = false; public static Boolean banquinaT = false;
        public static Boolean instalacionesT = false; public static Boolean vehiculosV = false;
        public static Boolean motosT = false; public static Boolean automovilesT = false;
        public static Boolean camionesT = false; public static Boolean autobusesT = false;
        public static Boolean chartersT = false;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Selenium");
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Ausapartesview()
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
                takeScreenShot("E:\\Selenium\\", "ausaLoginPagejpeg_", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaVerPartes\\attachments\\", "ausaLoginPagejpeg", "");                
                driver.FindElement(By.Id("BoxLogin")).SendKeys("calidad");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("calidad");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("E:\\Selenium\\", "AusamP_", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaVerPartes\\attachments\\", "AusamP", "");                
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;
                System.Threading.Thread.Sleep(1000);
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(2000);
                string mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();
                System.Threading.Thread.Sleep(8000);
                takeScreenShot("E:\\Selenium\\", "AusapP_", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaVerPartes\\attachments\\", "AusapP", "");
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
                var tabExpected = "Gestión de partes";
                Assert.AreEqual(tabExpected, newTab.Title);
                //Object Partes1 = mPartes;
                //Assert.AreEqual(mPartes, Partes1);
                System.Threading.Thread.Sleep(3000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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

                        BuscarElement1();
                        js.ExecuteScript("window.scrollBy(2100,0)", "");
                        System.Threading.Thread.Sleep(3000);

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
                Console.WriteLine(e.StackTrace);
                return;
            }
        }

        public static void BuscarElement1()
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
                string buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr" + "[" + xll + "]")).GetAttribute("id");
                string viewClick = buscar1.Substring(5);
                driver.FindElement(By.Id("view" + viewClick)).Click();
                System.Threading.Thread.Sleep(5000);
            } while (i < tableCount.Count);
            System.Threading.Thread.Sleep(2000);
            ViewElementContents();
        }

        public static void ViewElementContents()
        {
            string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
            var newTab = driver.SwitchTo().Window(newHandle);
            //var tabExpected = "#Parte";
            //Assert.AreEqual(tabExpected, newTab.Title);

            System.Threading.Thread.Sleep(1000);
            partText = driver.FindElement(By.Id("ctl00_ContentZone_txt_id_box_data")).GetAttribute("value");
            System.Threading.Thread.Sleep(1000);
            partPadreText = driver.FindElement(By.Id("ctl00_ContentZone_lnb_parent")).GetAttribute("value");
            if (partPadreText == null)
            {
                partPadreText = "";
            }
            System.Threading.Thread.Sleep(1000);
            statusText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_status_cmb_dropdown"))).SelectedOption;
            statusText1 = statusText.Text;
            origenText = driver.FindElement(By.Id("ctl00_ContentZone_txt_creationMode_box_data")).GetAttribute("value");
            beginDate = driver.FindElement(By.Id("ctl00_ContentZone_dt_opentime_box_date")).GetAttribute("value");
            endDate = driver.FindElement(By.Id("ctl00_ContentZone_dt_closetime_box_date")).GetAttribute("value");
            System.Threading.Thread.Sleep(1000);
            String templeClass = driver.FindElement(By.XPath("//*[contains(@name, '_template$')]")).GetAttribute("class");
            if (templeClass.Equals("generalDropdown"))
            {
                tempText = new SelectElement(driver.FindElement(By.Id(templateSel))).SelectedOption;
                tempText1 = tempText.Text;
            }
            if (templeClass.Equals("readonlyBox"))
            {
                tempText1 = templeClass = driver.FindElement(By.Id(templateSel)).GetAttribute("value");
            }
            sevText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_severity_cmb_dropdown"))).SelectedOption;
            sevText1 = sevText.Text;
            createdByText = driver.FindElement(By.Id("ctl00_ContentZone_txt_creator_box_data")).GetAttribute("value");
            updatedByText = driver.FindElement(By.Id("ctl00_ContentZone_txt_updated_box_data")).GetAttribute("value");
            priorText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_priority_cmb_dropdown"))).SelectedOption;
            priorText1 = priorText.Text;
            typeText = driver.FindElement(By.Id("ctl00_ContentZone_txt_type_box_data")).GetAttribute("value");
            assignedText = new SelectElement(driver.FindElement(By.Id(asignadoT))).SelectedOption;
            assignedText1 = assignedText.Text;
            locateText = driver.FindElement(By.Id("ctl00_ContentZone_txt_location_box_data")).GetAttribute("value");
            autopistaText = new SelectElement(driver.FindElement(By.Id(tValoresT))).SelectedOption;
            autopistaText1 = autopistaText.Text;
            bandaText = new SelectElement(driver.FindElement(By.Id(direcT))).SelectedOption;
            bandaText1 = bandaText.Text;
            PkmText = driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmKm_box_data")).GetAttribute("value");
            PkmText1 = driver.FindElement(By.Id("ctl00_ContentZone_ctlPkm_txt_PkmM_box_data")).GetAttribute("value");
            ramalsText = new SelectElement(driver.FindElement(By.Id(ramalsT))).SelectedOption;
            ramalsText1 = ramalsText.Text;
            observacionesText = driver.FindElement(By.Id("ctl00_ContentZone_txt_comments_box_data")).GetAttribute("value");
            if (driver.FindElements(By.Id(supervisorT)).Count != 0)
            {
                supervisorText = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_assigned_cmb_dropdown"))).SelectedOption;
                supervisorText1 = supervisorText.Text;
                supervT = true;
            }
            FileStream newFile = new FileStream("C:\\Selenium\\Resultados.txt", FileMode.Create);
            StreamWriter write = new StreamWriter(newFile);
            write.WriteLine("#Parte: " + partText);
            write.WriteLine("Padre Parte: " + partPadreText);
            write.WriteLine("Estado: " + statusText1);
            write.WriteLine("Origen: " + origenText);
            write.WriteLine("Fecha Inicio: " + beginDate);
            write.WriteLine("Plantilla: " + tempText1);
            write.WriteLine("Gravedad: " + sevText1);
            write.WriteLine("Creado Por: " + createdByText);
            write.WriteLine("Modificado Por: " + updatedByText);
            write.WriteLine("Fecha Cierre: " + endDate);
            write.WriteLine("Prioridad: " + priorText1);
            write.WriteLine("Tipo: " + typeText);
            write.WriteLine("Asignado: " + assignedText1);
            if (supervT)
            {
                write.WriteLine("Supervisor: " + supervisorText1);
            }
            write.WriteLine("Autopista: " + autopistaText1);
            write.WriteLine("Banda: " + bandaText1);
            write.WriteLine("PKM(Km+m): " + PkmText + "+" + PkmText1);
            write.WriteLine("Ramales: " + ramalsText1);
            write.WriteLine("Localización: " + locateText);
            write.WriteLine("Observaciones: " + observacionesText);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id(datoBtn)).Click();
            if (typeText.Equals("Incidente") || typeText.Equals("Accidente"))
            {
                string typeAcc = driver.FindElement(By.Id("ctl00_ContentZone_mc_typeOfAccident_txt_selected")).GetAttribute("value");
                write.WriteLine("Tipo de Accidentes: " + typeAcc);
                string typeImpact = driver.FindElement(By.Id("ctl00_ContentZone_mc_causal_txt_selected")).GetAttribute("value");
                write.WriteLine("Tipo de Impacto: " + typeImpact);
            }
            string cAparente = driver.FindElement(By.Id("ctl00_ContentZone_txt_causes_box_data")).GetAttribute("value");
            if (cAparente == null)
            {
                cAparente = "";
            }
            write.WriteLine("Causas Aparentes del Hecho: " + cAparente);
            string infoComp = driver.FindElement(By.Id("ctl00_ContentZone_txt_information_box_data")).GetAttribute("value");
            if (infoComp == null)
            {
                infoComp = "";
            }
            write.WriteLine("Información complementaria: " + infoComp);
            string obserGenerales = driver.FindElement(By.Id("ctl00_ContentZone_txt_observations_box_data")).GetAttribute("value");
            if (obserGenerales == null)
            {
                obserGenerales = "";
            }
            write.WriteLine("Observaciones Generales: " + obserGenerales);
            string notaCentro = driver.FindElement(By.Id("ctl00_ContentZone_txt_note_box_data")).GetAttribute("value");
            if (notaCentro == null)
            {
                notaCentro = "";
            }
            write.WriteLine("Nota del centro de operaciones: " + notaCentro);

            for (i = 1; i < dOption.Length; i++)
            {
                string options = driver.FindElement(By.XPath("//label[@for=" + "'" + dOption[i] + "'" + "]")).Text;
                string dOptionChecked = driver.FindElement(By.Id(dOption[i])).GetAttribute("checked");
                if (dOptionChecked != null)
                {
                    if (!options.Equals("Vehículos volcados"))
                    {
                        write.Write("x" + options + "        ");
                    }
                    if (options.Equals("Vehículos volcados"))
                    {
                        write.Write("xVehículos volcados" + ": " + driver.FindElement(By.Id(vVolcado)).GetAttribute("value"));
                    }
                }
                else
                {
                    write.Write(options + "         ");
                }
            }
            write.WriteLine(" ");
            if (typeText.Equals("Incidente") || typeText.Equals("Accidente"))
            {
                for (int i = 1; i < vOption.Length; i++)
                {
                    string options = driver.FindElement(By.XPath("//label[@for=" + "'" + vOption[i] + "'" + "]")).Text;
                    string vOptionChecked = driver.FindElement(By.Id(vOption[i])).GetAttribute("checked");
                    if (vOptionChecked != null)
                    {
                        write.Write("x" + options + ": " + driver.FindElement(By.Id(vOptionT[i])).GetAttribute("value") + "    ");
                    }
                    else
                    {
                        write.Write(options + "     ");
                    }
                }
                write.WriteLine("");
            }
            write.WriteLine("");
            IWebElement table = driver.FindElement(By.XPath("//table[@id='ctl00_ContentZone_TblComponent']"));
            IList<IWebElement> tablC = table.FindElements(By.TagName("tr"));
            for (int i = 1; i <= tablC.Count; i++)
            {
                if (i == 1)
                {
                    IWebElement head1 = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_A']"));
                    IList<IWebElement> headtd = head1.FindElements(By.TagName("td"));
                    for (int x = 1; x <= headtd.Count; x++)
                    {
                        string td1 = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_A']/td" + "[" + x + "]")).Text;
                        write.Write(td1.PadRight(30));
                    }
                    write.WriteLine(" ");
                    for (int a = 1; a <= 200; a++)
                    {
                        write.Write("-");
                    }
                    write.WriteLine(" ");
                }
                if (i > 1)
                {
                    IWebElement component = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblComponent']/tbody/tr" + "[" + i + "]"));
                    IList<IWebElement> componenttd = component.FindElements(By.TagName("td"));
                    for (int x = 1; x <= componenttd.Count; x++)
                    {
                        string format = "{0, -30}";
                        string td2 = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_TblComponent']/tbody/tr" + "[" + i + "]" + "/td" + "[" + x + "]")).Text;
                        var strinbuild = new StringBuilder().AppendFormat(format, td2);
                        write.Write(strinbuild.ToString());
                        if (x == 7)
                        {
                            write.WriteLine(" ");
                        }

                    }
                }

            }
            write.Flush();
        }




        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}