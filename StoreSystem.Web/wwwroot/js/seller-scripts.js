async function getCurrentSeller() {
    const response = await fetch("/api/seller/get", {
        method: "GET",
        headers: { "Accept" : "application/json" }
    });
}

getCurrentSeller(); // One Invoke