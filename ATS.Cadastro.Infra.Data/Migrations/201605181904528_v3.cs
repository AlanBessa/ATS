namespace ATS.Cadastro.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_PESSOA_FISICA", "TituloEleitor", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_PESSOA_FISICA", "TituloEleitor");
        }
    }
}
