using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurante___Final
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Session["usuario"] != null)
            {
                lbl_username.Visible = true;
                lbl_username.Text = "Bienvenido " + this.Session["usuario"].ToString();
                HyperLink2.Visible = false;
                Btn_closeSession.Visible = true;
                if (this.Session["admin"].ToString() == "1")
                {
                    LinkBtnAdmin.Visible = true;
                }
                else
                    LinkBtnAdmin.Visible = false;
            }
            else
            {
                lbl_username.Visible = false;
                Btn_closeSession.Visible = false;
                HyperLink2.Visible = true;
                LinkBtnAdmin.Visible = false;
            }

        }

        protected void Btn_closeSession_Click(object sender, EventArgs e)
        {
            this.Session.Clear();
            Response.Redirect("~/Home.aspx");
        }

        protected void LinkBtnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin.aspx");
        }
    }
}