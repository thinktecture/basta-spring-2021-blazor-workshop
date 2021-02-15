using System;
using BASTAConfTool.Shared.DTO;
using FluentValidation;

namespace BASTAConfTool.Shared.Validation
{
    public class ConferenceDetailsValidator : AbstractValidator<ConferenceDetails>
    {
        public ConferenceDetailsValidator()
        {
            RuleFor(conference => conference.DateTo)
                .GreaterThanOrEqualTo(conference => conference.DateFrom);
        }
    }
}
