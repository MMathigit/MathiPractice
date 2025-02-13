create table account(
account_number int primary key identity (20,1),
acc_name varchar(50) not null,
account_type varchar(50) not null,
acc_address varchar(200),
amount money )

create table [transaction](
id int primary key identity (1,1),
transaction_type varchar(50) not null,
amount money,
account_id int references account(account_number))

select * from account

--inserting the datas in to the account table

insert into account(acc_name,account_type,acc_address,amount) values ('Mathi','Saving','Chennai',10000)
insert into account(acc_name,account_type,acc_address,amount) values ('Pavu','Current','Coimbatore',50000)
insert into account(acc_name,account_type,acc_address,amount) values ('Deep','Saving','Trichy',30000)
insert into account(acc_name,account_type,acc_address,amount) values ('Vanu','Current','Cuddalore',70000)


--inserting the datas in to the transaction table

insert into [transaction](transaction_type,account_id,amount) values ('withdraw',20,2000)
insert into [transaction](transaction_type,account_id,amount) values ('Deposit',21,5000)
insert into [transaction](transaction_type,account_id,amount) values ('withdraw',20,300)

insert into [transaction](transaction_type,account_id,amount) values ('withdraw',20,2500)
insert into [transaction](transaction_type,account_id,amount) values ('Deposit',21,5400)
insert into [transaction](transaction_type,account_id,amount) values ('withdraw',23,4000)