import React from 'react'

export default function Form({ onSubmit, children }) {

    return (
        <form onSubmit={ onSubmit }>
            { children }
        </form>
    )
}
