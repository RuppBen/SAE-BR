--All numbers and names are Fictive

-- 1.1 Gesucht sind alle Daten aller Kunden.
select * from Kunden;
--1.2 Lassen Sie als einen Betrag die gesamten Lohnkosten anzeigen, welche die Firma jeden Monat zu zahlen hat. Die Spalte soll die Überschrift Monatslöhne bekommen.
select sum(Gehalt) from Mitarbeiter as Monatslöhne;
--1.3 Wie viele Mitarbeiter hat die Firma?
select count(*) from Mitarbeiter;
--1.4 Wie viele Mitarbeiter haben einen Vorgesetzten?
select count(*) from Mitarbeiter where Vorgesetzt is not null;
--1.5 Berechnen Sie das Jahresgehalt, das Herr Schulz bekommt. Das Jahresgehalt sollmit den Daten von Herrn Schulz angezeigt werden.
select Gehalt*12 from Mitarbeiter where Nachname="Schulz";
--1.6 Gesucht ist die Anzahl der Mitarbeiter, die keinen Vorgesetzten haben
select count(*) from Mitarbeiter where Vorgesetzt is null;
--1.7 Zeige alle Mitarbeiter die in Ulm wohnen oder einem seiner Teilorte wohnen.
select * from Mitarbeiter where Ort like "Ulm%";
--1.8 Zeige alle Mitarbeiter deren Namen mit „SCH“ beginnt.
select * from Mitarbeiter where Nachname like "sch%";
--1.9 Alle Mitarbeiter beginnend mit M im Namen, die aus Ulm kommen.
select * from Mitarbeiter where Nachname like "m%" and Ort like "Ulm";
--1.10 Zeigen Sie jede in Vorgesetzt eingetragene Nummer einmal an.
select Vorgesetzt from Mitarbeiter Group by Vorgesetzt;
--1.11 Zeigen Sie (absteigend sortiert) alle Mitarbeiter an die zwischen 1000 und 2000 € verdienen.
select * from Mitarbeiter where Gehalt>=1000 and Gehalt<=2000 Order by Gehalt DESC;


--2.1 Zeige mir alle Mitarbeitern an, die einen Chef haben und die mehr als 2000€ verdienen. Das Ganze soll nach Name und anschließend nach Gehalt sortiert werden.
select * from Mitarbeiter where Gehalt>=2000 AND Vorgesetzt is not null Order by Gehalt, Nachname;
--2.2 Lassen Sie sich die Daten aller Mitarbeiter aufsteigend sortiert nach Namen und dann nach Vornamen anzeigen.
select * from Mitarbeiter Order by Vorname ASC, Nachname ASC;
--2.3 Lassen Sie sich alle Mitarbeiter anzeigen die im gleichen Ort wohnen wie Frau Braun.
select * from Mitarbeiter where Ort like (Select Ort from Mitarbeiter where Nachname like "Braun");
--2.4 Gesucht ist die Anzahl der Mitarbeiter von jedem Vorgesetzten, deren Gehalt unter 2300 Euro liegt. Sowie das durchschnittliche Gehalt dieser Mitarbeiter.
select count(*), AVG(Gehalt), Vorgesetzt From Mitarbeiter Where Gehalt <= 2300 Group by Vorgesetzt;
--2.5 Gesucht sind die Daten des Mitarbeiters mit dem kleinsten Gehalt. 
select * from Mitarbeiter Where gehalt=(select min(gehalt) from Mitarbeiter);
--2.6 
    --a) Gesucht ist das durchschnittliche Gehalt der Mitarbeiter eines Vorgesetzten(jeweils ohne die Gehälter der Vorgesetzten).
    select AVG(Gehalt) From Mitarbeiter Where vorgesetzt is not null group by Vorgesetzt;
    --b) In der Ausgabe ist der Name des Chefs mit anzuzeigen.
    select AVG(M.Gehalt), V.Nachname, V.Vorname 
    from Mitarbeiter M JOIN Mitarbeiter V 
    ON M.Vorgesetzt = V.Persnr
    Where M.Vorgesetzt is not null group by M.Vorgesetzt;


