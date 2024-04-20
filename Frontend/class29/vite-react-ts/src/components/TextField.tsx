import React from 'react';
import InputField from './InputField';

interface TextFieldProps {
    value: string;
    onChange: (value: string) => void;
    title?: string;
    placeholder?: string;
}

const TextField: React.FC<TextFieldProps> = ({ value, onChange, title, placeholder }) => {
    return (
        <InputField value={value} onChange={onChange} title={title} placeholder={placeholder} type="text">
            {/* If for some reason we need to pass some component here (we shouldn't) */}
        </InputField>
    );
};

export default TextField;