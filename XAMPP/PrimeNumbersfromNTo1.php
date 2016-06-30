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
    function isPrime($number)
    {
        $boundary = floor(sqrt($number));
        if ($number == 1) {
            return false;
        }
        if ($number == 2) {
            return true;
        }
        for ($i = 2; $i <= $boundary; $i++) {
            if ($number % $i == 0) {
                return false;
            }
        }
        return true;
    }

    for ($i = $num; $i >= 1; $i--) {
        if (isPrime($i)) {
            echo "$i\n";
        }
    }
}
?>
</body>
</html>