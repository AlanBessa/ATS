namespace ATS.Cadastro.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_AGENDA",
                c => new
                    {
                        IdAgenda = c.Guid(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(maxLength: 10, unicode: false),
                        Compromisso = c.String(maxLength: 8000, unicode: false),
                        Email_Endereco = c.String(maxLength: 8000, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataAlteracao = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataInicio = c.DateTime(precision: 7, storeType: "datetime2"),
                        DataFim = c.DateTime(precision: 7, storeType: "datetime2"),
                        ValidationResult_Message = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdAgenda);
            
            CreateTable(
                "dbo.TB_ENDERECO",
                c => new
                    {
                        IdEndereco = c.Guid(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 200, unicode: false),
                        Complemento = c.String(maxLength: 200, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 80, unicode: false),
                        CidadeId = c.Guid(nullable: false),
                        EstadoId = c.Guid(nullable: false),
                        Cep_CepCod = c.String(nullable: false, maxLength: 8, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.TB_CIDADE", t => t.CidadeId)
                .ForeignKey("dbo.TB_ESTADO", t => t.EstadoId)
                .Index(t => t.CidadeId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.TB_CIDADE",
                c => new
                    {
                        IdCidade = c.Guid(nullable: false, identity: true),
                        EstadoId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.IdCidade)
                .ForeignKey("dbo.TB_ESTADO", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.TB_ESTADO",
                c => new
                    {
                        IdEstado = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.TB_PESSOA",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false, identity: true),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeAlteracao = c.DateTime(precision: 7, storeType: "datetime2"),
                        LimiteDeCredito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Referencias = c.String(maxLength: 8000, unicode: false),
                        Conceito = c.String(maxLength: 8000, unicode: false),
                        SPC = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Observacao = c.String(maxLength: 500, unicode: false),
                        DataDaUltimaCompra = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_MEIO_COMUNICACAO",
                c => new
                    {
                        IdMeioDeComunicacao = c.Guid(nullable: false, identity: true),
                        Valor = c.String(nullable: false, maxLength: 100, unicode: false),
                        TipoDeMeioDeComunicacaoId = c.Guid(nullable: false),
                        PessoaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdMeioDeComunicacao)
                .ForeignKey("dbo.TB_PESSOA", t => t.PessoaId)
                .ForeignKey("dbo.TB_TIPO_MEIO_COMUNICACAO", t => t.TipoDeMeioDeComunicacaoId)
                .Index(t => t.TipoDeMeioDeComunicacaoId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.TB_CONTATO",
                c => new
                    {
                        IdContato = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Observacao = c.String(maxLength: 500, unicode: false),
                        Email_Endereco = c.String(maxLength: 8000, unicode: false),
                        Telefone_Numero = c.String(maxLength: 8000, unicode: false),
                        PessoaJuridicaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdContato)
                .ForeignKey("dbo.TB_PESSOA_JURIDICA", t => t.PessoaJuridicaId)
                .Index(t => t.PessoaJuridicaId);
            
            CreateTable(
                "dbo.TB_TIPO_MEIO_COMUNICACAO",
                c => new
                    {
                        IdTipoDeMeioDeComunicacao = c.Guid(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdTipoDeMeioDeComunicacao);
            
            CreateTable(
                "dbo.TB_HISTORICO_DE_CARGO",
                c => new
                    {
                        IdHistoricoDoCargo = c.Guid(nullable: false, identity: true),
                        CargoId = c.Guid(nullable: false),
                        DataDeAdmissao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDeDemissao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FuncionarioId = c.Guid(nullable: false),
                        HorarioDeEntrada = c.String(nullable: false, maxLength: 8, unicode: false),
                        HorarioDeSaida = c.String(nullable: false, maxLength: 8, unicode: false),
                        HorarioDeEntradaFimDeSemana = c.String(maxLength: 8, unicode: false),
                        HorarioDeSaidaFimDeSemana = c.String(maxLength: 8, unicode: false),
                        Comissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdHistoricoDoCargo)
                .ForeignKey("dbo.TB_CARGO", t => t.CargoId)
                .ForeignKey("dbo.TB_FUNCIONARIO", t => t.FuncionarioId)
                .Index(t => t.CargoId)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.TB_CARGO",
                c => new
                    {
                        IdCargo = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.IdCargo);
            
            CreateTable(
                "dbo.TB_COFINS",
                c => new
                    {
                        IdCofins = c.Guid(nullable: false, identity: true),
                        CodValor = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdCofins);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        IdProduto = c.Guid(nullable: false, identity: true),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        CodFabrica = c.String(maxLength: 8000, unicode: false),
                        CodNcm = c.String(maxLength: 8000, unicode: false),
                        TaxaIcms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxaIpi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxaSt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AliquotaIcms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReducaoIcms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AliquotaCofins = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AliquotaPis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AliquotaIpi = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TribMedia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        WebUrl = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(maxLength: 8000, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        FornecedorId = c.Guid(),
                        FabricanteId = c.Guid(),
                        MarcaId = c.Guid(),
                        CorId = c.Guid(),
                        GrupoId = c.Guid(),
                        PisId = c.Guid(),
                        CofinsId = c.Guid(),
                        IpiId = c.Guid(),
                        TributacaoId = c.Guid(),
                        SitTributariaId = c.Guid(),
                        Cor_IdCor = c.Guid(nullable: false),
                        Fabricante_IdFabricante = c.Guid(nullable: false),
                        Fornecedor_IdFornecedor = c.Guid(),
                        Grupo_IdGrupo = c.Guid(),
                        Ipi_IdIpi = c.Guid(nullable: false),
                        Marca_IdMarca = c.Guid(nullable: false),
                        Pis_IdPis = c.Guid(nullable: false),
                        SitTributaria_IdSitTibutaria = c.Guid(nullable: false),
                        Tributacao_IdTributacao = c.Guid(nullable: false),
                        Cofins_IdCofins = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduto)
                .ForeignKey("dbo.TB_COR", t => t.Cor_IdCor)
                .ForeignKey("dbo.TB_FABRICANTE", t => t.Fabricante_IdFabricante)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_IdFornecedor)
                .ForeignKey("dbo.Grupo", t => t.Grupo_IdGrupo)
                .ForeignKey("dbo.TB_IPI", t => t.Ipi_IdIpi)
                .ForeignKey("dbo.TB_MARCA", t => t.Marca_IdMarca)
                .ForeignKey("dbo.TB_PIS", t => t.Pis_IdPis)
                .ForeignKey("dbo.TB_SIT_TRIBUTARIA", t => t.SitTributaria_IdSitTibutaria)
                .ForeignKey("dbo.TB_TRIBUTACAO", t => t.Tributacao_IdTributacao)
                .ForeignKey("dbo.TB_COFINS", t => t.Cofins_IdCofins)
                .Index(t => t.Cor_IdCor)
                .Index(t => t.Fabricante_IdFabricante)
                .Index(t => t.Fornecedor_IdFornecedor)
                .Index(t => t.Grupo_IdGrupo)
                .Index(t => t.Ipi_IdIpi)
                .Index(t => t.Marca_IdMarca)
                .Index(t => t.Pis_IdPis)
                .Index(t => t.SitTributaria_IdSitTibutaria)
                .Index(t => t.Tributacao_IdTributacao)
                .Index(t => t.Cofins_IdCofins);
            
            CreateTable(
                "dbo.TB_COR",
                c => new
                    {
                        IdCor = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.IdCor);
            
            CreateTable(
                "dbo.TB_FABRICANTE",
                c => new
                    {
                        IdFabricante = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.IdFabricante);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        IdFornecedor = c.Guid(nullable: false),
                        PessoaFisicaId = c.Guid(),
                        PessoaJuridicaId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        PessoaFisica_IdPessoa = c.Guid(),
                        PessoaJuridica_IdPessoa = c.Guid(),
                    })
                .PrimaryKey(t => t.IdFornecedor)
                .ForeignKey("dbo.TB_PESSOA_FISICA", t => t.PessoaFisica_IdPessoa)
                .ForeignKey("dbo.TB_PESSOA_JURIDICA", t => t.PessoaJuridica_IdPessoa)
                .Index(t => t.PessoaFisica_IdPessoa)
                .Index(t => t.PessoaJuridica_IdPessoa);
            
            CreateTable(
                "dbo.Entrada",
                c => new
                    {
                        IdEntrada = c.Guid(nullable: false, identity: true),
                        Fornecedor_IdFornecedor = c.Guid(),
                    })
                .PrimaryKey(t => t.IdEntrada)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_IdFornecedor)
                .Index(t => t.Fornecedor_IdFornecedor);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        IdGrupo = c.Guid(nullable: false),
                        Acrescimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Atualizar = c.String(maxLength: 8000, unicode: false),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(maxLength: 8000, unicode: false),
                        Desconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataAlteracao = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdGrupo);
            
            CreateTable(
                "dbo.TB_IPI",
                c => new
                    {
                        IdIpi = c.Guid(nullable: false, identity: true),
                        CodValor = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdIpi);
            
            CreateTable(
                "dbo.TB_MARCA",
                c => new
                    {
                        IdMarca = c.Guid(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Status = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.TB_PIS",
                c => new
                    {
                        IdPis = c.Guid(nullable: false, identity: true),
                        CodValor = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdPis);
            
            CreateTable(
                "dbo.TB_SIT_TRIBUTARIA",
                c => new
                    {
                        IdSitTibutaria = c.Guid(nullable: false, identity: true),
                        CodValor = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdSitTibutaria);
            
            CreateTable(
                "dbo.TB_TRIBUTACAO",
                c => new
                    {
                        IdTributacao = c.Guid(nullable: false, identity: true),
                        CodValor = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.IdTributacao);
            
            CreateTable(
                "dbo.TB_PESSOA_ENDERECO",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        IdEndereco = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdPessoa, t.IdEndereco })
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .ForeignKey("dbo.TB_ENDERECO", t => t.IdEndereco)
                .Index(t => t.IdPessoa)
                .Index(t => t.IdEndereco);
            
            CreateTable(
                "dbo.TB_CONTATO_ENDERECO",
                c => new
                    {
                        IdContato = c.Guid(nullable: false),
                        IdEndereco = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdContato, t.IdEndereco })
                .ForeignKey("dbo.TB_CONTATO", t => t.IdContato)
                .ForeignKey("dbo.TB_ENDERECO", t => t.IdEndereco)
                .Index(t => t.IdContato)
                .Index(t => t.IdEndereco);
            
            CreateTable(
                "dbo.TB_AGENDA_ENDERECO",
                c => new
                    {
                        IdAgenda = c.Guid(nullable: false),
                        IdEndereco = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdAgenda, t.IdEndereco })
                .ForeignKey("dbo.TB_AGENDA", t => t.IdAgenda)
                .ForeignKey("dbo.TB_ENDERECO", t => t.IdEndereco)
                .Index(t => t.IdAgenda)
                .Index(t => t.IdEndereco);
            
            CreateTable(
                "dbo.TB_PESSOA_FISICA",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        CPF_Codigo = c.String(nullable: false, maxLength: 11, unicode: false),
                        RG = c.String(nullable: false, maxLength: 8000, unicode: false),
                        DataDeNascimento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NomeDoPai = c.String(maxLength: 200, unicode: false),
                        NomeDaMae = c.String(maxLength: 200, unicode: false),
                        NaturalidadeId = c.Guid(),
                        Nacionalidade = c.String(maxLength: 60, unicode: false),
                        Sexo = c.Int(nullable: false),
                        EstadoCivil = c.Int(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .ForeignKey("dbo.TB_ESTADO", t => t.NaturalidadeId)
                .Index(t => t.IdPessoa)
                .Index(t => t.NaturalidadeId);
            
            CreateTable(
                "dbo.TB_FUNCIONARIO",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        CTPS = c.String(maxLength: 30, unicode: false),
                        DataDaProximaFerias = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA_FISICA", t => t.IdPessoa)
                .Index(t => t.IdPessoa);
            
            CreateTable(
                "dbo.TB_PESSOA_JURIDICA",
                c => new
                    {
                        IdPessoa = c.Guid(nullable: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 200, unicode: false),
                        NomeFantasia = c.String(nullable: false, maxLength: 200, unicode: false),
                        CNPJ_Codigo = c.String(nullable: false, maxLength: 14, unicode: false),
                        Inscricao = c.String(maxLength: 8000, unicode: false),
                        DataDeCriacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SocioId = c.Guid(nullable: false),
                        SocioMenorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA", t => t.IdPessoa)
                .ForeignKey("dbo.TB_PESSOA_FISICA", t => t.SocioId)
                .ForeignKey("dbo.TB_PESSOA_FISICA", t => t.SocioMenorId)
                .Index(t => t.IdPessoa)
                .Index(t => t.SocioId)
                .Index(t => t.SocioMenorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PESSOA_JURIDICA", "SocioMenorId", "dbo.TB_PESSOA_FISICA");
            DropForeignKey("dbo.TB_PESSOA_JURIDICA", "SocioId", "dbo.TB_PESSOA_FISICA");
            DropForeignKey("dbo.TB_PESSOA_JURIDICA", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_FUNCIONARIO", "IdPessoa", "dbo.TB_PESSOA_FISICA");
            DropForeignKey("dbo.TB_PESSOA_FISICA", "NaturalidadeId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_PESSOA_FISICA", "IdPessoa", "dbo.TB_PESSOA");
            DropForeignKey("dbo.Produto", "Cofins_IdCofins", "dbo.TB_COFINS");
            DropForeignKey("dbo.Produto", "Tributacao_IdTributacao", "dbo.TB_TRIBUTACAO");
            DropForeignKey("dbo.Produto", "SitTributaria_IdSitTibutaria", "dbo.TB_SIT_TRIBUTARIA");
            DropForeignKey("dbo.Produto", "Pis_IdPis", "dbo.TB_PIS");
            DropForeignKey("dbo.Produto", "Marca_IdMarca", "dbo.TB_MARCA");
            DropForeignKey("dbo.Produto", "Ipi_IdIpi", "dbo.TB_IPI");
            DropForeignKey("dbo.Produto", "Grupo_IdGrupo", "dbo.Grupo");
            DropForeignKey("dbo.Fornecedor", "PessoaJuridica_IdPessoa", "dbo.TB_PESSOA_JURIDICA");
            DropForeignKey("dbo.Fornecedor", "PessoaFisica_IdPessoa", "dbo.TB_PESSOA_FISICA");
            DropForeignKey("dbo.Produto", "Fornecedor_IdFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Entrada", "Fornecedor_IdFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Produto", "Fabricante_IdFabricante", "dbo.TB_FABRICANTE");
            DropForeignKey("dbo.Produto", "Cor_IdCor", "dbo.TB_COR");
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_AGENDA_ENDERECO", "IdAgenda", "dbo.TB_AGENDA");
            DropForeignKey("dbo.TB_ENDERECO", "EstadoId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_ENDERECO", "CidadeId", "dbo.TB_CIDADE");
            DropForeignKey("dbo.TB_CIDADE", "EstadoId", "dbo.TB_ESTADO");
            DropForeignKey("dbo.TB_HISTORICO_DE_CARGO", "FuncionarioId", "dbo.TB_FUNCIONARIO");
            DropForeignKey("dbo.TB_HISTORICO_DE_CARGO", "CargoId", "dbo.TB_CARGO");
            DropForeignKey("dbo.TB_MEIO_COMUNICACAO", "TipoDeMeioDeComunicacaoId", "dbo.TB_TIPO_MEIO_COMUNICACAO");
            DropForeignKey("dbo.TB_MEIO_COMUNICACAO", "PessoaId", "dbo.TB_PESSOA");
            DropForeignKey("dbo.TB_CONTATO", "PessoaJuridicaId", "dbo.TB_PESSOA_JURIDICA");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_CONTATO_ENDERECO", "IdContato", "dbo.TB_CONTATO");
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdEndereco", "dbo.TB_ENDERECO");
            DropForeignKey("dbo.TB_PESSOA_ENDERECO", "IdPessoa", "dbo.TB_PESSOA");
            DropIndex("dbo.TB_PESSOA_JURIDICA", new[] { "SocioMenorId" });
            DropIndex("dbo.TB_PESSOA_JURIDICA", new[] { "SocioId" });
            DropIndex("dbo.TB_PESSOA_JURIDICA", new[] { "IdPessoa" });
            DropIndex("dbo.TB_FUNCIONARIO", new[] { "IdPessoa" });
            DropIndex("dbo.TB_PESSOA_FISICA", new[] { "NaturalidadeId" });
            DropIndex("dbo.TB_PESSOA_FISICA", new[] { "IdPessoa" });
            DropIndex("dbo.TB_AGENDA_ENDERECO", new[] { "IdEndereco" });
            DropIndex("dbo.TB_AGENDA_ENDERECO", new[] { "IdAgenda" });
            DropIndex("dbo.TB_CONTATO_ENDERECO", new[] { "IdEndereco" });
            DropIndex("dbo.TB_CONTATO_ENDERECO", new[] { "IdContato" });
            DropIndex("dbo.TB_PESSOA_ENDERECO", new[] { "IdEndereco" });
            DropIndex("dbo.TB_PESSOA_ENDERECO", new[] { "IdPessoa" });
            DropIndex("dbo.Entrada", new[] { "Fornecedor_IdFornecedor" });
            DropIndex("dbo.Fornecedor", new[] { "PessoaJuridica_IdPessoa" });
            DropIndex("dbo.Fornecedor", new[] { "PessoaFisica_IdPessoa" });
            DropIndex("dbo.Produto", new[] { "Cofins_IdCofins" });
            DropIndex("dbo.Produto", new[] { "Tributacao_IdTributacao" });
            DropIndex("dbo.Produto", new[] { "SitTributaria_IdSitTibutaria" });
            DropIndex("dbo.Produto", new[] { "Pis_IdPis" });
            DropIndex("dbo.Produto", new[] { "Marca_IdMarca" });
            DropIndex("dbo.Produto", new[] { "Ipi_IdIpi" });
            DropIndex("dbo.Produto", new[] { "Grupo_IdGrupo" });
            DropIndex("dbo.Produto", new[] { "Fornecedor_IdFornecedor" });
            DropIndex("dbo.Produto", new[] { "Fabricante_IdFabricante" });
            DropIndex("dbo.Produto", new[] { "Cor_IdCor" });
            DropIndex("dbo.TB_HISTORICO_DE_CARGO", new[] { "FuncionarioId" });
            DropIndex("dbo.TB_HISTORICO_DE_CARGO", new[] { "CargoId" });
            DropIndex("dbo.TB_CONTATO", new[] { "PessoaJuridicaId" });
            DropIndex("dbo.TB_MEIO_COMUNICACAO", new[] { "PessoaId" });
            DropIndex("dbo.TB_MEIO_COMUNICACAO", new[] { "TipoDeMeioDeComunicacaoId" });
            DropIndex("dbo.TB_CIDADE", new[] { "EstadoId" });
            DropIndex("dbo.TB_ENDERECO", new[] { "EstadoId" });
            DropIndex("dbo.TB_ENDERECO", new[] { "CidadeId" });
            DropTable("dbo.TB_PESSOA_JURIDICA");
            DropTable("dbo.TB_FUNCIONARIO");
            DropTable("dbo.TB_PESSOA_FISICA");
            DropTable("dbo.TB_AGENDA_ENDERECO");
            DropTable("dbo.TB_CONTATO_ENDERECO");
            DropTable("dbo.TB_PESSOA_ENDERECO");
            DropTable("dbo.TB_TRIBUTACAO");
            DropTable("dbo.TB_SIT_TRIBUTARIA");
            DropTable("dbo.TB_PIS");
            DropTable("dbo.TB_MARCA");
            DropTable("dbo.TB_IPI");
            DropTable("dbo.Grupo");
            DropTable("dbo.Entrada");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.TB_FABRICANTE");
            DropTable("dbo.TB_COR");
            DropTable("dbo.Produto");
            DropTable("dbo.TB_COFINS");
            DropTable("dbo.TB_CARGO");
            DropTable("dbo.TB_HISTORICO_DE_CARGO");
            DropTable("dbo.TB_TIPO_MEIO_COMUNICACAO");
            DropTable("dbo.TB_CONTATO");
            DropTable("dbo.TB_MEIO_COMUNICACAO");
            DropTable("dbo.TB_PESSOA");
            DropTable("dbo.TB_ESTADO");
            DropTable("dbo.TB_CIDADE");
            DropTable("dbo.TB_ENDERECO");
            DropTable("dbo.TB_AGENDA");
        }
    }
}
