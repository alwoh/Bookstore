# Bookstore Project
This is a bookstore that uses .NET Core 9, EF, SQL Server as a back-end.  With a SPA front-end using Angular 19 and Bootstrap.

<img src="https://github.com/alwoh/alwoh/blob/main/images/Bookstore-SPA.gif" width="100%" alt="Bookstore"/>
      
## How It's Made:
There's an application, domain, infrastructure, and SPA layers to this bookstore app.  

1. Install [.NET Core 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
2. Install the latest [Node.js LTS](https://nodejs.org/en/)
3. To run this application you'll first need to edit the database connection string under **Bookstore.API/appsettings.json** `ConnectionStrings->DefaultConnection`.
4. Then navigate to the Bookstore.Infrastructure project folder and run `dotnet ef migrations add InitialCreate` then after apply it with `dotnet ef database update`
5. Navigate to the solution folder `dotnet build` then navigate to the API project folder `dotnet run`
   - This will supply Swagger UI to **localhost:5001**
6. To run Bookstore.SPA navigate to it's folder
   - first install Angular `npm install -g @angular/cli`
   - second run `ng s`
   - This will use **localhost:4200** 

**Tech used:** 
<div align="center">
	<table>
		<tr>
			<td>.NET Core <br /><code><img width="50" src="https://raw.githubusercontent.com/marwin1991/profile-technology-icons/refs/heads/main/icons/_net_core.png" alt=".NET Core" title=".NET Core"/></code></td>
			<td>MS SQL Server <br /><code><img width="50" src="https://raw.githubusercontent.com/marwin1991/profile-technology-icons/refs/heads/main/icons/mssql.png" alt="MSSQL" title="MSSQL"/></code></td>
			<td>Angular <br /><code><img width="50" src="https://raw.githubusercontent.com/marwin1991/profile-technology-icons/refs/heads/main/icons/angular.png" alt="Angular" title="Angular"/></code></td>
   <td>Bootstrap <br /><code><img width="50" src="https://raw.githubusercontent.com/marwin1991/profile-technology-icons/refs/heads/main/icons/bootstrap.png" alt="Bootstrap" title="Bootstrap"/></code></td>			
			<td>Swagger UI <br /><code><img width="50" src="https://raw.githubusercontent.com/marwin1991/profile-technology-icons/refs/heads/main/icons/swagger.png" alt="Swagger" title="Swagger"/></code></td>			
		</tr>
	</table>
</div>

