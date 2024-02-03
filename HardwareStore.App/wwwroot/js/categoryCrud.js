let div = document.querySelector('#cateInfoDiv');
let submitBtn = document.querySelector('#cateEditSubmitBtn');







div.addEventListener('click', ToggleReadonlyInput);
div.addEventListener('click', SubmitEditForm);

async function SubmitEditForm(event) {
    event.preventDefault();
    let target = event.target;
    if (event.target.matches('#cateEditSubmitBtn')) {

        let form = div.querySelector('form');
        $.validator.unobtrusive.parse(form);

        if ($(form).valid()) {
            submitBtn.textContent = "Loading";
            submitBtn.disabled = true;
            const url = form.action;
            let formData = new FormData(form);
            let token = document.querySelector('input[name="__RequestVerificationToken"]');
            if (token) {

                formData.append("RequestVerificationToken", token.value);
            }
            debugger;
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
            submitBtn.disabled = false;
        }
    }
}
function ToggleReadonlyInput(event) {
    let target = event.target;
    if (target.matches('button[data-edit]')) {

        let input = target.parentElement.querySelector('input');
        input.toggleAttribute('readonly');
    }
}