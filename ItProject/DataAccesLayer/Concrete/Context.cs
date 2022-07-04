using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    //context sınıfı dbset ile veri tabanına bağlantı kurarak tabloların oluşmasını sağlamakta tablo sutunları
    //için bilgiler entitylayer üzerinden gelmektedir.
   public class Context: DbContext
    {
        public DbSet<Company> companies { get; set; }
        public DbSet<Personal> personals { get; set; }
        public DbSet<Survey> surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyAnswer> surveyAnswers { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Manager> managers { get; set; }

    }
}
