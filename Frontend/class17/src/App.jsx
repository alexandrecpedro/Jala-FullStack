import { useEffect } from 'react'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import Home from './pages/home'
import About from './pages/about'
import Blog, { Irma, Tia, Tio, Pai, Mae, Irmao, Avo, Avoa } from './pages/blog'
import Example from './pages/example'
import Contact from './pages/contact'
import NotFound from './pages/notFound'
import Complexity from './pages/complexity'

const router = createBrowserRouter([
  { path: '/', element: <Home /> },
  { path: '/complexity/:level/:id?', element: <Complexity /> },
  { path: '/about', element: <About /> },
  { path: '/example', element: <Example />, },
  {
    path: '/blog', element: <Blog />,
    children: [
      { path: ":irma", element: <Irma /> },
      { path: "irmao", element: <Irmao /> },
      { path: "tia", element: <Tia /> },
      { path: "tio", element: <Tio /> },
      { path: "pai", element: <Pai /> },
      { path: "mae", element: <Mae /> },
      { path: "avo", element: <Avo /> },
      { path: "avoa", element: <Avoa /> },
    ]
  },
  { path: '/contact', element: <Contact /> },
  { path: '/*', element: <NotFound /> },
])

function App() {

  useEffect(() => {
    console.log('App.js')
  }, [])

  return <RouterProvider router={ router } />
}

export default App
