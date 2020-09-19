import Pedido from "./Pedido.js";

// declaramos variables.
let oArrayPedidos, oPedido, tblPedidos, oModelPedidos;

// inicializamos la funcion
OnInit();

function OnInit() {
	oArrayPedidos = "";
	oPedido = new Pedido();
	tblPedidos = document.getElementById('tblPedidos');
	// creando un object  vacio..
	oModelPedidos = {
		"orderID": null,
		"contactName": null,
		"orderDate": null,
		"phone": null
	}


	//console.log(oModelPedidos)
	oPedido.obtenerPedidos().then((response) => {

		response.forEach(elem => {
			oArrayPedidos +=
				`<tr data-pedido='${JSON.stringify(elem)}'>
				<td><a href="ListProduct.html">${elem.orderID}</a></td>
				<td>${elem.orderDate}</td>
				<td>${elem.contactName}</td>
				<td>${elem.phone}</td>				
			</tr>`;
		});
		tblPedidos.innerHTML = oArrayPedidos;		

	}).catch(error => {

	});
}

// evento click  para seleccionar las ordenes 
tblPedidos.addEventListener("click", function (e) {
	// definiendo el target
	e = e || window.event;
	var data = [];
	var target = e.srcElement || e.target;

	while (target && target.nodeName !== "TR") {
		target = target.parentNode;
		//console.log(target)
	}

	let productoSeleccionado = JSON.parse(target.dataset.pedido);
	//console.log('productoSeleccionado',productoSeleccionado)
	oModelPedidos = JSON.stringify(productoSeleccionado);

	//console.log('productoSeleccionado',productoSeleccionado)
	//console.log('oModelPedidos',target.dataset.pedido)

	// almacenando en el LocalStorage.
	localStorage.setItem("Pedidos", oModelPedidos);

});







