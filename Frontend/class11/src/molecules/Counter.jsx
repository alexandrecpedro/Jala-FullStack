import React from 'react'

//Alguem disse que isso funciona
export default function Counter({ count, onIncrement, onDecrement }) {

    return (
        <div>
            <button onClick={ onIncrement }>+</button>
            <span>{ count }</span>
            <button onClick={ onDecrement }>-</button>
        </div>
    )
}