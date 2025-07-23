using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Insfrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<TodoCategory>
    {
        public void Configure(EntityTypeBuilder<TodoCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.HasData(
                 new TodoCategory
                 {
                     Id = 1,
                     Title = "Work",
                     Description = "Work related tasks",
                     CreateDate = DateTime.Now,
                     UpdateDate = DateTime.Now
                 },
                new TodoCategory
                {
                    Id = 2,
                    Title = "Personal",
                    Description = "Personal tasks",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new TodoCategory
                {
                    Id = 3,
                    Title = "Shopping",
                    Description = "Shopping tasks",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                },
                new TodoCategory
                {
                    Id = 4,
                    Title = "Health",
                    Description = "Health related tasks",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
                , new TodoCategory
                {
                    Id = 5,
                    Title = "Fitness",
                    Description = "Fitness related tasks",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                }
                );
        }
    }
}
