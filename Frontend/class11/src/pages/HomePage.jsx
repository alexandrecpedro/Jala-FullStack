import React, { useEffect, useState } from 'react'
import Footer from '../organisms/Footer'
import Button from '../atoms/Button'
import { REGISTER_PAGE, WELCOME_PAGE, COUNTER_PAGE } from '../utils/homeRouteConstants'
import HomeRoutes from '../routes/homeRoutes'



const HomePage = () => {

    const [ route, setRoute ] = useState('')

    return (
        <>
            <div style={ { display: 'block' } }>
                <Button label="Register" onClick={ () => setRoute(REGISTER_PAGE) } />
                <Button label="Welcome" onClick={ () => setRoute(WELCOME_PAGE) } />
                <Button label="Counter" onClick={ () => setRoute(COUNTER_PAGE) } />
            </div>
            <HomeRoutes route={ route } />
            <Footer />
        </>

    )

}


export default HomePage