/**
 * Created by Hris on 17.6.2016 г..
 */
function main(arr) {
	let objects = arr.map(JSON.parse);
	let sums = {};
	for (let obj of objects)
		if (obj.town in sums)
			sums[obj.town] += obj.income;
		else
			sums[obj.town] = obj.income
	let towns = Object.keys(sums).sort();
	for (let town of towns)
		console.log(`${town} -> ${sums[town]}`);
}
main([{"town": "Sofia", "income": 200},
	{"town": "Varna", "income": 120},
	{"town": "Pleven", "income": 60},
	{"town": "Varna", "income": 70}]);