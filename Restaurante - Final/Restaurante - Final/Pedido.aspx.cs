using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurante___Final
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spGetDetallePedido", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PedidoID", Session["PedidoID"].ToString());
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch {}
            
            
            
        }

        protected void BtnConfirmar_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("UPDATE Pedidos SET Confirmado = 1 WHERE PedidoID = " + Session["PedidoID"].ToString(), con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('¡Pedido Confirmado!');</script>");
                BindGridView();
            }
            catch
            {
                Response.Write("<script>alert('Algo salio mal');</script>");
            }
            con.Close();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("DELETE FROM DetallePedido WHERE PedidoID = " + Session["PedidoID"].ToString(), con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Pedidos WHERE PedidoID = " + Session["PedidoID"].ToString(), con);
                Response.Write("<script>alert('¡Pedido Cancelado!');</script>");
                BindGridView();
            }
            catch
            {
                Response.Write("<script>alert('Algo salio mal');</script>");
            }
            con.Close();
        }
    }
}