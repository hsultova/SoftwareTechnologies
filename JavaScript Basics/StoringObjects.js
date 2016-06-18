/**
 * Created by Hris on 18.6.2016 г..
 */
function storeObjects(input) {
	let storedInfo = [];

	for (let i = 0; i < input.length; i++) {
		let tokens = input[i].split(" -> ");
		let name = tokens[0];
		let age = Number(tokens[1]);
		let grade = Number(tokens[2]);

		storedInfo.push({
			'Name': name,
			'Age': age,
			'Grade': grade.toFixed(2)
		});
	}

	for (let info of storedInfo) {
		let infoKeys = Object.keys(info);
		for (let key of infoKeys) {
			console.log(key + ": " + info[key]);
		}
	}
}

storeObjects(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 5.57', 'Toni -> 13 -> 4.90']);

