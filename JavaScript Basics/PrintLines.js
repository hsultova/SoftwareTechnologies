/**
 * Created by Hris on 18.6.2016 г..
 */
function printLines(input) {
	for (let i = 0; i < input.length; i++) {
		if (input[i] == 'Stop') {
			break;
		}
		console.log(input[i]);
	}
}

printLines(['Line 1', 'Line 2', 'Line 3', 'Stop']);