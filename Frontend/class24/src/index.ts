enum ContactStatusEnum { 
    Active = 'Active',
    Inactive = 'Inactive',
    Deleted = 'Deleted'
}
class Contact {
    id: number;
    name: string;
    birthDate: Date;
    phone: string;
    status: ContactStatusEnum;

    constructor(id: number, name: string, birthDate: Date, phone: string, status: ContactStatusEnum) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.phone = phone;
        this.status = status;
    }
}
interface IAddress {
    street: string;
    city: string;
    state: string;
    zip: string;
    div(name: string): IAddress;
}

const address: IAddress = { 
    street: '123 Main St', 
    city: 'Anytown',
    state: 'NY',
    zip: '12345',
    div: function(name: string) {
         return {...this, name}; 
    }
};

function clone<T>(source: T): T {
    return {...source};
}
interface IUser {
     id: number;
    name: string;
    birthDate: Date;
    phone: string;
    status: ContactStatusEnum;
}

const user:IUser = { id: 1, name: 'John Doe', birthDate: new Date(), phone: '1234567890', status: ContactStatusEnum.Active };
const contact = new Contact(1, 'John Doe', new Date(), '1234567890', ContactStatusEnum.Active);
const cloned = clone(contact);



function duplicate<T1 extends T2 ,T2>(source: T1): T2 {
    return {...source}
}

const result:IUser = duplicate<Contact,IUser>(contact)