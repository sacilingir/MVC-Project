namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_upt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 100));
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "ReceiverMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 50));
        }
    }
}
