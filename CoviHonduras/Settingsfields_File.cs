using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace CoviHonduras
{
    public class Settingsfields_File
    {
        public static string dateverTransacciones;
        public static string BoHostUrl = "http://virtualbo-qa/BOQAHostCoviHonduras/web/forms/core/login.aspx";
        public static string BoPlazaUrl = "http://virtualbo-qa/BOQAPlazaCoviHonduras/web/forms/core/login.aspx";
        public static string RUCid = "ctl00_ContentZone_ctrlAccountData_txt_RUC_box_data";
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
        public static string mcsVersion = "lbl_version";
        public static string confirmationMessage;
        public static Boolean errorTagAssignment = false;
        public static string tagIdNmbr;
        public static string[] colorS = new string[] { "Blanco", "Negro", "Azul", "Rojo", "Verde", "Amarillo" };
        public static string matletT = "TRWAGMYFPDXBNJZSQVHLCKE";
        public static string accountNumbr;
        public static int carSel;
        public static int carModel;
        public static string matriNu;
        public static string vehtypeModel;
        public static string vehtypeKind;
        public static string[,] cocheModels = { { "Seat", "Volkswagen", "Ford", "Fiat" }, { "Ibiza", "Polo", "Fiesta", "Punto" }, { "León", "Passat", "Focus", "Stilo" } };
        public static string[,] camionModels = { { "Mercedes-Benz", "Scania" }, { "Axor", "R500" }, { "Actros", "P400" } };
        public static string[,] furgonetaModels = { { "Mercedes-Benz", "Fiat" }, { "Vito", "Scudo" }, { "Citan", "Ducato" } };
        public static string[,] cicloModels = { { "Yamaha", "Honda" }, { "XT1200Z", "Forza 300" }, { "T-MAX SX", "X-ADV" } };
        public static string[,] autoBusModels = { { "DAIMLER-BENZ", "VOLVO" }, { "512-CDI", "FM-12380" }, { "DB 605", "FM 300" } };
        public static string Letter_Comb = "TRWAGMYFPDXBNJZSQVHLCKE";
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
        public static string CaCUrl = "http://virtualcac-qa/CACQACovihonduras/web/forms/core/login.aspx";
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
        public static string MCSUrl = "http://virtualmcs-qa/MCS_CoviHonduras";
        public static string MCSVersion;
        public static string BOVersion;
        public static string HMVersion;
        public static string[] nameOp = new String[] { "Pilar", "Mavi", "Franklyn", "Gemma", "Fatima", "Marc", "Miguel", "Francisco", "Oscar", "Maria" };
        public static string[] genderS = new String[] { "Femenino", "Femenino", "Masculino", "Femenino", "Femenino", "Masculino", "Masculino", "Masculino", "Masculino", "Femenino" };
        public static string[] sexSelc = new String[] { "Sra", "Sra", "Sr", "Sra", "Sra", "Sr", "Sr", "Sr", "Sr", "Sra" };
        public static string[] addressTec = new String[] { "CALLE SAN MAXIMO, 3", "CALLE SAN MAXIMO, 3", "Castanyer 29", "CALLE SAN MAXIMO, 3", "CALLE SAN MAXIMO, 3", "Catanyer 29", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo", "Edificio Tecsidel, P.T. de Boecillo" };
        public static string[] cpAdress = new String[] { "28041", "28041", "08022", "28041", "28041", "08022", "47151", "47151", "47151", "47151" };
        public static string[] townC = new String[] { "Madrid", "Madrid", "Barcelona", "Madrid", "Madrid", "Barcelona", "Valladolid", "Valladolid", "Valladolid", "Valladolid" };
        public static string[] workPhone1 = new String[] { "913530810", "913530810", "932922110", "913530810", "913530810", "932922110", "983546603", "983546603", "983546603", "983546603" };
        public static string[] lastNameOp = new String[] { "Bonilla", "Garrido", "Garcia", "Arjonilla", "Romano", "Navarro", "Sanchez", "Castro", "Bailon", "Blanco" };
        //Edit buttons icons configuration.	  	         
        public static string timet = timeStamp(new DateTime());

        public static string timeStamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }

        public static void takeScreenShot(string dir, string fname, string stmp)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            ITakesScreenshot scrFile = driver as ITakesScreenshot;
            scrFile.GetScreenshot().SaveAsFile(dir + fname + stmp, ScreenshotImageFormat.Jpeg);
        }

        public static void borrarArchivosTemp(string tempPath)
        {
            if (Directory.Exists(tempPath)){
                string[] allfiles = Directory.GetFiles(tempPath, "*.*");
                foreach (string filesS in allfiles)
                {
                    File.Delete(filesS);
                }
            }
        }

        public static void selectDropDownClick(string by)
        {
            var vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count);
            if (vdd < 0) {
                vdd = vdd + 1;
            }
            if (vdd >= dd.Count) {
                vdd = vdd - 1;
            }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);
        }

        public static void elementClick(string byID)
        {
            driver.FindElement(By.Id(byID)).Click();
        }

        public static void loginPage (string usr, string pwd)
        {
            driver.FindElement(By.Id(loginField)).SendKeys(usr);
            driver.FindElement(By.Id(passField)).SendKeys(pwd);
            driver.FindElement(By.Id(loginButton)).Click();
            System.Threading.Thread.Sleep(1000);
        }

        public static void selectDropDown(string by)
        {
            SelectElement vDropdown = new SelectElement(driver.FindElement(By.Id(by)));
            IList<IWebElement> dd = vDropdown.Options;
            Random rand = new Random();
            int vdd = rand.Next(dd.Count);
            if (vdd < 0) {
                vdd = 0;
            }
            if (vdd >= dd.Count) {
                vdd = vdd - 1;
            }
            new SelectElement(driver.FindElement(By.Id(by))).SelectByIndex(vdd);
        }

        public static DateTime dateSel(DateTime fromD, DateTime toD)
        {
            Random ran = new Random();
            var calF = toD - fromD;
            var randTimeSpan = new TimeSpan((long)(ran.NextDouble() * calF.Ticks));
            return fromD + randTimeSpan;
        }

        public static int ranNumbr(int min, int max)
        {
            Random rand = new Random();
            numbering = min + rand.Next((max - min) + 1);
            return numbering;
        }

     	/*public static String dniLetra (int dni){
  		  return String.valueOf(dni)+(NIF_STRING_ASOCIATION.charAt(dni % 23));
  	  }*/

    }
}
