const button = document.getElementById("addproduct-btn").addEventListener("click", addProduct);

async function addProduct() {
    const response = await fetch("/api/products/addproduct", {
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

function reset() {
    document.getElementById("productName").value = "";
    document.getElementById("productCount").value = "";
    document.getElementById("productPrice").value = "";
}