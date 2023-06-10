async function getProducts() {
    const response = await fetch("/api/products", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const products = await response.json();
        const rows = document.querySelector("tbody");
        products.forEach(product => rows.append(rowTable(product)));
    }
}

function rowTable(product) {
    const tr = rowProductInfo(product);
    
    const buttonTd = document.createElement("td");
    
    const button = document.createElement("button");
    button.classList.add("btn");
    button.append("Add");
    
    buttonTd.append(button);
    tr.appendChild(buttonTd);

    return tr;
}

function rowProductInfo(product) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", product.id);

    const nameTd = document.createElement("td");
    nameTd.append(product.name);
    tr.append(nameTd);

    const countTd = document.createElement("td");
    countTd.append(product.count);
    tr.append(countTd);

    const priceTd = document.createElement("td");
    priceTd.append(product.price);
    tr.append(priceTd);

    return tr;
}


getProducts();