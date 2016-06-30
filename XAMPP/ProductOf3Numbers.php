<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    X: <input type="text" name="num1"/>
    Y: <input type="text" name="num2"/>
    Z: <input type="text" name="num3"/>
    <input type="submit"/>
</form>
<?php if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])) {
    $a = intval($_GET['num1']);
    $b = intval($_GET['num2']);
    $c = intval($_GET['num3']);
    $count = 0;
    if ($a < 0) {
        $count++;
    }
    if ($b < 0) {
        $count++;
    }
    if ($c < 0) {
        $count++;
    }

    if ($count % 2 == 0 || $a == 0 || $b == 0 || $c == 0) {
        echo "Positive";
    } else {
        echo "Negative";
    }
}
?>
</body>
</html>