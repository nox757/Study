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
weigth_pf numeric(10,6) not null check (weigth_pf > 0),
edizm_pf varchar(20) references edizm,
price_pf numeric(10,2) not null check (price_pf >= 0),
country_pf varchar(50) references countries,
postavshik_pf numeric(3) references providers,
datesbor_pf date not null,
datepost_pf date not null check ((datepost_pf >= datesbor_pf) and datepost_pf <= now()),
srok_pf date not null check (srok_pf > datepost_pf)
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
sistmer_ed varchar(20) not null,
kg_ed numeric(10,6) not null check (kg_ed > 0)
);

create table sostav
(
id_s numeric(3) primary key not null,
prod_s numeric(3) references production,
fruct_s numeric(3) references postavkifruits,
mas_s numeric(10,6) not null check (mas_s > 0),
edizm_s varchar(20) references edizm
);

create table production
(
id_prod numeric(3) primary key not null,
name_prod varchar(50) references nameprod,
type_prod varchar(30) references typesupak,
date_prod date not null,
srok_prod date not null check(srok_prod > date_prod),
otd_prod numeric(3) references otdels,
mas_prod numeric(10,6) not null check(mas_prod > 0),
edizm_prod varchar(20) references edizm
);

create table nameprod
(
name_pr varchar(50) primary key not null
);

create table typeupak
(
name_t varchar(30) primary key not null
);

create table otdels
(
id_o numeric(3) primary key not null,
name_o varchar(30) not null,
phone_o varchar(10) not null,
spec_o varchar(20) not null
);

create table employees
(
id_e numeric(3) primary key not null,
fname_e varchar(25) not null,
lname_e varchar(40) not null,
born_e date not null,
sex_e char(1) not null,
sernum_e char(10) not null unique,
date_e date not null,
given_e varchar(50) not null,
inn_e char(12) not null unique,
snils_e char(14) not null unique,
address_e varchar(100) not null,
phone_e varchar(10),
otdel_e numeric(3) references otdels,
dolgn_e varchar(30) references dolgnosti,
login_e varchar(15)
);

create table dolgnosti
(
name_dol varchar(30) primary key not null,
sal_dol numeric(10,2) not null check(sal_dol>=6250) 
);

create table obrazovanie
(
id_obr numeric(3) references employees,
type_obr varchar(15) not null,
spec_obr varchar(30),
date_obr date not null,
numdip_obr numeric(15)
);

providers:
(001, 'JFC', 'Ecvador, Palma, Panamskaya, 38', '9436456591', Achot)
(002, 'Sunway', 'Marocco, Settat, Attaef, 12', '9483632345', Peter)
(003, 'Сорус', 'Russia, Sochi, Morskaya, 84', '9585462346', Vladimir)
(004, 'F-company', 'Senehal, Touba, N3, 16', '9963523424',)
(005, 'Megafruct', 'China, Pekin, Mira, 46', '9679754526', Kim)
(006, 'FruitPost', 'Gvinea, Conakry, Dubreka, 64', '9874545652', Alex)
(007, 'PFC', 'Portugal, Lisboa, Ponte, 43', '9966242522',)
(008, 'MexicaCompany', 'Mexica, Mexico, Piedad, 98', '9658871132', Chak);

postavkifruits:
(100, 'Банан', '2016-03-12', '2016-04-22', 43, kg, 100, 'Армения', '001', '2016-03-17')
(101, 'Апельсин', '2016-02-10', '2016-03-12', 10, pud, 1001, 'Россия', '003', '2016-02-20')
(102, 'Инжир', '2016-01-11', '2016-04-21', 100, funt, 522, 'Мавритания', '002', '2016-02-15')
(103, 'Клубника', '2016-03-10', '2016-04-25', 56, kg, 624, 'Испания', '007', '2016-03-15')


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
('kg','Metric', 1)
('funt','American', 0.5)
('drahma','Britan', 0.1)
('pud','Russian', 16)
('marka','European', 2);

