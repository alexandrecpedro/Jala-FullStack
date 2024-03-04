import React from 'react'


const Button = ({ onClick, label }) => {

    return (
        <button className='btn' onClick={ onClick }>{ label }</button>
    )
}


export default Button