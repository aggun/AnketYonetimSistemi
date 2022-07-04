using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
   public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminRole { get; set; }

        public bool AdminStatus { get; set; }
        public ICollection<Role> roles { get; set; }


    }
}
