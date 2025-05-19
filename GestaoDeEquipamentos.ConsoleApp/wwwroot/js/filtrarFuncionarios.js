const searchInput = document.getElementById("searchInput");
const sortFilter = document.getElementById("sortFilter");
const chamadosTable = document.getElementById("chamadosTable");

function renderTabela(dados) {
    if (dados.length === 0) {
        chamadosTable.innerHTML = `<tr><td colspan="9">Nenhum chamado encontrado.</td></tr>`;
        return;
    }

    let html = "";
    dados.forEach(chamado => {
        html += `
            <tr>
                <td>${chamado.Id}</td>
                <td>${chamado.Titulo}</td>
                <td>${chamado.Descricao}</td>
                <td>${chamado.NomeEquipamento}</td>
                <td>${chamado.NomeUsuario}</td>
                <td>${new Date(chamado.DataAbertura).toLocaleDateString('pt-BR')}</td>
                <td>${chamado.DiasEmAberto}</td>
                <td>
                    <span class="status-badge status-${chamado.Status.toLowerCase()}">${chamado.Status}</span>
                </td>
                <td class="card-actions">
                    <a href="/chamados/visualizar/${chamado.Id}" class="btn-detalhes">Detalhes</a>
                    <a href="/chamados/editar/${chamado.Id}" class="btn-editar">Editar</a>
                    <a href="/chamados/excluir/${chamado.Id}" class="btn-excluir">Excluir</a>
                </td>
            </tr>`;
    });

    chamadosTable.innerHTML = html;
}

function filtrarEOrdenar() {
    let filtroTexto = searchInput.value.toLowerCase();

    let filtrados = chamados.filter(c => {
        return c.Titulo.toLowerCase().includes(filtroTexto) ||
            c.Descricao.toLowerCase().includes(filtroTexto) ||
            c.NomeEquipamento.toLowerCase().includes(filtroTexto) ||
            c.NomeUsuario.toLowerCase().includes(filtroTexto) ||
            c.Status.toLowerCase().includes(filtroTexto);
    });

    switch (sortFilter.value) {
        case "recent":
            filtrados.sort((a, b) => new Date(b.DataAbertura) - new Date(a.DataAbertura));
            break;
        case "oldest":
            filtrados.sort((a, b) => new Date(a.DataAbertura) - new Date(b.DataAbertura));
            break;
        case "az":
            filtrados.sort((a, b) => a.Titulo.localeCompare(b.Titulo));
            break;
        case "za":
            filtrados.sort((a, b) => b.Titulo.localeCompare(a.Titulo));
            break;
        case "diasMais":
            filtrados.sort((a, b) => b.DiasEmAberto - a.DiasEmAberto);
            break;
        case "diasMenos":
            filtrados.sort((a, b) => a.DiasEmAberto - b.DiasEmAberto);
            break;
    }

    renderTabela(filtrados);
}

searchInput.addEventListener("input", filtrarEOrdenar);
sortFilter.addEventListener("change", filtrarEOrdenar);

renderTabela(chamados);
