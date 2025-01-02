using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Geçerli yazar ismi giriniz!");
            RuleFor(x => x.WriterMail).MinimumLength(5).WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(x => x.WriterTitle).MinimumLength(5).WithMessage("Geçerli bir ünvan giriniz.");

        }
    }
}
