module LoginPage

open Feliz
open Feliz.ViewEngine
open Htmx

let loginPage =
      Html.form [
          prop.action "action_page.php"
          prop.method "post"
          prop.children [
              Html.div [
                  prop.className "container"
                  prop.children [
                      Html.label [
                          prop.for' "uname"
                          prop.children [
                              Html.b "Username"
                          ]
                      ]
                      Html.input [
                          prop.type' "text"
                          prop.placeholder "Enter Username"
                          prop.name "uname"
                          prop.required true
                      ]
                      Html.label [
                          prop.for' "psw"
                          prop.children [
                              Html.b "Password"
                          ]
                      ]
                      Html.input [
                          prop.type' "password"
                          prop.placeholder "Enter Password"
                          prop.name "psw"
                          prop.required true
                      ]
                      Html.button [
                          prop.type' "submit"
                          prop.text "Login"
                      ]
                      Html.label [
                          Html.input [
                              prop.type' "checkbox"
                              prop.isChecked true
                              prop.name "remember"
                          ]
                          Html.text " Remember me"
                      ]
                  ]
              ]
              Html.div [
                  prop.className "container"
                  prop.style [style.backgroundColor("#20273d") ]
                  prop.children [
                      Html.button [
                          prop.className "cancelbtn"
                          prop.type' "button"
                          prop.text "Cancel"
                      ]
                      Html.span [
                          prop.className "psw"
                          prop.children [
                              Html.text "Forgot "
                              Html.a [
                                  prop.href "#"
                                  prop.text "password?"
                              ]
                          ]
                      ]
                  ]
              ]
          ]
      ]
    // |> Render.htmlView

