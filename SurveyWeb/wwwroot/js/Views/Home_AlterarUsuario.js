$("#btnAlterar").click(function () {
    var msg = "";
    var id = $("#txtId").val();
    var email = $("#txtEmail").val();
    var nome = $("#txtNome").val();
    var senha = $("#txtSenha").val();
    var senha2 = $("#txtSenha2").val();
    if (email === "") {
        msg += "Por favor, informe um e-mail para o usuário.<br />";
    }
    if (nome.length < 3) {
        msg += "Por favor, informe um nome válido para o usuário.<br />";
    }
    if (senha.length < 6) {
        msg += "Por favor, informe uma senha com pelo menos 6 caracteres.<br />";
    }
    if (senha2 !== senha) {
        msg += "A senha e a confirmação da senha não conferem.<br />";
    }
    if (msg.length > 0) {
        Mensagem("divAlerta", msg);
    }
    else {
        $("#divLoading").show(300);
        var excluir = false;
        if ($("#ckbExcluir").is(":checked")) {
            excluir = true;
        }
        $.ajax({
            method: 'POST',
            url: '/Home/Gravar',
            data: { Email: email, Nome: nome, Senha: senha, Id: id, Excluir: excluir },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlerta", result);
                }
                else {
                    if ($("#ckbExcluir").is(":checked")) {
                        window.location.href = "/Home/Logout";
                    }
                    else {
                        Mensagem("divAlerta", "Os dados do usuário foram alterados.");
                    }
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});

$(document).ready(function () {
    $("#divLoading").show(300);
    $.getJSON("/Home/ObterUsuario/", function (data) {
        $("#txtId").val(data.id);
        $("#txtEmail").val(data.email);
        $("#txtNome").val(data.nome);
        $("#txtSenha").val(data.senha);
        $("#txtSenha2").val(data.senha);
    });
    $("#divLoading").hide(300);
});