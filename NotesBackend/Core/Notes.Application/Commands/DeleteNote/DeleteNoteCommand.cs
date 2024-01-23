namespace Notes.Application.Commands.DeleteNote
{
    using MediatR;

    public class DeleteNoteCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id {  get; set; }
    }
}
