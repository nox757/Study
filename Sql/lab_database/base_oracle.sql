

create table genres (genre varchar(30) primary key not null );

create table Films
 (
 id numeric(6) primary key not null,
 NameFilm varchar(50) not null,
 Studio varchar(50) not null,
 YearE numeric(4) not null,
 Country varchar(30),
 TimeP numeric(4,2) not null,
 Genre varchar(30) references genres not null);
 
  create table Persons
 (
 id numeric(6) primary key not null,
 fio varchar(50) not null,
 country varchar(30) not null,
 birth date not null,
 death date );
 
  create table creators
(
film numeric(6) references films not null,
person numeric(6) references persons not null,
charact varchar(50) not null,
role varchar(30) );

INSERT INTO genres VALUES ('adventure');
INSERT INTO genres VALUES ('biography');
INSERT INTO genres VALUES ('comedy');
INSERT INTO genres VALUES ('detective');
INSERT INTO genres VALUES ('drama');
INSERT INTO genres VALUES ('family');
INSERT INTO genres VALUES ('fantasy');
INSERT INTO genres VALUES ('horor');
INSERT INTO genres VALUES ('musical');
INSERT INTO genres VALUES ('science');
INSERT INTO genres VALUES ('sports');
INSERT INTO genres VALUES ('triller');

INSERT INTO films VALUES (1,'Arab','WarnerBr',1995,'Turkey',1.25,'adventure');
INSERT INTO films VALUES (2,'Kitaec','Chaonli',1995,'China',1.32,'adventure');
INSERT INTO films VALUES (3,'Milayu','RashitSt',1983,'India',2.15,'adventure');
INSERT INTO films VALUES (4,'Piter','LenFilm',2001,'Russian Federation',1.17,'adventure');
INSERT INTO films VALUES (5,'PupEarth','Odessia',2005,'UKraine',0.57,'horor');
INSERT INTO films VALUES (6,'Zelenue','DreamWorks',2007,'Mexico',3.57,'triller');
INSERT INTO films VALUES (7,'KUKU','Gorkii',1965,'USSR',1.38,'horor');
INSERT INTO films VALUES (8,'miror','MGM',1981,'USA',1.21,'horor');
INSERT INTO films VALUES (9,'Kamalu','MGM',2015,'London',2.22,'drama');
INSERT INTO films VALUES (10,'microb','Columbia',2003,'France',3.22,'science');
INSERT INTO films VALUES (11,'trulala','paramaunt',1999,'Italy',1.16,'family');
INSERT INTO films VALUES (12,'Wolf','Gorkii',2010,'Kenia',1.47,'fantasy');
INSERT INTO films VALUES (13,'lubof','warnerbr',2011,'Japan',3.13,'detective');
INSERT INTO films VALUES (14,'MY Young Brother','Molot',2015,'Russian Federation',1.42,'comedy');
INSERT INTO films VALUES (15,'Mumia','Paramaunt',2012,'Egept',2.27,'fantasy');
INSERT INTO films VALUES (16,'Stalker','21cent',2005,'Russian Federation',2.23,'fantasy');
INSERT INTO films VALUES (17,'Muravii','Phantom',2015,'Russian Federation',2.53,'horor');

alter session set NLS_DATE_FORMAT='<my_format>';

