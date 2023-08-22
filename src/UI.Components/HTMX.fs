module Htmx

open Feliz.ViewEngine

let post (value: string) = Interop.mkAttr "hx-post" value
let put (value: string) = Interop.mkAttr "hx-put" value
let get (value: string) = Interop.mkAttr "hx-get" value
let delete (value: string) = Interop.mkAttr "hx-delete" value
let patch (value: string) = Interop.mkAttr "hx-patch" value

let trigger (value: string) = Interop.mkAttr "hx-trigger" value
let target (value: string) = Interop.mkAttr "hx-target" value


module swap =  
  let swap (value: string) = Interop.mkAttr "hx-swap" value
  let innerHTML = swap "innerHTML" 
  let outerHTML = swap "outerHTML" 
  let beforebegin = swap "beforebegin"
  let afterbegin = swap "afterbegin"
  let beforeend = swap "beforeend"
  let afterend = swap "afterend"
  let delete = swap "delete"
  let none = swap "none" 