sostav:
(111, 211, 100, 30, 'kg')
(112, 212, 101, 36, 'kg')
(113, 213, 102, 156, 'funt')
(114, 216, 101, 0.1, 'pud');

production:
(211, 'ААААААА', 'Картон', '2016-04-25', '2016-08-25', 311, 12, 'kg')
(212, 'ббббббб', 'Консерва', '2016-04-21', '2016-06-21', 312, 16, 'kg')
(213, 'ВВВВВВВ', 'Банка', '2016-04-22', '2016-07-22', 313, 0.1, 'pud')
(214, 'Гагагаг', 'Картон', '2016-04-23', '2016-08-23', 311, 100, 'funt')
(215, 'ДДВАРЛв', 'Банка', '2016-04-24', '2016-09-28', 313, 15, 'kg')
(216, 'Пшено', 'Склянка', '2016-04-25', '2016-07-21', 314, 3, 'kg');

nameprod:
('ААААААА')
('ббббббб')
('ВВВВВВВ')
('Гагагаг')
('ДДВАРЛв')
('HHHHHHHYY')
('Пшено');

typeupak:
('Картон')
('Банка')
('Склянка')
('Консерва');

otdels:
(311, 'джемовый', '9438456541', 'джем')
(312, 'вареньевый', '9436456551', 'варенье')
(313, 'консервный', '9436456543', 'консервы')
(314, 'Черная меза', '9436456547', 'фигня');

employees:
(411, 'Евтушенко', 'Никита Сергеевич', '1982-01-03', 'м', '5614678457', '1996-02-25', 'УФМС УКР', '012345678912', '01234567891234', 'ООООООО', '9779745521', 311, 'Начальник')
(412, 'Порошенко', 'петр', '1978-01-03', 'м', '6784968247', '1994-02-25', 'УФМС УКР', '012345678900', '01234567890000', 'ООЛПОАН', '', 312, 'Рабочий')
(413, 'Галайко', 'Евгения генадиевна', '1989-01-03', 'ж', '9375836501', '2009-02-25', 'УФМС УКРом', '987654321012', '98765432101234', 'ОООООООвар', '9779745554', 314, 'Кадровик')
(414, 'Четверенко', 'Прохор Прохорович', '2000-01-03', 'м', '6739671234', '2014-02-25', 'УФМС УКР', '012345679821', '01234567984321', 'ОООООООукр', '', 312, 'Рабочий');

dolgnosti:
('Начальник', 80000)
('Рабочий', 10000)
('Консультант', 30500)
('Кадровик', 74000);

obrazovanie:
(411, 'высшее', 'ггггггг', '2000-06-30', 012345678912345)
(412, 'среднее', '', '1998-06-30', 012345678912375)
(413, 'низшее', 'гггыппы', '2015-06-30', )
(414, 'ниже плинтуса', 'гаврпыр', '2016-06-30', 012345678912896);


/*1даннные об участниках отдела, где работает сотрудник*/
create or replace view my_kollegi( Familiya, Name, Dolgnost, Tel) as
	select e1.fname_e, e1.lname_e, e1.dolgn_e, e1.phone_e
	from employees e1
	where exists (select * 
				from employees e
				where e.otdel_e = e1.otdel_e and e.login_e = user());
/*2даннные о других начальниках отделов, для нач. отдела*/
create or replace view other_nach( Num_otdel,Familiya, Name, Tel) as
	select e1.otdel_e, e1.fname_e, e1.lname_e, e1.phone_e/*исключить некоторые поля*/
	from employees e1
	where exists (select * 
				from employees e
				where e.otdel_e <> e1.otdel_e and e.login_e = user() 
				and e.dolgn_e = e1.dolgn_e);
/*3Название поставщиков, от которых не было поставок фруктов"*/
create or replace view no_postavok(ID, NAME_Provider) as
	select p.id_p, p.name_p from providers p
	where NOT EXISTS (select * from postavkifruits pf
				where p.id_p = pf.postavshik_pf);
