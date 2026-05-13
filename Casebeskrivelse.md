### 1. Introduktion
***Formål***
Systemet har til formål at overvåge hjemmesider for brug af udvalgte ord for herigennem at fange mistænkelig aktivitet.

### 2. Problemstilling
***Hvad skal vi løse?***
Kunden, et anerkendt it-sikkerhedsfirma, ser ofte mistænkelig adfærd på nettet, men oplever at de ressourcer, som skal til for manuelt at overvåge websites er for høj. Der er derfor behov for en teknisk løsning som kan automatisere det meste af det grove arbejde. Den nuværende løsning tilbyder en automatisering af gennemsøgningen, men kræver fortsat manuel indtastning af søgeord og søgning.

***Hvilke mangler har den nuværende løsning?***
Systemet kan på nuværende tidspunkt ikke advare os hvis en side blokere for søgning via URL, og ved forekomster af et af de eftersøgte ord, viser den kun antallet af forekomster. Der ønsker kunden også at modtage en mulighed for at se antallet af søgninger, og få en oversigt over de forskellige URL'er og søgninger.
Systemet skal udvides med error handling og samt monitorering / logging så sikkerhedsfirmaet hurtigt kan få besked hvis fejl opstår. Hertil vil der skulle være opsat nogle alarmeringslister 

***Hvilke behov har kunden?***
Kunden har et behov for et monitorerings system hvor de kan søge efter mistænkelige ord på forskellige hjemmesider. Hermed skal det automatiseres, så de kan lave en oversigt og sikre mod evt. trusler eller opbyggende farer.

### 3. Eksisterende system
***Hvad kan systemet på nuværende tidspunkt?***
På nuværende tidspunkt, kan systemet søge efter et ord, og finde mængden af forekomster på den hjemmeside du har valgt og søge på og logger det i databasen.

***Hvordan fungerer systemet i dag?***
Brugeren indtaster et ord og en URL i Next.js frontend'en. Playwright scraper derefter indholdet af den angivne hjemmeside og sender en POST-request til C# API'en med det scrapede indhold og søgeordet. API'en gennemgår indholdet, tæller forekomster af ordet og returnerer resultatet til frontend'en. Søgningen og resultatet logges efterfølgende i databasen.

***Hvilke data gemmes?***
Ud fra søgningen gemmes der et ID, tidspunkt for søgning, URL'en der er søgt på, ordet der er søgt på og antal af forekomster.

### 4. Kundens nye ønsker
***Hvad skal systemet kunne nu?***
- Overvåge flere hjemmesider samtidigt via en liste af URLs der kan tilføjes i UI'et
- Søge efter flere ord ad gangen via en liste af søgeord i UI'et der kan tilføjes og redigeres
- Køre scanninger automatisk to gange dagligt uden manuel interaktion
- Give advarsel hvis en hjemmeside blokerer for scanning eller andre tekniske fejl opstår

### 5. Brugere & interessenter
***Hvem skal bruge systemet og hvem påvirkes af systemet??***
Dem der bruger systemet er analytikere hos sikkerhedsfirmaet, som opsætter og vedligeholder lister af hjemmesider og søgeord. Derudover findes en administratorrolle som har ansvar for den tekniske drift og konfiguration af systemet. Kunden som organisation er den overordnede stakeholder, da det er dem der har behov for overvågningen og som får værdi af det data som programmet indsamler.

***Hvilke roller eksisterer?***
- Administratorrolle
- Users / Analytikere
- Stakeholders / Organisationen

### 6. Forretningsværdi
***Løsningens vigtighed***
Løsningen frigør ressourcer hos sikkerhedsfirmaet ved at automatisere et arbejde der ellers kræver løbende manuel indsats Det giver firmaet mulighed for at skalere overvågningen uden at skalere personalet, og sikrer at mistænkelig aktivitet opdages hurtigere og mere konsekvent .
Hermed får de også bedre og mere konsistent data, som kan både øge sikkerhed og fremtidssikre firmaet fremadrettet.

***Fordele for kunden & ***hvordan systemet kan hjælpe sikkerhedsfirmaet?******
- Frigørelse af ressourcer
- Sikkerhed igennem logging
- Bedre uptime
- Skalerbart
- Mere konsistent data 


### 7. Afgrænsning
***Hvad skal systemet ikke kunne & evt. begrænsninger?***
- Der er ingen bruger auth/adgangskontrol
- Systemet understøtter ikke realtidsovervågning, kun planlagte jobs
- Der er ingen eksport af data bygget ind i systemet


### 8. Agile / SCRUM perspektiv
***Hvordan kan vi anvende SCRUM på dette projekt?***
Projektet vil anvende Scrum til at tilrettelægge arbejdet og derved sikre, at løsningen hele tiden genbesøges i tilfælde af, at kundens ønsker ændrer sig eller der er misforståelser i opgaveløsningen.

***Hvilke roller findes der i projektet?***
En Project Owner vil have ansvaret for teamets product backlog og derved også for teamets samlede leverance. Teamets udviklere har ansvar for de enkelte sprints og de tilhørende sprint backlogs. Disse leder frem til leveringen af increments i slutningen af hvert sprint. Arbejdet faciliteres af en scrum master, som planlægger møder og står for kontakten til interessenter eller andre teams, som skal indgå i opgaveløsningen.

***Hvilke sprints har vi på projektet?***
Udviklingsarbejdet kan ud fra backloggen opdeles i de enkelte sprints, således at teamets udviklere hver har ansvar for en del af incrementet.
