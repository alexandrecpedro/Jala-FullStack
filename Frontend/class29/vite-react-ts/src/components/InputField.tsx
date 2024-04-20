import React, { ChangeEvent, ReactNode } from 'react'


/*
 In this module we have 3 different ways to define the InputField component.
 Altough I couldn't sell those out as a good practice, I'm just showing how to do it.
 And still I'm using the first one in the TextField component. Because it's the most readable one, 
 and it's the most common way to define a professional grade component.
 
 It's only fair to also point out the advantes and disvantages of using React.FC

Advantages:
    1 - Type checking for props: React.FC takes a generic parameter which can be used to type check the props of the component.
    2 - Implicit children: React.FC automatically adds a children prop to your component, even if it's not defined in your props type. This can be useful if you're creating a component that wraps other elements or components.
    3 - Self-documenting: Using React.FC makes it clear that the function is a React component.

Disadvantages:
    1 - Implicit children can be confusing: If your component doesn't support children, it can be confusing to see them in the type definition. It can also lead to bugs if children are accidentally passed to a component that doesn't handle them.
    2 - No enforcement of defaultProps: React.FC doesn't play well with defaultProps. If you're using TypeScript 3.0 or later, it's recommended to use function default parameters instead.
    3 - Additional verbosity: Using React.FC adds a bit more verbosity to your component definitions.

*/

interface InputFieldProps {
    value: string
    onChange: (value: string) => void
    title?: string
    placeholder?: string
    type: string
    children?: ReactNode
}


const InputField: React.FC<InputFieldProps> = ({ value, onChange, title, placeholder, type, children }): ReactNode => {
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        onChange(event.target.value)
    }

    return (
        <div>
            { title && <label>{ title }</label> }
            <input type={ type } value={ value } onChange={ handleChange } placeholder={ !title ? placeholder : undefined } />
            {children}
        </div>
    )
}

function InputFieldType2 ({ value, onChange, title, placeholder, type }: InputFieldProps): ReactNode {
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        onChange(event.target.value)
    }

    return (
        <div>
            { title && <label>{ title }</label> }
            <input type={ type } value={ value } onChange={ handleChange } placeholder={ !title ? placeholder : undefined } />
        </div>
    )
}


const InputFieldType3 = (props: InputFieldProps): ReactNode => {
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        props.onChange(event.target.value)
    }

    return (
        <div>
            { props.title && <label>{ props.title }</label> }
            <input type={ props.type } value={ props.value } onChange={ handleChange } placeholder={ !props.title ? props.placeholder : undefined } />
            { props.children }
        </div>
    )
}

export { InputFieldType2, InputFieldType3 }
export default InputField
