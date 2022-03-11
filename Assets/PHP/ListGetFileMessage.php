<?php

if(!isset($_POST['e1']) || !isset($_POST['e2']))
{
    exit('false');
}

if($_POST['e1'] == '' || $_POST['e2'] == '')
{
    die('false');
}

$e1 = $_POST['e1'];
$e2 = $_POST['e2'];

if(file_exists($e1 . '-' . $e2))
{
    echo $e1 . '-' . $e2;
} 
else if (file_exists($e2 . '-' . $e1))
{
    echo $e2 . '-' . $e1;
} 
else 
{
    echo "false";
}