namespace eMatrimony.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Horoscope_Profile_Picture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfileFilePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfileFileContentType", c => c.String());
            AddColumn("dbo.AspNetUsers", "HoroscopeFilePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "HoroscopeFileContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HoroscopeFileContentType");
            DropColumn("dbo.AspNetUsers", "HoroscopeFilePath");
            DropColumn("dbo.AspNetUsers", "ProfileFileContentType");
            DropColumn("dbo.AspNetUsers", "ProfileFilePath");
        }
    }
}
