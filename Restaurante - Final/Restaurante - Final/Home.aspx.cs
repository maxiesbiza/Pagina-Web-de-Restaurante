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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindImageRepeater();
                BindRepeaterMenu();
            }
            Repeater1.ItemCommand += new RepeaterCommandEventHandler(Repeater1_ItemCommand);
            RepeaterMenu.ItemCommand += new RepeaterCommandEventHandler(RepeaterMenu_ItemCommand1);
            
        }

        void RepeaterMenu_ItemCommand1(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btnCat")
            {
                string CategoriaID = ((LinkButton)e.CommandSource).CommandArgument;
                Response.Redirect("~/Productos.aspx?Id=" + CategoriaID);
            }
        }

        void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btnPedido")
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

                string PromoID = ((LinkButton)e.CommandSource).CommandArgument;
                
                SqlConnection conexion = new SqlConnection(CS);
                SqlCommand command = new SqlCommand("SELECT * FROM Promos WHERE PromoID = " + PromoID, conexion);
                conexion.Open();
                SqlDataReader registro = command.ExecuteReader();

                if (registro.Read())
                {
                    SqlConnection conn = new SqlConnection(CS);

                    SqlCommand cmd = new SqlCommand("spInsertDetallePedido", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PedidoID", int.Parse(Session["PedidoID"].ToString()));
                    cmd.Parameters.AddWithValue("@NombreDetalle", registro["Titulo"]);
                    cmd.Parameters.AddWithValue("@DescripcionDetalle", registro["Descripcion"]);
                    cmd.Parameters.AddWithValue("@PrecioDetalle", registro["Precio"]);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conexion.Close();
                    conn.Close();
                    Response.Redirect("~/Pedido.aspx");
                }
                conexion.Close();
                

            }
        }

        private void BindImageRepeater()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetPromos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        private void BindRepeaterMenu()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CategoriasMenu", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                RepeaterMenu.DataSource = dt;
                RepeaterMenu.DataBind();
            }
        }

        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }
    }
}