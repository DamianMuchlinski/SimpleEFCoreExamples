using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfCore.API.Entities;

namespace SimpleEfCore.API.EntityConfigurations
{
    public class WorkbookSeriesConfiguration : IEntityTypeConfiguration<WorkbookSeries>
    {
        public void Configure(EntityTypeBuilder<WorkbookSeries> configuration)
        {
            configuration.Property(b => b.WorkbookId)
                .HasColumnName("workbookId");

            configuration.Property(b => b.SeriesId)
             .HasColumnName("seriesId");

            configuration
                .HasOne(x => x.Workbook)
                .WithMany(x => x.WorkbookSeries)
                .HasForeignKey(x => x.WorkbookId);

            configuration
                .HasOne(x => x.Series)
                .WithMany(x => x.WorkbookSeries)
                .HasForeignKey(x => x.SeriesId);

            configuration
               .HasKey(x => new { x.WorkbookId, x.SeriesId });

            configuration.ToTable("WorkbookSeries");
        }
    }
}
