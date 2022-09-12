using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder) { }
    }
}