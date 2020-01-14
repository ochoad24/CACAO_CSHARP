using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace REQUERIMIENTO_UNO
{
    public partial class frmHipotenusa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmHipotenusa()
        {
            InitializeComponent();
        }

        private void btnNuevoCalculo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCalculo frm = new frmCalculo();
            frm.ShowDialog();

        }
    }
}