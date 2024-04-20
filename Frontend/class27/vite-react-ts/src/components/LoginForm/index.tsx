import React, { useRef } from 'react';
import { toast } from 'react-toastify';
import { useUserContext } from '../../context/UserContext';
import { IUser } from '../../interfaces/IUser';
import Button from '../Button';
import Form from '../Form';
import InputField from '../InputField';

const LoginForm: React.FC = () => {
    const nameRef = useRef<HTMLInputElement>(null)
    const surnameRef = useRef<HTMLInputElement>(null)
    const passwordRef = useRef<HTMLInputElement>(null)
    const emailRef = useRef<HTMLInputElement>(null)
    const genderRef = useRef<HTMLInputElement>(null)

    const { setUser } = useUserContext()

    const handleLogin = () => {
        const user = {
            name: nameRef.current?.value,
            surname: surnameRef.current?.value,
            password: passwordRef.current?.value,
            email: emailRef.current?.value,
            gender: genderRef.current?.value
        } as IUser

        const validateFields = Object.entries(user).every(([, value]) => !value)
        if (!validateFields) {
            return toast.error('Please fill in the required fields!')
        }

        setUser(user)
    };

    return (
        <Form onSubmit={handleLogin}>
            <InputField
                placeholder="Enter your name"
                type="text"
                inputRef={nameRef}
                name="name"
                required
            />
            <InputField
                placeholder="Enter your surname"
                type="text"
                inputRef={surnameRef}
                name="surname"
                required
            />
            <InputField
                placeholder="Enter your email"
                type="email"
                inputRef={emailRef}
                name="email"
                required
            />
            <InputField
                placeholder="Enter your gender"
                type="text"
                inputRef={genderRef}
                name="gender"
                required
            />
            <InputField
                placeholder="Enter your password"
                type="password"
                inputRef={passwordRef}
                name="password"
                required
            />
            <Button text='Login' />
        </Form >
    );
};

export default LoginForm;
