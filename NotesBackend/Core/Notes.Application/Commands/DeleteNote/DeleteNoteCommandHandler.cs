namespace Notes.Application.Commands.DeleteNote
{
    using MediatR;
    using Notes.Application.Interfaces;
    using Notes.Application.Common.Exceptions;
    using Notes.Domain;

    public class DeleteNoteCommandHandler
        : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task Handle(DeleteNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
