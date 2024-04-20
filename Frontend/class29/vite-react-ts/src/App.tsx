import { ReactNode } from 'react'
import './App.css'
// import LoginForm from './containers/LoginForm'
import MemoComponent from './POCs/memo'
import EffectComponent from './POCs/effect'
import CallBackComponent from './POCs/callback'
import DebugValueComponent from './POCs/debugValue'
import RefComponent from './POCs/ref'
import LayoutEffectComponent from './POCs/LayoutEffect'
import ParentComponent from './POCs/ImperativeHandle'
import PseudoApp from './POCs/context'

const App = (): ReactNode => {
  return (
    <>
      { false ? <LoginForm /> : null }
      {false ? <MemoComponent /> : null}
      { false ? <EffectComponent /> : null }
      {false ? <CallBackComponent /> : null}
      {false ? <DebugValueComponent /> : null}
      {false ? <RefComponent /> : null}
      {true ? <LayoutEffectComponent /> : null}
      {false ? <ParentComponent /> : null}
      {false ? <PseudoApp /> : null}
    </>
  )
}

export default App
