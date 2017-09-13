using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SENAC
{
    public class crearIncidenciaRedMine : senacFieldsConfiguration
    {
        public static int i = 0;
        public static string[] values = null;
        public static List<string> redL = new List<string>();
        public static string[] testers = {"Pilar Bonilla", "Mavi Garrido", "Francisco Castro"};

    public static void createIncidence()
        {
            setUp();
            ReqRedmine();
            tearDown();

        }

        public static void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        public static void ReqRedmine()
        {
            System.Threading.Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://redmine.tecsidel.es");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("username")).SendKeys("fgn");
            driver.FindElement(By.Id("password")).SendKeys("Demo.1234");
            driver.FindElement(By.Name("login")).Click();
            System.Threading.Thread.Sleep(2000);
            new SelectElement(driver.FindElement(By.Id("project_quick_jump_box"))).SelectByText(projectSel);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Nueva petición")).Click();
            System.Threading.Thread.Sleep(1000);
            new SelectElement(driver.FindElement(By.Id("issue_tracker_id"))).SelectByText("IncidenceQA");
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id("issue_subject")).SendKeys(additionalTitle + errorLev);
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("issue_description")).SendKeys(descriptionSubject);
            System.Threading.Thread.Sleep(500);
            new SelectElement(driver.FindElement(By.Id("issue_assigned_to_id"))).SelectByText(testers[ranNumbr(0, 2)]);
            System.Threading.Thread.Sleep(500);
            new SelectElement(driver.FindElement(By.Id("issue_custom_field_values_59"))).SelectByText("Major");
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Name("attachments[dummy][file]")).Click();
            System.Threading.Thread.Sleep(1500);
            //selectoneFile();
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Name("commit")).Click();
            System.Threading.Thread.Sleep(3000);
            String inciName = driver.FindElement(By.XPath("//*[@id='content']/h2")).Text;
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Se ha creado la " + inciName + " correctamente");
        }

        public static void tearDown()
        {
            driver.Quit();
        }
    }
}
