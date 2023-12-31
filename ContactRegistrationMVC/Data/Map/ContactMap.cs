﻿using ContactRegistrationMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactRegistrationMVC.Data.Map
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);
        }
    }
}
