# helorepo

En how-to när man skapar en .NET konsollapp via VScode och hur man containeriserar den. 

1. Skapa ett nytt projekt.
   - Från wizard -> open folder... -> skapa ny mapp och välj
   - öppna terminalen och skriv in "dotnet new console --framework net7.0" för att skapa konsollappen med ett 7.0 framework.
   
       ![image](https://github.com/helojulia/helorepo/assets/130759487/784041fc-33e7-44bb-8395-404f08e751ed)

        Vårt extension rekommenderar oss att lägga till en build and debug, vilket vi gör.
       ![image](https://github.com/helojulia/helorepo/assets/130759487/6cca347c-bb12-4561-bc98-07676439aa38)

2. "insert code here"
    - När du skrivit klart din kod och kört programmet ser din filstruktur ut något sådant:
      ![image](https://github.com/helojulia/helorepo/assets/130759487/3b06d57d-4a52-44d7-8255-ebc4eb126c15)


      Jag skapar en mapp och döper den till "App", där jag drar in program.cs

3. Containerisera!
   - När allt är up-and-running ska vi nu skapa en container och en image i Docker. Innan vi gör det så behöver vi publisha vår
     app. Skriv in i terminalen: "dotnet publish -c Release"

