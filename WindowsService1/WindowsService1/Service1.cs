using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private static void LogWriteEvent(object source, ElapsedEventArgs e)
        {
            String Source = "TestService";
            String Log = "Application";
            String Event = "Coucou";

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, Log);
            }

            EventLog.WriteEntry(Source, Event);
        }

        protected override void OnStart(string[] args)
        {
            Timer temp = new Timer();
            temp.Elapsed += new ElapsedEventHandler(LogWriteEvent);
            temp.Interval = 60000;
            temp.Enabled = true;
        }

        protected override void OnStop()
        {
        }
    }
}
