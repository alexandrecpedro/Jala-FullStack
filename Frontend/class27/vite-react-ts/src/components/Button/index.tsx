import React from 'react';
import './styles.css';

interface ButtonProps {
  readonly text: string;
}

const Button: React.FC<ButtonProps> = ({ text }) => {
  return (
    //for accessibility purposes we have type and aria-label well defined here.
    <button className='btn' type="submit" aria-label={text}>
      {text}
    </button>
  );
};

export default Button;
