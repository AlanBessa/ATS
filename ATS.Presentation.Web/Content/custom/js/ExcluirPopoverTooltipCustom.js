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
        var caminho = window.location.pathname;

        var exclusao = $(this);

        $.ajax({
            type: "POST",
            url: caminho + "/Remover",
            data: "{'id' : '" + id + "'}",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (Resposta) {
                if (Resposta.Status == "1") {
                    toastr["success"](Resposta.Mensagem);
                    $(".datatable").DataTable().row(exclusao.parents("tr")).remove().draw();
                } else {
                    toastr["error"](Resposta.Mensagem);
                }

                exclusao.parent().find(".btnCancelarExclusao").click();
            }
        });
    });
});