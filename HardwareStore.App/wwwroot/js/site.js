async function AddProductToCart(event) {
    let target = event.target;
    if (target.matches("[data-addProductToCart]")) {

        let Id = Number(target.dataset.productid);

        const formData = new FormData();
        let token = document.querySelector('input[name="__RequestVerificationToken"]').value;
        formData.append('productId', Id);
        formData.append('__RequestVerificationToken', token);
        let url = "/Cart/AddItemToCart";

        let response = await fetch(url, {
            method: "POST",
            body: formData
        });
        if (response.redirected) {
            window.location.href = response.url;
        }
        if (response.ok) {

            let productName = target.dataset.addproducttocart;
            let toast = new bootstrap.Toast('.toast');
            let toastHeader = document.querySelector('.toast-header')

            toastHeader.innerHTML =
                `<a class="text-black text-decoration-none" href="/Cart">
                            <i class="bi bi-cart"></i>
                            <strong>Shopping Cart</strong>
                </a>`
            let toastMessageSpan = document.querySelector('.toast-message');
            toastMessageSpan.textContent = `${productName} added to cart`;
            toast.show();
        }
    }
}
async function RemoveProductFromCart(event) {
    let target = event.target;
    if (target.matches("[data-removeproductfromcart]")) {
        let Id = Number(target.dataset.removeproductfromcart);

        const formData = new FormData();
        let token = document.querySelector('input[name="__RequestVerificationToken"]').value;
        formData.append('productId', Id);
        formData.append('__RequestVerificationToken', token);
        let url = "/Cart/RemoveItem";

        let response = await fetch(url, {
            method: "POST",
            body: formData
        });
        if (response.redirected) {
            window.location.href = response.url;
        }

    }
}