import { useEffect } from 'react'
import { createBrowserRouter, RouterProvider, BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './pages/home'
import About from './pages/about'
import Blog, { Irma, Tia, Tio, Pai, Mae, Irmao, Avo, Avoa } from './pages/blog'
import Example from './pages/example'
import Contact from './pages/contact'
import NotFound from './pages/notFound'

const router = createBrowserRouter([
  { path: '/*', element: <NotFound /> },
  { path: '/', element: <Home /> },
  { path: '/about', element: <About /> },
  { path: '/example', element: <Example /> },
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
])

function App() {

  useEffect(() => {
    console.log('App.js')
  }, [])

  return <RouterProvider router={ router } />
  // (<BrowserRouter>
  //   <Routes>
  //     <Route path="/" element={ <Home /> } />
  //     <Route path="/about" element={ <About /> } />
  //     <Route path="/example" element={ <Example /> } />
  //     <Route path="/blog" element={ <Blog /> }>
  //       <Route path="irma" element={ <Irma /> } />
  //       <Route path="irmao" element={ <Irmao /> } />
  //       <Route path="tia" element={ <Tia /> } />
  //     </Route>
  //   </Routes>
  // </BrowserRouter>)
}

export default App
