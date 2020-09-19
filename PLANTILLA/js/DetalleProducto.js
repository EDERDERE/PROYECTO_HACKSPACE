import Servicio from "./Servicio.js";
export default class DetalleProducto extends Servicio {
    constructor() {
        super();
    }

    // metodos
    obtenerProductos(_idProducto) {
        var myRequest = new Request(`https://localhost:44396/api/orderlist/listproduct/${_idProducto}`, { method: 'GET', body: null });
        return new Promise(function (resolve, reject) {
            this.http(myRequest).then((response) => {
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        }.bind(this));
    }

    agregarProducto(_producto) {
        var myRequest = new Request(`https://localhost:44396/api/orderlist/GuardarDatos`, { method: 'PUT', body: JSON.stringify(_producto) , headers: { 'Content-Type': 'application/json' } });
        return new Promise(function (resolve, reject) {
            this.http(myRequest).then((response) => {
                resolve(response);
            }).catch(error => {
                reject(error);
            });
        }.bind(this));
    }


}

