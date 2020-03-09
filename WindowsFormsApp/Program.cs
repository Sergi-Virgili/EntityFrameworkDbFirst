using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using DataAccess;
using log4net;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            log4net.Config.XmlConfigurator.Configure();
            var student = new Student() 
            { 
                Name = "Sergi",
                Surname = "Virgili",
                AgeOfBirth = DateTime.Parse("29/04/1980"),
            };
            new StudentDao().Add(student);
        }
    }
}
