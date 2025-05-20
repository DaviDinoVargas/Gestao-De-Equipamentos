document.addEventListener('DOMContentLoaded', function () {

    const statusData = JSON.parse(document.getElementById("statusDataJson").textContent);
    const equipamentoData = JSON.parse(document.getElementById("equipamentoDataJson").textContent);
    const tendenciaData = JSON.parse(document.getElementById("tendenciaDataJson").textContent);

    new Chart(document.getElementById("graficoPizza"), {
        type: 'doughnut',
        data: {
            labels: Object.keys(statusData),
            datasets: [{
                label: "Distribuição por Status",
                data: Object.values(statusData),
                backgroundColor: [
                    '#0e2431', 
                    '#ffce56',
                    '#e52232',
                    '#ff6384', 
                    '#9966ff'  
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            cutout: '70%',
            plugins: {
                legend: {
                    display: false 
                },
                title: {
                    display: true,
                    text: 'Distribuição de Chamados por Status',
                    font: {
                        size: 16
                    }
                }
            }
        }
    });

    new Chart(document.getElementById("graficoEquipamento"), {
        type: 'bar',
        data: {
            labels: Object.keys(equipamentoData),
            datasets: [{
                label: "Quantidade de Chamados",
                data: Object.values(equipamentoData),
                backgroundColor: '#0e2431',
                borderColor: '#2980b9',
                borderWidth: 1
            }]
        },
        options: {
            indexAxis: 'x',
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { display: false },
                title: {
                    display: true,
                    text: 'Chamados por Equipamento',
                    font: { size: 16 }
                }
            },
            scales: {
                x: { beginAtZero: true }
            }
        }
    });

    document.addEventListener("DOMContentLoaded", () => {

        const tendenciaResolucaoScript = document.getElementById('tendenciaDataJson');
        const tendenciaResolucao = JSON.parse(tendenciaResolucaoScript.textContent);

        const datas = Object.keys(tendenciaResolucao).sort();

        const chamadosAbertos = datas.map(data => tendenciaResolucao[data].Abertos);
        const chamadosFechados = datas.map(data => tendenciaResolucao[data].Fechados);

        const ctx = document.getElementById('graficoTendencia').getContext('2d');

        new Chart(ctx, {
            type: 'line',
            data: {
                labels: datas,
                datasets: [
                    {
                        label: 'Chamados Abertos',
                        data: chamadosAbertos,
                        borderColor: 'rgba(54, 162, 235, 1)',
                        backgroundColor: 'rgba(54, 162, 235, 0.2)',
                        fill: true,
                        tension: 0.3
                    },
                    {
                        label: 'Chamados Fechados',
                        data: chamadosFechados,
                        borderColor: 'rgba(75, 192, 192, 1)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        fill: true,
                        tension: 0.3
                    }
                ]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        title: { display: true, text: 'Data' }
                    },
                    y: {
                        beginAtZero: true,
                        title: { display: true, text: 'Número de Chamados' }
                    }
                },
                plugins: {
                    legend: { position: 'top' }
                }
            }
        });
    });


});
