import React, { ChangeEvent, ReactNode } from 'react';

interface InputFieldProps {
    value: string;
    onChange: (value: string) => void;
    title: string;
    placeholder: string;
    type: string;
}

const InputField: React.FC<InputFieldProps> = ({ value, onChange, title, placeholder, type }):ReactNode => {
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        onChange(event.target.value);
    };

    return (
        <input type={type} value={value} onChange={handleChange} title={title} placeholder={placeholder} />
    );
};

export default InputField;