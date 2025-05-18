const searchInput = document.getElementById("searchInput");
const sortFilter = document.getElementById("sortFilter");
const usuariosTable = document.getElementById("usuariosTable");

function renderTabela(dados) {
    if (dados.length === 0) {
        usuariosTable.innerHTML = `<tr><td colspan="6">Nenhum usuário encontrado.</td></tr>`;
        return;
    }

    let html = "";
    dados.forEach(usuario => {
        html += `
            <tr>
                <td>${usuario.Id}</td>
                <td>${usuario.Nome}</td>
                <td>${usuario.Email}</td>
                <td>${usuario.Documento}</td>
                <td>${usuario.Telefone}</td>
                <td class="card-actions">
                    <a href="/usuarios/editar/${usuario.Id}" class="btn-editar">Editar</a>
                    <a href="/usuarios/excluir/${usuario.Id}" class="btn-excluir">Excluir</a>
                </td>
            </tr>`;
    });

    usuariosTable.innerHTML = html;
}

function filtrarEOrdenar() {
    let filtroTexto = searchInput.value.toLowerCase();

    let filtrados = usuarios.filter(u => {
        return u.Nome.toLowerCase().includes(filtroTexto) ||
            u.Email.toLowerCase().includes(filtroTexto) ||
            u.Documento.includes(filtroTexto) ||
            u.Telefone.includes(filtroTexto);
    });

    switch (sortFilter.value) {
        case "az":
            filtrados.sort((a, b) => a.Nome.localeCompare(b.Nome));
            break;
        case "za":
            filtrados.sort((a, b) => b.Nome.localeCompare(a.Nome));
            break;
    }

    renderTabela(filtrados);
}

searchInput.addEventListener("input", filtrarEOrdenar);
sortFilter.addEventListener("change", filtrarEOrdenar);

// Renderiza tudo inicialmente
renderTabela(usuarios);