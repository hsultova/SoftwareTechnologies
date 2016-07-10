<html>
<head>

</head>
<body>
<form>
    Input:
    <br>
    <textarea name="input"></textarea>
    <br>
    Delimiter:
    <br>
    <input type="text" name="delimiter">
    <br>
    <input type="submit">
</form>
<?php
if (isset($_GET['delimiter']) && isset($_GET['input'])) {
    $delimiter = $_GET['delimiter'];
    $input = $_GET['input'];
    $lines = explode("\r\n", $input);

    $arr = [];
    foreach ($lines as $line) {
        $tokens = explode($delimiter, $line);
        $key = $tokens[0];
        $value = $tokens[1];
        if ($key == "age" || $key == "grade") {
            $value = floatval($value);
        }
        if ($key != "") {
            $arr[$key] = $value;
        }
    }
    echo json_encode($arr, JSON_UNESCAPED_SLASHES);
}
?>
</body>
</html>