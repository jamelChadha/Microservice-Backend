using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Features.Posts.Command.CreatPost
{
   public class CreatCommandValidators : AbstractValidator<CreatPostCommand>
    {
        public CreatCommandValidators()
        {
            RuleFor(p => p.Title).NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(p => p.Content).NotEmpty()
                .NotNull();
        }
    }
}
