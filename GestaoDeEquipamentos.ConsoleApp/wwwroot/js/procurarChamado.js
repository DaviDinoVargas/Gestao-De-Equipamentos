document.addEventListener('DOMContentLoaded', function () {
    const searchInput = document.getElementById('searchInput');
    const searchButton = document.getElementById('searchButton');
    const chamadosList = document.getElementById('chamadosList');
    const chamadosContainer = document.getElementById('chamadosContainer');
    const chamadoItems = document.querySelectorAll('.chamado-item');
    function filterChamados() {
        const searchTerm = searchInput.value.toLowerCase();
        let hasResults = false;

        chamadoItems.forEach(item => {
            const textContent = item.textContent.toLowerCase();
            if (textContent.includes(searchTerm)) {
                item.style.display = '';
                hasResults = true;
            } else {
                item.style.display = 'none';
            }
        });

        noResultsMessage.style.display = hasResults ? 'none' : 'block';
    }

    searchButton.addEventListener('click', filterChamados);
    searchInput.addEventListener('keyup', function (e) {
        if (e.key === 'Enter') {
            filterChamados();
        }
    });
});