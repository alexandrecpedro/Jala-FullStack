"use strict";

function init() {
  var name = "Mozilla";
  var displayName = () => {
    console.log(name);
  };
  displayName();
  var name = "Bizarro";
}

init();

displayName();
const sum = (i, j) => i + j;
const sub = (i, j) => i - j;
const mult = (i, j) => i * j;
const div = (i, j) => i / j;

const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const evenNumbers = numbers.filter((number) => number % 2 === 0);

setTimeout(() => {
  console.log("Hello World");
}, 3000);

function doSomething() {}

const fish = {
  name: "Nemo",
  age: 2,
  color: "orange",
  height: 10,
  newHeight: function (height) {
    console.log((this.height + height).toString());
  },
};

var a0 = "JavaScript";
let a1 = "JavaScript";
// a2 = 33;

console.log(i.toString());
fish.newHeight(100);
console.log(`Height inside height: ${this.height}`);

(function exempleVar() {
  if (true) {
    var x = 10;
    console.log(x); // 10
  }
  console.log(x); // 10
})();

(function exempleLet(params) {
  if (true) {
    let y = 20;
    console.log(y); // 20
  }
  console.log(y); // undefined
})();
