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
    await getProducts(rowTable);
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

function rowTable(product) {
    const tr = getProductInfo(product);

    const button = createDefaultButton("Remove");
    button.addEventListener("click", async() => await removeProduct(product.id));
    
    tr.append(createTd(button));

    return tr;
}

function reset() {
    document.getElementById("productName").value = "";
    document.getElementById("productCount").value = "";
    document.getElementById("productPrice").value = "";
}

getProducts(rowTable);