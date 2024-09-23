window.onload = init

API_URL = ''

function init(){

    const form = document.querySelector('registerForm')

    form.addEventListener('submit', (e) => {
        e.preventDefault()
        registro()
    })

    function registro(){
        const password = document.getElementById('password').value
        const confirmPass = document.getElementById('confirm-password').value

        if(password != confirmPass){
            return Swal.fire({icon: 'info', text:'Las contraseñas no coinciden'})
        }

        const payload = {
            username: document.getElementById('username').value,
            email: document.getElementById('email').value,
            password: password,
            rememberMe: document.getElementById('remember-me').checked
        }

        fetch(`${API_URL}/api/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        })
        .then(res => res.json())
        .then(data => {
            if(data.status == 200){
                window.location.href = '/'
            }else{
                Swal.fire({icon: 'info', text:data.message})
            }
        })

    }

}

