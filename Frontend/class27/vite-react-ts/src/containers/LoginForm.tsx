import React, { useState } from 'react';
import Form from '../components/Form';
import Button from '../components/Button';
import TextField from '../components/TextField';

/* 
We have here a simple Login form component as we did before on our javascript app

*/
const LoginForm: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = () => {
        console.log(`Logging in with username: ${username} and password: ${password}`);
    };

    return (
        <Form>
            <TextField 
                value={username} 
                onChange={setUsername} 
                title="Username" 
                placeholder="Enter your username" 
            />
            <TextField 
                value={password} 
                onChange={setPassword} 
                title="Password" 
                placeholder="Enter your password" 
            />
            <Button onClick={handleLogin} text="Login" />
        </Form>
    );
};

export default LoginForm;