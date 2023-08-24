open IndexPage

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System
open System.Net.Mime
open Feliz.ViewEngine

let builder = WebApplication.CreateBuilder()
let app = builder.Build()

let reactElementTostr (s: ReactElement): string = Render.htmlDocument s
// Render.htmlview
let strToHtml s = Func<IResult>(fun () -> Results.Content(s, MediaTypeNames.Text.Html))
let reactElementToHtml s = s |> reactElementTostr |> strToHtml

let str s = Func<string>(fun () -> s)

let get (path: string) (response: Func<_>)= 
  app.MapGet(path, response) |> ignore

let post (path: string) (response: Func<_>)= 
  app.MapPost(path, response) |> ignore

get "/index.html" (strToHtml indexPage)
// app.MapGet("/index2.html", str document) |> ignore
// app.MapGet("/index.html", strToHtml document2) |> ignore
app.Run()

