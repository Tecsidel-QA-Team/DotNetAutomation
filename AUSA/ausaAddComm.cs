using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace AUSA
{
    [TestClass]
    public class ausaAddComm : AusaFieldsConfiguration
    {
        private static int i = 0;
        private static int xll = 0;
        public static IWebElement newCom;
        public static string newComSel;
        public static IWebElement comMean; public static string comMeanSel;
        public static string comTitle;
        public static IWebElement motiveD; public static string motiveSel;
        public static IWebElement originC; public static string originSel;
        public static IWebElement originC_DestinaC; public static string originC_DestSel;
        public static IWebElement importanceC; public static string importanceSel;
        public static string matterCom;
        public static string commentCom;
        public static string verFile;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver("C:\\Selenium");
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void ausaAddComPartee()
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
                borrarArchivosTemp("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\");
                takeScreenShot("E:\\Selenium\\", "ausaLoginPage", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\", "ausaLoginPage_", timet);
                driver.FindElement(By.Id("BoxLogin")).SendKeys("calidad");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("calidad");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("E:\\Selenium\\", "AusamP", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\", "AusamP", timet);
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;
                System.Threading.Thread.Sleep(1000);
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(2000);
                string mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();
                System.Threading.Thread.Sleep(8000);
                takeScreenShot("E:\\Selenium\\", "AusapP", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\", "AusapP", timet);
                if (lPartes.Equals("Issues"))
                {
                    Types = "All";
                }
                else
                {
                    Types = "Todos";
                }
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
                        buscarElement();
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
                //e.printStackTrace();//System.out.println(e.getStackTrace());
                return;
            }
        }

        public static void buscarElement()
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement table = driver.FindElement(By.CssSelector("tbody tr td table#tableIssues.generalTable"));
            IList<IWebElement> tableCount = table.FindElements(By.TagName("tr"));
            List<string> addComm = new List<string>();
            int x = 0;
            do
            {
                for (i = 1; i <= tableCount.Count; i++)
                {
                    string buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr" + "[" + i + "]/td[16]/input[3]")).GetAttribute("id");
                    if (buscar1.Contains("addComm"))
                    {
                        addComm.Add(buscar1);

                        x = x + 1;
                    }
                }
                System.Threading.Thread.Sleep(500);
            } while (i < tableCount.Count);
            Random xl = new Random();
            for (i = 1; i < addComm.Count; i++)
            {
                xll = xl.Next(addComm.Count) + 1;
                if (xll > addComm.Count - 1)
                {
                    xll = xll - 1;
                }
                if (xll < 0)
                {
                    xll = 0;
                }
            }
            driver.FindElement(By.Id(addComm[xll])).Click();
            System.Threading.Thread.Sleep(2000);
            createCommunication();
            System.Threading.Thread.Sleep(1000);
            grabarFichero();
            System.Threading.Thread.Sleep(1000);
            crearFichero();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Se ha creado una Comunicación a la parte " + addComm[xll].Substring(8) + " y se ha creado un Archivo Log " + verFile + timet + " con los datos agregados");
        }

        public static void createCommunication()
        {
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_Title_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_Title_box_data")).SendKeys("Communication" + " - " + ranNumbr(1, 99) + " QA Automation");
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_type_cmb_dropdown");
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_mean_cmb_dropdown");
            System.Threading.Thread.Sleep(500);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_motive_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_type_ori_des_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            notEmptyDropDown("ctl00_ContentZone_ctrlComunication_cmb_ori_des_cmb_dropdown");
            System.Threading.Thread.Sleep(1000);
            selectDropDownClick("ctl00_ContentZone_ctrlComunication_cmb_importance_cmb_dropdown");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_subject_box_data")).SendKeys("Created by Automation Script");
            driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_comment_box_data")).SendKeys("This Communication was created by an automation script for testing purpose");
            System.Threading.Thread.Sleep(1000);
            takeScreenShot("E:\\Selenium\\", "addCommScr_", timet);
            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\", "addCommScr", "");
            System.Threading.Thread.Sleep(500);

        }

        public static void grabarFichero()
        {
            System.Threading.Thread.Sleep(1500);
            comTitle = driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_Title_box_data")).GetAttribute("value");
            newCom = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_type_cmb_dropdown"))).SelectedOption;
            newComSel = newCom.Text;
            if (newComSel.Equals(null))
            {
                newComSel = "";
            }
            comMean = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_mean_cmb_dropdown"))).SelectedOption;
            comMeanSel = comMean.Text;
            if (comMeanSel.Equals(null))
            {
                comMeanSel = "";
            }
            motiveD = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_motive_cmb_dropdown"))).SelectedOption;
            motiveSel = motiveD.Text;
            if (motiveSel.Equals(null))
            {
                motiveSel = "";
            }
            originC = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_type_ori_des_cmb_dropdown"))).SelectedOption;
            originSel = originC.Text;
            if (originSel.Equals(null))
            {
                originSel = "";
            }
            if (originSel != null)
            {
                originC_DestinaC = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_ori_des_cmb_dropdown"))).SelectedOption;
                originC_DestSel = originC_DestinaC.Text;
                if (originC_DestSel.Equals(null))
                {
                    originC_DestSel = "";
                }
            }
            else
            {
                originC_DestSel = "";
            }
            importanceC = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_cmb_importance_cmb_dropdown"))).SelectedOption;
            importanceSel = importanceC.Text;
            if (importanceSel.Equals(null))
            {
                importanceSel = "";
            }
            matterCom = driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_subject_box_data")).GetAttribute("value");
            commentCom = driver.FindElement(By.Id("ctl00_ContentZone_ctrlComunication_txt_comment_box_data")).GetAttribute("value");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSave_IB_Label")).Click();
            System.Threading.Thread.Sleep(500);
        }

        public static void crearFichero()
        {
            System.Threading.Thread.Sleep(500);
            verFile = "addComArchivo_";
            FileStream newFile = new FileStream("C:\\Selenium\\verFile_" + timet + ".txt", FileMode.Create);
            FileStream resultTmp = new FileStream("E:\\workspace\\Pilar_Repository\\ausaAgregarComPartes\\attachments\\" + verFile + ".txt", FileMode.Create);
            StreamWriter write = new StreamWriter(newFile);
            StreamWriter writetmp = new StreamWriter(resultTmp);
            Console.WriteLine("Titulo de Comunicación: " + comTitle);
            Console.WriteLine("Tipo de Comunicación: " + newComSel);
            Console.WriteLine("Medio de Comunicación: " + comMeanSel);
            Console.WriteLine("Motivo de Comunicación: " + motiveSel);
            Console.WriteLine("Tipo Origen Destion: " + originSel);
            Console.WriteLine("Origen/Destino: " + originC_DestSel);
            Console.WriteLine("Importancia: " + importanceSel);
            Console.WriteLine("Asunto: " + matterCom);
            Console.WriteLine("Observaciones: " + commentCom);
            write.Flush();
            writetmp.Flush();


        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();

            {


                
                }


            }
        }
    }
