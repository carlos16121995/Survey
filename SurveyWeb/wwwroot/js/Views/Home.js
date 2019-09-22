$("#btnValidarAcesso").click(function () {
    var msg = "";
    var email = $("#txtEmail").val();
    var senha = $("#txtSenha").val();
    if (email === "") {
        msg = "Por favor, informe o e-mail para autenticação.<br />";
    }
    if (senha === "") {
        msg += "Por favor, informe uma senha para o processo de autenticação.";
    }
    if (msg.length > 0) {
        Mensagem("divAlerta", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Home/Validar',
            data: { Email: email, Senha: senha },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlerta", result);
                }
                else {
                    window.location.href = "/Dashboard";
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});

$("#btnConfirmar").click(function () {
    var msg = "";
    var email = $("#txtEmailNovo").val();
    var nome = $("#txtNomeNovo").val();
    var senha = $("#txtSenhaNovo").val();
    var senha2 = $("#txtSenhaNovo2").val();
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
        Mensagem("divAlertaNovoUsuario", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Home/Gravar',
            data: { Email: email, Nome: nome, Senha: senha },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlertaNovoUsuario", result);
                }
                else {
                    //window.location.href = "/Home";
                    $.fancybox.close();
                    $("#txtEmail").val(email);
                    $("#txtSenha").val(senha);
                    Mensagem("divAlerta", "Autentique-se com o seu novo usuário e senha");
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});

$("#btnEnviarRecuperar").click(function () {
    var msg = "";
    var email = $("#txtEmailRecuperar").val();
    if (email === "") {
        msg += "Por favor, informe o e-mail do usuário que deseja recuperar a senha.";
    }
    if (msg.length > 0) {
        Mensagem("divAlertaRecuperar", msg);
    }
    else {
        $("#divLoading").show(300);
        $.ajax({
            type: 'POST',
            url: '/Home/RecuperarSenha',
            data: { Email: email },
            success: function (result) {
                $("#divLoading").hide(300);
                if (result.length > 0) {
                    Mensagem("divAlertaRecuperar", result);
                }
                else {
                    $.fancybox.close();
                    bootbox.alert("Uma mensagem para recuperação de e-mail foi enviada para: " + email);
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                $("#divLoading").hide(300);
            }
        });
    }
});
