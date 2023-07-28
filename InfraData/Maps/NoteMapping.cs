using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Maps
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("note");
            builder.HasKey(x  => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("idNote")
                .UseIdentityColumn();

            builder.Property(x => x.Message)
                .HasColumnName("message");
            
            builder.Property(x => x.Title)
                .HasColumnName("title");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.Person.Id);
        }
    }
}
