
import React, { ReactNode } from 'react';
import './styles.css';

type FormProps = {
  readonly children: ReactNode;
  readonly onSubmit: () => void;
};

//this component is lacking a little bit of control, but it's fine for now
const Form: React.FC<FormProps> = ({ children, onSubmit }) => {
  return (
    <form className='form' onSubmit={onSubmit}>
      {children}
    </form>
  );
};

export default Form;
