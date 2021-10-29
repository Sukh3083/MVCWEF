# MVCWEF

Description: In this Project, I have created a database (crypto_db) in MySQL and a table named person in it.
create schema crypto_db;

CREATE TABLE Person (
    ID int NOT NULL AUTO_INCREMENT,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    salary int,
    dob DATE,
    PRIMARY KEY (ID)
);


Wrote code using ASP.NET core framework, In which All the CRUD operations are there.

After running the Application, Below urls can be used: 

List all persons: https://localhost:44353/Person

TO Create new person: https://localhost:44353/Person/Create

To edit existing: https://localhost:44353/person/edit/2

To delete existing: https://localhost:44353/person/delete/2



