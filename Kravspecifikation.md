# 1. Indledning

### 1.1. _Formål_

Denne kravspecifikation beskriver kravene til videreudviklingen af systemet **ScrummyWordCount**.
Systemet er udviklet til et anerkendt it-sikkerhedsfirma, som ønsker at automatisere overvågning af hjemmesider for forekomster af mistænkelige søgeord. V1 af systenmet er allerede leveret. Denne kravspecifikation omhandlder de nye krav som kunden ønsker implementeret til en fremtidig V2.

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

- Verdensbillede, en tegning af det totale system.
- Kort beskrivelse af hardwaren.
- Kort beskrivelse af softwaren.
- Det totale HW + SW (verdensbillede)
- Tilhørende forklaring

---

### 2.2 System funktion

Brugeren indtaster en liste af URL'er og søgeord i UI'et, som gemmes i databasen.

Systemet scanner automatisk alle URL'er for alle søgeord to gange dagligt via automatiske jobs i C# API'en, som scraper de ønskede sider og gemmer resultaterne i databasen.

Hvis en side ikke kan scannes, logges fejlen og en advarsel sendes på mail.

---

### 2.3. _System begrænsninger_

Da programmet er opsat med automatisering (på to tidspunkter hver dag), vil realtidsovervågning ikke være muligt.

Samtidig vil der ikke være nogen bruger autorisation/adgangskontrol.

Dataeksport vil heller ikke være en mulighed, men det vil være en af vores fremtidsmuligheder.

---

### 2.4. _Systemets fremtid_

Programmets forventes at være i produktion indtil sikkerhedsfirmaet ikke længere har behov for det.

Fremtidsmuligheder vil være features som Data eksport, og evt. realtidsovervågning.

---

### 2.5. _Brugerprofil_

    - Hvem skal bruge systemet.
    - Stilles der krav til erfaring med edb-udstyr.
    	- Opdeling i brugergrupper
    	- Deres forudsætninger
    	- Adgangsform

---

### 2.6 Krav til udviklingsforløbet

- **Metode:** Scrum
- **Versionsstyring:** Git / GitHub
- **Programmeringssprog:** TypeScript (frontend), C# (backend)
- **Dokumentation:** Casebeskrivelse, kravspecifikation, testrapport
- **Review:** Pull requests gennemgås af mindst ét andet teammedlem inden merge
- **Ændringer i kravspec:** Godkendes af PO og Project Lead i fællesskab.

---

2.7. _Omfang af kundeleverancer_ - Hvor meget af det samlede system skal leveres til kunden. - Hvor meget af dokumentationen skal leveres til kunden. - Produkt - Dokumentation - Afleveringsformat
2.8. _Forudsætninger_
Kunden skal stille en server til rådighed, og give de relevante i ScrummyWordCount-teamet adgang til at tilgå serveren.

3. **Specifikke Krav**

   3.1. _Definitioner_
   - Formatet på væsentlige data, som kunden ønsker fastlagt fra starten. - Design af specielle kommunikationsprotokoller (programmør)
     3.2. _Funktionelle krav_
   - Når I skal til dette punkt så tjek længere nede, der står der oplysninger om USE CASES, det ville være smart at placere disse her.
   - Beskrivelse af hver af de funktionaliteter, som programmet består af. Det være sig funktionaliteter, som brugeren oplever, men også funktionaliteter, der er væsentlige for programmets funktion.
   - Beskriv hvis der er noget særligt omhandlende input og output fra HW til SW eller omvendt.
     - Systematisk beskrivelse af alle funktionalitet er i systemet evt. med punkter og underpunkter
     - Skitse af komplet brugergrænseflade

4. **Eksterne grænseflade krav**

   4.1. _Bruger grænseflade_
   - Krav til måden programmet betjenes på: Menuer/ mus/ tastatur.
   - Forskellige brugeres rettigheder til brug af forskellige funktioner.

     4.2. _Hardware grænseflade_

   - Hvordan er delene i systemet hardwaremæssigt bygget sammen
   - På hvilken elektrisk form optræder informationerne. - Protokol, netværkstype (evt. bilagshenvisning) - I/O-karakteristika (evt. bilagshenvisning) (programmør)
     4.3. _Software grænseflade_
   - Operativsystemet som programmellet skal køre under.
   - Benyttelse af prædefinerede softwaremoduler.
   - Grænseflade til anden del af programmet, hvis projektet er en del af et større system. - Operativsystem
     4.4. _Kommunikations grænseflade_
     De fleste elever har ikke noget her.)
   - Overordnet kommunikationsprotokol.
   - Detaljeret kommunikationsprotokol, hvis det er et krav fra kunden, evt. under specifikationer.

5. **Krav til programmellets ydelse**
   - Specifikke tidskrav til udførelse af bestemte funktioner.
   - Krav til det eksekverbare programs størrelse.
     - Tidskrav på systemets responsens i forskellige situationer

6. **Kvalitetsfaktorer**
   - Argument for hver kvalitetsfaktor.
   - Hvad skal gøres for at opnå en bestemt kvalitetsfaktor.
   - Visse krav modarbejder hinanden.
   - Vigtighed angives som tal fra 1 til 5. - Hvilke faktorer vurderes (Pålidelighed, Vedligeholdelsesvenlighed, Udvidelsesvenlighed, Bruger-
     venlighed, Genbrugbarhed, Integritet, Effektivitet) - Hvilken kvalitet ønskes opnået på den enkelte faktor og hvordan opnås den
     6.1 _Pålidelighed_
   - Fejl i produktet.
   - Nøjagtighed.
   - Håndtering af fejlbetjening.

     6.2 _Vedligeholdelsesvenlighed_

   - Hvor lang tid tager det at finde en fejl.
   - Hvor nemt er det at lave en mindre tilpasning til et ændret behov.

     6.3 _Udvidelsesvenlighed_

   - Hvor nemt er det at lave en egentlig udvidelse af produktet.

     6.4 _Brugervenlighed_

   - Hvor lang tid tager det for en ny bruger at lære at betjene produktet, mm.

     6.5 _Genbrugbarhed_

   - Skal dele af programmet laves med henblik på at kunne bruges andetsteds.

     6.6 _Effektivitet_

   - Krav der ikke naturligt falder ind under de tidligere punkter.
     - Hvilke dele af produktet skal prioriteres høj effektivitet.

7. **Andre krav**
   - Øvrige endnu ikke nævnte krav

8. **Levering**
   - Til Flemming Sørensen senest Torsdag eftermiddag i den første uge.

9. **Skærmbilleder**
   - Det er hensigtsmæssigt at aflevere skærmbilleder med af systemet, det kan være håndtegnet eller andet.

10. **E/R Diagram**
    - I skal benytte et E/R diagram til at designe databasen. (se nedenfor for eks.)

11. **Estimeret Plan**

12. **Underskrift**
