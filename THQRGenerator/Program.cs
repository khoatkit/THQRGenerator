using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Threading.Tasks;
using System.Windows.Forms;
using THQRGenerator.Utils;

namespace THQRGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LifetimeServices.LeaseTime = TimeSpan.FromSeconds(5);
            LifetimeServices.LeaseManagerPollTime = TimeSpan.FromSeconds(5);
            LifetimeServices.RenewOnCallTime = TimeSpan.FromSeconds(1);
            LifetimeServices.SponsorshipTimeout = TimeSpan.FromSeconds(5);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Forms.DiemDanhCoDongForm());
            //Application.Run(new Forms.DanhBoForm());
            //Application.Run(new Forms.KiemKeForm());
            QRCodeUtil.ExportQrToFile(400);
        }
    }
}
