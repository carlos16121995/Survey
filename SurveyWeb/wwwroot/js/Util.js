function Mensagem(div, msg) {
    $("#" + div).html(msg);
    $("#" + div).show(300);
    $("#" + div).delay(5000);
    $("#" + div).hide(300);
};

function FormatarData(data) {
    //var jsData = eval(data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    var jsData = new Date(data);
    var dataFormatada = jsData.toLocaleDateString();

    return dataFormatada;
};

function FormatarDataIso(data) {
    data = FormatarData(data);
    var d = data.split("/");
    return d[2] + "-" + d[1] + "-" + d[0];
}

function getCookie(name,key) {
    var nameValue = document.cookie.match('(^|;) ?' + name + '=([^;]*)(;|$)');
    return nameValue ? nameValue[2].split('&')[key].split('=')[1] : null;
} 
