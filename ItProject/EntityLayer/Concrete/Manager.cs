using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        [StringLength(20)]
        public string ManagerName { get; set; }
        [StringLength(20)]
        public string ManagerSurname { get; set; }
        [StringLength(20)]
        public string ManagerUsername { get; set; }
        [StringLength(100)]
        public string ManagerPassword { get; set; }
        [StringLength(50)]
        public string ManagerMail { get; set; }

        public bool ManagerStatus { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
