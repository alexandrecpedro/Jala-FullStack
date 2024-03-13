import { Link } from 'react-router-dom'
import Spinner from '../components/Spinner'

const Home = () => {
    const loading = true
    if (loading) {
        return (
            <div className="home-container">
                <h1 className="home-title">Home</h1>
                <ul className="home-links">
                    <li><Link to="/about">About</Link></li>
                    <li><Link to="/contact">Contact</Link></li>
                    <li><Link to="/blog">Blog</Link></li>
                    <li><Link to="/example">Example</Link></li>
                    <li><Link to="complexity/:level">Complexity</Link></li>
                </ul>
            </div>
        )
    }
    return (
        <Spinner />
    )
}

export default Home
