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
        ]
    ]

let view = 
    Html.html [
        Html.head [ Html.title "Feliz" ]
        Html.body [
            Html.header [ prop.text "Feliz" ]
        ]
    ]

let document = Render.htmlDocument view
let document2 = Render.htmlDocument mainPage

// printfn "%s" document
// printfn "%s" document2

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System
open  System.Net.Mime

let builder = WebApplication.CreateBuilder()
let app = builder.Build()
// let r = ContentResult {
//         Content = document,
//         ContentType = "text/html"
//     }
let result = Results.Content(document, MediaTypeNames.Text.Html)

app.MapGet("/", Func<_>(fun () ->  result)) |> ignore
app.MapGet("/index2.html", Func<string>(fun () -> document)) |> ignore
app.MapGet("/index.html", Func<_>(fun () -> result)) |> ignore
app.Run()

