--All numbers and names are Fictive

-- 1.1 Gesucht sind alle Daten aller Kunden.
select * from Kunden;
--1.2 Lassen Sie als einen Betrag die gesamten Lohnkosten anzeigen, welche die Firma jeden Monat zu zahlen hat. Die Spalte soll die Überschrift Monatslöhne bekommen.
select sum(Gehalt) from Mitarbeiter;
--1.3 Wie viele Mitarbeiter hat die Firma?
select count(*) from Mitarbeiter;
--1.4 Wie viele Mitarbeiter haben einen Vorgesetzten?
select count(*) from Mitarbeiter where vorgesetzt is not null;
--1.5 Berechnen Sie das Jahresgehalt, das Herr Schulz bekommt. Das Jahresgehalt sollmit den Daten von Herrn Schulz angezeigt werden.
select *, SUM(Gehalt*12) as JahresGehalt from Mitarbeiter where Nachname = 'Schulz';
--1.6 Gesucht ist die Anzahl der Mitarbeiter, die keinen Vorgesetzten haben
select count(*) from Mitarbeiter where Vorgesetzt is null;
--1.7 Zeige alle Mitarbeiter die in Ulm wohnen oder einem seiner Teilorte wohnen.
select * from Mitarbeiter where Ort >= 'Ulm';
--1.8 Zeige alle Mitarbeiter deren Namen mit „SCH“ beginnt.
select * from Mitarbeiter where Nachname  >= 'sch';
--1.9 Alle Mitarbeiter beginnend mit M im Namen, die aus Ulm kommen.
select * from Mitarbeiter where Nachname >= 'M' and Ort = 'Ulm';
--1.10 Zeigen Sie jede in Vorgesetzt eingetragene Nummer einmal an.
select Vorgesetzt from Mitarbeiter group by Vorgesetzt;
--1.11 Zeigen Sie (absteigend sortiert) alle Mitarbeiter an die zwischen 1000 und 2000 € verdienen.
select * from Mitarbeiter where Gehalt Between 1000 and 2000 Order by Gehalt DESC;
--2.1 Zeige mir alle Mitarbeitern an, die einen Chef haben und die mehr als 2000€ verdienen. Das Ganze soll nach Name und anschließend nach Gehalt sortiert werden.
select * from Mitarbeiter where Vorgesetzt is not NULL and Gehalt > 2000 Order by Gehalt, Nachname;
--2.2 Lassen Sie sich die Daten aller Mitarbeiter aufsteigend sortiert nach Namen und dann nach Vornamen anzeigen.
select * from Mitarbeiter order by Vorname, Nachname ASC;
--2.3 Lassen Sie sich alle Mitarbeiter anzeigen die im gleichen Ort wohnen wie Frau Braun.
select * from Mitarbeiter where Ort = (Select Ort from Mitarbeiter where Nachname = 'Braun');
--2.4 Gesucht ist die Anzahl der Mitarbeiter von jedem Vorgesetzten, deren Gehalt unter 2300 Euro liegt. Sowie das durchschnittliche Gehalt dieser Mitarbeiter.
select COUNT(*), AVG(Gehalt) from Mitarbeiter Group by Vorgesetzt;
--2.5 Gesucht sind die Daten des Mitarbeiters mit dem kleinsten Gehalt. 
select * from Mitarbeiter where Gehalt = (select min(Gehalt) from Mitarbeiter);
--2.6 
    --a) Gesucht ist das durchschnittliche Gehalt der Mitarbeiter eines Vorgesetzten(jeweils ohne die Gehälter der Vorgesetzten).
    select COUNT(*), AVG(Gehalt) from Mitarbeiter where Vorgesetzt is not null Group by Vorgesetzt;
    --b) In der Ausgabe ist der Name des Chefs mit anzuzeigen.
    select AVG(M.Gehalt), V.Nachname FROM Mitarbeiter M
    join Mitarbeiter V on V.Persnr = M.Vorgesetzt
    Group by M.Vorgesetzt;
