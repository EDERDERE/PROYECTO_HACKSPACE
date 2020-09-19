
import DetalleProducto from "./DetalleProducto.js";
let oArrayDetalleProductos, oDetalleProducto, tblDetalleProductos, oModelDetalleProductos, btnGuardar, fecha, comentario, total, confirmado;
// declaramos 
let pedidos = localStorage.getItem("Pedidos");
let productoSeleccionado = JSON.parse(pedidos);
let contenido = document.getElementById("registro");
tblDetalleProductos = document.getElementById('tblDetalleProductos');
let _idProducto = productoSeleccionado['orderID'];
console.log('iddd', _idProducto)
btnGuardar = document.getElementById("btnGuardar");

//console.log(productoSeleccionado['orderID'])
//console.log(productoSeleccionado['contactName'])


fecha = document.getElementById('fecha');
comentario = document.getElementById('comentario');
total = document.getElementById('total');
confirmado = document.getElementById('confirmado');



// inicializamos la funcion
OnInit();

function OnInit() {

    oArrayDetalleProductos = "";
    oDetalleProducto = new DetalleProducto();

    // creando un object  vacio..
    oModelDetalleProductos = {
        "productID": null,
        "productName": null,
        "unitPrice": null,
        "quantity": null,
        "total": null
    }


    console.log(oModelDetalleProductos)


    contenido.innerHTML = `<h1>${productoSeleccionado['orderID']} - ${productoSeleccionado['contactName']} </h1>`;

    console.log(contenido)

    oDetalleProducto.obtenerProductos(_idProducto).then((response) => {

        response.forEach(elem => {
            oArrayDetalleProductos +=
                `<tr data-detalleProducto='${JSON.stringify(elem)}'>
				<td><a href="ListProduct.html">${elem.productID}</a></td>
				<td>${elem.productName}</td>
				<td>${elem.unitPrice}</td>
                <td>${elem.quantity}</td>
                <td>${elem.total}</td>				
			</tr>`;
        });
        tblDetalleProductos.innerHTML = oArrayDetalleProductos;
        console.log('response', response)

        var sumaTotal = 0.00;
        let x;
        for (x in response) {
            sumaTotal += Number(response[x].total);
        }
        total.value = "S/. " + parseFloat(sumaTotal.toFixed(2));

    }).catch(error => {

    });
}


btnGuardar.addEventListener("click", function (evet) {
    event.preventDefault();
    console.log('este es el boton')
    // console.log('fecha', fecha.value, confirmado.checked, total.value, comentario.value)
    //txtProducto.value && txtPrecio.value
    if (fecha.value && total.value) {

        // estado = confirmado.checked;

        let detallePedido = {
            "OrderID": productoSeleccionado['orderID'],
            "FechaConfirmacion": fecha.value,
            "Confirmacion": (confirmado.checked) ? 1 : 0,
            "Comentarios": comentario.value
        }

        console.log('detallePedido',JSON.stringify(detallePedido))

        oDetalleProducto.agregarProducto(detallePedido).then((response) => {
            //console.log(response)
            //window.location = "index.html";
        }).catch(error => {

        });

        window.location = "index.html";
    }

});