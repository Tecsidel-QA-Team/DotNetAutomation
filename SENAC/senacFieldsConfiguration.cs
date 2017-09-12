using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Support.UI;


namespace SENAC
{
    public class senacFieldsConfiguration
    {
        public static string NIF_STRING_ASOCIATION = "TRWAGMYFPDXBNJZSQVHLCKE";
        public static int delm;
        public static string caMe;
        public static string acam;
        public static string fileDatafilled;
        public static int ad;
        public static int caMer;
        public static string fileError;
        public static string folderSel;
        public static string projectSel;
        public static string additionalTitle;
        public static string descriptionSubject;
        public static string errorLev;
        public static IWebDriver driver;
        public static string baseUrl = "http://virtualbo-qa/BOQAHostSenac/web/forms/core/login.aspx";
        public Boolean acceptNextAlert = true;
        public static int numbering;
        public static string linkPartes;
        public static string Types;
        public static string tipoSel;
        public static string loginField = "BoxLogin";
        public static string passField = "BoxPassword";
        public static string loginButton = "BtnLogin";
        public static string opIdField = "ctl00_ContentZone_operatorId_box_data";
        public static string nameField = "ctl00_ContentZone_forename_box_data";
        public static string lastNameField = "ctl00_ContentZone_surname_box_data";
        public static string emailField = "ctl00_ContentZone_email_box_data";
        public static string groupOperator = "ctl00_ContentZone_group_cmb_dropdown";
        public static string pwdField = "ctl00_ContentZone_password_box_data";
        public static string repeatpwdField = "ctl00_ContentZone_password2_box_data";
        public static string hourNumber = "ctl00_ContentZone_TxtNomHousr_box_data";
        public static string submitBtn = "ctl00_ButtonsZone_BtnSubmit";
        public static string[] nameOp = { "Pilar", "Mavi", "Franklyn", "Gemma", "Fatima", "Marc", "Miguel", "Francisco", "Oscar", "Maria Jesus" };
        public static string[] sexSelc = { "Sra", "Sra", "Sr", "Sra", "Sra", "Sr", "Sr", "Sr", "Sr", "Sra" };
        public static string[] addressTec = { "CALLE SAN MAXIMO, 3", "CALLE SAN MAXIMO, 3", "Castanyer 29", "CALLE SAN MAXIMO, 3", "CALLE SAN MAXIMO, 3", "Catanyer 29", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo" };
        public static string[] cpAdress = { "28041", "28041", "08022", "28041", "28041", "08022", "47151", "47151", "47151", "47151" };
        public static string[] townC = { "Madrid", "Madrid", "Barcelona", "Madrid", "Madrid", "Barcelona", "Valladolid", "Valladolid", "Valladolid", "Valladolid" };
        public static string[] workPhone1 = { "913530810", "913530810", "932922110", "913530810", "913530810", "932922110", "983546603", "983546603", "983546603", "983546603" };
        public static string[] lastNameOp = { "Bonilla", "Garrido", "Garcia", "Arjonilla", "Romano", "Navarro", "Sanchez", "Castro", "Bailon", "Blanco" };
        //Generación de cuentta standard fields:
        public static string opzero = ""; //numero de operador
        public static string infoCuenta0 = "ctl00_ContentZone_ctrlAccountData_radio_company_0";
        public static string infoCuenta1 = "ctl00_ContentZone_ctrlAccountData_radio_company_1";
        public static string titulofield = "ctl00_ContentZone_ctrlAccountData_cmb_title_cmb_dropdown";
        public static string namef = "ctl00_ContentZone_ctrlAccountData_txt_forname_box_data";
        public static string surnamef = "ctl00_ContentZone_ctrlAccountData_txt_surname_box_data";
        public static string addressf = "ctl00_ContentZone_ctrlAccountData_txt_address_box_data";
        public static string cpf = "ctl00_ContentZone_ctrlAccountData_txt_postcode_box_data";
        public static string townf = "ctl00_ContentZone_ctrlAccountData_txt_town_box_data";
        public static string countryf = "ctl00_ContentZone_ctrlAccountData_txt_country_box_data";
        public static string emailf = "ctl00_ContentZone_ctrlAccountData_txt_email_box_data";
        public static string phoneCel = "ctl00_ContentZone_ctrlAccountData_txt_mobile_box_data";
        public static string workPhone = "ctl00_ContentZone_ctrlAccountData_txt_daytimephone_box_data";
        public static string perPhone = "ctl00_ContentZone_ctrlAccountData_txt_homephone_box_data";
        public static string faxPhone = "ctl00_ContentZone_ctrlAccountData_txt_fax_box_data";
        public static string companyf = "ctl00_ContentZone_ctrlAccountData_txt_company_box_data";
        public static string contactf = "ctl00_ContentZone_ctrlAccountData_txt_contact_box_data";
        public static int carModelSel;
        public static string confirmationMessage;
        public static Boolean errorTagAssignment = false;
        public static string tagIdNmbr;
        public static string[] colorS = { "Blanco", "Negro", "Azul", "Rojo", "Verde", "Amarillo" };
        public static string accountNumbrT;
        public static int carSel;
        public static int carModel;
        public static string matriNu;
        public static string vehtypeModel;
        public static string vehtypeKind;
        public static string[,] cocheModels = { {"Seat", "Volkswagen", "Ford", "Fiat" }, { "Ibiza", "Polo", "Fiesta", "Punto" }, { "León", "Passat", "Focus", "Stilo" } };
        public static string[,] camionModels =  {{ "Mercedes-Benz", "Scania" }, { "Axor", "R500" }, { "Actros", "P400" }};
        public static string[,] furgonetaModels = {{ "Mercedes-Benz", "Fiat" }, { "Vito", "Scudo" }, { "Citan", "Ducato" }};
        public static string[,] cicloModels = {{ "Yamaha", "Honda" }, { "XT1200Z", "Forza 300" }, { "T-MAX SX", "X-ADV" }};
        public static string[,] autoBusModels = {{ "DAIMLER-BENZ", "VOLVO" }, { "512-CDI", "FM-12380" }, { "DB 605", "FM 300" }};
        //Edit buttons icons configuration.	  	  
        public static string timet = timeStamp(new DateTime());

        

        public static string timeStamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }

