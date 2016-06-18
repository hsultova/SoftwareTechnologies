/**
 * Created by Hris on 18.6.2016 г..
 */
function multipleValues(input) {
	let pairs = {};
	for (let i = 0; i < input.length - 1; i++) {
		let tokens = input[i].split(' ');
		let key = tokens[0];
		let value = tokens[1];
		if (key in pairs) {
			pairs[key].push(value);
		}
		else {
			pairs[key] = [];
			pairs[key].push(value);
		}
	}
	let outputKey = input[input.length - 1];
	if (pairs[outputKey] == undefined) {
		console.log('None');
	}
	else {
		console.log(pairs[outputKey].join("\n"));
	}
}

/*multipleValues(['key value', 'key eulav', 'test tset', 'key']);*/
multipleValues(['3 test', '3 test1', '4 test2', '4 test3', '4 test5', '4']);