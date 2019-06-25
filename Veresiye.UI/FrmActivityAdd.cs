﻿using System;
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
    public partial class FrmActivityAdd : Form
    {
        private int CompanyId;
       public FrmCompanyEdit MasterForm { get; set; }
        private readonly IActivityService activityService;
        public FrmActivityAdd(IActivityService activityService)
        {
            this.activityService = activityService;
            InitializeComponent();
        }
        public void LoadForm(int companyId)//İlişkili olduğuna dikkat et!Save yaparken kullancaksın.
        {
            this.CompanyId = companyId;
            this.txtName.Clear();
            this.txtAmount.Clear();
            this.dtTransaction.Value = DateTime.Now;
            this.cmbActivityType.SelectedIndex = 0;

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

            var activity = new Activity();
            activity.CompanyId = this.CompanyId;
            activity.Name = txtName.Text;
            activity.Amount = Convert.ToDecimal(txtAmount.Text);
            activity.ActivityType = (ActivityType)(cmbActivityType.SelectedIndex+1);
            activity.TransactionDate = dtTransaction.Value;
            activityService.Insert(activity);
            MasterForm.LoadActivities();
            MessageBox.Show("İşlem kaydedildi.");
            this.Hide();
        }

        private void DtTransaction_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
