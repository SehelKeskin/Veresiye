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
        private readonly ICompanyService companyService;
        public FrmAdd frmAdd;
        public FrmEdit frmEdit;
        //private readonly FrmRegister frmRegister;
        public FrmCompanies(CompanyService companyService, FrmAdd frmAdd, FrmEdit frmEdit)
        {
         
            this.companyService = companyService;
         
            InitializeComponent();
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {
            LoadCompanies();

        }
        public void LoadCompanies()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = companyService.GetAll();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        { 
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            companyService.Delete(id);
            LoadGrid();
        }


        public void LoadGrid()
        {
            dataGridView1.DataSource = companyService.GetAll();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
