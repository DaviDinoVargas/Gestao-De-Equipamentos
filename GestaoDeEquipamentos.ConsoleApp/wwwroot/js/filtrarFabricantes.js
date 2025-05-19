const searchInput = document.getElementById("searchInput");
const sortFilter = document.getElementById("sortFilter");
const funcionariosTable = document.getElementById("funcionariosTable");

function renderTabela(dados) {
    if (dados.length === 0) {
        funcionariosTable.innerHTML = `<tr><td colspan="6">Nenhum funcionário encontrado.</td></tr>`;
        return;
    }

    let html = "";
    dados.forEach(funcionario => {
        html += `
            <tr>
                <td>${funcionario.Id}</td>
                <td>${funcionario.Nome}</td>
                <td>${funcionario.Email}</td>
                <td>${funcionario.Telefone}</td>
                <td>${funcionario.Departamento}</td>
                <td class="card-actions">
                    <a href="/funcionarios/editar/${funcionario.Id}" class="btn-editar">Editar</a>
                    <a href="/funcionarios/excluir/${funcionario.Id}" class="btn-excluir">Excluir</a>
                </td>
            </tr>`;
    });

    funcionariosTable.innerHTML = html;
}

function filtrarEOrdenar() {
    let filtroTexto = searchInput.value.toLowerCase();

    let filtrados = funcionarios.filter(f => {
        return f.Nome.toLowerCase().includes(filtroTexto) ||
            f.Email.toLowerCase().includes(filtroTexto) ||
            f.Departamento.toLowerCase().includes(filtroTexto) ||
            f.Telefone.includes(filtroTexto);
    });

    switch (sortFilter.value) {
        case "az":
            filtrados.sort((a, b) => a.Nome.localeCompare(b.Nome));
            break;
        case "za":
            filtrados.sort((a, b) => b.Nome.localeCompare(a.Nome));
            break;
        case "departamento":
            filtrados.sort((a, b) => a.Departamento.localeCompare(b.Departamento));
            break;
    }

    renderTabela(filtrados);
}

searchInput.addEventListener("input", filtrarEOrdenar);
sortFilter.addEventListener("change", filtrarEOrdenar);

renderTabela(funcionarios);