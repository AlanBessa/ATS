using ATS.Cadastro.Application.Interfaces;
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
    public class MeioDeComunicacaoController : BaseController
    {
        public readonly IMeioDeComunicacaoApp _meioDeComunicacaoApp;
        
        public MeioDeComunicacaoController(IMeioDeComunicacaoApp meioDeComunicacaoApp)
        {
            _meioDeComunicacaoApp = meioDeComunicacaoApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Cadastrar(string valor, Guid idTipo, Guid idPessoa)
        {
            var Resposta = new { Status = "0", Mensagem = "", Objeto = "" };

            try
            {
                var meio = _meioDeComunicacaoApp.CadastrarMeioDeComunicacao(valor, idTipo, idPessoa);

                var meioSerializado = new JavaScriptSerializer().Serialize(meio);

                if (ValidarErrosDominio())
                {
                    var mensagem = string.Empty;

                    foreach(var item in Toastr.ToastMessages)
                    {
                        mensagem += "<span>" + item.Message + "</span><br />";
                    }

                    Resposta = new { Status = "2", Mensagem = mensagem, Objeto = "" };
                }
                else
                {
                    Resposta = new { Status = "1", Mensagem = Texto.CadastroComSucesso, Objeto = meioSerializado };
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
                _meioDeComunicacaoApp.Remover(id);

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
    }
}