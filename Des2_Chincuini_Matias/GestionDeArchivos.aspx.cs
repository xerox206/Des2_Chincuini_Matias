using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Des2_Chincuini_Matias
{
    public partial class GestionDeArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        public void cargarGrilla()
        {
            if (Session["username"] != null)
            {
                string sesion = Session["username"].ToString();
                string path = $"{Server.MapPath(".")}/files/{sesion}";
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);
                    List<Archivo> fileList = new List<Archivo>();
                    foreach (string file in files)
                    {
                        var fileNew = new Archivo(Path.GetFileName(file), file);
                        fileList.Add(fileNew);
                    }
                    GridView1.DataSource = fileList;
                    GridView1.DataBind();
                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (Session["username"] != null)
            {
                string sesion= Session["username"].ToString();
                string path = $"{Server.MapPath(".")}/files/{sesion}";
            
            
                string result = string.Empty;
            
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (HttpPostedFile archivo in FileUpload1.PostedFiles) 
                {
                    if (File.Exists($"{path}/{archivo.FileName}"))
                    {
                        result += $"El archivo {archivo.FileName} ya existe - ";
                    }
                    else
                    {
                        FileUpload1.SaveAs($"{path}/{archivo.FileName}");
                    }
                
                
                }
                Label1.Text = result;
                cargarGrilla();
                }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Descargar")
            {
                GridViewRow registro = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                string filePath = registro.Cells[2].Text;

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename="+ Path.GetFileName(filePath));
                Response.TransmitFile(filePath);
                Response.End();
            }
        }
    }
}