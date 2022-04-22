
function modalBlock() {
    document.getElementById('cadastrar-modal').style.display = 'flex'
}


function modalNone() {
    document.getElementById('cadastrar-modal').style.display = 'none'
}


var candidatos = []


function popularCandidatos() {
    $('.candidatos').empty();

    $.ajax({
        type: "GET",
        url: `https://localhost:7298/api/Candidatos/GetAll`,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        success: function (response) {
            response.forEach((candidato) => {
                $('.candidatos').append(`
                    <div class="card" id="card-${candidato.id}">
                        <div class="desc">
                            <p class="canditado-nome">${candidato.nome}</p>
                            <p class="legenda">Legenda: ${candidato.legenda}</p>
                            <p class="vice">${candidato.nomeVice}</p>
                            <div class="infos">
                                <button onclick="deletarCandidato(${candidato.id})">Deletar</button>
                            </div>
                        </div>
                    </div>
                `);
            })
        }
    })
}

$(document).ready(function () {
    popularCandidatos()
})

function validarCamposVazios(values) {
    var existsNull = false
    values.forEach(x => {
        if (x == "" || x == null)
            existsNull = true
    })
    return existsNull
}

function cadastrarCandidato() {
    var nome = document.getElementById("nome-candidato").value
    var legenda = document.getElementById("legenda").value
    var vice = document.getElementById("nome-vice").value

    if (validarCamposVazios([nome, legenda, vice])) {
        modalNone();
        alert("Preencha todos os campos")
        return
    }

    $.ajax({
        type: "GET",
        url: `https://localhost:7298/api/Candidatos/GetFromLegenda/${legenda}`,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        success: function (response) {
            if (response && legenda == response.legenda) {
                alert("Candidato já cadastrado")
                return
            }

            $.ajax({
                type: "POST",
                url: `https://localhost:7298/api/Candidatos/Post`,
                contentType: "application/json",
                data: JSON.stringify({
                    nome: nome,
                    legenda: legenda,
                    nomeVice: vice,
                    data: new Date()
                }),
                headers: {
                    "accept": "application/json",
                    "Access-Control-Allow-Origin": "*"
                },
                success: function (response) {
                    popularCandidatos()
                }
            })

            modalNone();
        }
    })
}

function deletarCandidato(id) {
    $.ajax({
        type: "DELETE",
        url: `https://localhost:7298/api/Candidatos/Delete/${id}`,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        success: (response) => {
            popularCandidatos()
        }
    })
}

