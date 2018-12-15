﻿const pesquisarButton = $("#pesquisarButton");

pesquisarButton.click(obterProdutoPorCategoria);

function obterProdutoPorCategoria() {
    const categoriaId = $("#CategoriaId").val();

    $.ajax({
        url: "/Admin/Produtos/Categoria",
        method: "get", //type:
        data: { categoriaId }
        //success:
    })
        .done(function (response) { exibirPopover(response); }) //.done() // success
        .fail(function (e) { alert(e); }); // .fail() // error

    //alert("Passou aqui.");
}

function exibirPopover(response) {
    pesquisarButton
        .popover("destroy")
        .popover({
            content: montarGridProdutos(response),
            html: true,
            animation: true,
            title: "Produtos desta Categoria <span id='closePopover' class='close'>&times;</span>"
        })
        .popover("show");

}

function montarGridProdutos(produtos) {
    var html = "<table class='table table-striped'>";

    html += "<tr><th>Produto</th><th>Preço</th><th>Estoque</th></tr>";

    $(produtos).each(
        function (i) {
            html += "<tr>";
            html += "<td>" + produtos[i].Nome + "</td>";
            html += "<td>" + produtos[i].Preco.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }) + "</td>";
            html += "<td>" + produtos[i].Estoque + "</td>";
            html += "</tr>";
        }
    );

    return html + "</table>";
}