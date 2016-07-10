<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>PHP Basics</title>
</head>
<body>
<?php
function calcSumsByTown(array $townsIncome) :array
{
    $sums = [];
    foreach ($townsIncome as $townIncome) {
        $tokens = explode(':', $townIncome);
        $town = $tokens[0];
        $income = $tokens[1];
        if (isset($sums[$town])) {
            $sums[$town] += $income;
        } else {
            $sums[$town] = $income;
        }
    }
    ksort($sums);
    return $sums;
}

if (isset($_GET['towns-incomes'])) {
    $townsIncomes = array_map('trim', explode("\n", $_GET['towns-incomes']));
    $sumsByTown = calcSumsByTown($townsIncomes);
    foreach ($sumsByTown as $town => $sum) {
        echo $town . "->" . $sum . "<br>\n";
    }
}?>
<form>
    <textarea rows="10" name="towns-incomes"></textarea><br>
    <input type="submit" value="Calculate">
</form>
</body>
</html>