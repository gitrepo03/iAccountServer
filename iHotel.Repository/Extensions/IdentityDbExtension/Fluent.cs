using iHotel.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Extensions.IdentityDbExtension
{
    public class Fluent
    {
        public static void createEntityRules(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.Property(e => e.UserName)
            //        .HasMaxLength(150);

            //    entity.Property(e => e.Organization)
            //        .IsRequired();

            //    entity.HasOne(a => a.OrganizationNavigation)
            //        .WithMany(o => o.Users)
            //        .HasForeignKey(a => a.Organization)
            //        .HasConstraintName("FK__Organizat__AppUser__52B859C3");
            //});
        }
    }
}
