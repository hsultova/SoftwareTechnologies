<?php if (isset($_GET['number1']) && isset($_GET['number2'])) {
    $number1 = intval($_GET['number1']);
    $number2 = intval($_GET['number2']);
    $sum = $number1 + $number2;
    echo "$number1 + $number2 = $sum";
} ?>
<form>
    <div>First Number:</div>
    <input type="number" name="number1">
    <div>Second Number:</div>
    <input type="number" name="number2">
    <div><input type="submit" value="Submit"></div>
</form>