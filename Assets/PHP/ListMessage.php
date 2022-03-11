<?php

if (isset($_POST['user']) == false) {
    die("false");
}

if ($_POST['user'] == '') {
    die('false');
}

$user = $_POST['user'];

$ListCaht = [];

foreach (glob($user . '-*') as $item) {
    array_push($ListCaht, $item);
}

foreach (glob('*-' . $user) as $item) {
    array_push($ListCaht, $item);
}

$data = json_encode($ListCaht, JSON_UNESCAPED_UNICODE);

echo $data;
