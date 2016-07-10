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

    $lines = explode("\n", $input);

    foreach ($lines as $line){
        $tokens = explode($delimiter, $line);
        $name = $tokens[0];
        $age = intval($tokens[1]);
        $grade = floatval($tokens[2]);

        echo "<ul><li>Name: $name</li><li>Age: $age</li><li>Grade: $grade</li></ul>";
    }
}
?>
</body>
</html>