# 1. Indledning

### 1.1. _Formål_

Denne kravspecifikation beskriver kravene til videreudviklingen af systemet **ScrummyWordCount**.

Systemet er udviklet til et anerkendt it-sikkerhedsfirma, som ønsker at automatisere overvågning af hjemmesider for forekomster af mistænkelige søgeord. 

V1 af systemet er allerede leveret. Denne kravspecifikation omhandlder de nye krav som kunden ønsker implementeret til en fremtidig V2.

- **Produkt:** ScrummyWordCount v2
- **Kunde:** It-sikkerhedsfirma (anonymiseret)
- **Leverandør / producent:** ScrummyWordCount-teamet

---

### 1.2 Referencer

- Casebeskrivelse: `Casebeskrivelse.md`
- Eksisterende kodebase: `Source/ScrummyWordCountApi` og `scrummy-word-frontend`

---

### 1.3 Læsevejledning

Kravspecifikationen er organiseret således:

1. **Indledning** - formål, referencer og læsevejledning
2. **Generel beskrivelse** - systemoverblik, funktioner, begrænsninger og brugerprofiler
3. **Specifikke krav** - funktionelle krav med detaljeret beskrivelse

---

# 2. Generel beskrivelse

### 2.1 Systembeskrivelse

ScrummyWordCount er et webbaseret overvågningssystem bestående af en Next.js frontend, en C# .NET backend API og en PostgreSQL database, afviklet i Docker.

---

### 2.2 System funktion

Brugeren indtaster en liste af URL'er og søgeord i UI'et, som basis for programmets funktionalitet.

Systemet scanner automatisk alle URL'er for alle søgeord to gange dagligt via automatiske jobs i C# API'en, som scraper de ønskede sider og gemmer resultaterne i databasen.

Hvis en side ikke kan scannes er der tilføjet retry-funktionalitet. Lykkes det ikke efter det definerede antal forsøg, logges fejlen og en advarsel sendes på mail. Siden skannes igen næste gang, jobbet kører.

---

2.3. _System begrænsninger_

Da programmet er opsat med automatisering (på to tidspunkter hver dag), vil realtidsovervågning ikke være muligt under programmets nuværende udformning.

Data kan heller ikke eksporteres via UI.

Samtidig vil der ikke være nogen brugerautorisation/adgangskontrol.

2.4. _Systemets fremtid_
Programmets forventes at være i produktion indtil sikkerhedsfirmaet ikke længere har behov for det.

Fremtidsmuligheder vil være features som dataeksport, og evt. realtidsovervågning.

---

2.5 _Brugerprofil_

Der regnes med følgende brugerprofiler i programmets levetid.

**Analytiker**

- Opsætter og vedligeholder lister af hjemmesider og søgeord
- Læser og arbejder med søgeresultaterne
- Ingen teknisk baggrund krævet - betjener systemet via webbrowser
- Adgang via webapplikation i browser

**Administrator**

- Ansvarlig for teknisk drift, konfiguration og fejlfinding
- Har teknisk forståelse af systemets arkitektur
- Adgang til server, database og logfiler direkte

**Stakeholder**

- Beslutter om systemet opfylder forretningsbehov
- Har ikke nødvendigvis teknisk baggrund
- Primær kontaktperson for kravafklaring og videreudvikling

2.6 _Krav til udviklingsforløbet_

- **Metode:** Scrum
- **Versionsstyring:** Git / GitHub
- **Programmeringssprog:** TypeScript (frontend), C# (backend)
- **Dokumentation:** Casebeskrivelse, kravspecifikation, testrapport samt flow chart og use-case diagram.
- **Review:** Pull requests gennemgås af mindst ét andet teammedlem inden merge
- **Ændringer i kravspec:** Godkendes af PO og Project Lead i fællesskab.

---

2.7 _Omfang af kundeleverance_

