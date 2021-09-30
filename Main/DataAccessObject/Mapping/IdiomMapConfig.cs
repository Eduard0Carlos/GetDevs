using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Mapping
{
    internal class IdiomMapConfig : IEntityTypeConfiguration<Idiom>
    {
        public void Configure(EntityTypeBuilder<Idiom> builder)
        {
            builder.Property(i => i.Language).IsRequired();
            builder.Property(i => i.ReadProficiency).IsRequired();
            builder.Property(i => i.WriteProficiency).IsRequired();
            builder.Property(i => i.SpeechProficiency).IsRequired();
        }
    }
}
