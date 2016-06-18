/**
 * Created by Hris on 18.6.2016 г..
 */
function setValuesToIndexes(input) {
	let n = Number(input[0]);
	let numbers = [];

	for (let i = 0; i < n; i++) {
		numbers.push(0);
	}
	for (let i = 1; i < input.length; i++) {
		let index = Number(input[i].split(' - ')[0]);
		let number = Number(input[i].split(' - ')[1]);
		numbers.splice(index, 1, number)
	}
	for (let number of numbers) {
		console.log(number);
	}
}

setValuesToIndexes([ '3', '0 - 5', '1 - 6', '2 - 7' ]);
setValuesToIndexes(['5', '0 - 3', '3 - -1', '4 - 2']);