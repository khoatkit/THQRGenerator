using THQRGenerator.Utils;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace THQRGenerator.Forms
{
    public partial class RdlcViewer : Form
    {
        readonly ReportViewer viewer = new ReportViewer();
        public RdlcViewer(string name
            , List<KeyValuePair<string, object>> sourceList
            , List<KeyValuePair<string, string>> paramList = null
            , string displayName = "")
        {
            InitializeComponent();
            viewer = ReportUtil.CreateReport($@"Reports\{name}.rdlc", sourceList, paramList, displayName);
        }

        private void RdlcViewer_Load(object sender, EventArgs e)
        {
            this.Controls.Add(viewer);
        }

        private void RdlcViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            viewer.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
