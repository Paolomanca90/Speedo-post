function parseJsonDate(jsonDate) {
    let parsedDate = new Date(parseInt(jsonDate.substr(6)));
    return parsedDate.toLocaleDateString();
}

function parseJsonHour(jsonDate) {
    let parsedDate = new Date(parseInt(jsonDate.substr(6)));
    return parsedDate.toLocaleTimeString();
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
                    $("#query2 thead").append(row);
                });
            }
        })
    })

    $("#search").click(function () {
        $("#tracking").slideDown();
        var cf = $("#CF").val();
        var numeroParcel = $("#NumeroParcel").val();
        $.ajax({
            method: 'POST',
            url: "GetSpedizione",
            data: { cf: cf, numeroParcel: numeroParcel },
            success: function (result) {
                $("#tableParcel tbody").empty();
                $.each(result, function (i, v) {
                    var row = "<tr><td>" + parseJsonDate(v.DataModifica) + "</td><td>" + parseJsonHour(v.DataModifica) + "</td><td>" + v.LuogoModifica + "</td><td>" + v.StatoModifica + "</td></tr>";
                    $("#tableParcel tbody").append(row);
                });
            }
        });
    });

})
