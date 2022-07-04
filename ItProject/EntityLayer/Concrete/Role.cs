using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(1)]
        public string RoleName { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public int? AdminId { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
