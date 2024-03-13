import sunImage from '../assets/sun.png'

import PropTypes from 'prop-types'

const Spinner = ({ size = "40" }) => {
    const imageStyle = {
        width: size,
        height: size,
        animation: 'spin 2s linear infinite',
    }

    return (
        <div>
            <img src={ sunImage } alt="sun" style={ imageStyle } />
        </div>
    )
}

Spinner.propTypes = {
    size: PropTypes.string,
}

export default Spinner
