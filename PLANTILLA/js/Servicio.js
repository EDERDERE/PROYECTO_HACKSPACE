export default class Servicio {

	constructor() {

	}

	// metodo
	http(_request) {
		return new Promise(function (resolve, reject) {
			fetch(_request)
				.then(response => {
					console.log(response)
					if (response.status === 200) {
						return response.json(); 
					} else {
						throw new Error('Algo salió mal en el servidor api!');
					}
				})
				.then(data => {
					resolve(data);				
				}).catch(error => {
					reject(error);
				});
		});
	}
}

