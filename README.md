
<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

In olap-app file type !
* npm
  ```sh
  npm install
  ```
  
In olap-api file change databas name in connection string !
* Conection string example
  ```sh
  "ConnectionString": "server=localhost\\SQLEXPRESS;database=olap;Password=;Trusted_Connection=true;TrustServerCertificate=true"
  ```
  
Then add migration !
* Create migration command
  ```sh
  Add-Migration "migration name"
  ```
  
And final step update database !
* Database update comman
  ```sh
  Update-Database
  ```
  
