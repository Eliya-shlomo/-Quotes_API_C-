# Philosophers Quotes API

A RESTful API for managing and retrieving quotes by famous philosophers, built using ASP.NET Core and MongoDB.

## Features

- Add quotes by philosophers.
- Retrieve all quotes.
- Retrieve quotes by a specific philosopher.
- Retrieve a quote by its ID.
- Update or delete quotes.

---

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher)
- [MongoDB](https://www.mongodb.com/try/download/community) (Running locally or in the cloud)
- [Postman](https://www.postman.com/) (Optional, for API testing)

---

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/philosophers-quotes-api.git
   cd philosophers-quotes-api
### Install dependencies:
```bash
dotnet restore
```
### Update appsettings.json with your MongoDB connection string:
``` json
{
  "DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "PhilosophersDb",
    "CollectionName": "Quotes"
  }
}
```
### start the API
``` bash
dotnet run
```
