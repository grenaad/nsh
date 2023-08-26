module IndexPage

open LoginPage
open Feliz.ViewEngine
open Htmx

let fileToBase64 (relative_path: string) =
  let plainTextBytes = System.IO.File.ReadAllBytes(System.IO.Directory.GetCurrentDirectory()+relative_path)
  System.Convert.ToBase64String(plainTextBytes)

let indexPage: string =
  let icon_base_64_16 = fileToBase64 "/img/favicon-16x16.png"
  let icon_base_64_32 = fileToBase64 "/img/favicon-32x32.png"
//   let test = fileToBase64 "img/"
  Html.html
    [ Html.head
        [ Html.title "NSH"
          Html.meta [ prop.name "Content-Type"; prop.content "text/html; charset=utf-8" ]
          Html.meta [ prop.name "viewport"; prop.content "width=device-width, initial-scale=1" ]
          // Tailwind components
          Html.link [ prop.rel "stylesheet"; prop.href "https://cdn.jsdelivr.net/npm/daisyui@3.6.2/dist/full.css" ]
          Html.script[prop.src "https://cdn.tailwindcss.com"]
          // Htmx
          Html.script[prop.src "https://unpkg.com/htmx.org@1.9.4"]
          Html.link
            [ prop.rel "shortcut icon"; prop.type'.image; prop.href ("data:image/x-icon;base64," + icon_base_64_32); prop.sizes "32x32" ]
          Html.link
            [ prop.rel "shortcut icon"; prop.type'.image; prop.href ("data:image/x-icon;base64," + icon_base_64_16); prop.sizes "16x16" ] ]

      Html.body
        [ Html.div [ prop.id "main-app" ]
          // TODO: will need to add js later when required
          // Html.script[ prop.type' "module"; prop.src "./Main.fs.js" ]
          // <div hx-get="/example" hx-swap="innerHTML swap:1s">Get Some HTML & Append It</div>
          // Html.button [prop.text " some button"; hx.post "/clicked"; hx.swap.afterbegin'(hx.swap.ScrollBottom, hx.swap.FocusScroll true)]

          Html.div [ prop.text "Click here to Login"; hx.swap.innerHTML; hx.trigger "mouseenter"; hx.get "/login" ]
           ] ]
  |> Render.htmlDocument

