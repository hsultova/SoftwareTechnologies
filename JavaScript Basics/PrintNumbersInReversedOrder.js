/**
 * Created by Hris on 18.6.2016 г..
 */
function printNumbers(input) {
	for (let i = input.length - 1; i >= 0; i--) {
		console.log(input[i]);
	}
}

printNumbers(['10', '15', '20']);
printNumbers(['5', '5.5', '24', '-3']);
printNumbers(['20', '1', '20', '1', '20']);