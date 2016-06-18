/**
 * Created by Hris on 18.6.2016 г..
 */
function addRemoveElements(input) {
	let numbers = [];
	for (let i = 0; i < input.length; i++) {
		let line = input[i].split(' ');
		let command = line[0];
		let argument = Number(line[1]);
		if (command == 'add') {
			let element = argument;
			numbers.push(element);
		}
		else if (command == 'remove') {
			let index = argument;
			if (index < numbers.length) {
				numbers.splice(index, 1);
			}
		}
	}
	for (let number of numbers) {
		console.log(number);
	}
}

addRemoveElements(['add 3', 'add 5', 'remove 1', 'add 2']);
addRemoveElements(['add 3', 'add 5', 'remove 2', 'remove 0', 'add 7']);