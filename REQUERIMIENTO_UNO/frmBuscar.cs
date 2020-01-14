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
    public partial class frmBuscar : DevExpress.XtraEditors.XtraForm
    {
        double hipotenusa;
        public frmBuscar(double resultado)
        {
            hipotenusa = resultado;
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        int Usuario;
        bool Estado;
        private void frmBuscar_Load(object sender, EventArgs e)
        {
            string query = "SELECT idusuarios,nombre FROM usuarios;";
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, ClassConexion.cn))
            {
                try
                {
                    da.Fill(dt);
                    Usuarios.Properties.DisplayMember = "nombre";
                    Usuarios.Properties.ValueMember = "idusuarios";
                    Usuarios.Properties.DataSource = dt;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    da.Dispose();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERTAR_BUSQUEDA";
                using (MySqlCommand cmd = new MySqlCommand(query, ClassConexion.cn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = Usuarios.EditValue;
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}