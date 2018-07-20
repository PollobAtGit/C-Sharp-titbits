using CircleMvp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CircleMvp.Form
{
    public partial class Radius : Page, IView
    {
        Presenter.Presenter Presenter { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            Presenter = new Presenter.Presenter(this);
        }

        protected void Page_Load(object sender, EventArgs e) { }

        public string RadiusText
        {
            get { return TextRadiusTxt.Text; }
            set { TextRadiusTxt.Text = value; }
        }

        public string ResultText
        {
            get { return LabelResultLbl.Text; }
            set { LabelResultLbl.Text = value; }
        }

        protected void ButtonResult_Click(object sender, EventArgs e)
        {
            Presenter.CalculateCircleArea();
        }
    }
}