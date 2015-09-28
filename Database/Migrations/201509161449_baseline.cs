using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509161449)]
    public class BaseLine : Migration
    {
        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("code").AsString(50).NotNullable();

            Create.Table("MultimediaType")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(50).NotNullable();

            Insert.IntoTable("MultimediaType")
                .Row(new { name = "Image" })
                .Row(new { name = "Video" });

            Create.Table("User")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(50).NotNullable();

            Create.Table("MultimediaArchive")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("productID").AsInt32().NotNullable().ForeignKey("Product", "ID")
                .WithColumn("multimediaTypeID").AsInt32().NotNullable().ForeignKey("multimediaType", "ID").WithDefaultValue(0)
                .WithColumn("code").AsString(50).NotNullable()
                .WithColumn("filePath").AsString(255).NotNullable()
                .WithColumn("version").AsInt32().NotNullable();

            Create.Table("Multimedia")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("productID").AsInt32().Nullable().ForeignKey("Product", "ID")
                .WithColumn("multimediaTypeID").AsInt32().NotNullable().ForeignKey("multimediaType", "ID").WithDefaultValue(0)
                .WithColumn("code").AsString(50).NotNullable()
                .WithColumn("filePath").AsString(255).NotNullable()
                .WithColumn("isValid").AsBoolean().Nullable()
                .WithColumn("validatedAt").AsDateTime().Nullable()
                .WithColumn("validatedBy").AsInt32().Nullable().ForeignKey("User", "ID")
                .WithColumn("isUploadedToAmplience").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("uploadedToAmplienceAt").AsDateTime().Nullable()
                .WithColumn("multimediaArchiveID").AsInt32().Nullable().ForeignKey("multimediaArchive", "ID")
                .WithColumn("version").AsInt32().NotNullable().WithDefaultValue(0);            
        }

        public override void Down()
        {
            Delete.Table("Multimedia");
            Delete.Table("MultimediaArchive");
            Delete.Table("MultimediaType");
            Delete.Table("Product");
            Delete.Table("User");
        }
    }
}
