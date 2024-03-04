import React, { useContext } from 'react'
import { AppContext } from '../App'

function Contextor() {
    const contextValue = useContext(AppContext)
    return <p style={ { color: 'white' } }> { contextValue.name }</p>
}



export default Contextor