--3.1 Wie heißt der Kunde zu den jeweiligen Aufträgen?
select A.*, K.Firmenname from Auftrag A join Kunden K on K.Kundennr = A.Kundennr;
--3.2.1 Berechnen Sie, das durchschnittliche Gehalt von Mitarbeitern an einem Ort.
select AVG(Gehalt), Ort  from Mitarbeiter Group by Ort;
--3.2.2 Überprüfen sie durch hinzufügen des Minimalen und Maximalen Gehalts zur obigen Abfrage, ob es berechtigt ist zu behaupten: Wer an dem Ort wohnt, verdient mehr.
select AVG(Gehalt), MAX(Gehalt), MIN(Gehalt), Ort  from Mitarbeiter Group by Ort;
--3.3.1 Ermitteln Sie die Kundennr und Anzahl der Aufträge der Kunden mit mehr als einem Auftrag.
select COUNT(*), Kundennr from Auftrag Group by Kundennr having COUNT(*) >=2;
--3.3.2 Lassen Sie sich zusätzlich zu der Kundennummer in Aufg. 3.3.1 die Daten des Kunden ausgeben.
select K.*, COUNT(A.Kundennr), A.Kundennr from Auftrag A 
JOIN Kunden K ON K.Kundennr = A.Kundennr 
Group by K.Kundennr having COUNT(*) >=2;
--3.5 Gesucht sind alle Bewohner, die im gleichen Ort wie Herr Weiss/Mayer wohnen.
select * from Mitarbeiter where Ort = (select Ort from Mitarbeiter where Nachname = 'Meyer');
--3.6 Gesucht sind alle Bewohner, die im gleichen Ort wie Herr Weiss wohnen, auch wenn sie in einem Teilort wohnen.
select * from Mitarbeiter where Ort >= (select Ort from Mitarbeiter where Nachname = 'Meyer');
--a) Der neue Mitarbeiter Hein Blöd, Bergweg 6, 89073 Ulm mit einem Gehalt von 2000€ und dem Vergesetzten mit Personalnummer 2 wird eingestellt.
insert into Mitarbeiter (Nachname, Vorname, Strasse, Hausnummer, PLZ, Ort, Vorgesetzt, Gehalt)
value ('Blöd', 'Hein', 'Bergweg', 6, 89073, 'Ulm', 2, 2000);
--b) Der Kunde Bikers Paradies zieht ein Haus weiter
update Kunden set  Hausnr = Hausnr+1 where Firmenname = 'Bikers Paradise';
--c) Der Kunde Betten Frank ist Insolvent. Der Kunde un alle seine Aufträge sollen gelöscht werden.
delete from Auftrag where Kundennr = (Select Kundennr from Kunden where Firmenname = 'Betten Frank');
delete from Kunden where Firmenname = 'Betten Frank';
--d) Der Mitarbeiter Siegfried Weiss/Meyer zieht nach 33334 Gütersloh in die Buxelstr. 12 um.
update Mitarbeiter set PLZ=33334, Ort='Gütersloh', Strasse= 'Buxelstr.', Hausnummer= 12 where Nachname = 'Meyer';
--e) Die Mitarbeiterin Inge Braun kündigt. Alle von ihr bearbeiteten Aufträge werden ab sofort von Peter Kraus bearbeitet und ihre persönlichen Daten gelöscht.
update Auftrag set Auftragsnummer = (Select Persnr from Mitarbeiter where Nachname = 'Kraus' and Vorname = 'Peter') 
where Persnr = (select Persnr from Mitarbeiter where Nachname = 'Braun' And Vorname = 'Inge');
--f) Katrin Computerladen schließt heute bei der Mitarbeiterin Frau Moltke einen Auftrag ab. Legen Sie den zugehörigen Datensatz an.
insert into Auftrag (Kundennr, Persnr, Datum)
value ((select Kundennr from Kunden where Firmenname = 'Katrin Computerladen'), 
(select Persnr from Mitarbeiter where Nachname = 'Moltke'),
'2022-03-29');
--g) Erbach wird wegen den vielen Kreisverkehren in Ringbach umbenannt.
update Kunden set Ort = 'Ringbach' where Ort = 'Erbach';
update Mitarbieter set Ort = 'Ringbach' where Ort = 'Erbach';
--h) Alle Aufträge von Fahrrad Himmel sind ab sofort Chefsache und werden nur noch von Katharina Moltke bearbeitet.
update Auftrag set Persnr = (select Persnr from Mitarbeiter where Nachname = 'Moltke' and Vorname = 'Katharina')
where Kundennr = (select Kundennr from Kunden where Firmenname = 'Fahrrad Himmel');
--i) Alle Aufträge vom 01.08.2020 bis zum 30.09.2020 sollen gelöscht werden.
delete from Auftrag where Datum between '2004-08-01' and '2004-09-30';