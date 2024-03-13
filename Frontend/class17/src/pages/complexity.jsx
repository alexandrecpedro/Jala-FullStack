import { useParams, Link } from 'react-router-dom'


const Complexity = () => {
    const { level } = useParams()
    fetch(`https://jsonplaceholder.typicode.com/todos/${level}`).then(response => response.json()).then(json => console.log(json))

    return (
        <div>
            <h2>Complexity Level: { level }</h2>
            <p>The level of complexity for this guy is { level }</p>
            <Link to="/">Go back to homepage</Link>
        </div>
    )
}

export default Complexity
