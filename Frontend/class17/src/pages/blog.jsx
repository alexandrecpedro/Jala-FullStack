import { Route, Link, Routes, Outlet } from 'react-router-dom'

export const Irma = () => {
    return (
        <div>
            <h2>Irma</h2>
            <p>Descrição sobre a irmã</p>
        </div>
    )
}

export const Tia = () => {
    return (
        <div>
            <h2>Tia</h2>
            <p>Descrição sobre a tia</p>
        </div>
    )
}

export const Tio = () => {
    return (
        <div>
            <h2>Tio</h2>
            <p>Descrição sobre o tio</p>
        </div>
    )
}

export const Avo = () => {
    return (
        <div>
            <h2>Avo</h2>
            <p>Descrição sobre o avô</p>
        </div>
    )
}

export const Avoa = () => {
    return (
        <div>
            <h2>Avoa</h2>
            <p>Descrição sobre a avó</p>
        </div>
    )
}

export const Irmao = () => {
    return (
        <div>
            <h2>Irmão</h2>
            <p>Descrição sobre o irmão</p>
        </div>
    )
}

export const Mae = () => {
    return (
        <div>
            <h2>Mãe</h2>
            <p>Descrição sobre a mãe</p>
        </div>
    )
}

export const Pai = () => {
    return (
        <div>
            <h2>Pai</h2>
            <p>Descrição sobre o pai</p>
        </div>
    )
}

const Blog = () => {
    return (
        <div style={ { textAlign: 'center' } }>
            <h1>Blog</h1>
            <p>This is the blog page</p>

            <ul>
                <li>
                    <Link to="/blog/irmao">Irmão</Link>
                </li>
                <li>
                    <Link to="/blog/mae">Mãe</Link>
                </li>
                <li>
                    <Link to="/blog/pai">Pai</Link>
                </li>
                <li>
                    <Link to="/blog/avo">Avo</Link>
                </li>
                <li>
                    <Link to="/blog/avoa">Avoa</Link>
                </li>
                <li>
                    <Link to="/blog/tio">Tio</Link>
                </li>
                <li>
                    <Link to="/blog/tia">Tia</Link>
                </li>
                <li>
                    <Link to="/blog/irma">Irma</Link>
                </li>
            </ul>
            <Link to="/">Go back to homepage</Link>
            <Outlet />
        </div>
    )
}

export default Blog