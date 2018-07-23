module Client

open Elmish
open Elmish.React

open Fable.Helpers.React.Props

module R = Fable.Helpers.React

type Model = string option

type Msg = 
     | Clicked
     | Reset

let init () : Model * Cmd<Msg> =
    None, Cmd.none

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    match msg with
    | Clicked -> Some "You pressed the button!", Cmd.none
    | Reset   -> None, Cmd.none

let getOrElse otherValue value =
    match value with 
    | Some v -> v
    | _      -> otherValue

let view (model : Model) (dispatch : Msg -> unit) =
    R.div [] 
      [ R.button 
          [ OnClick (fun _ -> dispatch Clicked) ] 
          [ R.str "Click Me" ]
        R.button
          [ OnClick (fun _ -> dispatch Reset) ]
          [ R.str "Reset" ]
        R.div [] [ R.str (getOrElse "" model) ] 
      ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
