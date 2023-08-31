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
open System.Security.Claims
open Microsoft.AspNetCore.Authorization

[<Literal>] 
let accessDeniedPath = "/forbidden"

let configureServices (services: IServiceCollection) =
  services
    .AddAuthentication(fun opt -> 
    opt.DefaultAuthenticateScheme <- CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(fun options ->
      options.ExpireTimeSpan <- TimeSpan.FromMinutes 20
      options.SlidingExpiration <- true
      options.LoginPath <- "/index.html"
      options.AccessDeniedPath <- accessDeniedPath)
  |> ignore
  services.AddAuthorization(fun config ->
            let adminPolicy = (new AuthorizationPolicyBuilder()).RequireClaim(ClaimTypes.Role,["Admin"]).Build()
            let userPolicy = (new AuthorizationPolicyBuilder()).RequireClaim(ClaimTypes.Role,["User"]).Build()
            config.AddPolicy("Admin",adminPolicy)
            config.AddPolicy("User",userPolicy)
            ) |> ignore

  services.AddAuthorization(fun (options ) ->
        options.AddPolicy( "AdminPolicy", fun policy -> 
            policy.RequireClaim(ClaimTypes.Role, "Admin") |> ignore 
            // you can require other claims as well here
        ) |> ignore
    ) |> ignore

let configureApp (app: IApplicationBuilder) =
  let isDev = app.ApplicationServices.GetService<IWebHostEnvironment>().IsDevelopment()
  if not (isDev) then
      printfn "Production"
      app.UseExceptionHandler("/Error") |> ignore
      app.UseHsts() |> ignore
  // app.UseHttpsRedirection() |> ignore
  // app.UseStaticFiles() |> ignore

  app.UseAuthentication() |> ignore
  app.UseAuthorization() |> ignore

let configureLogging (builder: ILoggingBuilder) =
  let filter (l: LogLevel) = l.Equals LogLevel.Error
  builder.AddFilter(filter).AddConsole().AddDebug() |> ignore

let builder = WebApplication.CreateBuilder()

configureServices builder.Services

let app = builder.Build()

configureApp app

let reactElementTostr (s: ReactElement) : string = Render.htmlView s

let strToHtml s =
  Func<IResult>(fun () -> Results.Content(s, MediaTypeNames.Text.Html))

let reactElementToHtml s = s |> reactElementTostr |> strToHtml

let get (path: string) (response: Func<_>) (autPolicyName: string option ) = 
    match autPolicyName with
    | Some name -> app.MapGet(path, response).RequireAuthorization(name) |> ignore
    | None -> app.MapGet(path, response) |> ignore

let post (path: string) (response: Func<_>) (autPolicyName: string option )= 
    match autPolicyName with
    | Some name -> app.MapPost(path, response).RequireAuthorization(name) |> ignore
    | None -> app.MapGet(path, response) |> ignore

(*
let authorizeByPolicyName (app: IApplicationBuilder) (policyName : string) (authFailedHandler : HttpHandler) : HttpHandler =
    fun (next : HttpFunc) (ctx : HttpContext) ->
        task {
            let authService =  app.ApplicationServices.GetService<IAuthorizationService>()
            let! result = authService.AuthorizeAsync (ctx.User, policyName)
            return! (if result.Succeeded then next else authFailedHandler earlyReturn) ctx
        }

let requireAdminPolicy : HttpHandler = 
    authorizeByPolicyName "AdminPolicy" (RequestErrors.FORBIDDEN  "Permission denied. Failed Admin Policy")
*)

get "/index.html" (reactElementToHtml (indexPage login)) None

get "/login" (reactElementToHtml (indexPage loginComponent)) None

get "/main" (reactElementToHtml (mainLayout loginComponent)) (Some "Admin")

// TODO: need component
get accessDeniedPath (reactElementToHtml (loginComponent)) None

// post "/post" (strToHtml indexPage)

// app.MapGet("/index2.html", str document) |> ignore
// app.MapGet("/index.html", strToHtml document2) |> ignore
app.Run()
