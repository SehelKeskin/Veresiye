using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Model;

namespace Veresiye.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("name=DefaultConnection")
        {

            //Modele erişebilmek için Add-->Referans--> projectten ekledin Modeli
         

         
        }


        public virtual DbSet<User> Users { get; set; }//Bunları yazdığında hata veriyor! Ctrl+. Bas!
        public virtual DbSet<Company> Companys { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }



    }
}
