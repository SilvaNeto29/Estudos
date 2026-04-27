// Aceita inline
console.log("OI");
console.log("TUDO");
console.log("BEM?");

// Com ponto e virgula ou sem
console.log("Oi");
console.log("Oi");
//Exceto antes de [...]
alert("Hello")[(1, 2)].forEach(alert); //Isso causa um erro, pois o JavaScript interpreta isso como uma tentativa de acessar a propriedade [1, 2] do resultado de alert("Hello"), o que não é possível.
// Para evitar esse erro, é necessário adicionar um ponto e vírgula após alert("Hello"):

///////////////////////////////

// Se quisermos usar o ES6, precisamos usar o "use strict" para evitar erros de sintaxe
("use strict");

//Variáveis
let x = 10; // Isso é permitido
y = 20; // Isso causará um erro, pois y não foi declarado

// Variáveis e constantes
let a = 5; // Variável que pode ser reatribuída
const b = 10; // Constante que não pode ser reatribuída

a = 15; // Isso é permitido
// b = 20; // Isso causará um erro, pois b é uma constante

let user = "John",
  age = 25,
  message = "Hello"; //também pode-se declarar inline

// Tipos de dados
let str = "Hello"; // String
let num = 42; // Número
let bool = true; // Booleano
let arr = [1, 2, 3]; // Array
let obj = { name: "Alice", age: 30 }; // Objeto

// Funções
function greet(name) {
  return `Hello, ${name}!`;
}

console.log(greet("Alice")); // Output: Hello,

// Boa prática ESCREVER EM CAIXA ALTA PRA CONSTANTES
const COLOR_RED = "#F00";
const COLOR_GREEN = "#0F0";
const COLOR_BLUE = "#00F";
const COLOR_ORANGE = "#FF7F00";

// ...when we need to pick a color
let color = COLOR_ORANGE;
alert(color); // #FF7F00
