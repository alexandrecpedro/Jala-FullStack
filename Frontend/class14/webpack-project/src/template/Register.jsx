import React from 'react'
import Button from '../atoms/Button'
import Textfield from '../atoms/Textfield'
import Form from '../molecules/Form'


const Register = ({ onChange, onSubmit, values }) => {


    return (
        <div className='container'>
            <h1>Register</h1>
            <Form>
                <Textfield onChange={ onChange } value={ values?.username ?? '' } name="username" placeholder="Username" />
                <Textfield onChange={ onChange } value={ values?.email ?? '' } name="email" placeholder="Email" />
                <Button onClick={ onSubmit } label="Register" />
            </Form>
        </div>
    )
}

export default Register