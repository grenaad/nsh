module LoginComponent

open Feliz.ViewEngine

let loginComponent =
  Html.div
    [ prop.classes [ "hero"; "min-h-screen"; "bg-base-200" ]
      prop.children
        [ Html.div
            [ prop.classes ["hero-content"; "flex-col"; "lg:flex-row-reverse" ]
              prop.children
                [ Html.div
                    [ prop.classes [ "text-center"; "lg:text-left" ]
                      prop.children
                        [ Html.h1 [ prop.classes [ "text-5xl"; "font-bold" ]; prop.text "Login" ]
                          Html.p [ prop.className [ "w-max"; "py-6" ]; prop.text "NSH food parcels login page" ] ] ]
                  Html.div
                    [ prop.classes [ "card"; "flex-shrink-0"; "w-full"; "max-w-sm"; "shadow-2xl"; "bg-base-100" ]
                      prop.children
                        [ Html.div
                            [ prop.className "card-body"
                              prop.children
                                [ Html.div
                                    [ prop.className "form-control"
                                      prop.children
                                        [ Html.label
                                            [ prop.className "label"
                                              prop.children
                                                [ Html.span [ prop.className "label-text"; prop.text "Email" ] ] ]
                                          Html.input
                                            [ prop.type' "text"
                                              prop.placeholder "email"
                                              prop.classes [ "input"; "input-bordered" ] ] ] ]
                                  Html.div
                                    [ prop.className "form-control"
                                      prop.children
                                        [ Html.label
                                            [ prop.className "label"
                                              prop.children
                                                [ Html.span [ prop.className "label-text"; prop.text "Password" ] ] ]
                                          Html.input
                                            [ prop.type' "text"
                                              prop.placeholder "password"
                                              prop.classes [ "input"; "input-bordered" ] ]
                                          Html.label
                                            [ prop.className "label"
                                              prop.children
                                                [ Html.a
                                                    [ prop.classes [ "label-text-alt"; "link"; "link-hover" ]
                                                      prop.href "#"
                                                      prop.text "Forgot password?" ] ] ] ] ]
                                  Html.div
                                    [ prop.classes [ "form-control"; "mt-6" ]
                                      prop.children
                                        [ Html.button [ prop.classes [ "btn"; "btn-primary" ]; prop.text "Login" ] ] ] ] ] ] ] ] ] ] ]
