using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUSA
{
    public class asusaVerPartes : ausaFieldsConfiguration
    {
        [TestInitialize]
        public void seTup()
        {
            driver = new ChromeDriver("C:\\Selenium");



        }
    }
