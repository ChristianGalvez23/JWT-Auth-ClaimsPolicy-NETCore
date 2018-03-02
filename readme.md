# Authorization using Claims Policy

Hi everyone, I bring you a project which I implement Json Web Token as authentication security as always but this time I incorporated Authorization adding a new claim to the process of generate the token in sign in.

In this solution I am using [Migrations](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations) so you don't have to handle Sql Server.

## Steps

You have to go to API folder and run `dotnet run` to get APIRest available, database get created and filled.

## Test

If you want to validate authorization functionality in NET Core you have to use [Postman](https://www.getpostman.com/) to call endpoints with bearer token.

Migrations at the project start up creates two kind of users (user - password values):

* Admin Jhon (jhon@int.com - 123456)
* Common user Peter (peter@int.com - 123456)

## Endpoints

### **api/signin**

Use this endpoint to sign in and get your token with the previous users in Test section.

### **api/register**

To register a new user. To know the fields that you have to send, please open the project and check it.

### **api/users**

This endpoint is just for common users so that admin doesn't have access to it.

### **api/admins**

Just for admin users.

### **api/articles**

For authenticated users.

### **api/books**

For anonymous users.
