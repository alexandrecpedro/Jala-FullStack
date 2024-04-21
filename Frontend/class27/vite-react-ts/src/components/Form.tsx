
import React, { ReactNode } from 'react';

type FormProps = {
    children: ReactNode;
};

//this component is lacking a little bit of control, but it's fine for now
const Form: React.FC<FormProps> = ({ children }) => {
    return (
        <form>
            {children}
        </form>
    );
};

export default Form;