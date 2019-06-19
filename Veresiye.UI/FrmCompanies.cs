using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmCompanies : Form
    {
        //private readonly ICompanyService companyService;
        //private readonly FrmRegister frmRegister;
        public FrmCompanies(/*ICompanyService companyService*/)
        {
            //this.companyService = companyService;
         
            InitializeComponent();//mdiparent initial de belirlendiği için ! bundan sonra ekleeme yapıldı!!!!!!!
            //this.frmRegister.MdiParent = this;
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {

        }
    }
}
