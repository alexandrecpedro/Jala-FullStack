import { Link } from 'react-router-dom'


const Home = () => {
    return (
        <div className="home-container">
            <h1 className="home-title">Home</h1>
            <ul className="home-links">
                <li><Link to="/about">About</Link></li>
                <li><Link to="/contact">Contact</Link></li>
                <li><Link to="/blog">Blog</Link></li>
                <li><Link to="/example">Example</Link></li>
            </ul>
        </div>
    )
}

export default Home
