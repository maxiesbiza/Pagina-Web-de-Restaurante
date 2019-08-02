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
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                BindDropDownList();
            }            
        }

        private void BindGridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductosMenu WHERE CategoriaID = " + Session["CategoriaID"].ToString(), con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                GridViewCategoria.DataSource = dt;
                GridViewCategoria.DataBind();
            }
        }

        private void BindDropDownList()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("SELECT * FROM CategoriasMenu", con);
            con.Open();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            listCategorias.DataSource = dt;
            listCategorias.DataBind();
            listCategorias.DataTextField = "CategoriaNombre";
            listCategorias.DataValueField = "CategoriaID";
            listCategorias.DataBind();
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                SqlCommand cmd = new SqlCommand("INSERT INTO CategoriasMenu values ('" + txtNombreCategoria.Text
                    + "')", con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Categoría Agregada');</script>");
                    txtNombreCategoria.Text = "";
                    BindDropDownList();
                }
                catch
                {
                    Response.Write("<script>alert('Algo salió mal');</script>");
                    txtNombreCategoria.Text = "";
                }
                con.Close();
            }            
        }

        protected void GridViewCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductosMenu WHERE ProdID = " + this.GridViewCategoria.Rows[GridViewCategoria.SelectedIndex].Cells[0].Text, conexionSQL);

            conexionSQL.Open();

            try
            {
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    txtModProdID.Text = registro["ProdID"].ToString();
                    txtModProdTitulo.Text = registro["ProdNombre"].ToString();
                    txtModProdDescrip.Text = registro["ProdDescripcion"].ToString();
                    txtModProdPrecio.Text = registro["ProdPrecio"].ToString();
                }
            }
            catch
            {
                Response.Write("<script>alert('Algo salió mal');</script>");
            }
            conexionSQL.Close();
        }

        protected void listCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCatID.Text = listCategorias.SelectedValue;
            txtCambiarNomCat.Text = listCategorias.SelectedItem.ToString();
        }

        protected void btnCambiarNomCat_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("UPDATE CategoriasMenu SET CategoriaNombre = '" + 
                txtNombreCategoria.Text + "' WHERE CategoriaID = '" + lblCatID.Text, con);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Categoría Modificada');</script>");
                txtCambiarNomCat.Text = "";
                BindDropDownList();
            }
            catch
            {
                Response.Write("<script>alert('Algo salió mal');</script>");
                txtCambiarNomCat.Text = "";
            }
            con.Close();
        }

        protected void btnCargarCat_Click(object sender, EventArgs e)
        {
            Session["CategoriaID"] = listCategorias.SelectedValue;
            lblNomCat.Text = "Categoría " + listCategorias.SelectedItem.Text;
            BindGridView();
        }

        protected void btnAgrProd_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("INSERT INTO ProductosMenu VALUES (" + Session["CategoriaID"].ToString()
                + ",'" + txtAgrNombreProd.Text + "','" + txtAgrDescProd.Text + "',CONVERT(float," + txtAgrPrecProd.Text + 
                "),1)", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                BindGridView();
                Response.Write("<script>alert('¡Producto Agrgado!');</script>");
                txtAgrNombreProd.Text = "";
                txtAgrDescProd.Text = "";
                txtAgrPrecProd.Text = "";
            }
            catch
            {
                Response.Write("<script>alert('Algo salió mal');</script>");
            }
            con.Close();
        }

        protected void btnActualizarProd_Click(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);            
            SqlCommand cmd = new SqlCommand("UPDATE ProductosMenu SET ProdNombre = '" + txtModProdTitulo.Text +
                "', ProdDescripcion = '" + txtModProdDescrip.Text + "', ProdPrecio = '" + txtModProdPrecio.Text +
                "' WHERE ProdID = '" + txtModProdID.Text + "'", conexionSQL);
            conexionSQL.Open();
            try
            {
                cmd.ExecuteNonQuery();
                lblRespuesta.Text = "Producto Actualizado";
                BindGridView();
                txtModProdID.Text = "";
                txtModProdDescrip.Text = "";
                txtModProdPrecio.Text = "";
                txtModProdTitulo.Text = "";
                Response.Write("<script>alert('Producto Actualizado Correctamente');</script>");
            }
            catch
            {
                lblRespuesta.Text = "Algo salio mal";
            }
            
            conexionSQL.Close();
        }

        protected void btnBorrarProd_Click(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("DELETE FROM ProductosMenu WHERE ProdID = " + txtModProdID.Text, conexionSQL);

            conexionSQL.Open();

            int cantidad = cmd.ExecuteNonQuery();
            if (cantidad == 1)
                lblRespuesta.Text = "Se borró la promocion";
            else
                lblRespuesta.Text = "Algo salió mal";
            BindGridView();
            txtModProdID.Text = "";
            txtModProdDescrip.Text = "";
            txtModProdPrecio.Text = "";
            txtModProdTitulo.Text = "";

            conexionSQL.Close();
        }
    }
}