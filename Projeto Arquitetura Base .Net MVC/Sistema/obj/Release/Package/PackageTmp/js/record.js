function restore() {
    $("#record, #live").removeClass("disabled");
    $("#pause").replaceWith('<button type="button" id="pause" class="btn green disabled"><i class="fa fa-stop"></i> Pausar</button>');

    $(".one").addClass("disabled");
    Fr.voice.stop();
}
$(document).ready(function () {
    $(document).on("click", "#record:not(:disabled)", function () {
        elem = $(this);
        $("#pause").replaceWith('<button type="button" id="pause" class="btn green"><i class="fa fa-stop"></i> Pausar</button>');
        $("#stop").replaceWith('<button type="button" id="stop" class="btn purple"><i class="fa  fa-step-backward"></i> Reset</button>');
        Fr.voice.record($("#live").is(":checked"), function () {
            elem.addClass("disabled");

            $(".one").removeClass("disabled");
        });
    });

    $(document).on("click", "#pause:not(:disabled)", function () {
        if ($(this).hasClass("resume")) {
            Fr.voice.resume();
            $(this).replaceWith('<button type="button" id="pause" class="btn green"><i class="fa fa-stop"></i> Pausar</button>');
        } else {
            Fr.voice.pause();
            Fr.voice.export(function (url) {
                $("#audio").attr("src", url);
            }, "URL");
            $(this).replaceWith('<button type="button" id="pause" class="btn green resume"><i class="fa fa-stop"></i> Resumir</button>');
        }
    });

    $(document).on("click", "#stop:not(:disabled)", function () {
        $("#stop").replaceWith('<button type="button" id="stop" class="btn purple disabled"><i class="fa  fa-step-backward"></i> Reset</button>');
        $("#audio").attr("src", null);
        restore();
    });




    $(document).on("click", "#mp3:not(:disabled)", function () {
        alert("A conversao do audio pode demorar, por favor aguarde...");
        try {
            Fr.voice.export(function (url) {
                $('#base64Mp3GravacaoOracao').val(url);
                $('#formNovaOracao').submit();

            }, "mp3");

            restore();
        }
        catch (err) {
            alert("Nao e possivel enviar um audio vazio no pedido de oracao...");
        }


    });


    $(document).on("click", "#textoMensagem:not(:disabled)", function () {
        var bla = $('#textoMensagemOracao').val();
        if (bla === "") {
            alert("Nao e possivel enviar uma mensagem de texto vazia no pedido de oracao");
        }
        else {
            $('#formNovaOracao').submit();
        }

    });


    $(document).on("click", "#mp3Pastor:not(:disabled)", function () {
        alert("A conversao do audio pode demorar, por favor aguarde...");
        try {
            Fr.voice.export(function (url) {
                $('#GravacaoOracao').val(url);
                $('#formRespostaPastorNovaOracao').submit();

            }, "mp3");

            restore();
        }
        catch (err) {
            alert("Nao e possivel enviar um audio vazio no pedido de oracao...");
        }


    });

});
