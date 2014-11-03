namespace eMatrimony.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Lookup_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        EducationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.EducationId);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        ReligionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ReligionId);
            
            CreateTable(
                "dbo.Tongues",
                c => new
                    {
                        TongueId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TongueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tongues");
            DropTable("dbo.Religions");
            DropTable("dbo.EducationLevels");
            DropTable("dbo.Countries");
        }
    }
}