INSERT INTO persons VALUES (1,'Gulkin Petr Igorevich','USSR','1959-08-25','2011-06-13');
INSERT INTO persons VALUES (2,'Gusev Ilai Igorevich','Italy','1996-08-25',null);
INSERT INTO persons VALUES (3,'Belov Denis Sinovich','Russian Federation','1983-05-22',null);
INSERT INTO persons VALUES (4,'Brima Yanus Maidovich','India','1993-05-29',null);
INSERT INTO persons VALUES (5,'Yun Pal Tum','Japan','1955-05-22','1999-09-11');
INSERT INTO persons VALUES (6,'Kruchev Valentin Sergeevich','China','1963-08-25',null);
INSERT INTO persons VALUES (7,'Lyao Dzen Mee','Japan','1983-09-27',null);
INSERT INTO persons VALUES (8,'Miklov Vicktor Gregorevich','Russian Federation','2000-03-21',null);
INSERT INTO persons VALUES (9,'Garlo Malko Tulko','Mexico','1955-04-22','2011-12-02');
INSERT INTO persons VALUES (10,'Semenov Mihail Pavlovich','USSR','1933-10-05','1999-01-12');
INSERT INTO persons VALUES (11,'Ivanov Gregorii Ivanovich','USSR','1945-11-07','1994-03-22');
INSERT INTO persons VALUES (12,'Jan Jekii Chan','China','1965-11-05',null);
INSERT INTO persons VALUES (13,'Junk Meen Lan','China','1969-02-05',null);
INSERT INTO persons VALUES (14,'Hami Lany Pann','India','1958-03-07','2012-10-10');
INSERT INTO persons VALUES (15,'Tulna Mangi Ganni','India','1983-03-19',null);
INSERT INTO persons VALUES (16,'Mutko Igor Tavnaeevich','Ukraine','1985-07-08',null);
INSERT INTO persons VALUES (17,'Galaiko Vadim Timofeevich','Ukraine','1988-05-18',null);
INSERT INTO persons VALUES (18,'Gdanovna Olga Petrovna','Ukraine','1975-04-28',null);
INSERT INTO persons VALUES (19,'Vandi Mikela Balovna','Mexico','1976-11-20',null);
INSERT INTO persons VALUES (20,'Kilan Adgard Nakach','Mexico','1996-03-26',null);
INSERT INTO persons VALUES (21,'Kamrov Tiikn Palov','Mexico','1983-04-16',null);
INSERT INTO persons VALUES (22,'Janklod Van Dam','USA','1988-12-20',null);
INSERT INTO persons VALUES (23,'Trueman Mike Dimov','USA','1948-10-23','2000-10-20');
INSERT INTO persons VALUES (24,'Lunfish Kate Nikel','USA','1968-03-25','2014-09-29');
INSERT INTO persons VALUES (25,'Jan Jak Migel','France','1988-08-09',null);
INSERT INTO persons VALUES (26,'Mi Laura Aunti','France','1982-10-19',null);
INSERT INTO persons VALUES (27,'Per Del Tun','France','1962-10-19','2010-10-25');
INSERT INTO persons VALUES (28,'Shahmet Lui Tong','Egept','1969-12-29',null);
INSERT INTO persons VALUES (29,'Shooli Milay Youg','Egept','1999-02-22',null);
INSERT INTO persons VALUES (30,'Naomi Luisa Ken','UAR','1979-02-13',null);
INSERT INTO persons VALUES (31,'Ranefskay Faina Gregorevna','USSR','1896-08-27','1984-07-19');


INSERT INTO creators VALUES (1,1,'soundmaker',NULL);

INSERT INTO creators VALUES (1,1,'player','arab');
INSERT INTO creators VALUES (13,5,'producer',NULL);
INSERT INTO creators VALUES (3,4,'kompositor',NULL);
INSERT INTO creators VALUES (8,5,'player','plantotor');

