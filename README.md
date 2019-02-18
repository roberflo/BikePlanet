# GFShop API
Shop for my girlfriend about the usual boutique and accesories store

documentarion on swagger

#  Client App 
https://github.com/roberflo/GFShopFront

#  Real Deployed API 
https://talladita.azurewebsites.net


#  How to Test
You can download the postman collection 

-Try on the Real Deployed API 


-Build local with migrations of the proyect changing the connection string on Startup.cs


  `services.AddDbContext<GFStoreContext>(
                b => b.UseSqlServer("ConecctionString"));`
                
                
  -Then on the proyect execute "dotnet ef database update"
  


#  How to Test on february 2019
Just download, there is a connection string with my azure database connection <)

#  Trello Dashboard
https://trello.com/b/OMwJTxyU/store-api-challenge

#  Happy to seed your improvements
  
  HAPPY CODING!



