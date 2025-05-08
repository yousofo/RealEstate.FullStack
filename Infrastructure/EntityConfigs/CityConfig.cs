//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.EntityConfigs
//{
//    public class CityConfig : IEntityTypeConfiguration<City>
//    {
//        public void Configure(EntityTypeBuilder<City> builder)
//        {

//            builder.HasOne(a => a.CreatedBy)
//                 .WithMany() // No navigation property in AppUser
//                 .HasForeignKey(e => e.CreatedById)
//                 .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

//            builder.HasOne(a => a.ModifiedBy)
//                .WithMany()
//                .HasForeignKey(e => e.ModifiedById)
//                .OnDelete(DeleteBehavior.Restrict);

//            builder.HasOne(a => a.State)
//                .WithMany(s=>s.Cities)
//                .HasForeignKey(a => a.StateId)
//                .OnDelete(DeleteBehavior.Restrict);


//            builder.HasIndex(a => new { a.Name ,a.StateId}).IsUnique();
//        }
//    }
//}
