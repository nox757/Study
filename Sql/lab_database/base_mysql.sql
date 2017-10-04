create database13527

create database base13527;


use base13527

create table genres (genre varchar(30) primary key not null );

 create table Films
 (
 id numeric(6) primary key not null,
 NameFilm varchar(50) not null,
 Studio varchar(50) not null,
 Year numeric(4) not null,
 Country varchar(30),
 Time numeric(4,2) not null,
 Genre char(30) references genres);

 create table Persons
 (
 id numeric(6) primary key not null,
 fio varchar(50) not null,
 country varchar(30) not null,
 birth date not null,
 death date not null);
 
 create table creators
(
film numeric(6) references films,
person numeric(6) references persons,
charact varchar(50) not null,
role varchar(30) );

| genre     |
+-----------+
| adventure |
| comedy    |
| detective |
| drama     |
| family    |
| fantasy   |
| horor     |
| science   |
| triller   |
+-----------+

---+-----------+
 id | NameFilm         | Studio     | Year | Country            | Time | Genre
   | genre     |
----+------------------+------------+------+--------------------+------+-------
---+-----------+
  1 | Arab             | WarnerBr   | 1995 | Turkey             | 1.25 | advent
re | adventure |
  2 | Kitaec           | Chaonli    | 1995 | China              | 1.32 | advent
re | adventure |
  3 | Milayu           | RashitSt   | 1983 | India              | 2.15 | advent
re | adventure |
  4 | Piter            | LenFilm    | 2001 | Russian Federation | 1.17 | advent
re | adventure |
  5 | PupEarth         | Odessia    | 2005 | UKraine            | 0.57 | horor
   | horor     |
  6 | Zelenue          | DreamWorks | 2007 | Mexico             | 3.57 | Trille
   | triller   |
  7 | KUKU             | Gorkii     | 1965 | USSR               | 1.38 | horor
   | horor     |
  8 | miror            | MGM        | 1981 | USA                | 1.21 | horor
   | horor     |
  9 | Kamalu           | MGM        | 2006 | London             | 2.22 | drama
   | drama     |
 10 | Microb           | Columbia   | 2003 | France             | 3.22 | scienc
   | science   |
 11 | trulala          | paramaunt  | 1999 | Italy              | 1.16 | family
   | family    |
 12 | Wolf             | Gorkii     | 2010 | Kenia              | 1.47 | fantas
   | fantasy   |
 13 | lubof            | warnerbr   | 2011 | Japan              | 3.13 | detect
ve | detective |
 14 | MY Young Brother | Molot      | 2006 | Russian Federation | 1.22 | comedy
   | comedy    |
 15 | Mumia            | Paramaunt  | 2012 | Egept              | 2.27 | fantas
   | fantasy   |
----+------------------+------------+------+--------------------+------+-------




 select * from films f
 where year = year(now()) and country = 'russian federation';
 
 
 
 select * from
creators c, films f
where
f.namefilm = 'Stalker' and c.film = f.id;
 
 
 
 select f.* from
creators c, films f, persons p
where
p.fio like 'Ranefskay%' and p.id = c.person
and f.id = c.film;


 select * from genres g
 where genre not in (select distinct f.genre from films f);
 
  select * from genres g
 where not exists(select *  from films f where f.genre = g.genre);
 
 
 
  select p.fio, f.namefilm
 from films f, persons p,
 (select person, film, count(*)
 from creators
 where charact ='player'
 group by film, person having count(*) > 1) as cnt
where
cnt.film = f.id and cnt.person = p.id;




 select p.fio, f.namefilm, count(*)
 from persons p, films f
 , creators c
 where p.id = c.person and f.id = c.film
 and c.charact = 'player'
 group by  f.namefilm, p.fio
 having count(*) > 1;
 
 
 



