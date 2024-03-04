import React from 'react'
import Register from '../template/Register'
import Footer from '../organisms/Footer'
import Button from '../atoms/Button'

const home = true

const Home = () => {

    const [ values, setValues ] = React.useState({
        username: '',
        password: ''
    })

    const onChange = (e) => {
        setValues({
            ...values,
            [ e.target.name ]: e.target.value
        })
    }

    const onSubmit = (e) => {
        e.preventDefault()
        console.log(values)
    }

    return (
        <>
            { home ?
                (<>
                    < Register onChange={ onChange } onSubmit={ onSubmit } values={ values } />
                    <Footer />
                </>) : <Button label="Counter hooks" /> }
        </>

    )

}


export default Home