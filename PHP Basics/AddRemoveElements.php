<html>
<head>

</head>
<body>
<?php
if (isset($_GET['delimiter']) && isset($_GET['commands'])) {
    $delimiter = $_GET['delimiter'];
    $lines = $_GET['commands'];

    $arr = [];

    $pairs = explode("\n", $lines);
    $pairs = array_map('trim', $pairs);

    foreach ($pairs as $pair) {
        $tokens = explode($delimiter, $pair);
        $command = $tokens[0];
        $number = $tokens[1];

        if ($command == 'add') {
            array_push($arr, $number);
        } else if ($command == 'remove') {
            array_splice($arr, $number, 1);
        }
    }

    foreach ($arr as $value) {
        echo $value . "<br>";
    }
}
?>
 <form>
        Delimiter: <input type="text" name="delimiter">
        Input: <textarea name="commands"></textarea>
        <input type="submit">
 </form>
</body>
</html>