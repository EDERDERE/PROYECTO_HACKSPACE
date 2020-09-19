import Servicio from "./Servicio.js";
export default class Pedido extends Servicio {
    constructor() {
        super();
    }

    // metodos
    obtenerPedidos() {
        var myRequest = new Request(`https://localhost:44396/api/orderlist`, { method: 'GET', body: null });
        return new Promise(function (resolve, reject) {
            this.http(myRequest).then((response) => {
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        }.bind(this));
    }
   
}

