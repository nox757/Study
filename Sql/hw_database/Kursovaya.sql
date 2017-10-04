create table providers
(
id_p numeric(3) primary key not null,
name_p varchar(30) not null,
address_p varchar(100) not null,
phone_p varchar(10) not null,
contname_p varchar(30)
);

create table postavkifruits
(
id_pf numeric(3) primary key not null,
name_pf varchar(30) references typefruit,
datesbor_pf date not null,
srok_pf date not null,
weigth_pf numeric(10) not null,
edizm_pf varchar(20) references edizm,
price_pf numeric(10) not null,
country_pf varchar(50) references countries,
postavshik_pf numeric(3) references providers,
datepost_pf date not null
);

create table typefruit
(
name_f varchar(30) primary key not null
);

create table countries
(
name_count varchar(50) primary key not null
);

create table edizm
(
name_ed varchar(20) primary key not null,
sistmer_ed varchar(20) not null
);

create table sostav
(
id_s numeric(3) primary key not null,
prod_s numeric(3) references production,
fruct_s numeric(3) references postavkifruits,
mas_s numeric(3) not null,
edizm_s varchar(20) references edizm
);

create table production
(
id_prod numeric(3) primary key not null,
name_prod varchar(50) references nameprod,
type_prod varchar(30) references typesypak,
date_prod date not null,
srok_prod date not null,
otd_prod numeric(3) references otdel,
mas_prod numeric(10) not null,
edizm_prod varchar(20) references edizm
);

create table nameprod
(
name_pr varchar(50) primary key not null
);

create table typesypak
(
name_t varchar(30) primary key not null
);

create table otdel
(
id_o numeric(3) primary key not null,
name_o varchar(30) not null,
phone_o varchar(10) not null,
spec_o varchar(20) not null,
);

create table employees
(
id_e numeric(3) primary key not null,
fname_e varchar(25) not null,
lname_e varchar(40) not null,
born_e date not null,
sex_e char(1) not null,
sernum_e char(10) not null,
date_e date not null,
given_e varchar(50) not null,
inn_e char(12) not null,
snils_e char(14) not null,
address_e varchar(100) not null,
phone_e varchar(10),
otdel_e numeric(3) references otdel,
dolzn_e varchar(30) references dolznosti
);

create table dolznosti
(
name_dol varchar(30) primary key not null,
sal_dol numeric(10,2) not null check(sal_dol>=6250) 
);

create table obrazovanie
(
id_obr numeric(3) references employees
type_obr numeric(15) not null,
spec_obr varchar(30),
date_obr date not null,
numdip_obr numeric(15)
);

providers:
(001, 'JFC', 'Ecvador, Palma, Panamskaya, 38', 9436456591, Achot)
(002, 'Sunway', 'Marocco, Settat, Attaef, 12', 9483632345, Peter)
(003, 'Сорус', 'Russia, Sochi, Morskaya, 84', 9585462346, Vladimir)
(004, 'F-company', 'Senehal, Touba, N3, 16', 9963523424,)
(005, 'Megafruct', 'China, Pekin, Mira, 46', 9679754526, Kim)
(006, 'FruitPost', 'Gvinea, Conakry, Dubreka, 64', 9874545652, Alex)
(007, 'PFC', 'Portugal, Lisboa, Ponte, 43', 9966242522,)
(008, 'MexicaCompany', 'Mexica, Mexico, Piedad, 98', 9658871132, Chak);

postavkifruits:
(100, 'Банан', '2016-03-12', '2016-04-22', 43, )

typefruit:
('Банан')
('Апельсин')
('Яблоко')
('Виноград')
('Абрикос')
('Ананас')
('Арбуз')
('Гранат')
('Груша')
('Дыня')
('Клубника')
('Инжир')
('Киви')
('Лайм')
('Лимон')
('Мандарин')
('Персик')
('Помело')
('Вишня')
('Слива');

countries:
('Армения')
('Азербайджан')
('Россия')
('Китай')
('Мексика')
('Марокко')
('Гвинея')
('Сенегал')
('Гана')
('Алжир')
('Бенин')
('Гамбия')
('Аргентина')
('Мавритания')
('Того')
('Испания')
('Армения');

edizm:
('kg','Metric')


"Название поставщиков, от которых не было поставок фруктов"
select p.id_p, p.name_p, from providers p
where NOT EXISTS (select * from postavkifruits pf
where p.id_p = pf.postavshik_pf);

"кол-во произведенной продукции за прошлый месяц и какие использовались типы упаковок"
select count(name_prod), type_prod from production 
where month(date_prod) = month(now())-1;



"продукция, в состав которой входит несколько фруктов и их кол-во(масса)"
select prod.*, sum(s.mas_s) from production prod, sostav s  
where sum(select s.prod_s from sostav s)>2 and prod.id_prod = s.prod_s;

"названия фруктов, срок годности которых в поставке истекает через 5 дней"
select name_pf from postavkifruits 
where day(srok_pf) = day(now())+5; 

"вывод поставок с группировкой по названию в порядке убывания свежести"
select * from postavkifruits
group by name_pf 
order by srok_pf;








