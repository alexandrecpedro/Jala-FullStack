import React, { ReactNode, RefObject } from 'react';
import './styles.css';

interface InputFieldProps {
    inputRef: RefObject<HTMLInputElement>;
    name: string;
    placeholder: string;
    required: boolean
    type: string;
}


const InputField: React.FC<InputFieldProps> = ({ inputRef, name, placeholder, required, type }): ReactNode => {

    return (
        <input
            placeholder={placeholder}
            type={type}
            name={name}
            ref={inputRef}
            required={required}
            className='input'
        />
    )
}

export default InputField