Det forventes at nærværende systemopdateringer til ScrummyWordCount prodsættes som en enkelt samlet leverance. 
Kunden vil således kun opleve en kort nedetid på den eksisterende løsning, før de nye funktioner kan tages i brug.

Efter behov kan ScrummyWordCount-teamet tilbyde instruktion og brugervejledning til de nye features.

ScrummyWordCount teamet fastholder ejerskab over kodebasen.

---

2.8. _Forudsætninger_
Kunden skal stille en server til rådighed, og give de relevante i ScrummyWordCount-teamet adgang til at tilgå serveren.

### 3.  **Specifikke Krav**

3.1. _Definitioner_

Kunden ønsker mulighed for indtastning af to lister: en til søgeord og en til websites.
Dertil ønskes mulighed for dataudtræk, hvor det skal være muligt at se:
- Det anvendte søgeord
- Den gennemsøgte hjemmeside
- Dato og tidspunkt for søgningen
- Antallet af gange søgeordet forekom

3.2. _Funktionelle krav_

Use case forefindes i dokumentationspakken som vedlægges leverancen.

Der skal kunne søges bredt, både på flere ord og over flere hjemmesider.

En søgning skal kunne gentages ved afvisning et nærmere defineret antal gange. Hvis søgningen kontinuerligt fejler, skal programmet gå videre til næste ord eller hjemmeside, afhængig af, hvor i programmets afvikling afvisningen opstår. 
   
Der skal logges besked om afvisningen på mail og i logsystem.

### 4. **Eksterne grænseflade krav**

4.1. _Bruger grænseflade_

Systemet vil bestå af en webbaseret brugergrænseflade, som kan betjenes via mus eller keyboard.

Der er ingen særlige krav til betjening defineret.

Administratorer skal kunne oprette nye søgninger samt definere tidspunkter for den automatiske overvågning.

Analytikere vil skulle have adgang til til søgegænsefladen samt data-view af de allerede foretagne søgningen.

4.3. _Software grænseflade_
- Applikationen vil køre som to sammenkædede Docker-containere. 
Den ene vil indeholde databasen, mens den anden hoster API og frontend.

### 5. **Kvalitetsfaktorer**
- Argument for hver kvalitetsfaktor.
- Hvad skal gøres for at opnå en bestemt kvalitetsfaktor.
- Visse krav modarbejder hinanden.
- Vigtighed angives som tal fra 1 til 5. - Hvilke faktorer vurderes (Pålidelighed, Vedligeholdelsesvenlighed, Udvidelsesvenlighed, Bruger-
  venlighed, Genbrugbarhed, Integritet, Effektivitet) - Hvilken kvalitet ønskes opnået på den enkelte faktor og hvordan opnås den

5.1 _Pålidelighed_

- Fejl i produktet.
- Nøjagtighed.
- Håndtering af fejlbetjening.

5.2 _Vedligeholdelsesvenlighed_

- Hvor lang tid tager det at finde en fejl.
- Hvor nemt er det at lave en mindre tilpasning til et ændret behov.

5.3 _Udvidelsesvenlighed_

- Hvor nemt er det at lave en egentlig udvidelse af produktet.

5.4 _Brugervenlighed_

- Hvor lang tid tager det for en ny bruger at lære at betjene produktet, mm.

5.5 _Genbrugbarhed_

- Skal dele af programmet laves med henblik på at kunne bruges andetsteds.

5.6 _Effektivitet_

- Krav der ikke naturligt falder ind under de tidligere punkter.
- Hvilke dele af produktet skal prioriteres høj effektivitet.

### 6. **Levering**
Til Flemming Sørensen senest Torsdag eftermiddag i den første uge.

### 7. **E/R Diagram**
Et ER-diagram samt Use case og Flow Diagram ligger som dokumentation i kodebasen

### 8. **Estimeret Plan**

Det forventes at den nye funktionalitet kan leveres inden for et enkelt sprint.

### 9. **Underskrift**
Project Lead Momo