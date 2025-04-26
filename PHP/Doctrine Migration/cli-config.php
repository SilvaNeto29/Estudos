<?php

require 'vendor/autoload.php';

use Doctrine\DBAL\DriverManager;
use Doctrine\Migrations\Configuration\Connection\ExistingConnection;
use Doctrine\Migrations\Configuration\Migration\PhpFile;
use Doctrine\Migrations\DependencyFactory;

$config = new PhpFile(__DIR__ . '/migrations.php');
$env = parse_ini_file(__DIR__ . '/../.env');

$conn = DriverManager::getConnection([
                'driver'     => $env['DB_DRIVER'],
                'host'     => $env['DB_HOST'],
                'dbname' => $env['DB_NAME'],
                'user' => $env['DB_USER'],
                'password' => $env['DB_PASS'],
                'charset'  => 'utf8mb4']);

return DependencyFactory::fromConnection($config, new ExistingConnection($conn));