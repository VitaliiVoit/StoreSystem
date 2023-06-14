async function getCart() {
    const response = await fetch("/api/cart", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const products = await response.json();
        const rows = document.querySelector("tbody");
        products.forEach(product => rows.append(rowTable(product)));
    }
    await getTotalAmount();
}

async function removeFromCart(id) {
    const response = await fetch(`/api/cart/remove/${id}`, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const product = await response.json();
        document.querySelector(`tr[data-rowid='${product.id}']`).remove();
        await getTotalAmount();
    }
}

async function updateCount(id, value) {
    const response = await fetch(`/api/cart/updateCount/${id}-${value}`, {
        method: "PUT",
        headers: { "Accept": "application/json"}
    });
    if (response.ok === true) {
        await getTotalAmount();
    }
}

async function getTotalAmount() {
    const response = await fetch("/api/cart/totalAmount", {
        method: "GET",
        headers: { "Accept" : "application/json" }
    });
    if (response.ok === true) {
        const totalAmount = await response.json();
        const totalAmountTitle = document.querySelector(".cart__total-amount");
        totalAmountTitle.textContent = `$${totalAmount}`;
    }
}

function rowTable(pair) {
    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", pair.key.id);

    tr.append(createTd(pair.key.name));
    tr.append(createTd(pair.key.price));

    const countInput = document.createElement("input");
    countInput.id = "countInput";
    countInput.type = "number";
    countInput.min = "1";
    countInput.max = "100";
    countInput.step = "1";
    countInput.value = `${pair.value}`;
    countInput.addEventListener("input", async (e) => await updateCount(pair.key.id, e.target.value));

    tr.append(createTd(countInput));

    const button = document.createElement("button");
    button.classList.add("btn");
    button.append("X");
    button.addEventListener("click", async () => await removeFromCart(pair.key.id));
    tr.append(createTd(button));

    return tr;
}

function createTd(parameter) {
    const td = document.createElement("td");
    td.append(parameter);
    return td;
}
getCart();