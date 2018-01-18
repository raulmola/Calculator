# Calculator
This project implements a simple Calculator by means of a self host web service and a console client both implemented in C# with ServiceStack.

#### Build
The project was developped and  with Visual Studio 2017 (Community Edition) and .NET Framework 4.6.1

#### Deployment and running
Both the web service and the client can be launched directly from Visual Studio without deploying to an application server. Simply start an instance of the project "CalculatorService" and then launch an instance of the project "CalculatorClient".

#### CalculatorService
When you start the web service, a console will appear with an informative message of the port where it will be listening to client requests (default port is 8088)

#### CalculatorClient
When you start the client it will ask for a desired calculator operation to be requested to the server. Supported operations are  add/sub/mul/div/sqrt/query/exit.Mathematical operations explain themselves.**query** operation is explained below. Write "exit" to stop and exit the client. Follow the console client instrucctions.   

All operations ask for an optional track id (any value,for example your name). The server will save (cache in memory) **only** those requested operations with that id. Later on, by means of the **query** command, the client can request to the web service the history of the requests of the chosen id.






