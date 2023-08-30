open IndexPage
open LoginComponent
open MainLayoutComponent

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open System
open System.Net.Mime
open Feliz.ViewEngine
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Authentication.Cookies
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.Hosting
let configureServices (services: IServiceCollection) =

  services
    .AddAuthentication(fun opt -> opt.DefaultAuthenticateScheme <- CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(fun options ->
      options.ExpireTimeSpan <- TimeSpan.FromMinutes 20
      options.SlidingExpiration <- true
      options.AccessDeniedPath <- "/forbidden/")
  |> ignore

let configureApp (app: IApplicationBuilder) =
  if not (app.ApplicationServices.GetService<IWebHostEnvironment>().IsDevelopment()) then
      printfn "Development"
    //   app.UseExceptionHandler("/Error")
    //   app.UseHsts()
  // app.UseHttpsRedirection() |> ignore
  // app.UseStaticFiles() |> ignore

  app.UseAuthentication() |> ignore
// app.UseAuthorization() |> ignore

let configureLogging (builder: ILoggingBuilder) =
  let filter (l: LogLevel) = l.Equals LogLevel.Error
  builder.AddFilter(filter).AddConsole().AddDebug() |> ignore

let builder = WebApplication.CreateBuilder()

// builder.Services.AddSingleton<ILoggerFactory>(LoggerFactory.Create(builder.Configuration.GetSection "Logging")) |> ignore

configureServices builder.Services

let app = builder.Build()

configureApp app

let reactElementTostr (s: ReactElement) : string = Render.htmlView s

let strToHtml s =
  Func<IResult>(fun () -> Results.Content(s, MediaTypeNames.Text.Html))

let reactElementToHtml s = s |> reactElementTostr |> strToHtml


let get (path: string) (response: Func<_>) = app.MapGet(path, response) |> ignore

let post (path: string) (response: Func<_>) = app.MapPost(path, response) |> ignore

get "/index.html" (strToHtml indexPage)

get "/login" (reactElementToHtml loginComponent)

get "/main" (reactElementToHtml (mainLayout loginComponent))

// TODO: need to component
get "/forbidden" (reactElementToHtml (loginComponent))

// post "/post" (strToHtml indexPage)

// app.MapGet("/index2.html", str document) |> ignore
// app.MapGet("/index.html", strToHtml document2) |> ignore
app.Run()