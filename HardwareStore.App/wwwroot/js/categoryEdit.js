function CatagoryEdit() {
    let div = document.querySelector('#cateInfoDiv');
    let editSubmitBtn = document.querySelector('#cateEditSubmitBtn');

    div.addEventListener('click', ToggleReadonlyInput);
    div.addEventListener('click', SubmitEditForm);

    async function SubmitEditForm(event) {
        event.preventDefault();
        let target = event.target;
        if (event.target.matches('#cateEditSubmitBtn')) {

            let form = div.querySelector('form');
            $.validator.unobtrusive.parse(form);

            if ($(form).valid()) {
                editSubmitBtn.textContent = "Loading";
                editSubmitBtn.disabled = true;
                const url = form.action;
                let formData = new FormData(form);
                let token = document.querySelector('input[name="__RequestVerificationToken"]');
                if (token) {

                    formData.append("RequestVerificationToken", token.value);
                }
                let response = await fetch(url, {
                    method: "POST",
                    body: formData
                })

                if (response.ok) {
                    let html = await response.text();
                    let parser = new DOMParser();
                    let bodycontent = parser.parseFromString(html, 'text/html').body.querySelectorAll(':scope > *');
                    div.innerHTML = '';
                    bodycontent.forEach(function (x) {
                        div.appendChild(x);
                    });

                }
                editSubmitBtn.disabled = false;
            }
        }
    }
    function ToggleReadonlyInput(event) {

        let target = event.target;
        if (target.matches('button[data-edit]')) {
            let input = target.parentElement.querySelector('input');
            input.toggleAttribute('disabled');
        }
    }
}
