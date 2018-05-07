module main
open canopy.runner.classic
open canopy.configuration
open canopy.classic
open BingSearch
open System

chromeDir <- Environment.GetEnvironmentVariable("ChromeWebDriver")

//start an instance of chrome
start chrome

"Go to bing page"  &&& fun _ -> 
  search.Search("https://www.bing.com", "VSTS")
  on "https://www.visualstudio.com/"    
  
run()

//printfn "press [enter] to exit"
//System.Console.ReadLine() |> ignore


quit()