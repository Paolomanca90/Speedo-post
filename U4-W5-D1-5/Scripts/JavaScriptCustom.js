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