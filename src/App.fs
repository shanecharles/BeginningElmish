module Client

open Elmish
open Elmish.React

open Fable.Helpers.React

type Model = string

type Msg = Nothing

let init () : Model * Cmd<Msg> =
    "Initialized", Cmd.none

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    model, Cmd.none

let view (model : Model) (dispatch : Msg -> unit) =
    div [] [ str model ]

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
