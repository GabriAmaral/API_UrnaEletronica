var primeiroNumero = undefined
var segundoNumero = undefined

var candidato = undefined

function numeroCandidato(num) {
    if (primeiroNumero >= 0 && segundoNumero >= 0) {
        return
    }
    if (primeiroNumero >= 0) {
        segundoNumero = num
        document.getElementById("segundo-numero").value = segundoNumero

        let voto = `${primeiroNumero}${segundoNumero}`

        $.ajax({
            type: "GET",
            url: `https://localhost:7298/api/Candidatos/GetFromLegenda/${voto}`,
            headers: {
                "accept": "application/json",
                "Access-Control-Allow-Origin":"*"
            },
            success: function(response){
                if(!response) {
                    document.getElementById("nome-candidato").value = "Candidato não encontrado."

                    setTimeout(function() {
                        reiniciar()
                    }, 3000)

                    return
                }

                var nomeCandidato = response.nome
                var nomeVice = response.nomeVice

                candidato = response

                document.getElementById("nome-candidato").value = nomeCandidato
                document.getElementById("nome-vice").value = nomeVice
            }
        })
    }
    else {
        primeiroNumero = num
        document.getElementById("primeiro-numero").value = primeiroNumero
    }
}

function limpar() {
    primeiroNumero = undefined
    segundoNumero = undefined

    document.getElementById("segundo-numero").value = ""
    document.getElementById("primeiro-numero").value = ""

    document.getElementById("nome-candidato").value = ""
    document.getElementById("nome-vice").value = ""
}

function confimar(votoBranco) {
    let voto = `${primeiroNumero}${segundoNumero}`

    if(!votoBranco && candidato == null) {
        return
    }

    var bodyRequest = !votoBranco ? { idCandidato: candidato.id } : {}

    bodyRequest.dataDoVoto = new Date();

    $.ajax({
        type: "POST",
        url: `https://localhost:7298/api/Votos/Post`,
        contentType: "application/json",
        data: JSON.stringify(bodyRequest),
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin":"*"
        }
    })

    document.getElementById("tela").classList.add('show')
    document.getElementById("tela2").classList.add('show')

    return voto
}

function reiniciar() {
    location.reload()
}



