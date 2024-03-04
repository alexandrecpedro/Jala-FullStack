import React from 'react'

const Textfield = ({ onChange, value, name, placeholder, label }) => {

    if (label) {
        return (
            <div className='text-field' style={ { textAlign: 'left' } } >
                <label for={ name }>{ placeholder }</label>
                <input type="text" onChange={ onChange } value={ value } name={ name } />
            </div>
        )
    }
    return <input className='text-field' type="text" onChange={ onChange } value={ value } name={ name } placeholder={ placeholder } />

}

export default Textfield
