import React from 'react'
import Contextor from '../context/AppContext'

const Footer = () => {
    return (
        <footer className='footer'>
            <p style={ { fontSize: 20 } }>
                <Contextor />
            </p>
        </footer>
    )
}

export default Footer