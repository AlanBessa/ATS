$(document).ready(function ()
{
    $('.selectpickerEstado').multiselect({
        buttonWidth: '100%',
        buttonClass: 'btn btn-default formatMultiSelect',
        nonSelectedText: 'Selecione uma opção',
        maxHeight: 200,
        disableIfEmpty: true,
        onChange: function (option, checked) {
            var value = option.val();
            if (value != "" || value != "0") {
                var msgError = option.parent().parent().find(".text-danger");

                msgError.removeClass("field-validation-error").addClass("field-validation-valid");
                msgError.find('.msgError').remove();

                if (value != "" && value != "0") {
                    if (checked) {
                        $.getJSON("/PessoaFisica/AtualizarListaDeCidadesPorEstado",
                                 { idEstado: option.val() },
                                 function (resposta) {
                                     try {
                                         if (resposta.Status == "1") {
                                             var listaDeCidades = [];

                                             var acessos = $.parseJSON(resposta.Resource);

                                             acessos.forEach(function (c) {
                                                 listaDeCidades.push({ label: c.Text, value: c.Value });
                                             });

                                             $('#DadosDeEndereco_CidadeId').multiselect('dataprovider', listaDeCidades);
                                         }
                                         else {
                                             //Alerta(resposta.Mensagem, "Erro", "danger");
                                             $("#DadosDeEndereco_CidadeId").multiselect('dataprovider', "");
                                         }
                                     }
                                     catch (err) {
                                         //Alerta(err.mensagem, "Erro", "danger");
                                         $("#DadosDeEndereco_CidadeId").multiselect('dataprovider', "");
                                     }
                                 });
                    }
                    else {
                        $("#EstacaoAcessoId").multiselect('dataprovider', "");
                        $("#ATMId").multiselect('dataprovider', "");
                    }
                }
                else {
                    $("#EstacaoAcessoId").multiselect('dataprovider', "");
                    $("#ATMId").multiselect('dataprovider', "");
                }
            }
        }
    });

    $('.selectpickerOneOption').multiselect({
        buttonWidth: '100%',
        buttonClass: 'btn btn-default formatMultiSelect',
        nonSelectedText: 'Selecione uma opção',
        maxHeight: 200,
        disableIfEmpty: true,
        onChange: function (option, checked) {
            var value = option.val();
            if (value != "" || value != "0") {
                var msgError = option.parent().parent().find(".text-danger");

                msgError.removeClass("field-validation-error").addClass("field-validation-valid");
                msgError.find('.msgError').remove();
            }
        }
    });

    $('form').submit(function ()
    {
        var validation = [];

        $('.required').each(function () {
            var msgError = $(this).parent().find(".text-danger");

            var value = $(this).find("option:selected").val();
            if (value == "" || value == "0" || value == undefined) {
                var nomeCampo = $(this).attr('data-val-required');
                var id = $(this).attr('id');

                msgError.removeClass("field-validation-valid").addClass("field-validation-error");
                msgError.html('<span id="' + id + '-error" class="msgError">' + nomeCampo + '</span>');

                validation.push(false);
            }
            else {
                msgError.removeClass("field-validation-error").addClass("field-validation-valid");
                msgError.find('.msgError').remove();
            }
        });

        if (validation.length > 0) {
            return false;
        }
    });
});