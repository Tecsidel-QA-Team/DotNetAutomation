using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CoviHonduras
{
    [TestClass]
    public class verConfirmación_TransitosSubidos : Settingsfields_File
    {
        private static SqlConnection connection;
        private static string[] transactions = new string[2];
        private static List<string> transactionsIds = new List<string>();
        //private static DateTime localDate = DateTime.Now;
        private static string localDate = "20170926";


        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void verConfirmacion_Transitos()
        {
            dateverTransacciones = "26/07/2017";
            //borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\conexion_BBDDSenac\\attachments\\");
            try {

                GetConnection("PLAZA");
                if (transactions[0] == null && transactions[1] == null)
                {
                    Console.WriteLine("No han subido tránsitos a Plaza con fecha de hoy " + dateverTransacciones);
                    Assert.Fail("No han subido tránsitos a Plaza con fecha de hoy " + dateverTransacciones);
                }
                else
                {
                    Console.WriteLine("En Plaza han subido hoy: " + transactionsIds.Count / 2);
                    System.Threading.Thread.Sleep(1000);
                    GetConnection("HOST");
                    if (transactions[0] == null && transactions[1] == null)
                    {
                        Console.WriteLine("No han subido tránsitos a Host con fecha de hoy " + dateverTransacciones);
                        Assert.Fail("No han subido tránsitos a Host con fecha de hoy " + dateverTransacciones);
                    }
                    else
                    {
                        string Hour1 = transactionsIds[0].Substring(8, 2);
                        string Min1 = transactionsIds[0].Substring(10, 2);
                        string Sec1 = transactionsIds[0].Substring(12, 2);
                        Console.WriteLine("En Host han subido hoy: " + transactionsIds.Count / 2);                        
                        System.Threading.Thread.Sleep(1000);
                        CoviHonduras.BOHost_VerTransacciones.verTransacciones();
                        System.Threading.Thread.Sleep(1000);
                        IWebElement tablResult = driver.FindElement(By.Id("ctl00_ContentZone_tbl_logs"));
                        IList<IWebElement> transResult = tablResult.FindElements(By.TagName("tr"));
                        if (transResult.Count < 3)
                        {
                            Console.WriteLine("No hay Transacciones en el BackOffice Web con fecha de hoy");
                            Assert.Fail("No hay Transacciones en el BackOffice Web con fecha de hoy");
                            return;
                        }
                        string elementsFound = driver.FindElement(By.Id("ctl00_ContentZone_tablePager_LblCounter")).Text;
                        int elementBg = 24;
                        
                        if (transResult.Count > 11)
                        {
                            elementBg = 25;                            
                        }
                        if (transResult.Count < 19)
                        {
                            string transRes = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_tbl_logs']/tbody/tr[" + transResult.Count + "]/td[1]/a")).Text;
                            if (transRes.Equals(transactionsIds[1]))
                            {
                                Console.WriteLine("Hay " + elementsFound.Substring(elementBg, 2) + " transacciones y el último tránsito: " + transactionsIds[1]+ " ha subido satisfactoriamente el dia de hoy " + dateverTransacciones + "  {0}:{1}:{2}", Hour1, Min1, Sec1);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("No se ha subido el último tránsito a BackOffice Web desde HostManage de hoy");
                                Assert.Fail("No se ha subido el último tránsito a BackOffice Web HostManage con fecha de hoy");
                                return;
                            }

                        }else{
                                elementClick("ctl00_ContentZone_tablePager_BtnLast");
                                tablResult = driver.FindElement(By.Id("ctl00_ContentZone_tbl_logs"));
                                transResult = tablResult.FindElements(By.TagName("tr"));
                                string transRes = driver.FindElement(By.XPath("//*[@id='ctl00_ContentZone_tbl_logs']/tbody/tr[" + transResult.Count + "]/td[1]/a")).Text;
                                if (transRes.Equals(transactions[1])){
                                    Console.WriteLine("Hay "+elementsFound.Substring(elementBg, 2)+" transacciones y el último tránsito: "+transactionsIds[1]+" ha sido satisfactoriamente el dia de hoy "+dateverTransacciones+" {0}:{1}:{2}",Hour1,Min1,Sec1);
                                    return;
                                }else{
                                    Console.WriteLine("No se ha subido el último tránsito a BackOffice Web desde HostManage de hoy");
                                    Assert.Fail("No se ha subido el último tránsito a BackOffice Web HostManage con fecha de hoy");
                                    return;
                                 }
                         }
                     }

                 }
                 
            }catch(Exception e){
                Console.WriteLine(e.Message);
                Assert.Fail();
				}
		}

        private static void GetConnection(string Bd)
        {
            string connectionUrlPlaza = "Data Source=172.18.130.188;Initial Catalog=COVIHONDURAS_QA_TOLL"+Bd+"; user id=sa;password=lediscet;";
            connection = new SqlConnection();
            connection.ConnectionString = connectionUrlPlaza;
            connection.Open();
            SqlCommand query = new SqlCommand("select passagetime, transactionid from dbo.atransaction where passagetime like '" + localDate + "%' ORDER BY passagetime DESC", connection);
            SqlDataReader queryReader = query.ExecuteReader();
            
            int i = 0;
            while (queryReader.Read())
            {
                for (i = 0; i < 2; i++)
                {
                    transactions[0] = Convert.ToString(queryReader["passagetime"]);
                    transactions[1] = Convert.ToString(queryReader["transactionid"]);
                    transactionsIds.Add(transactions[i]);

                }
            }
            //Console.WriteLine("State: {0}", connection.State);
            //Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);

        }

        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
