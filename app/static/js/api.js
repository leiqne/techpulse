class Api {
    constructor (url){
        this.url = url
        // this.max_time_cache = max_time_cache || 60 * 60 * 2
    }

    async getProducts(){
        let response = await fetch(`${this.url}/products`)
        let data = await response.json()
        return data
    }

    #guardar_en_localStorage(prodID){
        let carrito = localStorage.getItem("carrito")
        carrito = carrito ? JSON.parse(carrito) : {}
        
        if(carrito[prodID] == undefined){
            carrito[prodID] = 0
        }
        carrito[prodID] += 1
        localStorage.setItem("carrito", carrito)
    }

    guardar_en_carrito(prodID){
        this.#guardar_en_localStorage(prodID)
        fetch(`${this.url}/add-shoping-car/${prodID}`)
        .then(res => res.json())
        .then(data => {
            console.log(data)
        })
    }

    async finalizar_compra(){
        let carrito = localStorage.getItem("carrito")
        carrito = carrito ? JSON.parse(carrito) : {}

        let response = await fetch(`${this.url}/end-shoping`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(carrito)
        })
        let data = await response.json()
        return data
    }
}