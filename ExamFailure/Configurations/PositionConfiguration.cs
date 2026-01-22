using ExamFailure.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamFailure.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Position> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(126);
        }
    }
}
