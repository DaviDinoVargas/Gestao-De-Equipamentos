const searchInput = document.getElementById("searchInput");
const sortFilter = document.getElementById("sortFilter");
const equipamentosTable = document.getElementById("equipamentosTable");

function renderTabela(dados) {
    if (dados.length === 0) {
        equipamentosTable.innerHTML = `<tr><td colspan="6">Nenhum equipamento encontrado.</td></tr>`;
        return;
    }

    let html = "";
    dados.forEach(equipamento => {
        html += `
            <tr>
                <td>${equipamento.Id}</td>
                <td>${equipamento.Nome}</td>
                <td>${new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(equipamento.PrecoAquisicao)}</td>
                <td>${equipamento.NomeFabricante || "Sem fabricante"}</td>
                <td>${new Date(equipamento.DataFabricacao).toLocaleDateString('pt-BR')}</td>
                <td class="card-actions">
                    <a href="/equipamentos/editar/${equipamento.Id}" class="btn-editar">Editar</a>
                    <a href="/equipamentos/excluir/${equipamento.Id}" class="btn-excluir">Excluir</a>
                </td>
            </tr>`;
    });

    equipamentosTable.innerHTML = html;
}

function filtrarEOrdenar() {
    let filtroTexto = searchInput.value.toLowerCase();

    let filtrados = equipamentos.filter(e => {
        return e.Nome.toLowerCase().includes(filtroTexto) ||
            (e.NomeFabricante && e.NomeFabricante.toLowerCase().includes(filtroTexto));
    });

    switch (sortFilter.value) {
        case "recent":
            filtrados.sort((a, b) => new Date(b.DataFabricacao) - new Date(a.DataFabricacao));
            break;
        case "oldest":
            filtrados.sort((a, b) => new Date(a.DataFabricacao) - new Date(b.DataFabricacao));
            break;
        case "precoMaior":
            filtrados.sort((a, b) => b.PrecoAquisicao - a.PrecoAquisicao);
            break;
        case "precoMenor":
            filtrados.sort((a, b) => a.PrecoAquisicao - b.PrecoAquisicao);
            break;
    }

    renderTabela(filtrados);
}

searchInput.addEventListener("input", filtrarEOrdenar);
sortFilter.addEventListener("change", filtrarEOrdenar);

// Renderiza tudo inicialmente
renderTabela(equipamentos);