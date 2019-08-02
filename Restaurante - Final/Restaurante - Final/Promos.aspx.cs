using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Restaurante___Final
{
    public partial class Promos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                if (Session["admin"].ToString() != "1")
                {
                    Response.Redirect("~/Home");
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
            BindGridView();
        }

        protected void btnSubirPromo_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    if (SubirImg.PostedFile != null)
                    {
                        string FileName = Path.GetFileName(SubirImg.PostedFile.FileName);
                        //Save files to disk  
                        SubirImg.SaveAs(Server.MapPath("imagenes/" + FileName));
                        //Add Entry to DataBase  
                        string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlCommand cmd = new SqlCommand("spInsertPromos", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            cmd.Parameters.AddWithValue("@Titulo", TxtBoxTitulo.Text);
                            cmd.Parameters.AddWithValue("@Descripcion", TxtBoxDesc.Text);
                            cmd.Parameters.AddWithValue("@Precio", TxtBoxPrecio.Text);
                            cmd.Parameters.AddWithValue("@ImageName", FileName);
                            cmd.Parameters.AddWithValue("@ImagePath", "imagenes/" + FileName);
                            cmd.ExecuteNonQuery();
                            BindGridView();

                        }
                    }

                }
                catch (Exception)
                {
                    Lblcatch.Text = "No se pudo subir. Falta algún valor.";
                }
            }
            
                                                               
           
        }




        private void BindGridView()
        {
            string CS = ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPromos", con);
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Promos WHERE PromoID = " + this.GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text, conexionSQL);

            conexionSQL.Open();

            try
            {
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    txtModPromoID.Text = registro["PromoID"].ToString();
                    txtModTitulo.Text = registro["Titulo"].ToString();
                    txtModDescrip.Text = registro["Descripcion"].ToString();
                    txtModPrecio.Text = registro["Precio"].ToString();
                    ImageMod.ImageUrl = registro["ImagePath"].ToString();
                    lblNombreImg.Text = registro["ImageName"].ToString();
                }
            }
            catch
            {
                Lblcatch.Text = this.GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
            }
            conexionSQL.Close();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            string nombreImg;
            try
            {
                nombreImg = Path.GetFileName(FileUploadMod.PostedFile.FileName);
                //Save files to disk  
                FileUploadMod.SaveAs(Server.MapPath("imagenes/" + nombreImg));
            }
            catch
            {
                nombreImg = lblNombreImg.Text;
            }
            SqlCommand cmd = new SqlCommand("UPDATE Promos SET Titulo = '" + txtModTitulo.Text +
                "', Descripcion = '" + txtModDescrip.Text + "', Precio = '" + txtModPrecio.Text +
                "', ImageName = '" + nombreImg + "', ImagePath = '" + "imagenes/" + nombreImg +
                "' WHERE PromoID = '" + txtModPromoID.Text + "'", conexionSQL);
            conexionSQL.Open();
            try
            {
                cmd.ExecuteNonQuery();
                lblRespuesta.Text = "Promoción Actualizada";
                Response.Write("<script>alert('Promoción Actualizada Correctamente');</script>");
                txtModDescrip.Text = "";
                txtModPrecio.Text = "";
                txtModPromoID.Text = "";
                txtModTitulo.Text = "";
                BindGridView();
            }
            catch
            {
                lblRespuesta.Text = "Algo salió mal";
                Response.Write("<script>alert('Algo salio mal');</script>");
            }     
            
            conexionSQL.Close();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
            SqlConnection conexionSQL = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("DELETE FROM Promos WHERE PromoID = " + txtModPromoID.Text, conexionSQL);

            conexionSQL.Open();
            int cantidad = cmd.ExecuteNonQuery();
            if (cantidad == 1)
            {
                lblRespuesta.Text = "Se borró la promocion";
                Response.Write("<script>alert('Borrada exitosamente');</script>");
                BindGridView();
            }

            else
            {
                lblRespuesta.Text = "Algo salió mal";
                Response.Write("<script>alert('Algo salió mal');</script>");
            }
                

            conexionSQL.Close();
        }

        
        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOriginal, int Alto)
        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaImagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRedimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRedimencionada;
        }
               
    }
}