# AngularDotNetCoreAppInDocker

A very simple sample using Angular, ASP.NET Core and Docker.

The application is a basic CRUD of clients and their addresses. The goal was just to get Docker Compose to run an application composed by a frontend Angular app, a backend ASP.NET WebApi using a SQL Server database.

##Running

docker-compose up on the repository root will build the container images and then run all the containers. For run daemon mode include -d argument.


## Usage

```
APP: http://localhost:4000
API: http://localhost:5000/api
SWAGGER: http://localhost:5000/swagger
```
