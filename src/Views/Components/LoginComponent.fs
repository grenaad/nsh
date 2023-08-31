module LoginComponent

open Feliz.ViewEngine
open Htmx

// open type Html
// open type prop

let login =
  Html.div
    [ prop.text "Hover here to Login"
      hx.swap.outerHTML
      hx.trigger "mouseenter"
      hx.get "/login"
      prop.classes [ "h-screen"; "flex"; "items-center"; "justify-center" ] ]

let loginComponent =
  Html.div
    [ prop.classes [ "flex"; "h-screen"; "justify-center"; "items-center" ]
      prop.children
        [ Html.div
            [ prop.classes [ "bg-white"; "rounded-lg"; "p-8"; "shadow-md"; "w-96" ]
              prop.children
                [ Html.h2 [ prop.classes [ "text-2xl"; "font-semibold"; "mb-4" ]; prop.text "Login" ]
                  Html.form
                    [ Html.div
                        [ prop.className "mb-4"
                          prop.children
                            [ Html.label
                                [ prop.classes [ "block"; "font-medium"; "mb-1"; "text-black" ]
                                  prop.for' "username"
                                  prop.text "Username" ]
                              Html.input
                                [ prop.type' "text"
                                  prop.id "username"
                                  prop.classes [ "w-full"; "p-2"; "rounded"; "border"; "bg-gray-100"; "text-black" ]
                                  prop.required true ] ] ]
                      Html.div
                        [ prop.className "mb-4"
                          prop.children
                            [ Html.label
                                [ prop.classes [ "block"; "font-medium"; "mb-1"; "text-black" ]
                                  prop.for' "password"
                                  prop.text "Password" ]
                              Html.input
                                [ prop.type' "password"
                                  prop.id "password"
                                  prop.classes [ "w-full"; "p-2"; "rounded"; "border"; "bg-gray-100"; "text-black" ]
                                  prop.required true ] ] ]
                      Html.button
                        [ prop.classes [ "w-full"; "btn"; "btn-primary"; "text-black" ]
                          prop.type' "submit"
                          prop.text "Login" ] ] ] ] ] ]
