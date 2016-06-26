/**
 * Created by Hris on 18.6.2016 г..
 */
function parseJSON(input) {
	let objects = [];
	for (let i = 0; i < input.length; i++) {
		objects.push(JSON.parse(input[i]));
	}
	for (let obj of objects) {
		let infoKeys = Object.keys(obj);
		for (let key of infoKeys) {
			console.log(key[0].toUpperCase() + key.substring(1) + ": " + obj[key]);
		}
	}
}

parseJSON(['{"name":"Gosho","age":10,"date":"19/06/2005"}',
	'{"name":"Tosho","age":11,"date":"04/04/2005"}']);

