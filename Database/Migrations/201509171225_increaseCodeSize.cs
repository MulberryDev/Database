using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509171225)]
    public class increaseCodeSize : Migration
    {
        public override void Up()
        {
            Alter.Column("code").OnTable("Multimedia").AsString(255);
        }

        public override void Down()
        {
            Alter.Column("code").OnTable("Multimedia").AsString(50);
        }    
    }
}
