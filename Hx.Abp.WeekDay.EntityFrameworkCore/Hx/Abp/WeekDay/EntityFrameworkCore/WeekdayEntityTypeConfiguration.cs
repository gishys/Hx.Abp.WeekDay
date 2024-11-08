using Hx.Abp.WeekDay.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hx.Abp.WeekDay.EntityFrameworkCore
{
    public class HxWorkflowModelBuilderConfigrationOptions(
        [NotNull] string tablePrefix,
        [CanBeNull] string schema) : AbpModelBuilderConfigurationOptions(tablePrefix, schema)
    {
    }
    public class WeekdayEntityTypeConfiguration
        : IEntityTypeConfiguration<Weekday>
    {
        public void Configure(EntityTypeBuilder<Weekday> builder)
        {
            var model = new HxWorkflowModelBuilderConfigrationOptions("HX", null);
            builder.ConfigureFullAuditedAggregateRoot();
            builder.ToTable(model.TablePrefix + "WEEKDAYS", model.Schema);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Year).HasColumnName("YEAR").HasPrecision(4);
            builder.Property(e => e.Month).HasColumnName("MONTH").HasPrecision(2);
            builder.Property(e => e.Day).HasColumnName("DAY").HasPrecision(2);
            builder.Property(e => e.AdjustmentDate).HasColumnName("ADJUSTMENTDATE").HasColumnType("date");

            builder.Property(e => e.Description).HasColumnName("DESCRIPTION").HasPrecision(200);
            builder.Property(e => e.AdjustmentType).HasColumnName("ADJUSTMENTTYPE").HasPrecision(1);
            builder.Property(e => e.AdjustmentOrganization).HasColumnName("ADJUSTMENTORGANIZATION").HasPrecision(1);

            builder.Property(p => p.CreationTime).HasColumnName("CREATIONTIME").HasColumnType("timestamp with time zone");
            builder.Property(p => p.CreatorId).HasColumnName("CREATORID");
            builder.Property(p => p.LastModificationTime).HasColumnName("LASTMODIFICATIONTIME").HasColumnType("timestamp with time zone");
            builder.Property(p => p.LastModifierId).HasColumnName("LASTMODIFIERID");
            builder.Property(p => p.IsDeleted).HasColumnName("ISDELETED");
            builder.Property(p => p.DeleterId).HasColumnName("DELETERID");
            builder.Property(p => p.DeletionTime).HasColumnName("DELETIONTIME").HasColumnType("timestamp with time zone");
        }
    }
}