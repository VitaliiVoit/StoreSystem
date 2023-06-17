async function getCustomers() {
    const response = await fetch("/api/customers", {
        method: "GET",
        headers: { "Accept" : "application/json"}
    });
    if (response.ok === true) {
        const customers = await response.json();
        const dataList = document.getElementById("customers");
        customers.forEach(customer => dataList.append(createOption(customer)));
    }
}

async function addCustomer() {
    const response = await fetch("/api/customers/add", {
        method: "POST",
        headers: { "Accept" : "application/json", "Content-Type" : "application/json"},
        body: JSON.stringify({
            firstName: document.getElementById("firstName").value,
            lastName: document.getElementById("lastName").value,
        }),
    });
}

function createOption(customer) {
    const option = document.createElement("option");
    option.value = `${customer.fullName}`;
    return option;
}

document.getElementById("addcustomer-btn").addEventListener("click", async () => await addCustomer());

getCustomers();