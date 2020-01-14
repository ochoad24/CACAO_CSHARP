using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace REQUERIMIENTO_UNO
{
    public partial class frmUsuario : DevExpress.XtraEditors.XtraForm
    {
        double hipotenusa;
        public frmUsuario(double resultado)
        {
            hipotenusa = resultado;
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = txtNombre.Text.ToString();
                int edad = Convert.ToInt32(txtEdad.Text.ToString());
                String lugar = txtLugar.Text.ToString();
                string query= "INSERTAR_NUEVO";
                using (MySqlCommand cmd = new MySqlCommand(query, ClassConexion.cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@NOMBRE", MySqlDbType.VarChar).Value = nombre;
                        cmd.Parameters.Add("@EDAD", MySqlDbType.VarChar).Value = edad;
                        cmd.Parameters.Add("@LUGAR", MySqlDbType.VarChar).Value = lugar;
                        cmd.Parameters.Add("@HIPOTENUSA", MySqlDbType.Float).Value = hipotenusa;
                        ClassConexion.cn.Open();
                        cmd.ExecuteNonQuery();
                        XtraMessageBox.Show("Se agrego el nuevo calculo.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (MySqlException exception)
                    {
                        XtraMessageBox.Show("Error" + exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        ClassConexion.cn.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}