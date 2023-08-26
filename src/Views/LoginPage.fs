module LoginPage

open Feliz
open Feliz.ViewEngine
open Htmx


let loginPage =
  Html.div
    [ Html.link [ prop.rel "stylesheet"; prop.href "https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" ]
      Html.form
        [ prop.action ""
          prop.method "post"
          prop.children
            [ Html.div
                [ prop.className "wrapper"
                  prop.children
                    [ Html.h1 "Login"
                      Html.div
                        [ Html.input
                            [ prop.className "input-box"
                              prop.style [ style.backgroundColor ("#fffff") ]
                              prop.type' "text"
                              prop.placeholder "Enter Username"
                              prop.required true ]
                          Html.i [ prop.className "bx bx-user" ] ]
                      Html.div
                        [ Html.input
                            [ prop.className "input-box"
                              prop.style [ style.backgroundColor ("#fffff") ]
                              prop.type' "password"
                              prop.placeholder "Enter Password"
                              prop.required true ]
                          Html.i [ prop.className "bx bx-lock-alt" ] ]
                      Html.button [ prop.type' "submit"; prop.text "Submit" ]
                      ] ] ] ]
      // |> Render.htmlView
      ]

