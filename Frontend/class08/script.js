class Animal {
  constructor(
    species,
    name,
    description,
    height,
    weight,
    age,
    bornDate,
    bornCountry,
    acquiredIn,
    hasWings,
    canFly,
    canSwim,
    canRun,
    canJump,
    canBreatheUnderWater,
    topSpeed,
    swimDistance,
    runningDistance,
    flyingDistance,
    isAlive,
    aggressiveness,
    intelligence,
    foodType,
    killedAnimals
  ) {
    this.species = species;
    this.name = name;
    this.description = description;
    this.height = height;
    this.weight = weight;
    this.age = age;
    this.bornDate = bornDate;
    this.bornCountry = bornCountry;
    this.acquiredIn = acquiredIn;
    this.hasWings = hasWings;
    this.canFly = canFly;
    this.canSwim = canSwim;
    this.canRun = canRun;
    this.canJump = canJump;
    this.canBreatheUnderWater = canBreatheUnderWater;
    this.topSpeed = topSpeed;
    this.swimDistance = swimDistance;
    this.runningDistance = runningDistance;
    this.flyingDistance = flyingDistance;
    this.isAlive = isAlive;
    this.aggressiveness = aggressiveness;
    this.intelligence = intelligence;
    this.foodType = foodType;
    this.killedAnimals = killedAnimals;
  }
}

// Exemplo de instância
var tiger = new Animal(
  "Mammal",
  "Tiger",
  "A fierce predator with stripes.",
  1.2,
  250,
  5,
  new Date("2017-01-01"),
  "India",
  "Zoo",
  false,
  false,
  true,
  true,
  true,
  false,
  50,
  0,
  5,
  0,
  true,
  8,
  7,
  "Carnivore",
  ["Deer", "Wild Boar"]
);

console.log(tiger);

/************************************************* */

// Definindo um construtor para um objeto 'Person'
function Person(name, age) {
  this.name = name;
  this.age = age;
}

// Criando uma instância do objeto 'Person' usando o construtor
const person1 = new Person("Alice", 25);

// Acessando os atributos da instância
console.log(person1.name); // Saída: Alice
console.log(person1.age); // Saída: 25

// Chamar o construtor sem 'new' pode levar a comportamentos inesperados
const person2 = Person("Bob", 30);

// Isso criará um objeto global (ou lançará um erro no modo estrito)
console.log(person2); // Saída: undefined
console.log(window.name); // Saída: Bob (se não estiver no modo estrito)

const MyClass = class {
  constructor(name) {
    this.name = name;
  }

  greet() {
    console.log(`Hello, ${this.name}!`);
  }
};

// Criando uma instância da classe
const myInstance = new MyClass("John");
myInstance.greet(); // Saída: Hello, John!

// Classe base usando class declaration
class Animal2 {
  constructor(name) {
    this.name = name;
  }

  speak() {
    console.log(`${this.name} makes a sound.`);
  }
}

// Classe derivada usando class expression
const Mammal = class extends Animal2 {
  constructor(name, furColor) {
    super(name); // Chamando o construtor da classe pai
    this.furColor = furColor;
  }

  // Sobrescrevendo o método speak da classe pai
  speak() {
    console.log(`${this.name} is a mammal and makes a sound.`);
  }

  // Novo método específico para a classe Mammal
  showFur() {
    console.log(`${this.name}'s fur color is ${this.furColor}.`);
  }
};

// Criando instâncias das classes
const genericAnimal2 = new Animal2("Generic Animal");
const mammalInstance1 = new Mammal("Mammal Example", "Brown");

// Chamando métodos das instâncias
genericAnimal2.speak(); // Saída: Generic Animal makes a sound.
mammalInstance1.speak(); // Saída: Mammal Example is a mammal and makes a sound.
mammalInstance1.showFur(); // Saída: Mammal Example's fur color is Brown.

// Classe base usando class declaration
class Animal3 {
  constructor(name) {
    this.name = name;
  }

  speak() {
    console.log(`${this.name} makes a sound.`);
  }

  // Método estático
  static info() {
    console.log("Animals are diverse living organisms on Earth.");
  }
}

// Classe derivada usando class expression
const Mammal2 = class extends Animal3 {
  constructor(name, furColor) {
    super(name); // Chamando o construtor da classe pai
    this.furColor = furColor;
  }

  // Sobrescrevendo o método speak da classe pai
  speak() {
    console.log(`${this.name} is a mammal and makes a sound.`);
  }

  // Novo método específico para a classe Mammal
  showFur() {
    console.log(`${this.name}'s fur color is ${this.furColor}.`);
  }
};

// Criando instâncias das classes
const genericAnimal = new Animal3("Generic Animal");
const mammalInstance = new Mammal2("Mammal Example", "Brown");

// Chamando métodos das instâncias
genericAnimal.speak(); // Saída: Generic Animal makes a sound.
mammalInstance.speak(); // Saída: Mammal Example is a mammal and makes a sound.
mammalInstance.showFur(); // Saída: Mammal Example's fur color is Brown.

// Chamando o método estático da classe Animal
Animal3.info(); // Saída: Animals are diverse living organisms on Earth.
