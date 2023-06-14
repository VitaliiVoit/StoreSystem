function createTd(parameter) {
    const td = document.createElement("td");
    td.append(parameter);
    return td;
}

function createDefaultButton(text) {
    const button = document.createElement("button");
    button.classList.add("btn");
    button.append(text);
    return button;
}

function createDefaultNumberInput(value = "1") {
    const countInput = document.createElement("input");
    countInput.id = "countInput";
    countInput.type = "number";
    countInput.min = "1";
    countInput.max = "100";
    countInput.step = "1";
    countInput.value = `${value}`;

    return countInput;
}

function getProductInfo(product) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", product.id);

    tr.append(createTd(product.name));
    tr.append(createTd(product.price));
    tr.append(createTd(product.count));

    return tr;
}

async function getProducts(rowFunction) {
    const response = await fetch("/api/products", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const products = await response.json();
        const rows = document.querySelector("tbody");
        products.forEach(product => rows.append(rowFunction(product)));
    }
}