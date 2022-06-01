namespace LabBigSchool_LamQuangTruong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (1,'DEVELOPMENT')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (2,'BUSINESS')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (3,'MARKETING')");
        }

        private void Sql()
        {
            throw new NotImplementedException();
        }

        public override void Down()
        {
        }
    }
}
