using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator:AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingID).NotEmpty().WithMessage("ID boş olamaz.");
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Category boş olamaz.");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("Yazar boş olamaz.");
            RuleFor(x => x.Category.CategoryName).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Lütfen geçerli isim giriniz.");
        }

    }
}
