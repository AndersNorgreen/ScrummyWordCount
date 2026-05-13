# 1. Indledning

### 1.1. *Formål*

  Denne kravspecifikation beskriver kravene til videreudviklingen af systemet **ScrummyWordCount**.
	Systemet er udviklet til et anerkendt it-sikkerhedsfirma, som ønsker at automatisere overvågning af hjemmesider for forekomster af mistænkelige søgeord. V1 af systenmet er allerede 		  	leveret. Denne kravspecifikation omhandlder de nye krav som kunden ønsker implementeret til en fremtidig V2.

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
  -  Det totale HW + SW (verdensbillede)
  -  Tilhørende forklaring

---

### 2.2 System funktion
	
Brugeren indtaster en liste af URL'er og søgeord i UI'et, som gemmes i databasen.

Systemet scanner automatisk alle URL'er for alle søgeord to gange dagligt via automatiske jobs i C# API'en, som scraper de ønskede sider og gemmer resultaterne i databasen. 

Hvis en side ikke kan scannes, logges fejlen og en advarsel sendes på mail. 

---
		
2.3. *System begrænsninger*
	- Beskrivelse af de ting programmet ikke skal kunne. 
	-  Opgaver som kunne opfattes som værende en del af systemet, men ikke er medtaget pga. tidsmæssige, økonomiske og ressourcemæssige årsager
		
2.4. *Systemets fremtid*
	- Programmets forventede levetid.
	- Udvidelsesmuligheder i senere versioner. Er der konkrete ting, der skal tages højde for nu.
	-  Udvidelsesmuligheder
	-  Levetid / perspektivering
		
2.5. *Brugerprofil*
	- Hvem skal bruge systemet.
	- Stilles der krav til erfaring med edb-udstyr.
		- Opdeling i brugergrupper
		- Deres forudsætninger
		- Adgangsform
		
2.6. *Krav til udviklingsforløbet*
	- Krav fra såvel udvikleren som kunden.
	- Anvendelse af vejledninger, designmetoder, standarder.
	- Programmeringssprog.
	- Review.
	- Hvilken dokumentation, skal der udarbejdes.
	- Hvordan skal ændringer i kravspecifikationen håndteres.
		-  Metoder (evt. SPU metoden)
		-  Dokumentationskrav (alt med sammenhængende indholdsfortegnelse)
		
2.7. *Omfang af kundeleverancer*
	- Hvor meget af det samlede system skal leveres til kunden.
	- Hvor meget af dokumentationen skal leveres til kunden.
		-  Produkt
		-  Dokumentation
		-  Afleveringsformat
		
	2.8. *Forudsætninger*
	- Udstyr som kunden skal stille tilrådighed under udviklingen.
	- Personer som kunden skal stille til rådighed.
		-  SW eller HW stillet til rådighed
		-  Kunderepræsentant til rådighed

3. **Specifikke Krav**

	3.1. *Definitioner*
	- Formatet på væsentlige data, som kunden ønsker fastlagt fra starten.
		-  Design af specielle kommunikationsprotokoller (programmør)
		
	3.2. *Funktionelle krav*
	- Når I skal til dette punkt så tjek længere nede, der står der oplysninger om USE CASES, det ville være smart at placere disse her.
	- Beskrivelse af hver af de funktionaliteter, som programmet består af. Det være sig funktionaliteter, som brugeren oplever, men også funktionaliteter, der er væsentlige for programmets funktion.
	- Beskriv hvis der er noget særligt omhandlende input og output fra HW til SW eller omvendt.
		-  Systematisk beskrivelse af alle funktionalitet er i systemet evt. med punkter og underpunkter
		-  Skitse af komplet brugergrænseflade

4. **Eksterne grænseflade krav**

	4.1. *Bruger grænseflade*
	-  Krav til måden programmet betjenes på: Menuer/ mus/ tastatur.
	- Forskellige brugeres rettigheder til brug af forskellige funktioner.
	
	4.2. *Hardware grænseflade*
	- Hvordan er delene i systemet hardwaremæssigt bygget sammen
	- På hvilken elektrisk form optræder informationerne. 
		-  Protokol, netværkstype (evt. bilagshenvisning)
		-  I/O-karakteristika (evt. bilagshenvisning) (programmør)
		
	4.3. *Software grænseflade*
	- Operativsystemet som programmellet skal køre under.
	- Benyttelse af prædefinerede softwaremoduler.
	- Grænseflade til anden del af programmet, hvis projektet er en del af et større system.
		-  Operativsystem
		
	4.4. *Kommunikations grænseflade*
	De fleste elever har ikke noget her.)
	- Overordnet kommunikationsprotokol.
	- Detaljeret kommunikationsprotokol, hvis det er et krav fra kunden, evt. under specifikationer.


5. **Krav til programmellets ydelse**
	- Specifikke tidskrav til udførelse af bestemte funktioner.
	- Krav til det eksekverbare programs størrelse.
		-  Tidskrav på systemets responsens i forskellige situationer

6. **Kvalitetsfaktorer**
	- Argument for hver kvalitetsfaktor.
	- Hvad skal gøres for at opnå en bestemt kvalitetsfaktor.
	- Visse krav modarbejder hinanden.
	- Vigtighed angives som tal fra 1 til 5.
		-  Hvilke faktorer vurderes (Pålidelighed, Vedligeholdelsesvenlighed, Udvidelsesvenlighed, Bruger-
		venlighed, Genbrugbarhed, Integritet, Effektivitet)
		-  Hvilken kvalitet ønskes opnået på den enkelte faktor og hvordan opnås den
		
	6.1 *Pålidelighed*
	- Fejl i produktet.
	- Nøjagtighed.
	- Håndtering af fejlbetjening.
	
	6.2 *Vedligeholdelsesvenlighed*
	- Hvor lang tid tager det at finde en fejl.
	- Hvor nemt er det at lave en mindre tilpasning til et ændret behov.
	
	6.3 *Udvidelsesvenlighed*
	- Hvor nemt er det at lave en egentlig udvidelse af produktet.
	
	6.4 *Brugervenlighed*
	- Hvor lang tid tager det for en ny bruger at lære at betjene produktet, mm.
	
	6.5 *Genbrugbarhed*
	- Skal dele af programmet laves med henblik på at kunne bruges andetsteds.
	
	6.6 *Effektivitet*
	- Krav der ikke naturligt falder ind under de tidligere punkter. 
		- Hvilke dele af produktet skal prioriteres høj effektivitet.

7. **Andre krav**
	-  Øvrige endnu ikke nævnte krav

8. **Levering**
	- Til Flemming Sørensen senest Torsdag eftermiddag i den første uge.

9. **Skærmbilleder**
	- Det er hensigtsmæssigt at aflevere skærmbilleder med af systemet, det kan være håndtegnet eller andet.

10. **E/R Diagram**
	- I skal benytte et E/R diagram til at designe databasen. (se nedenfor for eks.) 

11. **Estimeret Plan**

12. **Underskrift**
