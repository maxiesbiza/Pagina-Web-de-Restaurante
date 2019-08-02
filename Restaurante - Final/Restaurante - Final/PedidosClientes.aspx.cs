using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurante___Final
{
    public partial class PedidosClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
            
        }

        private void BindGridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetPedidosConfirmados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("SELECT * FROM DetallePedido WHERE PedidoID = " + this.GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text, conexionSQL);
            conexionSQL.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                GridViewDetalle.DataSource = dt;
                GridViewDetalle.DataBind();
                
                lblTo.Text = this.GridView1.Rows[GridView1.SelectedIndex].Cells[2].Text;


            }
            catch
            {
                Response.Write("<script>alert('Algo salio mal');</script>");
            }

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("SELECT * FROM DetallePedido WHERE PedidoID = " + this.GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text, conexionSQL);
            conexionSQL.Open();

            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("lenguajes32019@gmail.com");
                msg.To.Add(lblTo.Text);
                msg.Subject = "Tu pedido";
                msg.Body = txtMsg.Text;
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("lenguajes32019@gmail.com", "lenguajes3cuenta");
                sc.EnableSsl = true;
                sc.Send(msg);
                Response.Write("<script>alert('El correo ha sido enviado');</script>");
            }
            catch (Exception ex)
            {
            }
        }
    }
}