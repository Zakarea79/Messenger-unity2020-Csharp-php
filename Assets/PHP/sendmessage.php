<?php

if (!isset($_POST['e1']) || !isset($_POST['e2'])) {
    exit('false');
}

if ($_POST['e1'] == '' || $_POST['e2'] == '') {
    die('false');
}

$e1 = $_POST['e1'];
$e2 = $_POST['e2'];
$text = $_POST['txt'];

if (file_exists($e1 . '-' . $e2)) {
    if ($text != '') {
        $filename = $e1 . '-' . $e2;
        $file = fopen($filename, 'a') or die('false');

        fwrite($file, $e1 . ':' . $text . "\n");

        fclose($file);
        echo 'true';
    } else {
        echo 'false';
    }
} else if (file_exists($e2 . '-' . $e1)) {
    if ($text != '') {
        $filename = $e2 . '-' . $e1;
        $file = fopen($filename, 'a') or die('false');

        fwrite($file, $e1 . ':' . $text . "\n");

        fclose($file);
        echo 'true';
    } else {
        echo 'false';
    }
} else {
    file_put_contents($e1 . '-' . $e2, "");
    echo 'true';
}