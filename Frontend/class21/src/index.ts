enum Color {
  Red,
  Green,
  Blue,
}

class Contact {
  id: number;
  name: string;
  email: string;
  phone: string;

  constructor() {
    this.id = 0;
    this.name = "";
    this.email = "";
    this.phone = "";
  }
}

// let b: Contact = new Contact();
// b = { id: 0, name: "", email: "", phone: "" };

// interface IContact {
//   id: number;
//   name: string;
//   email: string;
//   phone: string;
// }

interface WithStrict {
  id: number;
  name: string;
  birthDate?: Date;
}

// class Point {
//   x: number;
//   y: number;
// }

let x: number[];
let y: number;
let a: Date;
let b: number[] | string[] | string | number | object | undefined;
let c: number[] | string[] | string | number | object | undefined;
let d: Array<number>;

// b = "Hello";
// b = 16287384;
// b = "Hello" as any;

interface IAddress {
  street: string;
  city: string;
  state: string;
  zip: string;
}

interface IPerson {
  id: number;
  name: string;
  birthDate?: Date;
  phoneNumber: string;
  address?: IAddress | null;
}

type CrazyType =
  | Array<string>
  | string
  | object
  | number
  | boolean
  | null
  | undefined;

type Animal = string | null | undefined;

interface IAnimal {
  name: Animal;
  age: CrazyType;
  isPet: CrazyType;
}

let primaryContact: IPerson = {
  id: 1,
  name: "John Doe",
  birthDate: new Date("08-07-1990"),
  phoneNumber: "123-456-7890",
  // address: {
  //   street: "123 Main St",
  //   city: "Somewhere",
  //   state: "CA",
  //   zip: "12345",
  // },
};
