using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509181541)]
    public class setArchiveProductKeyToNullable : Migration
    {
        public override void Up()
        {
            Alter.Column("productID").OnTable("MultimediaArchive").AsInt32().Nullable();
        }

        public override void Down()
        {
            Alter.Column("productID").OnTable("MultimediaArchive").AsInt32().NotNullable();
        }
    }
}
