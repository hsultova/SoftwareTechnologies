<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num"/>
    <input type="submit"/>
</form>
<?php if (isset($_GET['num'])) {
    $num = intval($_GET['num']);

    if ($num == 1) {
        echo 1;
    } else {
        $first = 1;
        $second = 1;
        $third = 2;
        $sum = 0;
        echo "$first\n$second\n$third\n";
    }
    for ($i = 3; $i < $num; $i++) {
        $sum = $first + $second + $third;
        echo "$sum\n";
        $first = $second;
        $second = $third;
        $third = $sum;
    }
}
?>
</body>
</html>