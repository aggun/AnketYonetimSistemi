using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BussinesLayer.ValidationRules
{    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
    //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket Adını Boş Geçemezsiniz.");
            RuleFor(x => x.CompanyName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage("Şirket Adı En Fazla 50 Karakter Olabilir.");
        }
    }
}
