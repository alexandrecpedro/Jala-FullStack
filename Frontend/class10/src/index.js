import React from "react"
import ReactDOM from "react-dom"
import App from "./App.js"

//this is the data that will never appear anywhere
var pokemons = [ {
    name: "Charizard",
    type: "fire"
},
{
    name: "Bulbasaur",
    type: "grass"
}, {
    name: "Squirtle",
    type: "water"
}, {
    name: "Pikachu",
    type: "electric"
}
]

ReactDOM.render(
    <App />,
    document.getElementById("root")
)

// const root = document.querySelector("#root")
// ReactDOM.createRoot(root)
