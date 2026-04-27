// ============================================================
//  MANUAL PRÁTICO: ESCOPOS DE let E const NO JAVASCRIPT
//  Rode cada seção no Node.js ou no console do navegador
// ============================================================

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 1. DIFERENÇA BÁSICA: var × let × const
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

{
  var comVar = "var ignora bloco";
  let comLet = "let respeita bloco";
  const comConst = "const respeita bloco";
}

console.log(comVar); // ✅ "var ignora bloco"
// console.log(comLet);  // ❌ ReferenceError: comLet is not defined
// console.log(comConst);// ❌ ReferenceError: comConst is not defined

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 2. ESCOPO DE BLOCO { }
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

let fora = "fora do bloco";

{
  let dentro = "dentro do bloco";
  console.log(fora); // ✅ "fora do bloco"
  console.log(dentro); // ✅ "dentro do bloco"
}

console.log(fora); // ✅ "fora do bloco"
// console.log(dentro);// ❌ ReferenceError

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 3. ESCOPO EM if / else
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

const logado = true;

if (logado) {
  let mensagem = "Bem-vindo!";
  const nivel = "admin";
  console.log(mensagem); // ✅ "Bem-vindo!"
  console.log(nivel); // ✅ "admin"
}

// console.log(mensagem); // ❌ ReferenceError
// console.log(nivel);    // ❌ ReferenceError

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 4. ESCOPO EM LOOPS — o problema clássico do var
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

// 4a. var: todos os callbacks capturam o MESMO i
console.log("--- var no loop ---");
const cbsVar = [];
for (var i = 0; i < 3; i++) {
  cbsVar.push(() => console.log("var i =", i));
}
cbsVar.forEach((fn) => fn()); // 3, 3, 3  ← bug clássico

// 4b. let: cada iteração tem seu PRÓPRIO i
console.log("--- let no loop ---");
const cbsLet = [];
for (let j = 0; j < 3; j++) {
  cbsLet.push(() => console.log("let j =", j));
}
cbsLet.forEach((fn) => fn()); // 0, 1, 2  ✅

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 5. TEMPORAL DEAD ZONE (TDZ)
//    let e const existem no escopo mas NÃO podem ser acessados
//    antes da linha de declaração
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

// console.log(tdz); // ❌ ReferenceError: Cannot access 'tdz' before initialization
let tdz = "agora sim";
console.log(tdz); // ✅ "agora sim"

// Contraste com var (hoisting sem TDZ):
console.log(semTdz); // ✅ undefined (hoisted, mas valor ainda não atribuído)
var semTdz = "var é hoisted com valor undefined";

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 6. REDECLARAÇÃO: var permite, let e const proíbem
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

var dupla = 1;
var dupla = 2; // ✅ sem erro, silenciosamente sobrescreve

let unica = 1;
// let unica = 2; // ❌ SyntaxError: Identifier 'unica' has already been declared

const fixa = 1;
// const fixa = 2; // ❌ SyntaxError

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 7. const NÃO É IMUTÁVEL — é não-reatribuível
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

const usuario = { nome: "Claudio", nivel: 1 };

// Mutação do objeto: ✅ permitida
usuario.nome = "João";
usuario.nivel = 99;
console.log(usuario); // { nome: 'João', nivel: 99 }

// Reatribuição da variável: ❌ proibida
// usuario = { nome: "Outro" }; // TypeError: Assignment to constant variable

// Mesmo com arrays:
const lista = [1, 2, 3];
lista.push(4); // ✅ ok
lista[0] = 99; // ✅ ok
console.log(lista); // [99, 2, 3, 4]
// lista = [];           // ❌ TypeError

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 8. ESCOPO EM FUNÇÕES
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

function saudacao(nome) {
  const prefixo = "Olá,"; // escopo: só dentro de saudacao()
  let contador = 0; // escopo: só dentro de saudacao()
  contador++;
  return `${prefixo} ${nome}! (chamada #${contador})`;
}

console.log(saudacao("Claudio")); // "Olá, Claudio! (chamada #1)"
// console.log(prefixo);          // ❌ ReferenceError
// console.log(contador);         // ❌ ReferenceError

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 9. CLOSURE COM let — estado privado por instância
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

function criarContador() {
  let total = 0; // capturado pelo closure
  return {
    incrementar: () => ++total,
    decrementar: () => --total,
    valor: () => total,
  };
}

const c1 = criarContador();
const c2 = criarContador();

c1.incrementar();
c1.incrementar();
c1.incrementar();
c2.incrementar();

console.log("c1:", c1.valor()); // 3
console.log("c2:", c2.valor()); // 1  — estado totalmente independente

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 10. SHADOWING — variável interna "oculta" a externa
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

const cor = "azul";

{
  const cor = "vermelho"; // shadow: variável diferente, mesmo nome
  console.log(cor); // ✅ "vermelho"
}

console.log(cor); // ✅ "azul" — a externa não foi tocada

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 11. MÓDULOS — let e const têm escopo de módulo por padrão
//     (rodar com: node --input-type=module < arquivo.mjs
//      ou adicionar "type":"module" no package.json)
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

// Em módulos, isso NÃO vai para window/global:
// export const API_URL = "https://api.exemplo.com";

// Em scripts normais, var vai para global, let/const não:
var globalVar = "estou em global";
let naoGlobal = "NÃO estou em global";

// No browser: window.globalVar   → "estou em global"
// No browser: window.naoGlobal   → undefined

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// 12. CASO REAL: configuração imutável vs. estado mutável
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

const CONFIG = Object.freeze({
  //freeze impede a modificação do objeto, mesmo sendo uma propriedade interna
  url: "https://api.prod.com",
  timeout: 5000,
  versao: "v2",
});

// CONFIG.url = "outra"; // ❌ silenciosamente ignorado (em strict mode: TypeError)
console.log(CONFIG.url); // ✅ "https://api.prod.com"

// Estado que muda ao longo do tempo → let
let tentativas = 0;

function fazerRequisicao() {
  tentativas++;
  const endpoint = `${CONFIG.url}/dados?t=${tentativas}`;
  console.log("Chamando:", endpoint);
  // ... lógica de fetch aqui
}

fazerRequisicao(); // Chamando: https://api.prod.com/dados?t=1
fazerRequisicao(); // Chamando: https://api.prod.com/dados?t=2

// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
// RESUMO RÁPIDO
// ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
//
//  ┌─────────────┬──────────┬────────────┬──────────────────┐
//  │             │  var     │   let      │   const          │
//  ├─────────────┼──────────┼────────────┼──────────────────┤
//  │ Escopo      │ função   │ bloco      │ bloco            │
//  │ Hoisting    │ sim*     │ TDZ        │ TDZ              │
//  │ Redeclara   │ sim      │ não        │ não              │
//  │ Reatribui   │ sim      │ sim        │ não              │
//  │ Global obj  │ sim      │ não        │ não              │
//  └─────────────┴──────────┴────────────┴──────────────────┘
//  * hoisted com valor undefined, não com o valor real
//
//  REGRA DE OURO:
//  → Use const por padrão
//  → Troque para let quando precisar reatribuir
//  → Nunca use var em código moderno
