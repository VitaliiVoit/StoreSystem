async function getCustomers() {
    const response = await fetch("/api/customers", {
        method: "GET",
        headers: { "Accept" : "application/json"}
    });
    if (response.ok === true) {
        const customers = await response.json();
        const select = document.getElementById("customers");
        customers.forEach(customer => select.append(createOption(customer)));
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
    if (response.ok === true) {
        const customer = await response.json();
        const datalist = document.getElementById("customers");
        datalist.append(createOption(customer));
    }
}

function createOption(customer) {
    const option = document.createElement("option");
    option.value = `${customer.fullName}`;
    option.setAttribute("customer-id", customer.id);
    return option;
}

async function setCustomer() {
    var val = document.getElementById("customer-input").value;
    var opts = document.getElementById('customers').childNodes;
    for (var i = 0; i < opts.length; i++) {
      if (opts[i].value === val) {
        let id = opts[i].getAttribute("customer-id");
        const response = await fetch(`/api/customers/set/${id}`, {
            method: "POST",
            headers: { "Accept" : "application/json" }
        });
        break;
      }
    }
}

async function removeCurrentCustomer() {
    await fetch("/api/customers/remove-current", {
        method: "DELETE",
    });
    document.getElementById("customer-input").value = "";
}

document.getElementById("customer-input").addEventListener("input", async() => await setCustomer());

document.getElementById("addcustomer-btn").addEventListener("click", async () => await addCustomer());
document.getElementById("new-customer-btn").addEventListener("click", () => {
    const form = document.querySelector(".form");
    form.classList.toggle("form-deactive");
});

getCustomers();