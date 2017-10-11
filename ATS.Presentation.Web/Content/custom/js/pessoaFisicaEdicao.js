$(document).ready(function () {
    $('.btnExcluir').popover({
        html: true,
        placement: "left",
        title: "Confirmação",
        trigger: "click",
        content: $("#DivPopover").html()
    });

    $(document).on("click", ".btnExcluir", function () {
        $(this).parents("tr").siblings().find(".btnExcluir").popover('hide');
    });

    $(document).on("click", ".btnCancelarExclusao", function () {
        $(this).parents("td").find(".btnExcluir").click();
    });

    $(document).on("click", ".btnConfirmarExclusao", function () {
        var id = $(this).parents("td").find(".btnExcluir").attr("id");
        var tabela = $(this).parents("td").find(".btnExcluir").attr("tabela");

        var caminho = "";
        var dado = "";
        var exclusao = $(this);
        var dataTable;

        if (tabela === "meio") {
            caminho = "/MeioDeComunicacao/Remover";
            dado = "{'id' : '" + id + "'}";
            dataTable = $("#tbMeios");
        }
        else if (tabela === "endereco") {
            caminho = "/Endereco/Remover";
            dado = "{'id' : '" + id + "'}";
            dataTable = $("#tbEnderecos");
        }

        $.ajax({
            type: "POST",
            url: caminho,
            data: dado,
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (Resposta) {
                if (Resposta.Status == "1") {
                    toastr["success"](Resposta.Mensagem);
                    dataTable.DataTable().row(exclusao.parents("tr")).remove().draw();
                } else {
                    toastr["error"](Resposta.Mensagem);
                }

                exclusao.parent().find(".btnCancelarExclusao").click();
            }
        });
    });

    $('.selectTipo').multiselect({
        buttonWidth: '100%',
        buttonClass: 'btn btn-default formatMultiSelect',
        nonSelectedText: 'Selecione uma opção',
        maxHeight: 200,
        disableIfEmpty: true,
        onChange: function (option, checked) {
            var value = option.text();
            if (value == "TELEFONE" || value == "CELULAR") {
                $(".meioModal").val("");
                $(".meioModal").mask(maskBehavior, options);
            }
            else {
                $(".meioModal").val("");
                $(".meioModal").unmask();
            }
        }
    });

    var tabela = $('.datatable').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "pageLength": 10,
        "responsive": true,
        "language": {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
    });

    $(document).on("click", ".btnSalvarMeio", function () {
        var tipoValido = false;
        var telefoneValido = false;
        var valor = $(".meioModal");
        var tipo = $(".selectTipo");
        var meioErro = $("#meioErro");
        var tipoErro = $("#tipoErro");
        var idPessoa = $("#DadosDaPessoaFisica_IdPessoa").val();
        var tipoSelecionado = "";

        if (valor.val() === "") {
            meioErro.text("Campo obrigatorio").show();
            telefoneValido = false;
        }
        else {
            if (tipo.val() != null) {
                tipoSelecionado = tipo.parent().find("ul li.active").text().trim();

                if (tipoSelecionado == "TELEFONE" || tipoSelecionado == "CELULAR") {
                    // Regex validate phone
                    var reFone8 = new RegExp(/\(\d{2}\) \d{4}-\d{4}/);
                    var reFone9 = new RegExp(/\(\d{2}\) \d{5}-\d{4}/);

                    if (valor.val().match(reFone8) == null && valor.val().match(reFone9) == null) {
                        meioErro.text("Telefone inválido").show();
                        telefoneValido = false;
                    }
                    else {
                        meioErro.text("").hide();
                        telefoneValido = true;
                    }
                }
                else {
                    meioErro.text("").hide();
                    telefoneValido = true;
                }
            }
            else {
                meioErro.text("").hide();
                telefoneValido = true;
            }
        }

        if (tipo.val() == null) {
            tipoErro.text("Campo obrigatorio").show();
            tipoValido = false;
        }
        else {
            tipoErro.text("").hide();
            tipoValido = true;
        }

        if (telefoneValido && tipoValido)
        {
            $.ajax({
                type: "POST",
                url: "/MeioDeComunicacao/Cadastrar",
                data: "{'valor' : '" + valor.val() + "', 'idTipo' : '" + tipo.val() + "', 'idPessoa' : '" + idPessoa + "'}",
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (Resposta)
                {  
                    if (Resposta.Status == "1") {
                        valor.val("");
                        tipo.multiselect('deselect', tipo.val());

                        var meio = $.parseJSON(Resposta.Objeto);

                        toastr["success"](Resposta.Mensagem);

                        window.setTimeout('location.reload()', 2000);
                    }
                    else if (Resposta.Status == "2") {
                        toastr["warning"](Resposta.Mensagem);
                    }
                    else {
                        toastr["error"](Resposta.Mensagem);
                    }
                }
            });
        }
    });    

    $(document).on("click", ".btnSalvarEndereco", function () {
        var logradouroValido = false;
        var numeroValido = false;
        var bairroValido = false;
        var cidadeValido = false;
        var estadoValido = false;
        var cepValido = false;
        var logradouro = $(".logradouro");
        var numero = $(".numero");
        var complemento = $(".complemento");
        var bairro = $(".bairro");
        var cidade = $(".cidade");
        var estado = $(".estado");
        var cep = $("span.cep");
        var logradouroErro = $("#logradouroErro");
        var numeroErro = $("#numeroErro");
        var bairroErro = $("#bairroErro");
        var cidadeErro = $("#cidadeErro");
        var estadoErro = $("#estadoErro");
        var cepErro = $("#cepErro");
        var idPessoa = $("#DadosDaPessoaFisica_IdPessoa").val();
        //var tipoSelecionado = "";

        if (logradouro.val() === "") {
            logradouroErro.text("Campo obrigatorio").show();
            logradouroValido = false;
        }
        else {
            logradouroErro.text("").hide();
            logradouroValido = true;
        }

        if (numero.val() === "") {
            numeroErro.text("Campo obrigatorio").show();
            numeroValido = false;
        }
        else {
            var reNumero = new RegExp('^\\d+$');

            if (numero.val().match(reNumero) == null) {
                numeroErro.text("Número inválido").show();
                numeroValido = false;
            }
            else {
                numeroErro.text("").hide();
                numeroValido = true;
            }
        }

        if (bairro.val() === "") {
            bairroErro.text("Campo obrigatorio").show();
            bairroValido = false;
        }
        else {
            bairroErro.text("").hide();
            bairroValido = true;
        }

        if (cidade.val() == null) {
            cidadeErro.text("Campo obrigatorio").show();
            cidadeValido = false;
        }
        else {
            cidadeErro.text("").hide();
            cidadeValido = true;
        }

        if (estado.val() == null) {
            estadoErro.text("Campo obrigatorio").show();
            estadoValido = false;
        }
        else {
            estadoErro.text("").hide();
            estadoValido = true;
        }

        if (cep.text() === "") {
            cepErro.text("Campo obrigatorio").show();
            cepValido = false;
        }
        else {
            cepErro.text("").hide();
            cepValido = true;
        }

        if (logradouroValido && numeroValido && bairroValido && cidadeValido && estadoValido && cepValido)
        {
            var o = new Object();
            o.PessoaId = idPessoa;
            o.Logradouro = logradouro.val();
            o.Complemento = complemento.val();
            o.Numero = numero.val();
            o.Bairro = bairro.val();
            o.CidadeId = cidade.val();
            o.EstadoId = estado.val();
            o.Cep = cep.text();
            
            $.ajax({
                type: "POST",
                url: "/Endereco/Cadastrar",
                data: JSON.stringify({ enderecoVM: o }),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (Resposta)
                {  
                    if (Resposta.Status == "1") {
                        valor.val("");
                        tipo.multiselect('deselect', tipo.val());

                        var meio = $.parseJSON(Resposta.Objeto);

                        toastr["success"](Resposta.Mensagem);

                        window.setTimeout('location.reload()', 1500);
                    }
                    else if (Resposta.Status == "2") {
                        toastr["warning"](Resposta.Mensagem);
                    }
                    else {
                        toastr["error"](Resposta.Mensagem);
                    }
                }
            });
        }
    });
});