using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurante___Final
{
    public partial class Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        { if (IsValid)
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();

                SqlCommand comando = new SqlCommand("select NombreID from Usuarios where NombreID = '"
                                                    + this.txtbox_login_username.Text + "' and ClaveUsuario = '"
                                                    + this.txtbox_login_pass.Text + "'", conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    if (registro["NombreID"].ToString() == "admin")
                        Session["admin"] = "1";
                    else
                        Session["admin"] = "0";
                    this.lbl_login.Text = "Bienvenido " + registro["NombreID"];
                    Session["usuario"] = txtbox_login_username.Text;
                    this.lbl_login.Text = Session["usuario"].ToString();
                    Response.Redirect("~/Home.aspx");
                }


                else
                    this.lbl_login.Text = "No existe un usuario con dicho nombre/clave";
                conexion.Close();
            }
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string s = System.Configuration.ConfigurationManager.ConnectionStrings["cadenaconexion1"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();

                SqlCommand comando = new SqlCommand("insert into Usuarios(NombreID,ClaveUsuario,MailUsuario,TelefonoUsuario) values('" +
                                                      this.txtbox_reg_username.Text + "','" + this.txtbox_reg_pass.Text + "','" +
                                                      this.txtbox_reg_mail.Text + "','" + this.txtbox_reg_telefono.Text + "')", conexion);
                try
                {
                    comando.ExecuteNonQuery();
                    Label1.Text = "Se registró el usuario";
                    conexion.Close();
                    try
                    {
                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("lenguajes32019@gmail.com");
                        msg.To.Add(txtbox_reg_mail.Text);
                        msg.Subject = "Gracias por ser parte";
                        msg.Body = "Tenemos una amplia variedad de comidas";
                        SmtpClient sc = new SmtpClient("smtp.gmail.com");
                        sc.Port = 25;
                        sc.Credentials = new NetworkCredential("lenguajes32019@gmail.com", "lenguajes3cuenta");
                        sc.EnableSsl = true;
                        sc.Send(msg);
                        Response.Write("<script>alert('Te hemos enviado un correo');</script>");
                    }
                    catch (Exception ex)
                    {

                    }
                    txtbox_reg_username.Text = null;
                    txtbox_reg_pass.Text = null;
                    txtbox_pass_confirm.Text = null;
                    txtbox_reg_mail.Text = null;
                    txtbox_reg_telefono.Text = null;

                    
                }
                catch
                {
                    txtbox_reg_username.Text = null;
                    this.Label1.Text = "";
                    Response.Write("<script>alert('Nombre de Usurio ya existente');</script>");
                }
                conexion.Close();
            }            

        }
        
    }
}