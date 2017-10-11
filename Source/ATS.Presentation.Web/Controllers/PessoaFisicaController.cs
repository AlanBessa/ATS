using ATS.Cadastro.Application.Interfaces;
using ATS.Cadastro.Application.ViewModels.PessoaFisica;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using ATS.Core.Domain.Helpers;
using System;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using ATS.Core.Domain.Resources;

namespace ATS.Presentation.Web.Controllers
{
    public class PessoaFisicaController : BaseController
    {
        private readonly IPessoaFisicaApp _pessoaFisicaApp;
        private readonly IEstadoApp _estadoApp;
        private readonly ICidadeApp _cidadeApp;
        private readonly ITipoDeMeioDeComunicacaoApp _tipoDeMeioDeComunicacaoApp;

        public PessoaFisicaController(IPessoaFisicaApp pessoaFisicaApp, IEstadoApp estadoApp, ICidadeApp cidadeApp, ITipoDeMeioDeComunicacaoApp tipoDeMeioDeComunicacaoApp)
        {
            _pessoaFisicaApp = pessoaFisicaApp;
            _estadoApp = estadoApp;
            _cidadeApp = cidadeApp;
            _tipoDeMeioDeComunicacaoApp = tipoDeMeioDeComunicacaoApp;
        }

        public ActionResult Index()
        {
            var pessoaFisicaPesquisaVM = new PesquisarPessoaFisicaViewModel();

            return View(_pessoaFisicaApp.PesquisarPessoaFisica(pessoaFisicaPesquisaVM));
        }

        public ActionResult Pesquisar()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(PesquisarPessoaFisicaViewModel pessoaFisicaPesquisaVM)
        {
            var resultado = _pessoaFisicaApp.PesquisarPessoaFisica(pessoaFisicaPesquisaVM);

            return View("Index", resultado);
        }

        public ActionResult Cadastrar()
        {
            var pessoaFisicaCadastroVM = new CadastrarPessoaFisicaViewModel();
            pessoaFisicaCadastroVM.EstadoList = PopularComboDeEstados();
            pessoaFisicaCadastroVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaFisicaCadastroVM.CidadeList = PopularComboDeCidades();

            return View(pessoaFisicaCadastroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastrarPessoaFisicaViewModel pessoaFisicaCadastroVM)
        {
            pessoaFisicaCadastroVM.EstadoList = PopularComboDeEstados();
            pessoaFisicaCadastroVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaFisicaCadastroVM.CidadeList = PopularComboDeCidades(pessoaFisicaCadastroVM.DadosDeEndereco.EstadoId);

            var pessoaFisicaVM = _pessoaFisicaApp.CadastrarPessoaFisica(pessoaFisicaCadastroVM);

            if (!ValidarErrosDominio())
            {
                return View("Editar", pessoaFisicaVM.IdPessoa);
            }

            return View(pessoaFisicaCadastroVM);
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
            var pessoaFisicaEdicaoVM = new EditarPessoaFisicaViewModel();
            pessoaFisicaEdicaoVM.EstadoList = PopularComboDeEstados();
            pessoaFisicaEdicaoVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaFisicaEdicaoVM.CidadeList = PopularComboDeCidades();
            pessoaFisicaEdicaoVM.TipoDeMeioDeComunicacaoList = PopularComboDeTiposDeMeio();

            var pessoaVM = _pessoaFisicaApp.ObterDadosPessoaFisica(id);

            pessoaFisicaEdicaoVM.DadosDaPessoaFisica = pessoaVM.DadosDaPessoaFisica;
            pessoaFisicaEdicaoVM.ListaDeEnderecos = pessoaVM.ListaDeEnderecos;
            pessoaFisicaEdicaoVM.ListaDeMeioDeComunicacao = pessoaVM.ListaDeMeioDeComunicacao;

            return View(pessoaFisicaEdicaoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditarPessoaFisicaViewModel pessoaFisicaEdicaoVM)
        {
            pessoaFisicaEdicaoVM.EstadoList = PopularComboDeEstados();
            pessoaFisicaEdicaoVM.EstadoCivilList = PopularComboDeEstadoCivil();
            pessoaFisicaEdicaoVM.CidadeList = PopularComboDeCidades();
            pessoaFisicaEdicaoVM.TipoDeMeioDeComunicacaoList = PopularComboDeTiposDeMeio();

            var pessoaVM = _pessoaFisicaApp.AtualizarPessoaFisica(pessoaFisicaEdicaoVM);

            if (ValidarErrosDominio())
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Editar", pessoaFisicaEdicaoVM.DadosDaPessoaFisica.IdPessoa);             
        }

        [HttpPost]
        public JsonResult Remover(Guid id)
        {
            var Resposta = new { Status = "0", Mensagem = "" };

            try
            {
                _pessoaFisicaApp.ExcluirPessoaFisica(id);

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

        private IEnumerable<SelectListItem> PopularComboDeTiposDeMeio()
        {
            return _tipoDeMeioDeComunicacaoApp.ObterTodosOsTipos().ToSelectList(m => m.IdTipoDeMeioDeComunicacao, m => m.Descricao);
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