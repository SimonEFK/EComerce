async function AddProductToCart(event) {
    let target = event.target;
    if (target.matches("[data-addProductToCart]")) {

        let Id = Number(target.dataset.productid);

        const formData = new FormData();
        formData.append('productId', Id);

        let url = "/Cart/AddItemToCart";

        let response = await fetch(url, {
            method: "POST",
            body: formData
        });

        if (response.ok) {
            
            let productName = target.dataset.addproducttocart;
            let toast = new bootstrap.Toast('.toast');
            let toastMessageSpan = document.querySelector('.toast-message');
            toastMessageSpan.textContent = `${productName} added to cart`;
            toast.show();
            let parser = new DOMParser();
        }
    }
}