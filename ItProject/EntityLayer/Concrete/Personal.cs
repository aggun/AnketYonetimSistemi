using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{    //sql üzerinde oluşacak tablo ve tablonun sutunları değer bilgisi. ilişkili olacağı diğer tablolar.
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        [StringLength(20)]
        public string PersonalName { get; set; }
        [StringLength(20)]
        public string PersonalSurname { get; set; }
        [StringLength(20)]
        public string PersonalUsername { get; set; }
        [StringLength(100)]
        public string PersonalPassword { get; set; }
        [StringLength(50)]
        public string PersonalMail { get; set; }

        public bool PersonalStatus { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<SurveyAnswer> surveyanswers { get; set; }

    }
}
