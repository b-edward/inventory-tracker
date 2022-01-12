## Inventory Tracker Web Application

The Inventory Tracker is a web application for a logistics company. It was developed in ASP.NET and is hosted on Microsoft Azure App Service. It presents the user interface, allowing basic CRUD Functionality. The application will validate user input, create SQL queries, send the query request to the DataServer via TCP/IP, parse the response and display it.

The user is able to:
* Create products, items, and warehouses
* Edit them
* Delete them [see note]
* View a list of one or more items, products, or warehouses
* Assign an item to a warehouse
* View a list of items in a warehouse
* View a list of warehouses with a product in stock

Notes: 
* Products represent a type of item, for example "Snowboard"
* Items represent individual units of a product, for example "Item #2006", which happens to be a Snowboard
* An item can be unnassigned, or assigned to only one warehouse at a time
* Items, products and warehouses are not actually deleted, but set to inactive (or sold)
* Only warehouse items are deleted


## Data Server Web Service

The data access component is accomplished by the Data Server project. It was developed as a .NET console application, hosted on a Microsoft Azure Virtual Machine. It functions as a web API service and allows clients to access the MySQL database via TCP/IP. 

The DataServer has a custom protocol, *loosely* based on REST/HTTP. 

Requests must:
* Start with a verb command followed by a new line character (\n)
* Commands supported are PUT, GET, POST, and DELETE
* Finally, a SQL query string corresponding to the command
* For example: "GET\nSELECT * FROM 'Item';" will return all data from the Item table

Responses:
* Start with an HTTP status code, followed by a new line character
* If returning a read request, the data follows
* Read data is formatted with a comma ',' separating each field, and an ampersand '&' separating each record/row