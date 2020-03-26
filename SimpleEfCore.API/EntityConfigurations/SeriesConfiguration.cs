using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfCore.API.Entities;

namespace SimpleEfCore.API.EntityConfigurations
{
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> configuration)
        {
            configuration.HasKey(x => x.Id);
            configuration.ToTable("Series");
        }
    }
}
