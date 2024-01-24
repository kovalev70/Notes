﻿namespace Notes.Application.Commands.DeleteNote
{
    using FluentValidation;

    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator() 
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id)
                .NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand => deleteNoteCommand.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
