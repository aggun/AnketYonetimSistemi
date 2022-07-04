using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; }
        public bool CompanyStatus { get; set; }

        public ICollection<Survey> surveys { get; set; }
        public ICollection<Personal> personals { get; set; }
        public ICollection<Manager> managers { get; set; }

    }
}