INSERT INTO creators VALUES (1,27,'regiser',NULL);
INSERT INTO creators VALUES (2,12,'regiser',NULL);
INSERT INTO creators VALUES (2,13,'player','main');
INSERT INTO creators VALUES (2,9,'player','second');
INSERT INTO creators VALUES (2,30,'grimmer',NULL);
INSERT INTO creators VALUES (3,14,'player','main');
INSERT INTO creators VALUES (3,15,'produser',NULL);
INSERT INTO creators VALUES (3,23,'soundmaker',NULL);
INSERT INTO creators VALUES (4,8,'player','main');
INSERT INTO creators VALUES (4,8,'produser',NULL);
INSERT INTO creators VALUES (4,3,'regiser',NULL);
INSERT INTO creators VALUES (5,24,'player','main');
INSERT INTO creators VALUES (5,16,'player','second');
INSERT INTO creators VALUES (5,17,'regiser',NULL);
INSERT INTO creators VALUES (5,18,'produser',NULL);
INSERT INTO creators VALUES (5,18,'soundmaker',NULL);
INSERT INTO creators VALUES (6,19,'player','main');
INSERT INTO creators VALUES (6,20,'player','second');
INSERT INTO creators VALUES (6,20,'player','clon');
INSERT INTO creators VALUES (6,20,'produser',NULL);
INSERT INTO creators VALUES (6,21,'regiser',NULL);
INSERT INTO creators VALUES (6,30,'soundmaker',NULL);
INSERT INTO creators VALUES (7,31,'player','main');
INSERT INTO creators VALUES (7,10,'regiser',NULL);
INSERT INTO creators VALUES (7,11,'produser',NULL);
INSERT INTO creators VALUES (8,23,'player','main');
INSERT INTO creators VALUES (8,24,'player','second');
INSERT INTO creators VALUES (8,9,'regiser',NULL);
INSERT INTO creators VALUES (9,13,'player','main');
INSERT INTO creators VALUES (9,2,'player','boy');
INSERT INTO creators VALUES (9,22,'regiser',NULL);
INSERT INTO creators VALUES (10,25,'player','main');
INSERT INTO creators VALUES (10,26,'player','second');
INSERT INTO creators VALUES (10,27,'regiser',NULL);
INSERT INTO creators VALUES (11,2,'player','main');
INSERT INTO creators VALUES (11,3,'player','mama');
INSERT INTO creators VALUES (11,19,'produser',NULL);
INSERT INTO creators VALUES (12,29,'player','main');
INSERT INTO creators VALUES (12,9,'player','second');
INSERT INTO creators VALUES (12,18,'produser',NULL);
INSERT INTO creators VALUES (13,25,'player','main');
INSERT INTO creators VALUES (13,15,'player','second');
INSERT INTO creators VALUES (13,22,'regiser',NULL);
INSERT INTO creators VALUES (14,3,'produser',NULL);
INSERT INTO creators VALUES (14,8,'player','main');
INSERT INTO creators VALUES (14,30,'soundmaker',NULL);
INSERT INTO creators VALUES (14,25,'player','tump');
INSERT INTO creators VALUES (15,28,'player','main');
INSERT INTO creators VALUES (15,29,'player','second');
INSERT INTO creators VALUES (15,24,'regiser',NULL);
INSERT INTO creators VALUES (16,8,'player','main');
INSERT INTO creators VALUES (16,3,'player','second');
INSERT INTO creators VALUES (16,15,'player','gun');
INSERT INTO creators VALUES (16,17,'player','type');
INSERT INTO creators VALUES (16,12,'regiser',NULL);
INSERT INTO creators VALUES (16,22,'produser',NULL);
INSERT INTO creators VALUES (8,31,'player','aunt');
INSERT INTO creators VALUES (17,25,'player','main');
INSERT INTO creators VALUES (17,7,'player','moop');
INSERT INTO creators VALUES (17,3,'regiser',NULL);
INSERT INTO creators VALUES (17,20,'produser',NULL);
INSERT INTO creators VALUES (17,6,'player','plato');
INSERT INTO creators VALUES (17,18,'player','tok');
INSERT INTO creators VALUES (10,27,'player','third');
INSERT INTO creators VALUES (15,24,'player','man');
INSERT INTO creators VALUES (27,10,'player','youn');


select id, time_film(id) from films;

create or replace FUNCTION time_film(timep in number) 
return varchar 
is str_p varchar(50); 
begin
	str_p := to_char(trunc(timep)) || ' ч. ' || to_char(round(mod(timep, 1)*60)) || ' м.';
	return str_p;	
end;

BEGIN uchastniki(11); END;

create or replace procedure uchastniki(id_f in number)
is
temp_str varchar(100);
pl varchar(100);
begin
temp_str := '';
 select (films.namefilm||'(год выхода '||to_char(films.yeare)
		||', продолжительность '||time_film(films.timep)||')'||chr(10)||'Жанр: '||films.genre) into temp_str
		from films where films.id = id_f;
	dbms_output.put_line(temp_str);
	temp_str := '';
        pl := '#5';
for smth in (select c.charact as cc, listagg(p.fio||DECODE(role,'','',' ('||role||')'),', ' )
	within group (order by p.fio) as t
	from persons p, creators c
	where c.film = id_f and p.id = c.person
	group by c.charact)
	loop
                 temp_str := smth.cc;
		if(temp_str = 'player') then
			pl := smth.t;
		else
		dbms_output.put_line(smth.cc||'(-s): ' ||smth.t);
