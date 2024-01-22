﻿namespace Notes.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Notes.Application.Interfaces;
    using Notes.Domain;
    using Notes.Persistence.EntityTypeConfigurations;

    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
