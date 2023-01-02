using System.Data.Entity.ModelConfiguration;

namespace FluentAPI.Models.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //Table Name
            ToTable("Courses");

            //Primary Keys
            HasKey(c => c.Id);

            //Properties
            Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(2000);

            Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);
            
            //Relationships
            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course);

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");
            });            
        }
    }
}
