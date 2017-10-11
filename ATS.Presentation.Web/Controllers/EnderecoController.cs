using ATS.Cadastro.Application.Commands;
using ATS.Cadastro.Application.Interfaces;
using ATS.Core.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ATS.Presentation.Web.Controllers
{
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoApp _enderecoApp;

        public EnderecoController(IEnderecoApp enderecoApp)
        {
            _enderecoApp = enderecoApp;
        }

        // GET: Endereco
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(EnderecoCommands enderecoVM)
        {
            var Resposta = new { Status = "0", Mensagem = "", Objeto = "" };

            try
            {
                var endereco = _enderecoApp.CadastrarEndereco(enderecoVM);

                var enderecoSerializado = new JavaScriptSerializer().Serialize(endereco);

                if (ValidarErrosDominio())
                {
                    var mensagem = string.Empty;

                    foreach (var item in Toastr.ToastMessages)
                    {
                        mensagem += "<span>" + item.Message + "</span><br />";
                    }

                    Resposta = new { Status = "2", Mensagem = mensagem, Objeto = "" };
                }
                else
                {
                    Resposta = new { Status = "1", Mensagem = Texto.CadastroComSucesso, Objeto = enderecoSerializado };
                }
            }
            catch (Exception ex)
            {
                Resposta = new { Status = "0", Mensagem = string.Format(ex.Message), Objeto = "" };
            }

            return Json(Resposta);
        }

        [HttpPost]
        public JsonResult Remover(Guid id)
        {
            var Resposta = new { Status = "0", Mensagem = "" };

            try
            {
                _enderecoApp.RemoverEndereco(id);

                if (ValidarErrosDominio())
                {
                    var mensagem = string.Empty;

                    foreach (var item in Toastr.ToastMessages)
                    {
                        mensagem += "<span>" + item.Message + "</span><br />";
                    }

                    Resposta = new { Status = "2", Mensagem = mensagem };
                }
                else
                {
                    Resposta = new { Status = "1", Mensagem = Texto.ExcluidoComSucesso };
                }
            }
            catch (Exception ex)
            {
                Resposta = new { Status = "0", Mensagem = string.Format(ex.Message) };
            }

            return Json(Resposta);
        }
    }
}