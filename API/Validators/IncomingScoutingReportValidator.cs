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
                   .WithErrorCode("ISR001");

            this.RuleFor(p => p.DefenseRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("ISR002");

            this.RuleFor(p => p.ReboundRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("ISR003");

            this.RuleFor(p => p.AssistRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("ISR004");

            this.RuleFor(p => p.ShootingRating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 10)
                .WithMessage("{PropertyName} has to be between 1 and 10")
                .WithErrorCode("ISR005");

            this.RuleFor(p => p.TeamCity)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .WithErrorCode("ISR006");

            this.RuleFor(p => p.TeamName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .WithErrorCode("ISR007");

            this.RuleFor(p => p.PlayerFirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .WithErrorCode("ISR008");

            this.RuleFor(p => p.PlayerLastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .WithErrorCode("ISR009");

            this.RuleFor(p => p.Comments)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Comments need to be provided!")
                .WithErrorCode("ISR010");
        }
    }
}
