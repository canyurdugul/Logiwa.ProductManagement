# Logiwa.ProductManagement

## Init

* You need to change connection string configuration in appsettings.Development.json and appsettings.Production.json files.

```sh
...
"ConnectionStrings": {
    "MsSqlDefaultConnection": "Server=localhost;Database=Dev_LogiwaProductManagement;User Id=XX;Password=XX"
  },
...
```

* Then init database using by package manager console. **Logiwa.ProductManagement.Client.Api** project needs to be startup project then work on **Logiwa.ProductManagement.Database** project on package manager console.

```sh
... // First command for create migration
add-migration InitMigration
... // Second command for migrate database
update-database
...
```

* For frontend environment (Angular 13)
Go to \frontend\logiwa-product-management folder and run
```sh
npm i
```