async function addToCart(id) {
    const count = parseInt(document.getElementById("countInput").value);
    const response = await fetch(`/api/cart/add/${id}-${count}`, {
        method: "POST",
        headers: { "Accept" : "application/json" }
    });
    if (response.ok != true){
        const error = await response.json();
        console.log(error);
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

    const countInput = document.createElement("input");
    countInput.id = "countInput";
    countInput.type = "number";
    countInput.min = "1";
    countInput.max = "100";
    countInput.step = "1";
    countInput.value = "1";
    

    const addButton = document.createElement("button");
    addButton.classList.add("btn");
    addButton.append("To Cart");
    addButton.addEventListener("click", async() => await addToCart(product.id));

    const div = document.createElement("div");
    div.style.display = "flex";

    div.append(countInput);
    div.append(addButton);
    tr.append(createTd(div));

    return tr;
}

function createTd(parameter) {
    const td = document.createElement("td");
    td.append(parameter);
    return td;
}

getProducts();