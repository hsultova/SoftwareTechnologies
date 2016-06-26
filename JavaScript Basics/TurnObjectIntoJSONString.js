/**
 * Created by Hris on 19.6.2016 г..
 */
function turnObjectToJSON(input) {
	let object = {};
	for (let i = 0; i < input.length; i++) {
		let tokens = input[i].split(' -> ');
		let key = tokens[0];
		let value = tokens[1];

		if (key == "age" || key == "grade") {
			value = Number(value);
		}
		object[key] = value;
	}
	console.log(JSON.stringify(object));
}

turnObjectToJSON(['name -> Angel',
	'surname -> Georgiev',
	'age -> 20',
	'grade -> 6.00',
	'date -> 23/05/1995',
	'town -> Sofia']);