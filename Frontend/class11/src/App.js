import React, { createContext } from "react"
import { hot } from "react-hot-loader"
import HomePage from "./pages/HomePage"
import Header from "./organisms/Header"
import './styles/global.css'

export const AppContext = createContext(null)

const App = () => (
    <>

        <AppContext.Provider value={ { name: 'John Weekend' } }>
            <Header />
            <div style={ { marginTop: 90 } } className="container">
                <HomePage />
            </div>
        </AppContext.Provider>
    </>
)

export default hot(module)(App)
