namespace ATS.Cadastro.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdAgenda", "dbo.TB_AGENDA");
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdContato", "dbo.TB_CONTATO");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            AddForeignKey("dbo.TB_AGENDA_ENDERECO", "IdAgenda", "dbo.TB_AGENDA", "IdAgenda", cascadeDelete: true);
            AddForeignKey("dbo.TB_AGENDA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco", cascadeDelete: true);
            AddForeignKey("dbo.TB_CONTATO_ENDERECO", "IdContato", "dbo.TB_CONTATO", "IdContato", cascadeDelete: true);
            AddForeignKey("dbo.TB_CONTATO_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco", cascadeDelete: true);
            AddForeignKey("dbo.TB_PESSOA_ENDERECO", "IdPessoa", "dbo.TB_PESSOA", "IdPessoa", cascadeDelete: true);
            AddForeignKey("dbo.TB_PESSOA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdContato", "dbo.TB_CONTATO");
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdAgenda", "dbo.TB_AGENDA");
            AddForeignKey("dbo.TB_PESSOA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco");
            AddForeignKey("dbo.TB_PESSOA_ENDERECO", "IdPessoa", "dbo.TB_PESSOA", "IdPessoa");
            AddForeignKey("dbo.TB_CONTATO_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco");
            AddForeignKey("dbo.TB_CONTATO_ENDERECO", "IdContato", "dbo.TB_CONTATO", "IdContato");
            AddForeignKey("dbo.TB_AGENDA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO", "IdEndereco");
            AddForeignKey("dbo.TB_AGENDA_ENDERECO", "IdAgenda", "dbo.TB_AGENDA", "IdAgenda");
        }
    }
}
