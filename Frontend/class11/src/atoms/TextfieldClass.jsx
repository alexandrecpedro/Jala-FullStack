import React, { Component } from 'react'

class Textfield extends Component {
    constructor (props) {
        super(props)
        this.state = {
            name: props.name,
            placeholder: props.placeholder,
            label: props.label
        }
    }

    render() {
        const { onChange, value } = this.props
        const { name, placeholder, label } = this.state

        if (label) {
            return (
                <div className='text-field' style={ { textAlign: 'left' } }>
                    <label htmlFor={ name }>{ placeholder }</label>
                    <input type="text" onChange={ onChange } value={ value } name={ name } />
                </div>
            )
        }
        return <input className='text-field' type="text" onChange={ onChange } value={ value } name={ name } placeholder={ placeholder } />
    }
}



export default Textfield 