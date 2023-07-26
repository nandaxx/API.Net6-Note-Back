using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Maps
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.PassWord).HasColumnName("password");
            builder.Property(x => x.GitHub).HasColumnName("github");
            builder.Property(x => x.Linkedin).HasColumnName("linkedin");
            builder.HasMany(x => x.Notes).WithOne(x => x.Person).HasForeignKey(x => x.Person.Id);




        }
    }
}
