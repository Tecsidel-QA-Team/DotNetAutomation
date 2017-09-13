using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SENAC
{
    [TestClass]
    public class gestiondeFonds_Reddition : senacFieldsConfiguration
    {
        [TestInitialize]
        public void setUp()
        {
            driver = new ChromeDriver();//opts); poner esta opción cuando se vaya a subir al Git
            driver.Manage().Window.Maximize();

        }

        [TestMethod]
        public void FondsReddition()
        {
            Actions action = new Actions(driver);
            projectSel = "Proyecto de test";
            fileDatafilled = "RedditionPageDataFilled";
            folderSel = "E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments";
            borrarArchivosTemp("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\");
            fileError = "RedditionErr";
            try
            {
                driver.Navigate().GoToUrl("http://virtualbo-qa/BOQAPlazaSenac");
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "loginPlazatSenacPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", "loginPlazaSenacPage","");
                driver.FindElement(By.Id(loginField)).SendKeys("00001");
                driver.FindElement(By.Id(passField)).SendKeys("00001");
                driver.FindElement(By.Id(loginButton)).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "homePlazatSenacPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", "homePlazaSenacPage","");
                System.Threading.Thread.Sleep(2000);
                action.ClickAndHold(driver.FindElement(By.LinkText("Gestion des fonds"))).Build().Perform();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Reddition")).Click();
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "RedditionPage_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", "RedditionPage","");
                System.Threading.Thread.Sleep(1000);
                selectDropDown("ctl00_ContentZone_cmb_numBags_cmb_dropdown");
                System.Threading.Thread.Sleep(1000);
                IWebElement bagsnumbr = new SelectElement(driver.FindElement(By.Id("ctl00_ContentZone_cmb_numBags_cmb_dropdown"))).SelectedOption;
                String bagNum = bagsnumbr.Text;
                System.Threading.Thread.Sleep(500);
                for (int i = 1; i <= Int32.Parse(bagNum); i++)
                {
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C5_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C10_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C25_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C50_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C100_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C200_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C250_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01C500_" + i)).SendKeys(ranNumbr(1, 4) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N500_" + i)).SendKeys(ranNumbr(1, 5) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N1000_" + i)).SendKeys(ranNumbr(1, 5) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N2000_" + i)).SendKeys(ranNumbr(1, 5) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N5000_" + i)).SendKeys(ranNumbr(1, 5) + "");
                    System.Threading.Thread.Sleep(200);
                    driver.FindElement(By.Id("ctl00_ContentZone_NumberCASH01N10000_" + i)).SendKeys(ranNumbr(1, 5) + "");
                }
                System.Threading.Thread.Sleep(500);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberCH201")).SendKeys(ranNumbr(1, 5) + "");
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberCH202")).SendKeys(ranNumbr(1000, 10000) + "");
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberVO01201")).SendKeys(ranNumbr(1, 5) + "");
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberVO01202")).SendKeys(ranNumbr(1000, 10000) + "");
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberOM201")).SendKeys(ranNumbr(1, 5) + "");
                System.Threading.Thread.Sleep(200);
                driver.FindElement(By.Id("ctl00_ContentZone_NumberOM202")).SendKeys(ranNumbr(1000, 10000) + "");
                System.Threading.Thread.Sleep(1000);
                takeScreenShot("E:\\Selenium\\", "RedditionPageDataFilled_" , timet);
                takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", "RedditionPageDataFilled","");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_ButtonsZone_BtnSubmit")).Click();
                System.Threading.Thread.Sleep(400);
                if (isAlertPresent())
                {
                    driver.SwitchTo().Alert().Accept();
                }
                System.Threading.Thread.Sleep(3000);
                if (!isAlertPresent())
                {
                    System.Threading.Thread.Sleep(3000);
                    nextPTitle = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                    if (nextPTitle.Contains("Reddition"))
                    {
                        errorLev = driver.FindElement(By.Id("ctl00_LblError")).Text;
                        if (errorLev.Contains("une erreur interne"))
                        {
                            additionalTitle = "No se puede crear Reddition a causa de: ";
                            descriptionSubject = "No se ha podido crear una Reddition debido a un error en la creación, mirar el arhivo RedditionErr.jpg para mas detalles";
                            Console.WriteLine(errorLev);
                            takeScreenShot("E:\\Selenium\\", fileError + "_" , timet);
                            takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", fileError ,"");
                            System.Threading.Thread.Sleep(1000);
                            crearIncidenciaRedMine.createIncidence();
                            Assert.Fail(errorLev);
                            return;
                        }
                    }
                }
                if (isAlertPresent())
                {
                    driver.SwitchTo().Alert().Accept();
                    System.Threading.Thread.Sleep(4000);
                    nextPTitle = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                    if (nextPTitle.Equals("Reddition"))
                    {
                        takeScreenShot("E:\\Selenium\\", "RedditionCreated_" , timet );
                        takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", "RedditionCreated","");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Se ha creado correctamente Reddition");
                        return;
                    }
                    if (nextPTitle.Contains("Une erreur a été detectée"))
                    {
                        System.Threading.Thread.Sleep(1500);
                        additionalTitle = "No se puede crear Reddition a causa de: ";
                        descriptionSubject = "No se ha podido crear una Reddition debido a un error en la creación, mirar el arhivo RedditionErr.jpg para mas detalles";
                        errorLev = driver.FindElement(By.Id("ctl00_ContentZone_lblMsg")).Text;
                        takeScreenShot("E:\\Selenium\\", fileError + "_" , timet );
                        takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", fileError , "");
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine(errorLev);
                        System.Threading.Thread.Sleep(1000);
                        driver.Quit();
                        crearIncidenciaRedMine.createIncidence();
                        Assert.Fail(errorLev);
                        return;

                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                    nextPTitle = driver.FindElement(By.Id("ctl00_SectionZone_LblTitle")).Text;
                    if (nextPTitle.Contains("Une erreur a été detectée"))
                    {
                        System.Threading.Thread.Sleep(1500);
                        additionalTitle = "No se puede crear Reddition a causa de: ";
                        descriptionSubject = "No se ha podido crear una Reddition debido a un error en la creación, mirar el arhivo RedditionErr.jpg para mas detalles";
                        errorLev = driver.FindElement(By.Id("ctl00_ContentZone_lblMsg")).Text;
                        takeScreenShot("E:\\Selenium\\", fileError + "_" , timet );
                        takeScreenShot("E:\\workspace\\Mavi_Repository\\gestionFonds_Reddition\\attachments\\", fileError , "");
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine(errorLev);
                        System.Threading.Thread.Sleep(1000);
                        crearIncidenciaRedMine.createIncidence();
                        Assert.Fail(errorLev);
                        return;
                    }
                }
                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception e)
            {
                e.GetBaseException();
                Assert.Fail();
            }
        }
        public static Boolean isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException e)
            {
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
