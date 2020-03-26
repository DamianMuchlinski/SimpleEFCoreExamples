using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfCore.API.Entities;

namespace SimpleEfCore.API.EntityConfigurations
{
    public class WorkbookConfiguration : IEntityTypeConfiguration<Workbook>
    {
        public void Configure(EntityTypeBuilder<Workbook> configuration)
        {
            configuration.HasKey(x => x.Id);
            configuration.ToTable("Workbook");
        }
    }
}
