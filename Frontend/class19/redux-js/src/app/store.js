import { configureStore } from '@reduxjs/toolkit'
import counterReducer from '../features/counter/counterSlice'
import storage from 'redux-persist/lib/storage'
import sessionStorage from 'redux-persist/lib/storage/session'
import { persistReducer, persistStore } from 'redux-persist'
import { thunk } from 'redux-thunk'

// const persistConfig = {
//   key: 'root',
//   storage,
// }

const persistConfig = {
  key: 'root',
  sessionStorage,
}

//state.value
//persistor.state.counter.value
const persistedReducer = persistReducer(persistConfig, counterReducer)

export const store = configureStore({
  reducer: persistedReducer,
  middleware: [ thunk ]
})

export const persistor = persistStore(store)