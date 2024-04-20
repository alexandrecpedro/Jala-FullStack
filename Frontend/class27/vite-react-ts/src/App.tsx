import { ReactNode } from 'react'
import './App.css'
import { UserContextProvider } from './context/UserContext'
import Home from './pages/Home'

const App = (): ReactNode => {
  return (
    <UserContextProvider>
      <Home />
    </UserContextProvider>
  )
}

export default App
