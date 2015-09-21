using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509211606)]
    public class addProductCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("GoogleCategory")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("parentID").AsInt32().Nullable().ForeignKey("GoogleCategory", "ID")
                .WithColumn("name").AsString(255).NotNullable();

            Insert.IntoTable("GoogleCategory")
                .Row(new { name = "Clothing & Accessories" })
                .Row(new { parentID = 1, name = "Handbags, Wallets & Cases" })
                .Row(new { parentID = 2, name = "Handbags" });

            Create.Table("Language")
                .WithColumn("ID").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("code").AsString(50).NotNullable()
                .WithColumn("name").AsString(50).NotNullable();

            Create.Table("ProductLanguage")
                .WithColumn("productID").AsInt32().NotNullable().ForeignKey("Product", "ID")
                .WithColumn("languageID").AsInt32().NotNullable().ForeignKey("Language", "ID")
                .WithColumn("googleName").AsString(255).Nullable()
                .WithColumn("googleMaterial").AsString(255).Nullable()
                .WithColumn("googleColour").AsString(255).Nullable();

            Alter.Table("Product")
                .AddColumn("googleCategoryID").AsInt32().NotNullable().ForeignKey("GoogleCategory", "ID").WithDefaultValue(1);

            Insert.IntoTable("Language")
                .Row(new { code = "ENG", name = "English" })
                .Row(new { code = "DEU", name = "German" });
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Product_googleCategoryID_GoogleCategory_ID").OnTable("Product");
            Delete.Column("googleCategoryID").FromTable("Product");
            Delete.Table("GoogleCategory");
            Delete.Table("ProductLanguage");
            Delete.Table("Language");
            
        }
    }
}
