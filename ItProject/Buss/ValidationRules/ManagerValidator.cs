using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;
namespace BussinesLayer.ValidationRules

{    //kullanıcı giriş yaparken istenilen formatta olup olmadığını kontrol etmek için projeye Fluent Validation
     //referans olarak eklendi ardından data katmanındaki veriler getirilerek şartları girildi.
    public class ManagerValidator : AbstractValidator<Manager>
{
        public ManagerValidator()
        {
            RuleFor(x => x.ManagerName).NotEmpty().WithMessage("Yönetici Adını Boş Geçemezsiniz.");
            RuleFor(x => x.ManagerName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.ManagerName).MaximumLength(30).WithMessage("Yönetici Adı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.ManagerSurname).NotEmpty().WithMessage("Yönetici Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.ManagerSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.ManagerSurname).MaximumLength(30).WithMessage("Yönetici Soyadı En Fazla 30 Karakter Olabilir.");
            RuleFor(x => x.ManagerUsername).NotEmpty().WithMessage("Yönetici Kullanıcı adını Boş Geçemezsiniz.");
            RuleFor(x => x.ManagerUsername).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.ManagerUsername).MaximumLength(10).WithMessage("Yönetici Kullanıcı adı En Fazla 10 Karakter Olabilir.");
            RuleFor(x => x.ManagerPassword).NotEmpty().WithMessage("Yönetici Şifresini adını Boş Geçemezsiniz.");
            RuleFor(x => x.ManagerPassword).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Girişi Yapınız.");
            RuleFor(x => x.ManagerPassword).MaximumLength(20).WithMessage("Yönetici şifresi adı En Fazla 20 Karakter Olabilir.");
        }
    }
}
