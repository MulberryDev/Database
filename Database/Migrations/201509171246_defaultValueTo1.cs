using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509171246)]
    public class defaultValueTo1 : Migration
    {
        public override void Up()
        {
            Alter.Column("multimediaTypeID").OnTable("Multimedia").AsInt32().WithDefaultValue(1);     
        }

        public override void Down()
        {
            Alter.Column("multimediaTypeID").OnTable("Multimedia").AsInt32().WithDefaultValue(0);    
        }
    }
}
