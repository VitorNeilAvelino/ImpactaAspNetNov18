<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Pessoal.WebForms.Tarefas.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nova Tarefa</h1>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <table>
        <tr>
            <td style="width: 140px">Nome</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome é obrigatório." CssClass="text-danger" ControlToValidate="nomeTextBox">(!)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Prioridade</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" DataSourceID="prioridadesObjectDataSource" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="Selecione" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Selecione a Prioridade." ControlToValidate="prioridadeDropDownList" CssClass="text-danger" InitialValue="0">(!)</asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="prioridadesObjectDataSource" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Tarefas.Create"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Concluída</td>
            <td>
                <asp:CheckBox Text="" ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 140px">Observações</td>
            <td>
                <asp:TextBox TextMode="MultiLine" ID="observacoesTextBox" Rows="5" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button Text="Gravar" ID="gravarButton" runat="server" OnClick="gravarButton_Click" />
</asp:Content>
