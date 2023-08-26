module IndexPage

open LoginPage
open Feliz.ViewEngine
open Htmx

let indexPage: string =
  Html.html
    [ Html.head
        [ Html.title "NSH"
          Html.meta [ prop.name "Content-Type"; prop.content "text/html; charset=utf-8" ]
          Html.meta [ prop.name "viewport"; prop.content "width=device-width, initial-scale=1" ]
          Html.link
            [ prop.rel "shortcut icon"; prop.type'.image; prop.href "./img/favicon-32x32.png"; prop.sizes "32x32" ]
          Html.link
            [ prop.rel "shortcut icon"; prop.type'.image; prop.href "./img/favicon-16x16.png"; prop.sizes "16x16" ] ]
      Html.body
        [ Html.div [ prop.id "main-app" ]
          // TODO: will need to add js later when required
          // Html.script[ prop.type' "module"; prop.src "./Main.fs.js" ]
          Html.script[prop.src "https://unpkg.com/htmx.org@1.9.4"]
          // <div hx-get="/example" hx-swap="innerHTML swap:1s">Get Some HTML & Append It</div>
          // Html.button [prop.text " some button"; hx.post "/clicked"; hx.swap.afterbegin'(hx.swap.ScrollBottom, hx.swap.FocusScroll true)]
          Html.div [ hx.swap.innerHTML; hx.get "/login" ]
          loginPage ] ]
  |> Render.htmlDocument

