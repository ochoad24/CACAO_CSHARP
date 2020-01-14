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

namespace REQUERIMIENTO_UNO
{
    public partial class frmCalculo : DevExpress.XtraEditors.XtraForm
    {
        public frmCalculo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double A = Convert.ToDouble(txtCatetoA.Text.ToString());
                double B = Convert.ToDouble(txtCatetoB.Text.ToString());
                double hipotenusa = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
                XtraMessageBox.Show("La hipotenusa es: "+hipotenusa.ToString(), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (XtraMessageBox.Show("Ya tienes un usuario?", "Pregunta", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    frmBuscar frm = new frmBuscar(hipotenusa);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                    this.Close();
                }
                else
                {
                    frmUsuario frm = new frmUsuario(hipotenusa);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCalculo_Load(object sender, EventArgs e)
        {

        }
    }
}