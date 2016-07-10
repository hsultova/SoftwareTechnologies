<html>
<head>

</head>
<body>
<?php
if (isset($_GET['delimiter']) && isset($_GET['array-size']) && isset($_GET['key-value-pairs'])) {
    $delimiter = $_GET['delimiter'];
    $size = $_GET['array-size'];
    $lines = $_GET['key-value-pairs'];

    $arr = [];
    for ($i = 0; $i < $size; $i++) {
        $arr[$i] = 0;
    }

    $pairs = explode("\n", $lines);
    $pairs = array_map('trim', $pairs);

    foreach ($pairs as $pair) {
        $tokens = explode($delimiter, $pair);
        $key = $tokens[0];
        $value = $tokens[1];
        $arr[$key] = $value;
    }

    foreach ($arr as $key => $value) {
        echo $value . "<br>";
    }
}
?>
<form>
        Delimiter: <input type="text" name="delimiter">
        Array-size: <input type="text" name="array-size">
        Input: <textarea name="key-value-pairs"></textarea>
        <input type="submit">
    </form>
</body>
</html>