using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Model;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmCompanyEdit : Form
    {
        private readonly ICompanyService companyService;
        private readonly IActivityService activityService;
        private readonly FrmActivityAdd frmActivityAdd;
        public FrmCompanies MasterForm { get; set; }
    
     
        public FrmCompanyEdit(ICompanyService companyService, IActivityService activityService, FrmActivityAdd frmActivityAdd)
        {
            this.activityService = activityService;
            this.companyService = companyService;
            this.frmActivityAdd = frmActivityAdd;

            
            InitializeComponent();
            this.frmActivityAdd.MdiParent = this.MdiParent;
            this.frmActivityAdd.MasterForm = this;
        }

      

        private void FrmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
          
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          
           

        }
       
        private int Id;
        public void LoadForm(int id)
        {
            var company = companyService.Get(id);
            this.Id = id;
            
            txtname.Text = company.Name;
            txtcity.Text = company.City;
            txtphone.Text = company.Phone;
            txtregion.Text = company.Region;
            LoadActivities();
        }

        public void LoadActivities()
        {
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = activityService.GetAllByCompanyId(this.Id);
        }
        private void FrmAdd_Load(object sender, EventArgs e)
        {
            this.FormClosing += FrmAdd_FormClosing;
           



        }
        private void FrmAdd_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
           
            this.Hide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //Validasyonlar
            if (txtname.Text == "")//builderlara bağlı!! zorunlu alanları yapacaksın.
            {
                MessageBox.Show("Ad giriniz"); return;
            }
            else if (txtphone.Text == "")
            {
                MessageBox.Show("Phone giriniz"); return;
            }

            var companyy = companyService.Get(this.Id);
            companyy.Name = txtname.Text;
            companyy.City = txtcity.Text;
            companyy.Phone = txtphone.Text;
            companyy.Region = txtregion.Text;
            companyService.Update(companyy);

            MessageBox.Show("Kullanıcı başarıyla oluşturuldu.");

            MasterForm.LoadCompanies();
            this.Hide(); //bilerek close demedik çünkü siliniyordu bilgiler.

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmActivityAdd.Show();
            frmActivityAdd.LoadForm();

        }
    }
}
