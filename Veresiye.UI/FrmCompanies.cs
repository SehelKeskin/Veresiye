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
        private readonly FrmAdd frmAdd;
        private readonly FrmCompanyEdit frmCompanyEdit;
        //private readonly FrmRegister frmRegister;
        public FrmCompanies(ICompanyService companyService, FrmAdd frmAdd, FrmCompanyEdit frmCompanyEdit)
        {
            
            this.companyService = companyService;
            this.frmAdd = frmAdd;
           this.frmCompanyEdit = frmCompanyEdit;
         
            InitializeComponent();
           
            this.frmAdd.MasterForm = this;
            this.frmAdd.MdiParent = this.MdiParent;

            this.frmCompanyEdit.MasterForm = this;
            this.frmCompanyEdit.MdiParent = this.MdiParent;
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
           

             

            if (this.dataGridView1.SelectedRows.Count>0)
            { var cevap = MessageBox.Show("Silmek istediğinize emin misiniz?", "Dİkkat!", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                companyService.Delete(id);
                LoadCompanies();
                }
                else
                {
                    MessageBox.Show("Silme işlemi gerçekleştirilmiyor");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz Firmayı seçiniz!");
            }
           
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmAdd.Show();
            this.frmAdd.ClearForm();//form açılırken temizlenmesi için!
            
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count>0)
            {
               
               int selectedId=int.Parse( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                frmCompanyEdit.Show();
                frmCompanyEdit.LoadForm(selectedId);
              
                
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz firmayı seçiniz");
            }
           
        }
    }
}
