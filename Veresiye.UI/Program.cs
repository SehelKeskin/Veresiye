﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Veresiye.Data;
using Veresiye.Service;

namespace Veresiye.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //AutoFAc
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            //Servislerimiz
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<ActivityService>().As<IActivityService>();



            //Formlarımız c# a eklendi!
            builder.RegisterType<FrmMain>().As<FrmMain>();
            builder.RegisterType<FrmRegister>().As<FrmRegister>();
            builder.RegisterType<FrmCompanies>().As<FrmCompanies>();
            builder.RegisterType<FrmLogin>().As<FrmLogin>();
            builder.RegisterType<FrmAdd>().As<FrmAdd>();
            builder.RegisterType<FrmCompanyEdit>().As<FrmCompanyEdit>();
            builder.RegisterType<FrmActivityAdd>().As<FrmActivityAdd>();
            builder.RegisterType<FrmActivityEdit>().As<FrmActivityEdit>();



            var container = builder.Build();

            using (var scope=container.BeginLifetimeScope())

            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var frm = scope.Resolve<FrmMain>();//new frmmain yapıyor!
                Application.Run(frm);
            }


        }
    }
}
