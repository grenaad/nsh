module UIComponents

open Feliz.ViewEngine

let mainPage =
    Html.html [
        Html.head [
            Html.title "Feliz App"
            Html.meta [ prop.name "Content-Type"; prop.content "text/html; charset=utf-8" ]
            Html.meta [ prop.name "viewport"; prop.content "width=device-width, initial-scale=1" ]
            Html.link [ prop.rel "shortcut icon"; prop.type'.image; prop.href "./img/favicon-32x32.png"; prop.sizes "32x32" ]
            Html.link [ prop.rel "shortcut icon"; prop.type'.image; prop.href "./img/favicon-16x16.png"; prop.sizes "16x16" ]
        ]
        Html.body [
            Html.div [ prop.id "feliz-app" ]
            // TODO: will need to add js later when required
            // Html.script[ prop.type' "module"; prop.src "./Main.fs.js" ]
            Html.header [ prop.text "Feliz" ]
        ]
    ]

// let view = 
//     Html.html [
//         Html.head [ Html.title "Feliz" ]
//         Html.body [
//             Html.header [ prop.text "Feliz" ]
//         ]
//     ]


let indexPage :string = Render.htmlDocument mainPage


