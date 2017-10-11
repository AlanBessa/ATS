namespace ATS.Cadastro.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TB_PESSOA_JURIDICA", new[] { "SocioMenorId" });
            AlterColumn("dbo.TB_PESSOA_JURIDICA", "SocioMenorId", c => c.Guid());
            CreateIndex("dbo.TB_PESSOA_JURIDICA", "SocioMenorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TB_PESSOA_JURIDICA", new[] { "SocioMenorId" });
            AlterColumn("dbo.TB_PESSOA_JURIDICA", "SocioMenorId", c => c.Guid(nullable: false));
            CreateIndex("dbo.TB_PESSOA_JURIDICA", "SocioMenorId");
        }
    }
}
