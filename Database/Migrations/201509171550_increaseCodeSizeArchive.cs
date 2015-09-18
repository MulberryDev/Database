using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509171550)]
    public class increaseCodeSizeArchive : Migration
    {
        public override void Up()
        {
            Alter.Column("code").OnTable("MultimediaArchive").AsString(255);
        }

        public override void Down()
        {
            Alter.Column("code").OnTable("MultimediaArchive").AsString(50);
        }
    }
}
