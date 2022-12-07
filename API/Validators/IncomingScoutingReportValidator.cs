// <copyright file="IncomingScoutingReportValidator.cs" company="Miami Heat">
// Copyright (c) Miami Heat. All rights reserved.
// </copyright>

namespace API.Validators
{
    using API.Common.Models.Input;
    using FluentValidation;

    /// <summary>
    /// This validation class will be looking into the necessary validations before inserting data into the database.
    /// </summary>
    public class IncomingScoutingReportValidator : AbstractValidator<IncomingScoutingReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingScoutingReportValidator"/> class.
        /// </summary>
        public IncomingScoutingReportValidator()
        {
            this.RuleFor(p => p.ScoutName)
                   .Cascade(CascadeMode.Stop)
                   .NotEmpty().WithMessage("{PropertyName} should not be empty")
                   .WithErrorCode("SR001");

            this.RuleFor(p => p.DefenseRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("SR002");

            this.RuleFor(p => p.ReboundRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("SR003");

            this.RuleFor(p => p.AssistRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("SR004");

            this.RuleFor(p => p.ShootingRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("SR005");
        }
    }
}
