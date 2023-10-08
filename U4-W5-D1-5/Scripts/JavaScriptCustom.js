function parseJsonDate(jsonDate) {
    let parsedDate = new Date(parseInt(jsonDate.substr(6)));
    return parsedDate.toLocaleDateString();
}

$(document).ready(function () {

    $("#privato").click(function () {
        $("#formPrivato").slideToggle();
    })

    $("#azienda").click(function () {
        $("#formAzienda").slideToggle();
    })

    $("#SpedizionePrivato").click(function () {
        $("#formSpedizionePrivato").slideToggle();
    })

    $("#SpedizioneAzienda").click(function () {
        $("#formSpedizioneAzienda").slideToggle();
    })
    $("#oggi").click(function () {
        $.ajax({
            method: 'GET',
            url: "GetToday",
            success: function (result) {
                $("#query tbody").empty();
                $.each(result.ListaSpedizioniPrivati, function (i, v) {
                    var row = "<tr><td>" + v.Mittente + "</td><td>" + v.NomeDestinatario + "</td><td>" + v.CognomeDestinatario + "</td>><td>" + v.IndirizzoDestinatario + "</td>><td>" + v.CittaDestinatario + "</td><td>" + parseJsonDate(v.DataSpedizione) + "</td><td>" + parseJsonDate(v.dataConsegna) + "</td><td>" + v.NumeroParcel + "</td></tr>";
                    $("#query tbody").append(row);
                });

                $.each(result.ListaSpedizioniAziende, function (i, v) {
                    var row = "<tr><td>" + v.Azienda + "</td><td>" + v.NomeDestinatario + "</td><td>" + v.CognomeDestinatario + "</td>><td>" + v.IndirizzoDestinatario + "</td>><td>" + v.CittaDestinatario + "</td><td>" + parseJsonDate(v.DataSpedizione) + "</td><td>" + parseJsonDate(v.dataConsegna) + "</td><td>" + v.NumeroParcel + "</td></tr>";
                    $("#query tbody").append(row);
                })
            }
        })
    })
    $("#destinazione").click(function () {
        $.ajax({
            method: 'GET',
            url: "GetCitta",
            success: function (result) {
                $("#query1 tbody").empty();
                $.each(result, function (i, v) {
                    var row = "<tr><td>" + v.CittaDestinatario + "</td><td>" + v.NumeroSpedizioni + "</td></tr>";
                    $("#query1 tbody").append(row);
                });
            }
        })
    })
    $("#consegna").click(function () {
        $.ajax({
            method: 'GET',
            url: "GetConsegna",
            success: function (result) {
                $("#query2 thead").empty();
                $.each(result, function (i, v) {
                    var row = "<tr><th>" + "Spedizioni in attesa di consegna" + "</th><th>" + v.NumeroSpedizioni + "</th></tr>";
                    $("#query1 thead").append(row);
                });
            }
        })
    })
})









//$("#GetClienti").click(function () {
//    $("#ListaClienti").empty();
//    $.ajax({
//        method: 'GET',
//        url: "GetListaClienti",
//        success: function (lista) {
//            $.each(lista, function (i, v) {
//                var licurrent = "<li>" + v.Nome + " " + v.Cognome + "</li>";
//                $("#ListaClienti").append(licurrent);
//            })
//        }
//    })
//})

//$("#btnCerca").click(function () {
//    var nomeDaRicercare = $("#InizialeNome").val();

//    $.ajax({
//        method: 'POST',
//        url: 'GetPersonByNome',
//        data: { nome: nomeDaRicercare },
//        success: function (data) {
//            $(".risultatoRicerca").html("<p class='alert alert-success'>" + data.Nome + ", " + data.Cognome + "</p>")
//        }
//    })

//})