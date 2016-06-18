/**
 * Created by Hris on 18.6.2016 г..
 */
function solve(input) {
	let pairs = {};
	for (let i = 0; i < input.length - 1; i++) {
		let tokens = input[i].split(' ');
		let key = tokens[0];
		let value = tokens[1];
		pairs[key] = value;
	}
	let result = pairs[input[input.length - 1]];
	if (result == undefined) {
		console.log('None');
	}
	else {
		console.log(result);
	}
}

solve(['key value', 'key eulav', 'test tset', 'key']);