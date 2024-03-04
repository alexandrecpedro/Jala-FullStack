import React from 'react'
import Register from '../template/Register'


const RegisterPage = () => {
    const [ values, setValues ] = React.useState({
        username: '',
        email: ''
    })

    const onChange = (e) => {
        setValues({
            ...values,
            [ e.target.name ]: e.target.value
        })
    }

    const onSubmit = (e) => {
        e.preventDefault()
        console.log("Pretendig that things have been sent somewhere: ", values)
    }

    return <Register onChange={ onChange } onSubmit={ onSubmit } values={ values } />
}

export default RegisterPage