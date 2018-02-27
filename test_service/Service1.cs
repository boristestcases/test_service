using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace test_service
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false))
                .Company;
            string product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(
                    Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute), false))
                .Product;
            // Console.WriteLine(company+" "+product);
            Logging.WriteLog("старт");
            regUpdater.WriteKey(company, product);
        }

        protected override void OnStop()
        {
            Logging.WriteLog("стоп");
            Logging.Close();
        }
    }
}
