using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Database.Migrations
{
    [Migration(201509161552)]
    public class InsertMultimediaTypes : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("MultimediaType")
                .Row(new { name = "Image" })
                .Row(new { name = "Video" });
        }

        public override void Down()
        {
            Delete.FromTable("MultimediaType").Row(new { name = "Image" });
            Delete.FromTable("MultimediaType").Row(new { name = "Video" });
        }
    }
}
