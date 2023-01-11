using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillRange).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
            RuleFor(x => x.SkillRange).LessThan(101).WithMessage("Gireceğiniz Değer 100 'den Büyük Olmamalı");
        }
    }
}
