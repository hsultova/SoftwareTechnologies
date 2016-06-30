<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        table * {
            border: 1px solid black;
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php

    for ($i = 51; $i <= 255; $i += 51) {
        echo "<tr>";
        for ($j = 0; $j < 3; $j++) {
            if ($j == 0) {
                $r = $i;
                $g = 0;
                $b = 0;
            } else if ($j == 1) {
                $r = 0;
                $g = $i;
                $b = 0;
            } else if ($j == 2) {
                $r = 0;
                $g = 0;
                $b = $i;
            }
            echo "<td style='background-color: rgb($r,$g,$b)'></td>";
        }
        echo "</tr>";
    }
    ?>
</table>
</body>
</html>