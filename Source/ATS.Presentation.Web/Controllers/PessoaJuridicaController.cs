using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Application.ViewModels.PessoaJuridica;
using ATS.Core.Domain.Helpers;
using ATS.Core.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ATS.Presentation.Web.Controllers
{
    public class PessoaJuridicaController : BaseController
    {
        private readonly IPessoaJuridicaApp _pessoaJuridicaApp;
        private readonly IPessoaFisicaApp _pessoaFisicaApp;
        private readonly IEstadoApp _estadoApp;
        private readonly ICidadeApp _cidadeApp;
        private readonly ITipoDeMeioDeComunicacaoApp _tipoDeMeioDeComunicacaoApp;

        public PessoaJuridicaController(IPessoaFisicaApp pessoaFisicaApp, IPessoaJuridicaApp pessoaJuridicaApp, IEstadoApp estadoApp, ICidadeApp cidadeApp, ITipoDeMeioDeComunicacaoApp tipoDeMeioDeComunicacaoApp)
        {
            _pessoaJuridicaApp = pessoaJuridicaApp;
            _pessoaFisicaApp = pessoaFisicaApp;
            _estadoApp = estadoApp;
            _cidadeApp = cidadeApp;
            _tipoDeMeioDeComunicacaoApp = tipoDeMeioDeComunicacaoApp;
        }

        // GET: PessoaJuridica
        public ActionResult Index()
        {
            var pessoaJuridicaPesquisaVM = new PesquisarPessoaJuridicaViewModel();

            return View(_pessoaJuridicaApp.PesquisarPessoaJuridica(pessoaJuridicaPesquisaVM));
        }

        public ActionResult Pesquisar()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(PesquisarPessoaJuridicaViewModel pessoaJuridicaPesquisaVM)
        {
            var resultado = _pessoaJuridicaApp.PesquisarPessoaJuridica(pessoaJuridicaPesquisaVM);

            return View("Index", resultado);
        }

        public ActionResult Cadastrar()
        {
            var pessoaJuridicaCadastroVM = new CadastrarPessoaJuridicaViewModel();
            pessoaJuridicaCadastroVM.EstadoList = PopularComboDeEstados();
            pessoaJuridicaCadastroVM.CidadeList = PopularComboDeCidades();
            pessoaJuridicaCadastroVM.EstadoCivilList = PopularComboDeEstadoCivil();

            return View(pessoaJuridicaCadastroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastrarPessoaJuridicaViewModel pessoaJuridicaCadastroVM)
        {
            pessoaJuridicaCadastroVM.EstadoList = PopularComboDeEstados();
            pessoaJuridicaCadastroVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaJuridicaCadastroVM.CidadeList = PopularComboDeCidades(pessoaJuridicaCadastroVM.DadosDeEndereco.EstadoId);

            var pessoaJuridicaVM = _pessoaJuridicaApp.CadastrarPessoaJuridica(pessoaJuridicaCadastroVM);

            if (!ValidarErrosDominio())
            {
                return View("Editar", pessoaJuridicaVM.IdPessoa);
            }

            return View(pessoaJuridicaCadastroVM);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult AtualizarListaDeCidadesPorEstado(Guid idEstado)
        {
            var resposta = new { Resource = "", Messagem = "", Status = "0" };

            try
            {
                var lista = PopularComboDeCidades(idEstado);

                var acessosSerialize = new JavaScriptSerializer().Serialize(lista);

                resposta = new { Resource = acessosSerialize, Messagem = string.Empty, Status = "1" };
            }
            catch (Exception ex)
            {
                resposta = new { Resource = string.Empty, Messagem = "Erro " + ex.Message, Status = "0" };
            }

            return Json(resposta, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Editar(Guid id)
        {
            var pessoaJuridicaEdicaoVM = new EditarPessoaJuridicaViewModel();
            pessoaJuridicaEdicaoVM.EstadoList = PopularComboDeEstados();
            pessoaJuridicaEdicaoVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaJuridicaEdicaoVM.CidadeList = PopularComboDeCidades();
            pessoaJuridicaEdicaoVM.TipoDeMeioDeComunicacaoList = PopularComboDeTiposDeMeio();

            var pessoaVM = _pessoaJuridicaApp.ObterDadosPessoaJuridica(id);

            pessoaJuridicaEdicaoVM.DadosDaPessoaJuridica = pessoaVM.DadosDaPessoaJuridica;
            pessoaJuridicaEdicaoVM.ListaDeEnderecos = pessoaVM.ListaDeEnderecos;
            pessoaJuridicaEdicaoVM.ListaDeMeioDeComunicacao = pessoaVM.ListaDeMeioDeComunicacao;

            return View(pessoaJuridicaEdicaoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditarPessoaJuridicaViewModel pessoaJuridicaEdicaoVM)
        {
            pessoaJuridicaEdicaoVM.EstadoList = PopularComboDeEstados();
            pessoaJuridicaEdicaoVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaJuridicaEdicaoVM.CidadeList = PopularComboDeCidades();
            pessoaJuridicaEdicaoVM.TipoDeMeioDeComunicacaoList = PopularComboDeTiposDeMeio();

            var pessoaVM = _pessoaJuridicaApp.AtualizarPessoaJuridica(pessoaJuridicaEdicaoVM);

            if (!ValidarErrosDominio())
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Editar", pessoaJuridicaEdicaoVM.DadosDaPessoaJuridica.IdPessoa);
        }

        [HttpPost]
        public JsonResult Remover(Guid id)
        {
            var Resposta = new { Status = "0", Mensagem = "" };

            try
            {
                //_pessoaFisicaApp.ExcluirPessoaFisica(id);

                Resposta = new { Status = "1", Mensagem = Texto.ExcluidoComSucesso };
            }
            catch (SqlException ex)
            {
                Resposta = new { Status = "0", Mensagem = string.Format(Texto.NaoEhPossivelExcluir, ex.Message) };
            }
            catch (Exception ex)
            {
                Resposta = new { Status = "0", Mensagem = string.Format(Texto.NaoEhPossivelExcluir, ex.Message) };
            }

            return Json(Resposta);
        }

        private IEnumerable<SelectListItem> PopularComboDeEstados()
        {
            return _estadoApp.ObterTodosOsEstados().OrderBy(m => m.Nome).ToSelectList(m => m.IdEstado, m => (m.Nome + "/" + m.UF)).Where(m => m.Value != "");
        }

        private IList<SelectListItem> PopularComboDeEstadoCivil()
        {
            return _pessoaFisicaApp.ObterTodosOsEstadosCivis()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();
        }

        private IEnumerable<SelectListItem> PopularComboDeTiposDeMeio()
        {
            return _tipoDeMeioDeComunicacaoApp.ObterTodosOsTipos().ToSelectList(m => m.IdTipoDeMeioDeComunicacao, m => m.Descricao);
        }
        
        private IEnumerable<SelectListItem> PopularComboDeCidades(Guid? idEstado = null)
        {
            if (idEstado == null)
            {
                return new List<SelectListItem>();
            }
            else
            {
                return _cidadeApp.ObterTodasCidadesPor(idEstado.Value).ToSelectList(m => m.IdCidade, m => m.Nome).Where(m => m.Value != "");
            }
        }
    }
}