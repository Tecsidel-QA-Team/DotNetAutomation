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

namespace AUSA
{
    [TestClass]
    public class ausaIssues : AusaFieldsConfiguration
    {

        [TestInitialize]
        public void seTup()
        {
            driver = new ChromeDriver("C:\\Selenium");
            driver.Manage().Window.Maximize();
        }


        [TestMethod]
        public void ausaPartesBusca()
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
                            System.Threading.Thread.Sleep(2500);
                            string mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                            System.Threading.Thread.Sleep(2500);
                            driver.FindElement(By.LinkText(mPartes)).Click();
                            System.Threading.Thread.Sleep(4000);
                            string newHandle = driver.WindowHandles.Last(); //Para moverse a otro tab de ventana
                            var newTab = driver.SwitchTo().Window(newHandle);
                            var tabExpected = mPartes;
                            Assert.AreEqual(tabExpected, newTab.Title);    // termina logica para enfocarse en otrotab            
                            System.Threading.Thread.Sleep(3000);
                            driver.FindElement(By.Id("ctl00_ContentZone_imgShow")).Click();
                            System.Threading.Thread.Sleep(2000);
                            string Tipo = driver.FindElement(By.Id("ctl00_ContentZone_mc_type_txt_selected")).GetAttribute("value");
                            string Gravedad = driver.FindElement(By.Id("ctl00_ContentZone_mc_severity_txt_selected")).GetAttribute("value");
                            string Estado = driver.FindElement(By.Id("ctl00_ContentZone_mc_status_txt_selected")).GetAttribute("value");
                            string Origen = driver.FindElement(By.Id("ctl00_ContentZone_mc_creationMode_txt_selected")).GetAttribute("value");
                            string Prioridad = driver.FindElement(By.Id("ctl00_ContentZone_mc_priority_txt_selected")).GetAttribute("value");
                            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                            //bool b1 = (bool)js.ExecuteScript("return document.documentElement.scrollWidth>document.documentElement.clientWidth;");

                            System.Threading.Thread.Sleep(500);
                            string[] its = new string[] { "juan", "pilar", "cesar" };
                            int it = 1;
                            const string gotIts = "juan";
                            switch (its[it])
                            {
                                case gotIts: break;
                            }



                            if (Tipo.Equals("Todos"))
                            {
                                driver.FindElement(By.Id("ctl00_ContentZone_mc_type_img_expand")).Click();
                                System.Threading.Thread.Sleep(1000);
                                clickAll("ctl00_ContentZone_mc_type_ctl", 45, 53);
                                System.Threading.Thread.Sleep(600);
                                ranClick("ctl00_ContentZone_mc_type_ctl", 43, 53);// Elección de elemento del campo Tipo
                            }
                            System.Threading.Thread.Sleep(500);
                            if (Gravedad.Equals("Todos"))
                            {
                                driver.FindElement(By.Id("ctl00_ContentZone_mc_severity_img_expand")).Click();
                                System.Threading.Thread.Sleep(1000);
                                clickAll("ctl00_ContentZone_mc_severity_ctl", 33, 39);
                                System.Threading.Thread.Sleep(600);
                                ranClick("ctl00_ContentZone_mc_severity_ctl", 31, 31);// Elección de elemento del campo Tipo
                            }
                            System.Threading.Thread.Sleep(500);
                            if (Estado.Equals("Todos"))
                            {
                                driver.FindElement(By.Id("ctl00_ContentZone_mc_status_img_expand")).Click();
                                System.Threading.Thread.Sleep(1000);
                                clickAll("ctl00_ContentZone_mc_status_ctl", 45, 53);
                                System.Threading.Thread.Sleep(600);
                                ranClick("ctl00_ContentZone_mc_status_ctl", 43, 43);// Elección de elemento del campo Tipo
                            }
                            System.Threading.Thread.Sleep(500);
                            if (Origen.Equals("Todos"))
                            {
                                driver.FindElement(By.Id("ctl00_ContentZone_mc_creationMode_img_expand")).Click();
                                System.Threading.Thread.Sleep(1000);
                                clickAll("ctl00_ContentZone_mc_creationMode_ctl", 23, 27);
                                System.Threading.Thread.Sleep(600);
                                ranClick("ctl00_ContentZone_mc_creationMode_ctl", 21, 21);// Elección de elemento del campo Tipo
                            }
                            System.Threading.Thread.Sleep(500);
                            if (Prioridad.Equals("Todos"))
                            {
                                driver.FindElement(By.Id("ctl00_ContentZone_mc_priority_img_expand")).Click();
                                System.Threading.Thread.Sleep(1000);
                                clickAll("ctl00_ContentZone_mc_priority_ctl", 45, 53);
                                System.Threading.Thread.Sleep(600);
                                ranClick("ctl00_ContentZone_mc_priority_ctl", 43, 43);// Elección de elemento del campo Tipo
                            }
                System.Threading.Thread.Sleep(500);
                selectDropDownClick("ctl00_ContentZone_cmb_assigned_cmb_dropdown");
                System.Threading.Thread.Sleep(1000);
                selectDropDownClick("ctl00_ContentZone_cmd_supervisor_cmb_dropdown");
                System.Threading.Thread.Sleep(1500);
                elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
                System.Threading.Thread.Sleep(6000);

                 if (isElementPresent(By.Id("tableIssues")))
                 {
                     IWebElement table = driver.FindElement(By.Id("tableIssues"));
                     IList<IWebElement> tableCount = table.FindElements(By.TagName("tr"));
                     if (tableCount.Count == 0)
                     {
                         Console.WriteLine("Ningún parte encontrado para los criterios de selección introducidos");
                     }
                     else
                     {
                         Console.WriteLine("Se han encontrado" + tableCount.Count + " Registro/s");
                         js.ExecuteScript("window.scrollBy(2100,0)", "");
                         System.Threading.Thread.Sleep(3000);

                     }
                 }
                 else
                 {
                     Console.WriteLine("No hubo Elementos Encontrados");
                 }


             }
             catch (Exception e)
             {
                 Console.WriteLine(e.StackTrace);
                 throw;
             }
         }
        
        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }
}