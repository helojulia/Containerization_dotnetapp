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
   - När allt är up-and-running ska vi nu skapa en container och en image i Docker. Innan vi gör det så          behöver vi publisha vår
     app. Skriv in i terminalen: "dotnet publish -c Release"

   - Skapa en ny fil i din mappstruktur och döp den till Dockerfile. Dockerfilen används av "docker build"
     kommandot för att bygga din container-image. Kopiera in följande, men glöm inte att ändra                   "DotNet.Docker.dll" till din egen:
     
   ```
   FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
   WORKDIR /App

   COPY . ./
   RUN dotnet restore
   RUN dotnet publish -c Release -o out

   FROM mcr.microsoft.com/dotnet/aspnet:7.0
   WORKDIR /App
   COPY --from=build-env /App/out .
   ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
   ```

   - Från terminalen, kör:
   ```
   docker build -t counter-image -f Dockerfile .
   ```
   -t är där du ger din image ett namn. -f är vilken fil vi letar efter.
   Detta kommando bygger din image och skapar ett lokalt repository som pekar mot din specifika image.
   
   - För att se så att din image är installerad kan du köra:
   ```
   docker images
   ```
   Varje kommando i din dockerfil har genererat ett lager och har skapat ett IMAGE-ID. Detta ID't kommer
   vi att använda för att skapa en container baserat på vår image.
   ![image](https://github.com/helojulia/helorepo/assets/130759487/300fc8b9-a25c-4b06-8ee1-8c417933bd61)

4. Skapa din container
   - Nu har vi en image som innehåller vår app. Kör:
        ```
        docker create -it --name guidecontainer guide-image
        ```
       Din output du får är ett ID på din container. -it står för interactive vilket förhindrar att             containern stoppas direkt efter den skapats.

   - För att se alla containers, kör:
     ```
     docker ps -a
     ```
   - När din container är igång, kan du connecta den för att se en output. Använd ```docker start```          och ```docker attach```. Docker attach körs lokalt hos dig i din terminal.
     

     

