use master
create database ednevnik2022
use ednevnik

--drop table ocena
--drop table raspodela
--drop table upisnica
--drop table predmet
--drop table odeljenje
--drop table osoba
--drop table smer
--drop table skolska_godina

create table Smer(
id INT IDENTITY(1,1) PRIMARY KEY,
naziv NVARCHAR(60)
)

create table Skolska_godina(
id INT IDENTITY(1,1) PRIMARY KEY,
naziv NVARCHAR(15)
)

create table Predmet(
id INT IDENTITY(1,1) PRIMARY KEY,
naziv NVARCHAR(20),
razred INT
)
create table Osoba(
id INT IDENTITY(1,1) PRIMARY KEY,
ime NVARCHAR(20),
prezime NVARCHAR(30),
adresa NVARCHAR(30),
jmbg VARCHAR(15),
email VARCHAR(30),
pass VARCHAR(20),
uloga INT
)

create table Odeljenje(
id INT IDENTITY(1,1) PRIMARY KEY,
razred INT,
indeks VARCHAR(10),
smer_id INT FOREIGN KEY REFERENCES Smer(id),
razredni_id INT FOREIGN KEY REFERENCES osoba(id),
godina_id INT FOREIGN KEY REFERENCES Skolska_godina(id)
)

create table Upisnica(
id INT IDENTITY(1,1) PRIMARY KEY,
osoba_id INT FOREIGN KEY REFERENCES Osoba(id),
odeljenje_id INT FOREIGN KEY REFERENCES Odeljenje(id)
)

create table Raspodela(
id INT IDENTITY(1,1) PRIMARY KEY,
nastavnik_id INT FOREIGN KEY REFERENCES osoba(id),
godina_id INT FOREIGN KEY REFERENCES Skolska_godina(id),
predmet_id INT FOREIGN KEY REFERENCES Predmet(id),
odeljenje_id INT FOREIGN KEY REFERENCES Odeljenje(id)
)

create table Ocena(
id INT IDENTITY(1,1) PRIMARY KEY,
datum DATE default GETDATE(),
raspodela_id INT FOREIGN KEY REFERENCES Raspodela(id),
ocena INT,
ucenik_id INT FOREIGN KEY REFERENCES osoba(id)
)

insert into Smer
values('Prirodni')
insert into Smer
values('Informaticki') --2 (OVAJ)

insert into Skolska_godina
values('2019/29'); --1
insert into Skolska_godina
values('2020/21'); --2 (OVAJ MI TREBA)

insert into Predmet
values('Baze Podataka', 4),
('Programiranje', 3), 
('Srpski', 3),
('Srpski', 4),
('Matematika',4),
('Paradigme',4) 
--3 i 4 su predmeti iz treceg razreda (godina 2019/20)

insert into Osoba
values('Teodor','Djelic','Adr1','123456789','teodor@gmail.com','12346',1),
      ('Matija','Zivanovic','Adr2', '321654','matija@sbb.net','111',1),
	  ('Marija','Draskovic','Adr3', '321654','marija@sbb.net','111',1),
	  ('Irena','Josifoski','Adr4', '321654','irena@sbb.net','111',1),
      ('Dimitrije','Mickovski','Adr5', '321654','dimi@sbb.net','111',1),
	  ('Dusan','Derikonjic','Adr6', '321654','dule@sbb.net','111',1),
	  ('Milos','Pusic','Adr7', '321654','smoki@sbb.net','111',2),
	  ('Danijela','Vujetic','Adr8', '321654','daca@sbb.net','111',2),
      ('Valentina','Popovic','Adr9', '321654','valentina@sbb.net','111',2),
	  ('Aleksandra','Nedic Filipovic','Adr10', '321654','aleksandra@sbb.net','111',2)

insert into Odeljenje
values(4,'R',2,7,2),(3,'10',2,8,2),(3,'9',2,9,2),(3,'R',2,7,1)

insert into Upisnica
values (1,1),(2,1),(3,1),(4,1),(5,1),(6,1)

insert into Raspodela values
(7,2,1,1), --pusic,4,baze,4r
(7,1,2,4), --pusic,3,prog,4r * (ostavicemo da je 4r zato sto je mozda sada neko 3r.)
(8,2,4,1), --srpski,4,danijela,4r
(8,1,3,4), --srpski,3,danijela,4r
(10,2,5,1), --matematika,4,aleksandra,4r
(9,2,6,1), --paradigme,4,valentina,4r
(7,2,2,2),
(7,2,2,3)
--provera
select osoba.ime+Osoba.prezime as Nastavnik, Skolska_godina.naziv as Godina, Predmet.naziv as Predmet, STR(Odeljenje.razred) + '/' +  Odeljenje.indeks as Odeljenje from
Raspodela left join Osoba on Raspodela.nastavnik_id = Osoba.id
left join Skolska_godina on Raspodela.godina_id = Skolska_godina.id
left join Predmet on Raspodela.predmet_id = Predmet.id
left join Odeljenje on Raspodela.odeljenje_id = Odeljenje.id
--kraj provere

insert into Ocena(raspodela_id,ocena,ucenik_id) values
(1,3,2),
(1,4,3),
(1,5,4),
(1,5,5),
(1,4,6),
(1,5,7),
(3,2,2),
(3,4,3),
(3,5,4),
(3,2,5),
(3,4,6),
(3,5,7),
(5,3,2),
(5,4,3),
(5,5,4),
(5,5,5),
(5,4,6),
(5,5,7)
