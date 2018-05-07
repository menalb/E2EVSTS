namespace BingSearch

module search =
  open canopy.classic   
     
    let Search (homePage: string, query :string) = 
       url homePage

       waitForElement "#sb_form_q"        

       "#sb_form_q" << query
       click("#sb_form_go")
       click("//ol[@id='b_results']/li[3]/h2/a")      