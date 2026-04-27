# Para que serve?

- Foi criado para tornar páginas web reativas, mas pelo Node.js agora também consegue rodar no backend.

# Como funciona a interpretação

- A engine, v8 ou Spider Monkey rodando no browser lê (faz o parse) do código e transforma em código de máquina

# O que consegue fazer?

- Tudo relacionado a páginas web.
- Requisições AJAX, HTTP, cookies...
- Rodando no node tem acesso a arquivos, I/O.

# O que NÂO consegue fazer?

- Não consegue fazer interações com o SO rodando no browser, porque os acessos são limitados. Até interação com dispositivos é limitado, como webcam que precisa da permissão do usuário. Com o node ele ganha as funções de programação como as outras linguagens.
- JS não interagem entre páginas. Cada JS só acessa a própria página.
- JS não tem acesso ilimitado a todos os domínios rodando dentro de um browser. Ele pode mandar requisições, mas receber requisições, arquivos é bem limitado.

# Práticas de configuração

`

<script src="file.js">
  alert(1); // the content is ignored, because src is set
</script>

`
