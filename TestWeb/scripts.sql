--create database VacationManagement;

--use database VacationManagement;

create table Employees (
    Id int not null primary key identity,
    Name nvarchar(128) not null,
    Surname nvarchar(128) not null,
);

insert into Employees (Name, Surname) values
('Mario', 'Rossi'),
('Luigi', 'Neri'),
('Anna', 'Gialli'),
('Barbara', 'Arancioni'),
('Carla', 'Bruni'),
('Elena', 'Rossi');

create table Vacations (
    Id int not null primary key identity,
    Start datetime not null,
    End datetime not null,
    EmployeeId int not null references Employees (Id)
);