end if;
	end loop;

	if(pl != '#5') then
		dbms_output.put_line('player'||'(-s): '||chr(10) || REplace(pl,', ',chr(10)));
    end if;
end;


//trigger

create or replace trigger kino1
before
insert or update on films
for each row
declare 
temp_str varchar(100);
begin
    if(:new.timep*60 < 10) then
        raise_application_error(-20050,'продолжительность меньше 10 мин');
    end if;
    if(:new.yeare is null) then    
        :new.yeare := to_number(TO_CHAR(sysdate, 'YYYY'));
    end if;
    IF(TO_NUMBER(:NEW.YearE) > to_number(TO_CHAR(sysdate, 'YYYY'))) THEN
        raise_application_error(-20051,'ГОД БОЛЬШЕ ТЕКУЩЕГО');
    END IF;
    :new.country = trim(' ' from :new.country);
    temp_str := upper(:new.country);
IF(temp_str = upper('рф')) or (temp_str = upper('российская федерация')) THEN
        :NEW.COUNTRY := 'Россия';
    end if;
IF(temp_str = upper('великобритания') ) THEN
        :NEW.COUNTRY := 'Англия';
    end if;
IF (temp_str = upper('голландия'))  THEN
        :NEW.COUNTRY := 'Нидерланды';
    end if;
IF(temp_str = upper('кнр'))  THEN
        :NEW.COUNTRY := 'Китай';
    end if;

end;
/
INSERT INTO films(id,namefilm,studio,country,timep,genre) VALUES (21,'Muravii1','Phantom1','РФ',1.01,'horor');


	create table films_log_delet
	(
	 id numeric(6) primary key not null,
	 NameFilm varchar(50) not null,
	 Studio varchar(50) not null,
	 YearE numeric(4) not null,
	 Country varchar(30),
	 TimeP numeric(4,2) not null,
	 Genre varchar(30) references genres not null,
	 d_date date not null,
	 user_l varchar(35) not null);


create or replace trigger del_film
after delete on films
for each row
begin
	insert into films_log_delet values(:old.id, :old.namefilm, :old.studio,:old.yeare, :old.country, :old.timep, :old.genre, sysdate, substr(user,1,30));	
end;





















///mysop
create or replace trigger kino1
before
insert or update on films
for each row
declare 
temp_str varchar(100);
begin
	if(:new.timep*60 < 10) then
		raise_application_error(-20050,'продолжительность меньше 10 мин');
	end if;
	if(:new.yeare is null) then	
		:new.yeare := to_number(TO_CHAR(sysdate, 'YYYY'));
	end if;
	IF(TO_NUMBER(:NEW.YearE) > to_number(TO_CHAR(sysdate, 'YYYY'))) THEN
		raise_application_error(-20051,'ГОД БОЛЬШЕ ТЕКУЩЕГО');
	END IF;
	:new.country = trim(' ' from :new.country);
	temp_str := upper(:new.country);
	IF(temp_str = upper('рф')) or (temp_str = upper('российская федерация') THEN
		:NEW.COUNTRY := 'Россия';
	end if;
	IF(temp_str = upper('великобритания')  THEN
		:NEW.COUNTRY := 'Англия';
	end if;
	IF (temp_str = upper('голландия')  THEN
		:NEW.COUNTRY := 'Нидерланды';
	end if;
	IF(temp_str = upper('кнр')  THEN
		:NEW.COUNTRY := 'Китай';
	end if;

end;
/




create or replace trigger kino1
before
insert or update on films
for each row
declare 
temp_str varchar(100);
begin
    if(:new.timep*60 < 10) then
        raise_application_error(-20050,'продолжительность меньше 10 мин');
    end if;
    if(:new.yeare is null) then    
        :new.yeare := to_number(TO_CHAR(sysdate, 'YYYY'));
    end if;
    IF(TO_NUMBER(:NEW.YearE) > to_number(TO_CHAR(sysdate, 'YYYY'))) THEN
        raise_application_error(-20051,'ГОД БОЛЬШЕ ТЕКУЩЕГО');
    END IF;
    temp_str := upper(trim(' ' from :new.country));
    dbms_output.put_line(temp_str);
IF(temp_str = upper('рф')) THEN        
        raise_application_error(-20052,);
    end if;
    
end;