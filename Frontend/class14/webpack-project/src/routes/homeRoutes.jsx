import React from 'react'

import RegisterPage from '../pages/RegisterPage'
import CounterPage from '../pages/CounterPage'
import WelcomePage from '../pages/WelcomePage'

import { REGISTER_PAGE, COUNTER_PAGE, WELCOME_PAGE } from '../utils/homeRouteConstants'

const homeRoutes = ({ route }) => {

    switch (route) {
        case REGISTER_PAGE:
            return <RegisterPage />
        case COUNTER_PAGE:
            return <CounterPage />
        case WELCOME_PAGE:
            return <WelcomePage />
        default:
            return <RegisterPage />
    }
}

export default homeRoutes