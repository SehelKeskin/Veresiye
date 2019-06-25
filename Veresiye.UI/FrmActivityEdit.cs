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
    public partial class FrmActivityEdit : Form
    {
        private int activityId;
       public FrmCompanyEdit MasterForm { get; set; }
        private readonly IActivityService activityService;
        public FrmActivityEdit(IActivityService activityService)
        {
            this.activityService = activityService;
            InitializeComponent();
        }
        public void LoadForm(int activityId)//İlişkili olduğuna dikkat et!Save yaparken kullancaksın.
        {
            this.activityId = activityId;
            var activity = activityService.Get(activityId);
            if (activity != null)
            {
                this.txtName.Text = activity.Name;
                this.txtAmount.Text = activity.Amount.ToString();
                this.dtTransaction.Value = activity.TransactionDate;
                this.cmbActivityType.SelectedIndex = ((int)activity.ActivityType) - 1;
            }
        }
        private void FrmActivityAdd_Load(object sender, EventArgs e)
        {
          
        }

        private void FrmActivityAdd_FormClosing(object sender, FormClosingEventArgs e)
        {


            e.Cancel = true;
            this.Hide();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (txtName.Text=="")
            {
                MessageBox.Show("İŞlem adı giriniz");return;
            }
            else if (txtAmount.Text=="")
            {
                MessageBox.Show("Miktar gereklidir.");return;
            }
            else if (cmbActivityType.SelectedIndex<0)
            {
                MessageBox.Show("İşlem türü gereklidir.");
            }

            var activity = activityService.Get(this.activityId);
            activity.Name = txtName.Text;
            activity.Amount = Convert.ToDecimal(txtAmount.Text);
            activity.ActivityType = (ActivityType)(cmbActivityType.SelectedIndex+1);
            activity.TransactionDate = dtTransaction.Value;
            activityService.Update(activity);
            MasterForm.LoadActivities();
            MessageBox.Show("İşlem kaydedildi.");
            this.Hide();
        }
    }
}
