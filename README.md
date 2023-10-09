# Flow Provider Documentation

This documentation provides an overview of the Flow Provider project, its architecture, and key components.

## Introduction

Flow Provider is a platform designed to manage programs, including program details, application forms, and stages. It is built using Microsoft Azure Cosmos DB and provides APIs for program management.

## Usage

### PreviewController

#### `GetPreview(string programId)`

- Get a preview of program details.

### ProgramController

#### `GetProgram(string programId)`

- Retrieve program details by program ID.

#### `CreateProgram(ProgramBindingModel model)`

- Create a new program.

#### `Update(ProgramUpdateModel model)`

- Update program details.


### AppTemplateController

#### `GetSingle(string programId)`

- Retrieve Application Form details by program ID.

#### `Update`

- Update Application Form details.
  

### WorkFlowController

#### `GetSingle(string programId)`

- Retrieve WorkFlow details by program ID.


#### `Update`

- Update WorkFlow details.

## Installation

Clone the repository and configure your Azure Cosmos DB connection in the `appsettings.json` file.

```json
{
  "ConnectionStrings": {
    "DatabaseId": "Your-Database-ID",
    // Add other connection settings here
  }
}
```

Install the necessary dependencies.

Configure the connection to your Azure Cosmos DB instance.

Build and run the project


### Adding CI/CD


### License
This project is licensed under the MIT License.

Thank you for checking out this project! If you have any questions or feedback, please feel free to create an issue or contact me. Happy coding!
