import React, { useEffect } from 'react'

const WelcomePage = () => {

    const [ dog, setDog ] = React.useState('')
    let doggy = 'Thiago falo que é um cachorro aleatório'

    useEffect(() => {
        fetch('https://dog.ceo/api/breeds/image/random')
            .then(res => res.json())
            .then(data =>
                setDog(data.message)
            )
    }, [])


    //does not render in time
    async function init() {
        const response = await fetch('https://dog.ceo/api/breeds/image/random')
        const data = await response.json()
        doggy = data.message
        console.log(doggy)
        setDog(doggy)
    }

    useEffect(() => { init() }, [])

    return (
        <div>
            <h1>Welcome to the Welcome Page</h1>
            <img src={ dog } alt="Random Dog" />
        </div>
    )
}

export default WelcomePage