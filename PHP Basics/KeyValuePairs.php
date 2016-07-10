<html>
<head>

</head>
<body>
<?php
if (isset($_GET['delimiter']) && isset($_GET['target-key']) && isset($_GET['key-value-pairs'])) {
    $delimiter = $_GET['delimiter'];
    $targetKey = $_GET['target-key'];
    $lines = $_GET['key-value-pairs'];

    $arr = [];

    $pairs = explode("\n", $lines);
    $pairs = array_map('trim', $pairs);

    foreach ($pairs as $pair) {
        $tokens = explode($delimiter, $pair);
        $key = $tokens[0];
        $value = $tokens[1];

        $arr[$key] = $value;
    }

    if (isset($arr[$targetKey])) {
        echo $arr[$targetKey];
    } else {
        echo "None";
    }
}
?>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="key-value-pairs"></textarea>
    Target Key: <input type="text" name="target-key">
    <input type="submit">
</form>
</body>
</html>