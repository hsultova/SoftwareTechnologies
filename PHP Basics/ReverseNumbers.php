<html>
<head>

</head>
<body>
<?php
if (isset($_GET['delimiter']) && isset($_GET['numbers'])) {
    $delimiter = $_GET['delimiter'];
    $lines = $_GET['numbers'];

    $arr = explode($delimiter, $lines);
    $arr = array_map('trim', $arr);

    for ($i = count($arr) - 1; $i >= 0; $i--) {
        echo $arr[$i] . "<br>";
    }
}
?>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="numbers"></textarea>
    <input type="submit">
</form>
</body>
</html>