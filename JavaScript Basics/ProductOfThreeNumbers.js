/**
 * Created by Hris on 18.6.2016 г..
 */
function solve(arr) {
	let numbers = [];
	let negativeCounter = 0;
	for (let i = 0; i < arr.length; i++) {
		numbers.push(Number(arr[i]));
	}
	for (let number of numbers) {
		if (number < 0) {
			negativeCounter++;
		}
		else if (number == 0) {
			console.log('Positive');
			return;
		}
	}
	if (negativeCounter % 2 == 0) {
		console.log('Positive');
	}
	else {
		console.log('Negative');
	}
}

solve(['2', '3', '-1']);
solve(['5', '4', '3']);
solve(['-3', '-4', '5']);
solve(['-3', '0', '5']);