import React from 'react';

interface ButtonProps {
    onClick: () => void;
    text: string;
}

const Button: React.FC<ButtonProps> = ({ onClick, text }) => {
    return (
        //for accessibility purposes we have type and aria-label well defined here.
        <button type="button" onClick={onClick} aria-label={text}>
            {text}
        </button>
    );
};

export default Button;