using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TZTest.Models;

namespace TZTest.Data
{
    public class FolderConfiguration : IEntityTypeConfiguration<FolderClass>
    {
        string Paths = Path.Combine(Directory.GetCurrentDirectory(), "Creating Digital Images");

        public void Configure(EntityTypeBuilder<FolderClass> builder)
        {
            builder.HasData(new FolderClass[]
            {
                new FolderClass{Id=Guid.Parse("5F3015CF-98D3-4900-B010-322BB0F52112"),Name="Creating Digital Images",ParentFolderId=Guid.Parse("5F3015CF-98D3-4900-B010-322BB0F52113"), Path=Paths},
            }) ;
        }
    }
}

