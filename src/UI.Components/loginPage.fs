module LoginPage

open Feliz
open Feliz.ViewEngine
open Htmx

let loginPage =
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
                                        prop.required true ] ]
                            Html.div
                                [ Html.input
                                      [ prop.className "input-box"
                                        prop.style [ style.backgroundColor ("#fffff") ]
                                        prop.type' "password"
                                        prop.placeholder "Enter Password"
                                        prop.required true ] ] ] ] ] ]
// |> Render.htmlView
