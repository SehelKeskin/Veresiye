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
    public partial class FrmRegister : Form
    {
        private readonly IUserService userService;
        public FrmRegister(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
        }

       
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            
         
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(txtPassword.Text!=txtPasswordConfirm.Text)
            {
                MessageBox.Show("Paroların aynı olamlıdır!");
            }

            var user = new User();
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.CompanyName = txtCompany.Text;
            user.City = txtCity.Text;
            user.Phone = txtPhone.Text;
            user.Region = txtRegion.Text;
            var status = userService.Register(user);


            switch (status)
            {
                case RegisterStatus.Success:
                    MessageBox.Show("KullanıcıBaşarıylaOluşturuldu");this.Close();
                    break;
                case RegisterStatus.InvalidFields:
                    MessageBox.Show("KullanıcıAdıBoşOlamaz");
                    break;
                case RegisterStatus.UserAlreadyExists:
                    MessageBox.Show("Kullanıcı zaten var");
                    break;
                default:
                    break;
            }

            

            //  userService.Register(txtUserName.Text,txtPassword.Text,txt)


            //  userService.Register();
        }
    }
}
