using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClient
{
    public partial class serviceClient : Form
    {
        public serviceClient()
        {
            InitializeComponent();
        }

        // POI: This button event handler invokes a Web Service not a WCF Service
        private void btnInvokeService_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBxName.Text))
            {
                var serviceClient = new HelloWorldServiceClient.WebServiceOneSoapClient();
                lblReturnedValue.Text = serviceClient.GetMessage(txtBxName.Text);
            }
        }

        // POI: This event handler invokes a WCF service
        private void btnLibraryService_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBxName.Text))
            {
                var serviceClient = new HelloServiceWCF.HelloServiceClient("BasicHttpBinding_IHelloService");
                lblReturnedValue.Text = serviceClient.Transform(txtBxName.Text);
            }
        }
    }
}