--3.1 Wie heißt der Kunde zu den jeweiligen Aufträgen?
Select * from Kunden where Kundennr = ANY (Select distinct Kundennr from Auftrag);
--3.2.1 Berechnen Sie, das durchschnittliche Gehalt von Mitarbeitern an einem Ort.
select AVG(Gehalt), Ort from Mitarbeiter Group by Ort;
--3.2.2 Überprüfen sie durch hinzufügen des Minimalen und Maximalen Gehalts zur obigen Abfrage, ob es berechtigt ist zu behaupten: Wer an dem Ort wohnt, verdient mehr.
select MIN(Gehalt), MAX(Gehalt), AVG(Gehalt), Ort from Mitarbeiter Group by Ort;
--3.3.1 Ermitteln Sie die Kundennr und Anzahl der Aufträge der Kunden mit mehr als einem Auftrag.
select Kundennr, count(*) from Auftrag 
where Kundennr = any (select Kundennr from Kunden) 
group by Kundennr having count(*)>1;
--3.3.2 Lassen Sie sich zusätzlich zu der Kundennummer in Aufg. 3.3.1 die Daten des Kunden ausgeben.
select K.*, Count(*) AS AnzahlAufräge
from Auftrag A 
JOIN Kunden K 
    ON A.Kundennr = K.Kundennr 
where A.Kundennr = any (select Kundennr from Kunden) group by A.Kundennr having count(*)>1;
--3.5 Gesucht sind alle Bewohner, die im gleichen Ort wie Herr Weiss/Mayer wohnen.
select * from Mitarbeiter  where Ort IS (select Ort from Mitarbeiter where Nachname = "Meyer");
--3.6 Gesucht sind alle Bewohner, die im gleichen Ort wie Herr Weiss wohnen, auch wenn sie in einem Teilort wohnen.
select * from Mitarbeiter where ORT >= (select Ort from Mitarbeiter where Nachname LIKE "Meyer");


--a) Der neue Mitarbeiter Hein Blöd, Bergweg6, 89073 Ulm mit einem Gehalt von 2000€ und dem Vergesetzten mit Personalnummer 2 wird eingestellt.
insert into Mitarbeiter (Nachname, Vorname, Strasse, Hausnummer, PLZ, Ort, Vorgesetzt, Gehalt) 
values ('Bloed', 'Hein', 'Bergweg', 6, 'Ulm',  89073, 2, 2000);
--b) Der Kunde Bikers Paradies zieht ein Haus weiter
update Kunden SET Hausnr = Hausnr+1 
where Firmenname = "Bikers Paradise";
--c) Der Kunde Betten Frank ist Insolvent. Der Kunde un alle seine Aufträge sollen gelöscht werden.
delete from Auftrag where Kundennr = (select Kundennr from Kunden where Firmenname + "Betten Frank");
delete from Kunden where Firmenname = "Betten Frank";
--d) Der Mitarbeiter Siegfried Weiss/Meyer zbieht nach 33334 Gütersloh in die Buxelstr. 12 um.
update Mitarbeiter set Strasse='Buxelstr.', Hausnummer=12, PLZ=33334, Ort='Gütersloh' 
Where Vorname='Siegfried' and Nachname='Meyer';
--e) Die Mitarbeiterin Inge Braun kündigt. Alle von ihr bearbeiteten Aufträge werden ab sofort von Peter Kraus bearbeitet und ihre persönlichen Daten gelöscht.
update Auftrag set Persnr = (select Persnr from Mitarbeiter where Vorname='Peter' and Nachname='Kraus') 
where Persnr = (select Persnr From Mitarbeiter where Vorname="Inge" and Nachname="Braun");
--f) Katrin Computerladen schließt heute bei der Mitarbeiterin Frau Moltke einen Auftrag ab. Legen Sie den zugehörigen Datensatz an.
insert into Auftrag (Kundennr, Persnr, Datum)
values (
    (select Kundennr from Kunden where Firmenname = "Katrin Computerladen"),
    (select Persnr from Mitarbeiter where Nachname = "Moltke"), 
    '2022-02-07');
/*
--This statemant is wrong, but I left it there, because it is a good example of a Right Join
select K.Kundennr, M.Persnr From Kunden K 
Right Join Mitarbeiter M ON M.Persnr = K.Kundennr
where K.Firmenname = "Katrin Computerladen" OR M.Nachname = "Moltke";
*/
--g) Erbach wird wegen den vielen Kreisverkehren in Ringbach umbenannt.
update Mitarbeiter  Set Ort = "Ringbach" where Ort = "Erbach";
update Kunden  Set Ort = "Ringbach" where Ort = "Erbach";
--h) Alle Aufträge von Fahrrad Himmel sind ab sofort Chefsache und werden nur noch von Katharina Moltke bearbeitet.
update Auftrag set Persnr = (select Persnr from Mitarbeiter where Vorname = "Katharina" and Nachname = "Moltke")
where Kundennr = (select Kundennr from Kunden where Firmenname ="Fahrrad Himmel");
--i) Alle Aufträge vom 01.08.2004 bis zum 30.09.2004 sollen gelöscht werden.
delete from Auftrag where Datum Between '2020.08.01' and '2020.09.30';