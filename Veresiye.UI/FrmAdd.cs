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
    public partial class FrmAdd : Form
    {
        private readonly ICompanyService companyService;
        public FrmCompanies MasterForm { get; set; }
    
     
        public FrmAdd(ICompanyService companyService)
        {
            
            this.companyService = companyService;
            InitializeComponent();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            this.FormClosing += FrmAdd_FormClosing;
            
        }

        private void FrmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
          
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {//Validasyonlar
            if(txtname.Text=="")//builderlara bağlı!! zorunlu alanları yapacaksın.
            {
                MessageBox.Show("Ad giriniz");return;
            }
            else if(txtphone.Text=="")
            {
                MessageBox.Show("Phone giriniz"); return;
            }
          
            var companyy = new Company();
            companyy.Name = txtname.Text;
            companyy.City = txtcity.Text;
            companyy.Phone = txtphone.Text;
            companyy.Region = txtregion.Text;
            companyService.Insert(companyy);

            MessageBox.Show("Kullanıcı başarıyla oluşturuldu.");
        
            MasterForm.LoadCompanies();
            this.Hide(); //bilerek close demedik çünkü siliniyordu bilgiler.

          
           

        }

        public void ClearForm()
        {
            txtcity.Clear();
            txtname.Clear();
            txtregion.Clear();
            txtphone.Clear();
        }
        private void FrmAdd_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
           
            this.Hide();
        }
    }
}
