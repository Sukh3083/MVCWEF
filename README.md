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

![image](https://user-images.githubusercontent.com/32491392/139459903-8971adaa-c224-4291-ad07-174c30f4ec64.png)


Wrote code using ASP.NET core framework, In which All the CRUD operations are there.

After running the Application, Below urls can be used: 

List all persons: https://localhost:44353/Person
![image](https://user-images.githubusercontent.com/32491392/139460011-b46657b3-a5c8-4568-b358-cdc7e30c5c79.png)

TO Create new person: https://localhost:44353/Person/Create
![image](https://user-images.githubusercontent.com/32491392/139460097-9d80c208-c7bc-41d0-9f00-6e9b52de229e.png)


To edit existing: https://localhost:44353/person/edit/2

![image](https://user-images.githubusercontent.com/32491392/139460166-3e82f5f4-f392-4e4f-a89a-7a532f0fb457.png)

![image](https://user-images.githubusercontent.com/32491392/139460235-e16d0c5c-691b-420d-a79e-faf103e3a4bd.png)

To delete existing: https://localhost:44353/person/delete/2

![image](https://user-images.githubusercontent.com/32491392/139460314-a6772b78-4f69-4fe3-afde-18c6659e840c.png)






