    function showTable(idTabela) {
        document.querySelectorAll('div[id^="tabela"]').forEach(tabela => {
            tabela.style.display = 'none';
        });
    document.getElementById(idTabela).style.display = 'block';
    }