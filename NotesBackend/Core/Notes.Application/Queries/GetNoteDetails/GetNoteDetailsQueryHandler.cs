namespace Notes.Application.Queries.GetNoteDetails
{
    using MediatR;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Notes.Application.Interfaces;
    using Notes.Application.Common.Exceptions;
    using Notes.Domain;
    public class GetNoteDetailsQueryHandler
        : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbcontext;
        private readonly IMapper _mapper;
        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Notes
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
