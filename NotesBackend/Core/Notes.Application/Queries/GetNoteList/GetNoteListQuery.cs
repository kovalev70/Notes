namespace Notes.Application.Queries.GetNoteList
{
    using MediatR;

    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
