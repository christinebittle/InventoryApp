# InventoryApp

Connects to a sample DB "test" on a locally hosted MongoDB to retrieve a list of inventory items.

## Installation Steps

- download msi file from (https://www.mongodb.com/try/download/community?tck=docs_server)

- run msi file

- uncheck as a service

- check mongodb compass (similar to phpmyadmin)

- open cmd prompt

- navigate to C:/
```
> md "\data\db"
> cd \data\db
> "C:\Program Files\MongoDB\Server\4.4\bin\mongod.exe" --dbpath="c:\data\db"
```
- leave running, new cmd prompt terminal
```
> "C:\Program Files\MongoDB\Server\4.4\bin\mongo.exe"
```
- get connection string properties
```
> db.inventory.insertMany([
   { item: "journal", qty: 25, status: "A", size: { h: 14, w: 21, uom: "cm" }, tags: [ "blank", "red" ] },
   { item: "notebook", qty: 50, status: "A", size: { h: 8.5, w: 11, uom: "in" }, tags: [ "red", "blank" ] },
   { item: "paper", qty: 10, status: "D", size: { h: 8.5, w: 11, uom: "in" }, tags: [ "red", "blank", "plain" ] },
   { item: "planner", qty: 0, status: "D", size: { h: 22.85, w: 30, uom: "cm" }, tags: [ "blank", "red" ] },
   { item: "postcard", qty: 45, status: "A", size: { h: 10, w: 15.25, uom: "cm" }, tags: [ "blue" ] }
]);
```
- run visual studio project
