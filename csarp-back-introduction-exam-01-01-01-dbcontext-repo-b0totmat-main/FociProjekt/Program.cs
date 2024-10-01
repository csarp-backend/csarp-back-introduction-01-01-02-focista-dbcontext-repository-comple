// Réteg közötti kapcsolat felépítése

using FociProjekt.Context;
using FociProjekt.Entities;
using FociProjekt.Repos;

// Adatbázis kezelés
AppDbContext appDbContext = new AppDbContext();

// A repo réteg ismeri a DbContext réteget, mert azon keresztül éri el a táblákat
FocistakRepo<Focista> focistakRepo = new FocistakRepo<Focista>(appDbContext);
FociKlubokRepo<FociKlub> fociKlubokRepo = new FociKlubokRepo<FociKlub>(appDbContext);
EdzoRepo<Edzo> edzoRepo = new EdzoRepo<Edzo>(appDbContext);
BajnoksagRepo<Bajnoksag> bajnoksagRepo = new BajnoksagRepo<Bajnoksag>(appDbContext);

// Klubok létrehozása
DateTime datum = new DateTime(1902, 04, 16);
FociKlub realMadrid = new FociKlub(datum, "Real Madrid", 577.7);
FociKlub bayernMunchen = new FociKlub(new DateTime(1900, 02, 27), "Bayern Münhcen", 474.4);

// Focista létrehozása és adatbázishoz adása
Focista ramos = new Focista("Sergio Ramos", 4, 184, 82, true, realMadrid);
Focista hazard = new Focista("Eden Hazard", 7, 175, 74, true, realMadrid);
Focista courtois = new Focista("Thibaut Courtois", 1, 199, 96, false, realMadrid);

Focista pavard = new Focista("Benjamin Pavard", 5, 186, 76, true, bayernMunchen);
Focista lewandowski = new Focista("Robert Lewandowski", 9, 184, 80, true, bayernMunchen);
Focista kimich = new Focista("Joshua Kimmich", 6, 176, 73, true, bayernMunchen);

focistakRepo.Hozzad(ramos);
focistakRepo.Hozzad(hazard);
focistakRepo.Hozzad(courtois);

focistakRepo.Hozzad(pavard);
focistakRepo.Hozzad(lewandowski);
focistakRepo.Hozzad(kimich);

// Hány focistát tárolunk?
int focistakSzama = focistakRepo.GetFocistakSzama();
Console.WriteLine($"Focisák száma az adatbázisba: {focistakSzama} fő.");
// Törlés
focistakRepo.Torol(courtois);
focistakSzama = focistakRepo.GetFocistakSzama();
// Módosítás
Console.WriteLine($"Összes focista: {focistakSzama}. fő");
focistakRepo.Modosit(new Focista("Sergio Ramos", 9, 184, 82, true, realMadrid));

// Sikerült-e módosítani a focista adatait?
// 1.
int ujMezszam = focistakRepo.KeresFocista("Sergio Ramos").Mezszam;
Console.WriteLine($"Sergio Ramos új mezszáma: {ujMezszam}");
// 2.
Focista? ujRamos = focistakRepo.KivalasztOsszesFocistat().Find(focista => focista.Nev == "Sergio Ramos");
if (ujRamos is not null)
    Console.WriteLine($"{ujRamos.Nev} új mezszama {ujRamos.Mezszam}.");



// FociKlubokRepo teszt
FociKlub fk1 = new(new DateTime(1950, 4, 16), "FK1", 100);
FociKlub fk2 = new(new DateTime(1968, 2, 2), "FK2", 250);
FociKlub fk3 = new(new DateTime(1957, 9, 28), "FK3", 420);
FociKlub fk4 = new(new DateTime(1978, 9, 10), "FK4", 230);
FociKlub fk5 = new(new DateTime(1955, 3, 14), "FK5", 340);
FociKlub fk6 = new(new DateTime(2000, 8, 30), "FK6", 500);

