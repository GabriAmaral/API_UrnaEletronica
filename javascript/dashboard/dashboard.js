let navigation = document.querySelector('.navigation');
let list = document.querySelectorAll('.navigation li');
function activeLink() {
    list.forEach((item) =>
        item.classList.remove('hovered'));
    this.classList.add('hovered');

    let screens = document.querySelectorAll(".show")
    screens.forEach((item) =>
        item.classList.remove('show'));

    let scren = document.getElementById(this.dataset.value)
    scren.classList.add("show")

}
list.forEach((item) => item.addEventListener('mouseover', activeLink));


$(document).ready(function () {
    preencherDashboard()
})

var bodyTabela = []


function preencherDashboard() {
    $('.corpo-tabela').empty();
    $('.card-box').empty();

    $.ajax({
        type: "GET",
        url: `https://localhost:7298/api/Candidatos/GetCandidatosVotos`,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        success: function (candidato) {
            candidato.forEach((candidato) => {
                bodyTabela.push(candidato)
                $('.corpo-tabela').append(`
                    <tr>
                        <td class="id">${candidato.id}</td>
                        <td class="nome">${candidato.nome}</td>
                        <td class="vice">${candidato.nomeVice}</td>
                        <td class="legenda">${candidato.legenda}</td>
                        <td class="votos">${candidato.totalVotos}</td>
                    </tr>
                `);
            })
        }
    })

    var countVotos = 0
    var countVotosNulos = 0

    $.ajax({
        type: "GET",
        url: `https://localhost:7298/api/Votos/GetAll`,
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        success: function (response) {
            response.forEach((response) => {
                countVotos++
                if (response.idCandidato == 0 || response.idCandidato == 00) {
                    countVotosNulos++
                }
            })
            $('.card-box').append(`
                <div class="card">
                    <div>
                        <div class="numeros-1">${countVotos}</div>
                        <div class="cardNome">Total de Votos</div>
                    </div>
                    <div class="iconBx">
                        <ion-icon name="file-tray-full-outline"></ion-icon>
                    </div>
                </div>
                    <div class="card">
                        <div>
                            <div class="numeros-2">${countVotosNulos}</div>
                            <div class="cardNome">Votos Nulos</div>
                    </div>
                    <div class="iconBx">
                        <ion-icon name="file-tray-full-outline"></ion-icon>
                    </div>
                </div>
            `);
        }
    })
}