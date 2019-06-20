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
    public partial class FrmLogin : Form
    {
        public FrmMain MasterForm { get; set; }
        private readonly IUserService userService;
  
        public FrmLogin(IUserService userService)
        {
            this.userService = userService;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           var a= userService.Login(txtName.Text,txtPassword.Text);
            if (a!=null)
            {
                MessageBox.Show("Var");
                MasterForm.ShowCompany();
            }
            else
            {
                MessageBox.Show("yok");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
