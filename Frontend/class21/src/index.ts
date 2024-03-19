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

let b: Contact = new Contact();
b = { id: 0, name: "", email: "", phone: "" };

// interface IContact {
//   id: number;
//   name: string;
//   email: string;
//   phone: string;
// }
