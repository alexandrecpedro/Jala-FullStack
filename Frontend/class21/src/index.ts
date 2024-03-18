class Contact {
  // constructor() {
  //   this.id = 0;
  //   this.name = "";
  //   this.email = "";
  //   this.phone = "";
  // }

  id: number;
  name: string;
  email: string;
  phone: string;
}

let b: Contact = new Contact();
b = { id: 0, name: "", email: "", phone: "" };

interface IContact {
  id: number;
  name: string;
  email: string;
  phone: string;
}