        public void clickAll(string id, int camp1, int camp2)
        {

            for (int i = camp1; i <= camp2; i = i + 2)
            {
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id(id + i)).Click();
            }


        }

        public static void selectDropDownClick(string by)
        {

            var vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count);
            if (vdd < 0) { vdd = vdd + 1; }
            if (vdd >= dd.Count) { vdd = vdd - 1; }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);

        }

        public static void selectDropDown(string by)
        {
            SelectElement vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count);
            if (vdd < 0) { vdd = 0; }
            if (vdd >= dd.Count) { vdd = vdd - 1; }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);

        }

        public static void ranclickOption(string[] id, int min, int max)
        {

            Random rand = new Random();
            int selOp = rand.Next(max - min) + 1;
            if (selOp >= id.Length)
            {
                selOp = selOp - 1;
            }
            for (int i = 1; i <= selOp; i++)
            {

                if (selOp == id.Length - 1)
                {
                    if (!driver.FindElement(By.Id(id[i])).Selected)
                    {
                        driver.FindElement(By.Id(id[i])).Click();
                        System.Threading.Thread.Sleep(300);
                    }
                }
                else
                {
                    int selc = rand.Next(max - min) + 1;
                    if (selc == id.Length)
                    {
                        selc = selc - 1;
                    }
                    if (!driver.FindElement(By.Id(id[i])).Selected)
                    {
                        driver.FindElement(By.Id(id[selc])).Click();
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

        }

        public static void elementClick(string byID)
        {
            driver.FindElement(By.Id(byID)).Click();

        }

        public static void notEmptyDropDown(string by)
        {
            SelectElement fDropDown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> fDsel = fDropDown.Options;
            if (fDsel.Count > 1)
            {
                selectDropDownClick(by);
            }
            System.Threading.Thread.Sleep(1000);
        }
        public static void ranSelection(string selId, int len1)
        {
            IList<IWebElement> mcCameras = driver.FindElements(By.XPath("//*[contains(@id, '" + selId + "')]"));
            caMe = mcCameras.ElementAt(0).GetAttribute("id");
            acam = mcCameras.ElementAt(mcCameras.Count - 1).GetAttribute("id");
            ad = Convert.ToInt16(caMe.Substring(len1));
            caMer = Convert.ToInt16(acam.Substring(len1));
        }

        public static void ranClick(String ranSel, String del, int min, int max)
        {// Elegir elemento al azar
            Random rand = new Random();

            delm = rand.Next((max - min) + 1) + min;
            if (delm < min) { delm = delm + 1; }
            if (delm > max) { delm = delm - 1; }
            if ((delm % 2) == 0)
            {
                delm = delm - 1;
            }
            if (delm < 10)
            {
                driver.FindElement(By.Id(ranSel + del + delm)).Click();
            }
            else
            {
                //No Comment
                driver.FindElement(By.Id(ranSel + delm)).Click();
            }

        }
        public static int ranNumbr(int min, int max)
        {
            Random rand = new Random();
            numbering = min + rand.Next((max - min) + 1);
            return numbering;

        }
        public static void takeScreenShot(string dir, string fname, string stmp)
        {
            ITakesScreenshot scrFile = driver as ITakesScreenshot;
            scrFile.GetScreenshot().SaveAsFile(dir + fname + stmp, ScreenshotImageFormat.Jpeg);

        }

        public static void selectDropDownClick2(string by)
        {
            SelectElement vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count) + 1;
            if (vdd <= 0) { vdd = vdd + 1; }

            if (vdd >= dd.Count) { vdd = dd.Count - 1; }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);

        }

        public static string dniLetra(int dni)
        {

            char dniLet = NIF_STRING_ASOCIATION.ElementAt(dni % 23);
            return string.Concat(dni) + dniLet;
        }

        public static int ranYearNumbr(int min, int max)
        {
            Random rand = new Random();
            numbering = min + rand.Next((max - min) + 1);
            return numbering;
        }

        public static void ranClick(string ranSel, int min, int max)
        {// Elegir elemento al azar
            Random rand = new Random();

            int d = rand.Next(min, max);
            if (d < min) { d = d + 1; }
            if (d > max) { d = d - 1; }
            if ((d % 2) == 0)
            {
                d = d - 1;
            }
            driver.FindElement(By.Id(ranSel + d)).Click();

        }


        public Boolean isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)

            {
                return false;
            }

        }
        public static DateTime dateSel(DateTime fromD, DateTime toD)
        {
            Random ran = new Random();
            var calF = toD - fromD;
            var randTimeSpan = new TimeSpan((long)(ran.NextDouble() * calF.Ticks));
            return fromD + randTimeSpan;

        }

        public static void borrarArchivosTemp(string tempPath)
        {
            string[] allfiles = Directory.GetFiles(tempPath, "*.*");

            foreach (string filesS in allfiles)
            {
                File.Delete(filesS);
            }


        }
    }

}