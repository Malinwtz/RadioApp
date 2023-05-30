# RadioApp

Webbapplikation baserad på .Net Core med MVC som pattern. Applikationen hämtar och visar data i json-format från Sveriges Radios öppna Api. 

## Installerade nugetpaket
- Newtonsoft.Json: för att konvertera data från api till json-format. 

##Klassbibliotek
I projektet används ett klassbibliotek (ServiceLibrary) för att hämta data från Sveriges Radios api. Radioapplikationens HomeController använder sig i sin tur av klassbiblioteket för att hämta den data som ska visas i Index-vyn. 

I klassbiblioteket finns en radioservice med ett tillhörande interface och även de klasser som behövs för att hämta data från api:et. 
