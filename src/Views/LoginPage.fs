module LoginPage

open Feliz.ViewEngine
open Htmx


let loginPage =
  Html.div
    [ 
      Html.div [
          prop.className "field"
          prop.children [
              Html.label [
                  prop.className "label"
                  prop.text "Name"
              ]
              Html.div [
                  prop.className "control"
                  prop.children [
                      Html.input [
                          prop.className "input"
                          prop.type' "text"
                          prop.placeholder "Enter Username"
                      ]
                  ]
              ]
              Html.div [
                  prop.className "control"
                  prop.children [
                      Html.input [
                          prop.className "input"
                          prop.type' "password"
                          prop.placeholder "Enter Password"
                      ]
                  ]
              ]
              Html.button []
          ]
      ]
      // |> Render.htmlView
      ]

