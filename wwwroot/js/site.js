function showTable(tableId) {
    var tables = document.querySelectorAll('div[id$="Table"]');
    tables.forEach(function (table) {
        table.style.display = 'none';
    });

    var tableToShow = document.getElementById(tableId);
    if (tableToShow) {
        tableToShow.style.display = 'block';

        var type = tableId === 'foodTable' ? 'food' : 'drink';
        getProducts(type);
    }
}

async function getProducts(type) {
    try {
        const response = await fetch(`/Home/GetProducts?type=${type}`);
        if (!response.ok) {
            throw new Error('Erro ao carregar produtos.');
        }

        const produtos = await response.json();

        const tableBodyId = type === 'food' ? 'foodTableBody' : 'drinkTableBody';
        const tableBody = document.getElementById(tableBodyId);
        if (tableBody) {
            tableBody.innerHTML = '';

            produtos.forEach(produto => {
                const row = `
                    <tr>
                        <td>${produto.name}</td>
                        <td>${produto.price}</td>
                    </tr>`;
                tableBody.insertAdjacentHTML('beforeend', row);
            });
        }
    } catch (error) {
        console.error(error);
    }
}

function toggleItem(itemID) {
    var item = document.getElementById(itemID);
    var otherItems = document.querySelectorAll('.item-form');

    otherItems.forEach(function (otherItem) {
        if (otherItem !== item) {
            otherItem.style.display = 'none';
        }
    });

    item.style.display = item.style.display === 'none' ? 'block' : 'none';
}

function submitNewItem() {
    var itemName = document.getElementById("itemName").value;
    var itemPrice = document.getElementById("itemPrice").value;
    var itemType = document.getElementById("itemType").value;

    var data = {
        Name: itemName,
        Price: parseFloat(itemPrice),
    };

    fetch("/Home/InsertMenuItem", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                var form = document.getElementById("addItemForm");
                form.style.display = "none";
                location.reload();
            } else {
                console.error('Erro ao adicionar item:', response.status);
                alert('Erro ao adicionar item. Por favor, tente novamente.');
            }
        })
        .catch(error => {
            console.error('Erro ao adicionar item:', error);
            alert('Erro ao adicionar item. Por favor, tente novamente.');
        });
    return false;
}
