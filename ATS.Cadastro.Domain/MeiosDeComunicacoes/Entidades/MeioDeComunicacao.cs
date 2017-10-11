using ATS.Cadastro.Domain.MeiosDeComunicacoes.Scopes;
using ATS.Cadastro.Domain.Pessoas.Entidades;
using ATS.Core.Domain.Helpers;
using ATS.Core.Domain.ValueObjects;
using DomainValidation.Validation;
using System;

namespace ATS.Cadastro.Domain.MeiosDeComunicacoes.Entidades
{
    public class MeioDeComunicacao
    {
        protected MeioDeComunicacao()
        {
        }

        public MeioDeComunicacao(string valor, Guid? idPessoa, TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao, Guid? idMeioDeComunicacao)
        {
            IdMeioDeComunicacao = (idMeioDeComunicacao == null || idMeioDeComunicacao == Guid.Empty) ? Guid.NewGuid() : idMeioDeComunicacao.Value;

            DefinirPessoa(idPessoa);
            DefinirTipoDeMeioDeComunicacao(tipoDeMeioDeComunicacao.IdTipoDeMeioDeComunicacao);
            DefinirValorDoMeioDeComunicacao(valor, tipoDeMeioDeComunicacao);
        }

        #region "Propriedades"

        public Guid IdMeioDeComunicacao { get; private set; }

        public string Valor { get; private set; }

        public Guid TipoDeMeioDeComunicacaoId { get; private set; }

        public TipoDeMeioDeComunicacao TipoDeMeioDeComunicacao { get; private set; }

        public Guid PessoaId { get; private set; }

        public Pessoa Pessoa { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region "Métodos"

        public void DefinirPessoa(Guid? idPessoa)
        {
            if (!this.DefinirPessoaMeioDeComunicacaoScopeEhValido(idPessoa))
                return;

            PessoaId = idPessoa.Value;
        }

        public void DefinirTipoDeMeioDeComunicacao(Guid? idTipoDeMeioDeComunicacao)
        {
            if (!this.DefinirTipoMeioDeComunicacaoMeioDeComunicacaoScopeEhValido(idTipoDeMeioDeComunicacao))
                return;

            TipoDeMeioDeComunicacaoId = idTipoDeMeioDeComunicacao.Value;
        }

        public void DefinirTipoDeMeioDeComunicacao(TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao)
        {
            if (!this.DefinirTipoMeioDeComunicacaoMeioDeComunicacaoScopeEhValido(tipoDeMeioDeComunicacao))
                return;

            TipoDeMeioDeComunicacao = tipoDeMeioDeComunicacao;
        }

        public void DefinirValorDoMeioDeComunicacao(string valor, TipoDeMeioDeComunicacao tipoDeMeioDeComunicacao)
        {
            switch (tipoDeMeioDeComunicacao.Descricao)
            {
                case "TELEFONE":
                    var tempTelefone = new Telefone(valor);

                    if (!this.DefinirTelefoneMeioDeComunicacaoScopeEhValido(tempTelefone))
                        return;

                    Valor = TextoHelper.GetNumeros(tempTelefone.Numero);
                    break;
                case "CELULAR":
                    var tempCelular = new Telefone(valor);

                    if (!this.DefinirTelefoneMeioDeComunicacaoScopeEhValido(tempCelular))
                        return;

                    Valor = TextoHelper.GetNumeros(tempCelular.Numero);
                    break;
                case "E-MAIL":
                    var tempEmail = new Email(valor);

                    if (!this.DefinirEmailMeioDeComunicacaoScopeEhValido(tempEmail))
                        return;

                    Valor = tempEmail.Endereco;
                    break;
                case "REDE SOCIAL":
                    if (!this.DefinirRedeSocialMeioDeComunicacaoScopeEhValido(valor))
                        return;

                    Valor = valor;
                    break;
                case "SITE":
                    if (!this.DefinirSiteMeioDeComunicacaoScopeEhValido(valor))
                        return;

                    Valor = valor;
                    break;
            }
        }

        #endregion
    }
}
