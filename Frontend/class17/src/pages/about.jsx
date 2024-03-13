import { Link } from 'react-router-dom'

const About = () => {
    return (
        <div style={ { textAlign: 'center' } }>
            <h1 style={ { color: 'blue' } }>About</h1>
            <div style={ { margin: '20px' } }>
                <img src="kangaroo.jpg" alt="Kangaroo" style={ { width: '300px' } } />
            </div>
            <div style={ { margin: '20px' } }>
                <h2 style={ { color: 'green' } }>Kangaroos</h2>
                <p style={ { fontSize: '18px' } }>
                    Kangaroos are marsupials that are native to Australia. They are known for their
                    powerful hind legs, large feet, and long tail. Kangaroos are herbivores and
                    primarily eat grass and other vegetation.
                </p>
            </div>
            <Link to="/">Go back to homepage</Link>
        </div>
    )
}

export default About