/*4????продукция, в состав которой входит несколько фруктов и их кол-во*/
create  or replace view no_single_prod(ID, NAME_Postavki, kol_vo) as
	select prod.id_prod, prod.name_prod, (select count(*)
			from  sostav s  
			where prod.id_prod = s.prod_s) as cnt
	from production prod
	having cnt > 1;
/*5количество продукции по категории названию варенье внучка 5*/	
create or replace view cnt_production(kateg, name, kol_vo) as
	select o.spec_o, prod.name_prod, count(*)
	from production prod, otdels o
	where prod.otd_prod = o.id_o
	group by o.spec_o, prod.name_prod;
/*6стоимость статистика по странам*/
create or replace view 	sum_postavki(country, cost) as
	select pf.country_pf , sum(pf.price_pf)
	from postavkifruits pf
	group by pf.country_pf;
/*7поставщики, поставляющие фрукты из разных стран*/
create or replace view many_countries(ID, Name, Phone, kolvo_country) as
	select p.id_p, p.name_p, p.phone_p,
		(select count(distinct pf.country_pf)
		from postavkifruits pf
		where p.id_p = pf.postavshik_pf) as cnt_country 
	from providers p
	having cnt_country > 1;
/*8???сколько в среднем проходит дней с поставки до производства продукции*/
create or replace view dneysr (ID_prod, avg_day) as
	select prod.id_prod, avg(datediff(prod.date_prod, spf.d))
	from production prod, (select 
					s.prod_s as pr, pf.datepost_pf as d
					from sostav s, postavkifruits pf
					where 
					s.fruct_s = pf.id_pf					
				) as spf
	where spf.pr = prod.id_prod
	group by prod.id_prod;
/*9???самые дешевые поставщики за кг одной и той же продукции*/
create or replace view cheaper_postavki (id_postav, name, postavshik, min_price) as
	select pf0.id_pf, pf0.name_pf, pf0.postavshik_pf, mn.min_pf
	from postavkifruits pf0, (
		select pf.name_pf as name, min(pf.price_pf / to_kg(pf.weigth_pf, pf.edizm_pf)) as min_pf
		from postavkifruits pf
		group by pf.name_pf) as mn
	where mn.name = pf0.name_pf 
	and  pf0.price_pf / to_kg(pf0.weigth_pf, pf0.edizm_pf) - mn.min_pf <= 0.000001;
/*10остаток поставок(то есть неиспользуемые для производства поставки)*/
create or replace view ostatki_postavok(ID, Name, Weight) as
	select p0.id_pf, p0.name_pf, to_kg(p0.weigth_pf, p0.edizm_pf)
	from postavkifruits p0
	where  not exists (						
				select * 
				from sostav s
				where s.fruct_s = p0.id_pf		
				)				
	union
		select p0.id_pf, p0.name_pf, to_kg(p0.weigth_pf, p0.edizm_pf) - p1.sum_
		from postavkifruits p0, 					
			(select p.id_pf as id_pf, sum(to_kg(s.mas_s, s.edizm_s)) as sum_
				from sostav s, postavkifruits p
				where s.fruct_s = p.id_pf		
				group by p.id_pf 
			) as p1
		where p0.id_pf = p1.id_pf
		and p1.sum_ < to_kg(p0.weigth_pf, p0.edizm_pf);
/*+функция перевода в кг*/
delimiter //
create function to_kg (weigth_ numeric(10,6), ed varchar(20))
returns numeric(10,6) 	 
begin
	declare perem numeric(10,6) ;
	set perem = -1;
	select edizm.kg_ed into perem from edizm where ed = edizm.name_ed;	
		if (perem = -1) then
			signal sqlstate '45000' set 
			message_text = 'нет такой ед.изм';  
		end if;
	return perem*weigth_;
end;	//
delimiter ;
 --or update of fruct_s, prod_s
/*триггер проверяет наличие уже такого состава на тот же продукт и поставку  */
delimiter //
create  trigger sost 
		before 
		insert
		on sostav
		for each row
