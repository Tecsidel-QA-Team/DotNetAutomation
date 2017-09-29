using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Globalization;

namespace SENAC
{
    [TestClass]
    public class telecargas_Promociones : senacFieldsConfiguration
    {
        private static string[] dateS = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private static string[] telP = { "ctl00_ContentZone_Prepay", "ctl00_ContentZone_Postpay" };
        private static string[] promoSel = { "En función de recarga", "En función de tránsitos", "En función del horario" };
        private static Actions action;
        private static int dateMFrom;
        private static string dateFrom;
        private static int dateFro;
        private static int dateMFromR;
        private static int linkSel;
        private static string errorText;
        private static string[] weekDay = { "ctl00_ContentZone_chk_lundi", "ctl00_ContentZone_chk_mardi", "ctl00_ContentZone_chk_mercredi", "ctl00_ContentZone_chk_jeudi", "ctl00_ContentZone_chk_vendredi", "ctl00_ContentZone_chk_samedi", "ctl00_ContentZone_chk_dimanche" };

        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void senacPromocionesPage()
        {
            action = new Actions(driver);
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\");
			try{
			    driver.Navigate().GoToUrl(baseUrl);
                takeScreenShot("E:\\Selenium\\","loginpageSenac_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","loginpageSenac","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
				dateMFrom = ranNumbr(0,12);
					if (dateMFrom>=12){
						dateMFromR = dateMFrom-1;
					}else{
						dateMFromR = dateMFrom;
					}
                dateFro = dateMFromR + 1;
                takeScreenShot("E:\\Selenium\\","homepageSenac_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","homepageSenac","");
                System.Threading.Thread.Sleep(1000);
				action.ClickAndHold(driver.FindElement(By.LinkText("Configuración sistema"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
			    action.ClickAndHold(driver.FindElement(By.LinkText("Promociones"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
				linkSel = ranNumbr(0,2);
                driver.FindElement(By.LinkText(promoSel[linkSel])).Click();
                System.Threading.Thread.Sleep(2000);
				switch (linkSel){
					case 0:                         System.Threading.Thread.Sleep(1000);
                                                    enfuncionRecarga();
												    break;
					case 1:						    enfunciontransitos();
												    break;							
					case 2:						    enfuncionhorario();
												    break;												
					}
			}catch(Exception e){
                Console.WriteLine(e.GetBaseException());
				Console.WriteLine("No se puede crear Telecarga Promociones "+ promoSel[linkSel]+ " debido a: "+errorText);
                Assert.Fail(errorText);
			}			
		}			
			
		public static void enfuncionRecarga()
        {
            driver.FindElement(By.Id("ctl00_ContentZone_BtnCreate")).Click(); // Botón crear operador
            //takeScreenShot("E:\\Selenium\\","promoenFuncionRecarga_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionRecarga","");
            System.Threading.Thread.Sleep(1500);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionRecargaCreate_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionRecargaCreate","");
            driver.FindElement(By.Id("ctl00_ContentZone_txtNom_box_data")).SendKeys("PROMO_"+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(1000);
            dateFro = dateMFromR + 1;            
            if (dateFro < 10)
            {
                dateFrom = "0" + dateFro;
            }
            else
            {
                dateFrom = ""+dateFro;
            }
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31)).ToString("dd/"+ dateFrom + "/yyyy"));
            System.Threading.Thread.Sleep(1000);
            
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31)).ToString("dd/MM/yyyy"));
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXtMsgPromotion_box_data")).SendKeys("Nueva Promoción para "+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_CboType");
            System.Threading.Thread.Sleep(1000);
            IWebElement lanetype = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_CboType"))).SelectedOption;
            string laneS = lanetype.Text;
			if (laneS.Equals("Vías")){
                selectDropDown("ctl00_ContentZone_Vias");
                System.Threading.Thread.Sleep(100);
                selectDropDown("ctl00_ContentZone_Vias");
			}
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.Id("ctl00_ContentZone_BtnCreate")).Click();
            System.Threading.Thread.Sleep(1500);
            driver.FindElement(By.Id("ctl00_ContentZone_TxtBoxImporte_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_TxtBoxImporte_box_data")).SendKeys(ranNumbr(1000,10000)+"");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TxtboxPorcentaje_box_data")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_TxtboxPorcentaje_box_data")).SendKeys(ranNumbr(1,100)+"");
            System.Threading.Thread.Sleep(500);
            elementClick("ctl00_ContentZone_BtnApply");
            System.Threading.Thread.Sleep(2000);
            takeScreenShot("E:\\Selenium\\","promoenFuncionRecargaCreateDataFill_",timet);
            takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionRecargaCreateDataFill","");
            elementClick("ctl00_ButtonsZone_BtnSubmit");
            System.Threading.Thread.Sleep(3000);
		    if (isAlertPresent()){
			    errorText = driver.SwitchTo().Alert().Text;
                takeScreenShot("E:\\Selenium\\","promoenFuncionRecargaErr_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionRecargaCreateErr","");
				return;
			}else{
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ButtonsZone_BtnDownload");
                System.Threading.Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\","promoenFuncionRecargaSuccess_",timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionRecargaSuccess","");
                string successMessage = driver.FindElement(By.Id("ctl00_LblError")).Text;
                System.Threading.Thread.Sleep(3000);
			    Console.WriteLine("Telecarga de Promociones "+ promoSel[linkSel]+" ha sido creada y Envio de Telecarga: "+successMessage);
				return;
			}
						
		}
			
		public static void enfunciontransitos() 
        {
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionTransito_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionTransito","");
            elementClick("ctl00_ContentZone_BtnCreate");
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionTransitoCreate_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promoiones\\attachments\\","promoenFuncionTransitoCreate","");
            driver.FindElement(By.Id("ctl00_ContentZone_txtNom_box_data")).SendKeys("PROMO_"+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);
            dateFro = dateMFromR + 1;
            if (dateFro < 10)
            {
                dateFrom = "0" + dateFro;
            }
            else
            {
                dateFrom = "" + dateFro;
            }
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31)).ToString("dd/"+ dateFrom + "/yyyy"));
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31)).ToString("dd/MM/yyyy"));
            System.Threading.Thread.Sleep(1000); 
			if (ranNumbr(1,2)<2){
                driver.FindElement(By.Id(telP[ranNumbr(0, 1)])).Click();
            }else{
                driver.FindElement(By.Id(telP[0])).Click();
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id(telP[1])).Click();
            }
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXTNombrePassage_box_data")).SendKeys(ranNumbr(1,999)+"");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXTPassageGratuit_box_data")).SendKeys(ranNumbr(1,999)+"");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXtMsgPromotionTFI_box_data")).SendKeys("Promoción de "+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXtMsgPromotion_box_data")).SendKeys("La Nueva Promoción de "+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_Vias");
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_Categoria");
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionTransitoCreateFillData_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionTransitoCreateFillData","");
            elementClick("ctl00_ButtonsZone_BtnSubmit");
            //action.Click(driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSubmit"))).Build().Perform();
            System.Threading.Thread.Sleep(3000);
			if (isAlertPresent()){
                errorText = driver.SwitchTo().Alert().Text;
                takeScreenShot("E:\\Selenium\\", "promoenFuncionTransitoErr_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\", "promoenFuncionTransitoErr","");
                return;
            }else{
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ButtonsZone_BtnDownload");
                System.Threading.Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\", "promoenFuncionTransitoSuccess_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\", "promoenFuncionTransitoSuccess","");
                string successMessage = driver.FindElement(By.Id("ctl00_LblError")).Text;
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Telecarga de Promociones " + promoSel[linkSel] + " ha sido creada y Envio de Telecarga: " + successMessage);
                System.Threading.Thread.Sleep(1000);
                return;
            }

        }

        public static void enfuncionhorario() 
        {
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionhorario_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionhorario","");
            elementClick("ctl00_ContentZone_BtnCreate");
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionhorarioCreate_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionhorarioCreate","");
            driver.FindElement(By.Id("ctl00_ContentZone_txtNom_box_data")).SendKeys("PROMO_"+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);

            dateFro = dateMFromR + 1;
            if (dateFro < 10)
            {
                dateFrom = "0" + dateFro;
            }
            else
            {
                dateFrom = "" + dateFro;
            }
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmfrom_box_date")).SendKeys(dateSel(new DateTime(2017, dateMFromR+1, 1), new DateTime(2018, 12, 31)).ToString("dd/"+dateFrom+"/yyyy"));
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).Clear();
            driver.FindElement(By.Id("ctl00_ContentZone_dtmTo_box_date")).SendKeys(dateSel(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31)).ToString("dd/MM/yyyy"));
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_TXtMsgPromotion_box_data")).SendKeys("La Nueva Promoción de "+dateS [dateMFromR]);
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_Vias");
            System.Threading.Thread.Sleep(500);
            selectDropDown("ctl00_ContentZone_Categoria");
            System.Threading.Thread.Sleep(500);
			int weekS = ranNumbr(1,7);				
			if (weekS < 7){
                for (int i = 0; i < weekS; i++)
                {
                    int selW = ranNumbr(0, weekDay.Length - 1);
                    System.Threading.Thread.Sleep(500);
                    driver.FindElement(By.Id(weekDay[selW])).Click();
                    if (!driver.FindElement(By.Id(weekDay[selW])).Selected)
                    {
                        driver.FindElement(By.Id(weekDay[selW])).Click();
                    }
                }       
            }else{
                for (int i = 0; i < weekDay.Length; i++)
                {
                    driver.FindElement(By.Id(weekDay[i])).Click();
                }
            }
            System.Threading.Thread.Sleep(500);
		    int HourS = ranNumbr(0,22);
			if (HourS < 10){
                driver.FindElement(By.Id("ctl00_ContentZone_horainio_box_data")).SendKeys("0" + HourS + "00");
                System.Threading.Thread.Sleep(500);
                if (HourS + 1 < 10)
                {
                    driver.FindElement(By.Id("ctl00_ContentZone_horafinal_box_data")).SendKeys("0" + HourS + 1 + "00");
                }else{
                    driver.FindElement(By.Id("ctl00_ContentZone_horafinal_box_data")).SendKeys(HourS + 1 + "00");
                }
            }else{
                driver.FindElement(By.Id("ctl00_ContentZone_horainio_box_data")).SendKeys(HourS + "00");
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_horafinal_box_data")).SendKeys(HourS + 1 + "00");
            }
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.Id("ctl00_ContentZone_porce_promotion_box_data")).SendKeys(ranNumbr(1,100)+"");
            System.Threading.Thread.Sleep(1000);
            //takeScreenShot("E:\\Selenium\\","promoenFuncionhorarioCreateFillData_",timet);
            //takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\","promoenFuncionhorarioCreateFillData","");
            driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSubmit")).Click();
            //elementClick("ctl00_ButtonsZone_BtnSubmit");
            System.Threading.Thread.Sleep(3000);
			if (isAlertPresent())
            {
                errorText = driver.SwitchTo().Alert().Text;
                takeScreenShot("E:\\Selenium\\", "promoenFuncionhorarioErr_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\", "promoenFuncionhorarioErr","");
                return;
            }else{
                System.Threading.Thread.Sleep(1000);
                elementClick("ctl00_ButtonsZone_BtnDownload");
                System.Threading.Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
                System.Threading.Thread.Sleep(2000);
                takeScreenShot("E:\\Selenium\\", "promoenFuncionhorarioSuccess_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\telecargas_Promociones\\attachments\\", "promoenFuncionhorarioSuccess","");
                string successMessage = driver.FindElement(By.Id("ctl00_LblError")).Text;
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Telecarga de Promociones " + promoSel[linkSel] + " ha sido creada y Envio de Telecarga: " + successMessage);
                System.Threading.Thread.Sleep(1000);
                return;
            }
        }

        public static Boolean isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;

            }catch (NoAlertPresentException e){
                return false;
            }
        }


        [TestCleanup]
        public void tearDown()
        {
            driver.Quit();
        }

    }


}
