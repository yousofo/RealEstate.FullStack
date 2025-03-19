add-migration name 
-Context ApplicationDbContext 
-OutputDir Data/Migrations/SurveyBasket 
-Project SurveyBasket.Data 
-StartupProject SurveyBasket

add-migration name -s api -p infrastructure -c ApplicationDbContext
