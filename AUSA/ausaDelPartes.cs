using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace AUSA
{
    [TestClass]
    public class ausaDelPartes : AusaFieldsConfiguration
    {
        private static string errorText;
        private static int i = 0;
        private static int xll = 0;

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver("C:\\Selenium");
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void ausaDeletePartes()
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
                borrarArchivosTemp("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\");
                takeScreenShot("E:\\Selenium\\", "ausaLoginPageCrearPartes", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\", "ausaLoginPageCrearPartes", "");
                driver.FindElement(By.Id("BoxLogin")).SendKeys("calidad");
                driver.FindElement(By.Id("BoxPassword")).SendKeys("calidad");
                driver.FindElement(By.Id("BtnLogin")).Click();
                System.Threading.Thread.Sleep(3000);
                takeScreenShot("E:\\Selenium\\", "AusamP", timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\", "AusamP", "");
                string lPartes = driver.FindElement(By.XPath("//div[7] / div / ul / li[5] / a")).Text;
                System.Threading.Thread.Sleep(1000);
                IWebElement Partes = driver.FindElement(By.LinkText(lPartes));
                action.ClickAndHold(Partes).Perform();
                System.Threading.Thread.Sleep(2000);
                string mPartes = driver.FindElement(By.XPath("// div[7] / div / ul / li[5] / ul / li / a")).Text;
                driver.FindElement(By.LinkText(mPartes)).Click();
                System.Threading.Thread.Sleep(8000);
                takeScreenShot("E:\\Selenium\\", "AusapP",  timet);
                takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\", "AusapP", "");
                if (lPartes.Equals("Issues"))  
                {
                    Types = "All";
                }
                else{
                    Types = "Todos";
                }
                System.Threading.Thread.Sleep(1500);
                driver.FindElement(By.Id("ctl00_ContentZone_imgShow")).Click();
                System.Threading.Thread.Sleep(500);
                selectDropDownClick("ctl00_ContentZone_cmb_assigned_cmb_dropdown");
                System.Threading.Thread.Sleep(800);
                elementClick("ctl00_ButtonsZone_BtnSearch_IB_Label");
                System.Threading.Thread.Sleep(1000);
                if (driver.FindElements(By.XPath("//div[@class='toast-item toast-type-error']/p")).Count != 0)
                {
                    errorText = driver.FindElement(By.XPath("//div[@class='toast-item toast-type-error']/p")).Text;
                    takeScreenShot("E:\\Selenium\\", "errorSearch",  timet);
                    takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\", "errorSearch","");
                    Console.WriteLine("ERROR EN BUSQUEDA: " + errorText + ". Ver Imagen de Captura Busqueda.jpeg");
                }
                else
                {
                    borrarElement();
                }


            }
            catch (Exception e)
            {
                
                return;
            }
        }
        public static void borrarElement() 
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement table = driver.FindElement(By.CssSelector("tbody tr td table#tableIssues.generalTable"));
            IList<IWebElement> tableCount = table.FindElements(By.TagName("tr"));
            List<string> delPart = new List<string>();
            int x = 0;
	  					do{		  						
	  						for (i = 1; i  <=  tableCount.Count; i++){	  							
	  							String buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr" + "[" + i + "]/td[16]/input[3]")).GetAttribute("id");
	  							if (buscar1.Contains("addComm")){
	  								buscar1 = table.FindElement(By.XPath("//table[@id='tableIssues']/tbody/tr"+"["+i+"]/td[16]/input[4]")).GetAttribute("id");
    }
	  							if (buscar1.Contains("delete")){
	  								delPart.Add(buscar1);
	  								x = x+1;
	  							}
	  							
	  						}	  
	  						System.Threading.Thread.Sleep(100);
	  					}while (i<tableCount.Count);
	  						Random xl = new Random();
	  					for (i = 1; i <= delPart.Count; i++){
  							xll = xl.Next(delPart.Count)+1;
  							if (xll > delPart.Count-1){
  								xll = xll -1;
  							}
  							if (xll< 0){
  								xll = 0;
  							}
	  					}
	  					driver.FindElement(By.Id(delPart[xll])).Click();
	  					if (driver.FindElements(By.XPath("//div[@class='toast-item toast-type-error']/p")).Count!=0){
                            takeScreenShot("E:\\Selenium\\","noIssuesDeleted",timet);
                            takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\","noIssuesDeleted","");
                            System.Threading.Thread.Sleep(1000);
                            errorText = driver.FindElement(By.XPath("//div[@class='toast-item toast-type-error']/p")).Text;
                            Console.WriteLine("ERROR AL ELIMINAR PARTE: "+errorText+ ". Ver Imagen de Captura noIssuesDeleted.jpeg");
	  						return;
	  					}
                        System.Threading.Thread.Sleep(1000);
	  					driver.FindElement(By.Id("popup_ok")).Click();
                        System.Threading.Thread.Sleep(1000);
                        takeScreenShot("E:\\Selenium\\","parteEliminada",timet);
                        takeScreenShot("E:\\workspace\\Pilar_Repository\\ausaBorrarPartes\\attachments\\","parteEliminada","");
                        Console.WriteLine("Se ha Eliminado la Parte "+ delPart[xll].Substring(7) + " Correctamente. Vea Imagen de Captura Mensaje de Confirmación de Elemento Borrado");
	  				}
	  				
       [TestCleanup]
       public void tearDown()
        {
            driver.Quit();
        }
}
        }
    

