/**
 * Created by Hris on 18.6.2016 г..
 */
function solve(arr) {
	let n = Number(arr[0]);
	let x = Number(arr[1]);

	if (x >= n) {
		console.log(n * x);
	}
	else if (n > x) {
		console.log(n / x);
	}
}

solve(['2', '3']);
solve(['13', '13']);
solve(['3', '2']);
solve(['144', '12']);