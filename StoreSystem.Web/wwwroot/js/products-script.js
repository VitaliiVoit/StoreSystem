const button = document.getElementById("addproduct-btn").addEventListener("click", addProduct);

async function addProduct() {
    const response = await fetch("/api/products/add", {
        method: "POST",
        headers: { "Accept" : "application/json", "Content-Type" : "application/json"},
        body: JSON.stringify({
            name: document.getElementById("productName").value,
            count: parseInt(document.getElementById("productCount").value),
            price : parseFloat(document.getElementById("productPrice").value),
        }),
    });
    reset();
    await getProducts();
}

async function removeProduct(id) {
    const response = await fetch(`/api/products/remove/${id}`, {
        method: "DELETE",
        headers: { "Accept" : "application/json" }
    });
    if (response.ok === true) {
        const product = await response.json();
        document.querySelector(`tr[data-rowid='${product.id}']`).remove();
    }
}

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
    button.append("Remove");
    button.addEventListener("click", async() => await removeProduct(product.id));
    
    tr.append(createTd(button));

    return tr;
}

function createTd(parameter) {
    const td = document.createElement("td");
    td.append(parameter);
    return td;
}

function reset() {
    document.getElementById("productName").value = "";
    document.getElementById("productCount").value = "";
    document.getElementById("productPrice").value = "";
}

getProducts();