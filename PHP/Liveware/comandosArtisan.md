# 📦 Criar novo projeto Laravel
laravel new nome-projeto
# ou
composer create-project laravel/laravel nome-projeto

# 🧱 Criar model
php artisan make:model NomeModel

# 🧱 Criar model com migration, factory e seeder
php artisan make:model NomeModel -mfsc

# 🔄 Criar migration
php artisan make:migration create_nome_tabela_table

# 🧪 Criar seeder
php artisan make:seeder NomeSeeder

# 🧪 Criar factory
php artisan make:factory NomeFactory

# 🧬 Rodar migrations
php artisan migrate

# ♻️ Resetar e rodar migrations
php artisan migrate:fresh

# ♻️ Com seed após resetar
php artisan migrate:fresh --seed

# 🚀 Rodar seeders
php artisan db:seed

# 👤 Criar controller
php artisan make:controller NomeController

# 👤 Criar controller resource (CRUD)
php artisan make:controller NomeController --resource

# 🌐 Criar request personalizado (validação)
php artisan make:request NomeRequest

# 🔧 Criar middleware
php artisan make:middleware NomeMiddleware

# 🔁 Criar job
php artisan make:job NomeJob

# ⚙️ Criar service provider
php artisan make:provider NomeProvider

# 💡 Criar command (CLI personalizado)
php artisan make:command NomeCommand

# 📧 Criar mail
php artisan make:mail NomeMail

# 📜 Criar policy
php artisan make:policy NomePolicy

# 🔐 Criar event
php artisan make:event NomeEvent

# 🔔 Criar notification
php artisan make:notification NomeNotification

# 🧪 Criar teste (Feature)
php artisan make:test NomeTest

# 🧪 Criar teste (Unit)
php artisan make:test NomeTest --unit

# 🗂️ Criar recurso API (Resource)
php artisan make:resource NomeResource

# 📄 Criar nova view
touch resources/views/nome.blade.php

# 🚀 Servidor local
php artisan serve

# 🧪 Rodar testes
php artisan test

# 📜 Listar todas as rotas
php artisan route:list

# 🔐 Criar auth scaffolding (se usar Laravel Breeze, Jetstream, etc)
php artisan breeze:install
php artisan jetstream:install livewire