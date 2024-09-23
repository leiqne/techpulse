window.onload = init

API_URL = ''

function init(){

    const form = document.querySelector('loginForm')

    form.addEventListener('submit', (e) => {
        e.preventDefault()
        login()
    })

    function login(){
        const payload = {
            email: document.getElementById('email').value,
            password: document.getElementById('password').value,
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

