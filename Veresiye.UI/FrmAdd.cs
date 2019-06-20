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
        public CompanyService companyService;
    
     
        public FrmAdd(CompanyService companyService)
        {
            
            this.companyService = companyService;
            InitializeComponent();
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var companyy = new Company();
            companyy.Name = txtname.Text;
            companyy.City = txtcity.Text;
            companyy.Phone = txtphone.Text;
            companyy.Region = txtregion.Text;
            companyy.CreateAt =DateTime.Parse(txtcreateat.Text);
            companyy.CreateBy = txtCreateBy.Text;
            companyy.UpdateAt = DateTime.Parse(txtUpdateAt.Text);
            companyy.UpdatedBy = txtUpdateBy.Text;
            companyService.Insert(companyy);

        }
    }
}
