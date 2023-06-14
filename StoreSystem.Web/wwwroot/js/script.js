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
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", product.id);

    tr.append(createTd(product.name));
    tr.append(createTd(product.price));
    tr.append(createTd(product.count));

    const button = document.createElement("button");
    button.classList.add("btn");
    button.append("To Cart");
    button.addEventListener("click", async() => await addToCart(product.id));
    
    tr.append(createTd(button));

    return tr;
}

function createTd(parameter) {
    const td = document.createElement("td");
    td.append(parameter);
    return td;
}

getProducts();