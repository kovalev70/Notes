namespace Notes.Application.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Notes.Domain;
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
