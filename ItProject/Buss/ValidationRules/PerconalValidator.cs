using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;
namespace BussinesLayer.ValidationRules
{
   public class PerconalValidator : AbstractValidator<Personal>
    {    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
         //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
        public PerconalValidator()
        {
            RuleFor(x => x.PersonalName).NotEmpty().WithMessage("Personel Adını Boş Geçemezsiniz.");
            RuleFor(x => x.PersonalName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.PersonalName).MaximumLength(30).WithMessage("Yönetici Adı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.PersonalSurname).NotEmpty().WithMessage("Personel Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.PersonalSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.PersonalSurname).MaximumLength(30).WithMessage("Personel Soyadı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.PersonalUsername).NotEmpty().WithMessage("Personel Kullanıcı adını Boş Geçemezsiniz.");
            RuleFor(x => x.PersonalUsername).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.PersonalUsername).MaximumLength(10).WithMessage("Personel Kullanıcı adı En Fazla 10 Karakter Olabilir.");
            RuleFor(x => x.PersonalPassword).NotEmpty().WithMessage("Personel Şifresini adını Boş Geçemezsiniz.");
            RuleFor(x => x.PersonalPassword).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.PersonalPassword).MaximumLength(20).WithMessage("Personel şifresi adı En Fazla 20 Karakter Olabilir.");
            RuleFor(x => x.PersonalMail).NotEmpty().WithMessage("Personel mailini adını Boş Geçemezsiniz.");
            RuleFor(x => x.PersonalMail).MinimumLength(10).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.PersonalMail).MaximumLength(50).WithMessage("Personel mailini En Fazla 20 Karakter Olabilir.");
        }
    }
}
