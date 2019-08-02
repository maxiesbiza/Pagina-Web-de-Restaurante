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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * FROM ProductosMenu WHERE CategoriaID = " + Request.QueryString["Id"], con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
                Response.Redirect("~/Sesion.aspx");

            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;

            if (Session["PedidoID"] == null)
            {
                SqlConnection con = new SqlConnection(CS);

                SqlCommand insertPedido = new SqlCommand("spInsertPedidos", con);
                insertPedido.CommandType = CommandType.StoredProcedure;
                insertPedido.Parameters.AddWithValue("@NombreUsuarioID", Session["usuario"].ToString());
                insertPedido.Parameters.AddWithValue("@Confirmado", 0);
                con.Open();
                insertPedido.ExecuteNonQuery();
                con.Close();

                SqlConnection connection = new SqlConnection(CS);
                SqlCommand getPedido = new SqlCommand("spGetLastPedido", connection);
                getPedido.CommandType = CommandType.StoredProcedure;
                getPedido.Parameters.AddWithValue("@NombreUsuarioID", Session["usuario"].ToString());
                connection.Open();
                SqlDataReader registroNroPedido = getPedido.ExecuteReader();

                if (registroNroPedido.Read())
                {
                    Session["PedidoID"] = registroNroPedido["PedidoID"].ToString();
                }

                connection.Close();
            }

            string ProdID = this.GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;

            SqlConnection conexion = new SqlConnection(CS);
            SqlCommand command = new SqlCommand("SELECT * FROM ProductosMenu WHERE ProdID = " + ProdID, conexion);
            conexion.Open();
            SqlDataReader registro = command.ExecuteReader();

            if (registro.Read())
            {
                SqlConnection conn = new SqlConnection(CS);

                SqlCommand cmd = new SqlCommand("spInsertDetallePedido", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", int.Parse(Session["PedidoID"].ToString()));
                cmd.Parameters.AddWithValue("@NombreDetalle", registro["ProdNombre"]);
                cmd.Parameters.AddWithValue("@DescripcionDetalle", registro["ProdDescripcion"]);
                cmd.Parameters.AddWithValue("@PrecioDetalle", registro["ProdPrecio"]);
                conn.Open();
                cmd.ExecuteNonQuery();

                conexion.Close();
                conn.Close();
                Response.Redirect("~/Pedido.aspx");
            }
            conexion.Close();

        }
            
    }
}