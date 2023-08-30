module MainLayoutComponent

open Feliz.ViewEngine

let mainLayout (main_section: ReactElement) =
    Html.div [
        prop.className "bg-gray-100"
        prop.children [
            Html.div [
                prop.classes [ "flex"; "h-screen" ]
                prop.children [
                    Html.div [
                        prop.classes [ "w-1/4"; "bg-white"; "p-4"; "shadow-md" ]
                        prop.children [
                            Html.h2 [
                                prop.classes [ "text-xl"; "font-semibold"; "mb-4" ]
                                prop.text "Sidebar"
                            ]
                            Html.ul [
                                prop.className "space-y-2"
                                prop.children [
                                    Html.li [
                                        Html.a [
                                            prop.className "hover:text-blue-500"
                                            prop.href "#"
                                            prop.text "Home"
                                        ]
                                    ]
                                    Html.li [
                                        Html.a [
                                            prop.className "hover:text-blue-500"
                                            prop.href "#"
                                            prop.text "About"
                                        ]
                                    ]
                                    Html.li [
                                        Html.a [
                                            prop.className "hover:text-blue-500"
                                            prop.href "#"
                                            prop.text "Services"
                                        ]
                                    ]
                                    Html.li [
                                        Html.a [
                                            prop.className "hover:text-blue-500"
                                            prop.href "#"
                                            prop.text "Contact"
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                    Html.div [
                        prop.classes [ "w-3/4"; "p-8" ]
                        prop.children [
                            Html.h1 [
                                prop.classes [ "text-2xl"; "font-semibold"; "mb-4" ]
                                prop.text "Main Content"
                            ]
                            // Html.p "This is the main content area. Add your content here."
                            main_section
                        ]
                    ]
                ]
            ]
        ]
    ]
