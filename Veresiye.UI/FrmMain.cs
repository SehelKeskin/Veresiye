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
    public partial class FrmMain : Form
    {
        private readonly IUserService userService;
        private readonly FrmRegister frmRegister;
        private readonly FrmCompanies frmCompanies;
        private readonly FrmLogin FrmLogin;

        public FrmMain(IUserService userService,FrmRegister frmRegister,FrmCompanies frmCompanies, FrmLogin FrmLogin)
        {
            this.FrmLogin = FrmLogin;
            this.userService = userService;
            this.frmCompanies = frmCompanies;
            this.frmRegister = frmRegister;
            InitializeComponent();//mdiparent initial de belirlendiği için ! bundan sonra ekleeme yapıldı!!!!!!!
           this.frmRegister.MdiParent = this;
            this.frmCompanies.MdiParent = this;
            this.FrmLogin.MdiParent = this;
            this.FrmLogin.MasterForm = this;
        }



        public void ShowCompany()
        {
            frmCompanies.Show();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //burada eğer sıfır kullanıcı var ise direk olarak frmRegistery açılıyor.
            var userCount = userService.GetAll().Count();
            if(userCount==0)
            {
               frmRegister.Show();
               
            }
            else
            {
                FrmLogin.Show();
            }
        }
    }
}
