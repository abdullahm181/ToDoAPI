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
            builder.Property(c => c.Color).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.HasData(
                 new TodoCategory
                 {
                     Id = 1,
                     Title = "Work",
                     Color = "red",
                     Description = "Work related tasks",
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                new TodoCategory
                {
                    Id = 2,
                    Title = "Personal",
                    Color = "gray",
                    Description = "Personal tasks",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new TodoCategory
                {
                    Id = 3,
                    Title = "Shopping",
                    Color = "yellow",
                    Description = "Shopping tasks",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new TodoCategory
                {
                    Id = 4,
                    Title = "Health",
                    Color = "green",
                    Description = "Health related tasks",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                , new TodoCategory
                {
                    Id = 5,
                    Title = "Fitness",
                    Color = "blue",
                    Description = "Fitness related tasks",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                );
        }
    }
}
