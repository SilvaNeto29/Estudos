<?php

# 📦 Criar componente (classe + view Blade)
php artisan make:livewire NomeComponente

# 🧩 Criar componente inline (apenas classe, sem view separada)
php artisan make:livewire NomeComponente --inline

# 🛠️ Criar componente com namespace
php artisan make:livewire Admin/Painel

# 🧪 Criar teste para componente Livewire
php artisan make:livewire-test NomeComponente

# 📜 Listar todos os comandos relacionados ao Livewire
php artisan list livewire

# ⚙️ Publicar arquivo de config do Livewire
php artisan vendor:publish --tag=livewire:config

# ⚡ Livewire V3: testar reatividade (somente se usar Vite + Livewire v3)
php artisan livewire:test

(Opcional) Criar componente com Blade direto usando Volt (Livewire v3)
php artisan make:volt NomeComponente


?>