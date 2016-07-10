<html>
<head>

</head>
<body>
<form>
    Start Date:
    <br>
    <input type="text" name="date">

    <br>
    Output Format:
    <br>
    <input type="text" name="format">
    <br>
    Commands:
    <br>
    <textarea name="commands"></textarea>
    <br>
    <input type="submit">
</form>
<?php
if (isset($_GET['date']) && isset($_GET['format']) && isset($_GET['commands'])) {
    $commands = $_GET['commands'];
    $date = $_GET['date'];
    $format = $_GET['format'];

    $lines = explode("\n", $commands);
    $date = date_create_from_format("d/m/Y", $date);
    foreach ($lines as $line) {
        $tokens = explode(" ", $line);
        $command = $tokens[0];
        $number = intval($tokens[1]);
        if ($command == "add") {
            date_add($date, date_interval_create_from_date_string("$number days"));
        } else if ($command == "subtract") {
            date_sub($date, date_interval_create_from_date_string("$number days"));
        }
    }

    echo date_format($date, $format);
}
?>
</body>
</html>