// Hozzáadás a repo-hoz:
fociKlubokRepo.Hozzad(fk1);
fociKlubokRepo.Hozzad(fk2);
fociKlubokRepo.Hozzad(fk3);
fociKlubokRepo.Hozzad(fk4);
fociKlubokRepo.Hozzad(fk5);
fociKlubokRepo.Hozzad(fk6);

// GetFociKlubokSzama metódus:
Console.WriteLine($"Fociklubok száma: {fociKlubokRepo.GetFociKlubokSzama()}");
fociKlubokRepo.Torol(fk2); // Törlés
Console.WriteLine($"Fociklubok száma törlés után: {fociKlubokRepo.GetFociKlubokSzama()}");

// Módosítás
Console.WriteLine($"\nFK4 módosítás előtt: {fk4.Nev}, {fk4.Koltsegvetes}, {fk4.AlapitasiIdo}");
fociKlubokRepo.Modosit(new FociKlub(new DateTime(2010, 9, 17), "FK4", 300));
Console.WriteLine($"\nFK4 módosítás után: {fk4.Nev}, {fk4.Koltsegvetes}, {fk4.AlapitasiIdo}");

// Edző repo teszt:
Edzo e1 = new("Edző1", 100, fk1);
Edzo e2 = new("Edző2", 150, fk2);
Edzo e3 = new("Edző3", 120, fk3);
Edzo e4 = new("Edző4", 210, fk4);
Edzo e5 = new("Edző5", 160, fk5);
Edzo e6 = new("Edző6", 130, fk6);

// Hozzáadás repo-hoz:
edzoRepo.Hozzad(e1);
edzoRepo.Hozzad(e2);
edzoRepo.Hozzad(e3);
edzoRepo.Hozzad(e4);
edzoRepo.Hozzad(e5);
edzoRepo.Hozzad(e6);

// Get metódus:
Console.WriteLine($"Edzők száma: {edzoRepo.GetEdzokSzama()}");
edzoRepo.Torol(e2); // Törlés
Console.WriteLine($"Edzők száma törlés után: {edzoRepo.GetEdzokSzama()}");

// Módosítás
Console.WriteLine($"\nE4 módosítás előtt: {e4.Nev}, {e4.FociKlub}, {e4.Fizetes}");
fociKlubokRepo.Modosit(new FociKlub(new DateTime(2010, 9, 17), "FK4", 300));
Console.WriteLine($"\nE4 módosítás után: {e4.Nev}, {e4.FociKlub}, {e4.Fizetes}");


// Bajnokság teszt:

Bajnoksag b1 = new("B1", appDbContext.FociKlubok, new DateTime(2024, 10, 20));
Bajnoksag b2 = new("B2", appDbContext.FociKlubok, new DateTime(2025, 3, 16));
Bajnoksag b3 = new("B3", appDbContext.FociKlubok, new DateTime(2025, 7, 5));
Bajnoksag b4 = new("B4", appDbContext.FociKlubok, new DateTime(2026, 5, 30));

// Hozzáadás repo-hoz:
bajnoksagRepo.Hozzad(b1);
bajnoksagRepo.Hozzad(b2);
bajnoksagRepo.Hozzad(b3);
bajnoksagRepo.Hozzad(b4);

// Törlés, Get:
Console.WriteLine($"Bajnokságok száma: {bajnoksagRepo.GetBajnoksagokSzama()}");
bajnoksagRepo.Torol(b2); // Törlés
Console.WriteLine($"Bajnokságok száma törlés után: {bajnoksagRepo.GetBajnoksagokSzama()}");

// Módosítás
Console.WriteLine($"\nB4 módosítás előtt: {b4.Nev}, {b4.BajnoksagKezdete}");
bajnoksagRepo.Modosit(new Bajnoksag("B4", new List<FociKlub> { fk2, fk5}, new DateTime(2027, 9, 18)));
Console.WriteLine($"\nB4 módosítás után: {b4.Nev}, {b4.BajnoksagKezdete}");