begin
	DECLARE	 cnt1 numeric;
	DECLARE	 cnt2 numeric;
	DECLARE	 cnt3 numeric;
	select count(*) into cnt1 
	from postavkifruits as pf
	where new.fruct_s = pf.id_pf;
	select count(*) into cnt2 
	from production as p
	where new.prod_s = p.id_prod;
	select count(*) into cnt3 
	from sostav as s
	where new.fruct_s = s.fruct_s and new.prod_s = s.prod_s;
	if not(cnt1 > 0 and cnt2 > 0 and cnt3 = 0) then		
		signal sqlstate '45000' set 
		message_text = 'такая запись уже есть(обновляйте значение  массы)';  
	end if;
end; //
delimiter ;

/*триггер проверка работника*/
--возможно можно что то еще добавить
delimiter //
create trigger proverka before insert on employees
for each row
begin
	if((year(curdate()) - year(new.born_e) - 
	(date_format(curdate(),'00-%m-%d') < date_format(new.born_e,'00-%m-%d'))) < 16) then
		signal sqlstate '45000' set 
		message_text = 'Человеку меньше 16 лет';  
	end if;
	if ((year(new.date_e) - year(new.born_e) - 
	(date_format(new.date_e,'00-%m-%d') < date_format(new.born_e,'00-%m-%d'))) < 14) then
		signal sqlstate '45000' set 
		message_text = 'Неверная дата выдачи паспорта';		
	end if;
	set new.sex_e := lower(new.sex_e);
	set new.fname_e := upper(new.fname_e);
	set new.lname_e := upper(new.lname_e);
end; //
delimiter ;	

/*создает этикетки для всех продукций c указанной даты по текущую название состав, масса брутто, масса нетто*/	

--исправленный вариант
delimiter //
create procedure etiketka(d date)	 
begin
	declare mas numeric(10,6) default 0;
	declare cnt numeric(5) default 0;
	declare kat varchar(20);
	declare etik text;
	declare l_eof bool default false;
	declare otd_prod1 numeric(3);
	declare name_prod1 varchar(50);
	declare id_prod1 numeric(3);
	declare mas_prod1 numeric(10,6);
	declare date_prod1 date;
	declare edizm_prod1 varchar(20);
	declare crs1 cursor for select otd_prod, name_prod, id_prod, mas_prod, date_prod, edizm_prod
					from production 
					where date_prod between d and now();
	declare continue handler for not found set	l_eof = true;	
	open crs1;
	l1:	loop			
			set etik = '';
			fetch crs1 into otd_prod1, name_prod1, id_prod1, mas_prod1, date_prod1, edizm_prod1;
			select o.spec_o into kat from otdels o where o.id_o = otd_prod1;
			set etik = concat_ws(' ',etik,'-=Etiketka=- ', kat , name_prod1);
			set etik = concat_ws('\n',etik, '-=Sostav:=-');
			set mas = 0;			
			if l_eof then
				leave l1;
			end if;
			set cnt = cnt + 1; 
			begin				
				declare weigth_pf1 numeric(10,6);
				declare edizm_s1 varchar(20);
				declare name_pf1 varchar(30);
				declare crs2 cursor for select weigth_pf, edizm_s, name_pf 
					from sostav s, postavkifruits pf
					where id_prod1 = s.prod_s and pf.id_pf = s.fruct_s;
				open crs2;
				l2:	loop
						fetch crs2 into weigth_pf1, edizm_s1, name_pf1;
						if l_eof then							
							leave l2;
						end if;
						set mas = mas + to_kg(weigth_pf1, edizm_s1);
						set etik = concat_ws('\n',etik, name_pf1);
					end loop l2;
				close crs2;
				set l_eof = false;
			end;
			set mas_prod1 = to_kg(mas_prod1,edizm_prod1);
			set etik = concat_ws('\n',etik, 'Massa netto kg:', mas_prod1 - mas);
			set etik = concat_ws('\n',etik, 'Massa brytto kg:',mas_prod1);
			set etik = concat_ws('\n',etik, 'Goden do:',date_prod1);	
			select etik;
		end loop l1;
		set etik = concat_ws('_','After date: ', d, 'have', cnt, 'prodaction');
		select etik;
		close crs1;
end; //
delimiter ;	

