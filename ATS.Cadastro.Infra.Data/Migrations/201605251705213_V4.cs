namespace ATS.Cadastro.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_PESSOA_FISICA", "RG", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_PESSOA_FISICA", "RG", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
    }
}
