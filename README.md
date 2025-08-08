HARDCODETESTCASE2
Empowering Seamless Communication for Scalable Innovation

last-commit repo-top-language repo-language-count
Built with the tools and technologies:

JSON Markdown Docker NuGet

Table of Contents
Overview
Getting Started
Prerequisites
Installation
Usage
Testing
Overview
HardCodeTestCase2 is a robust developer tool designed to facilitate the development of scalable, decoupled microservices architectures. It integrates core components such as message brokering with RabbitMQ, API routing via Ocelot, and comprehensive API documentation with Swagger, enabling seamless communication and testing across services. The project emphasizes clean data flow through DTOs and object mappings, while supporting containerized deployment with Docker for consistent environments.

Why HardCodeTestCase2?

This project aims to simplify building reliable, event-driven systems. The core features include:

🧩 🔗 Message Brokering: Utilizes RabbitMQ for dependable asynchronous communication between microservices.
🚦 API Gateway Routing: Orchestrates requests with Ocelot, ensuring efficient and secure API interactions.
🛠️ Modular Data Handling: Implements DTOs and object mappings for clean, maintainable data flow.
🐳 Containerized Deployment: Supports Docker for consistent, scalable deployment environments.
📄 Integrated Documentation: Provides Swagger UI for easy API testing and validation.
⚙️ Configurable Environments: Facilitates development and production setups with flexible configuration files.
Getting Started
Prerequisites
This project requires the following dependencies:

Programming Language: CSharp
Package Manager: Nuget
Container Runtime: Docker
Installation
Build HardCodeTestCase2 from the source and install dependencies:

Clone the repository:

❯ git clone https://github.com/Yerkyway/HardCodeTestCase2
Navigate to the project directory:

❯ cd HardCodeTestCase2
Install the dependencies:

Using docker:

❯ docker build -t Yerkyway/HardCodeTestCase2 .
Using nuget:

❯ dotnet restore
Usage
Run the project with:

Using docker:

docker run -it {image_name}
Using nuget:

dotnet run
Testing
Hardcodetestcase2 uses the {test_framework} test framework. Run the test suite with:

Using docker:

echo 'INSERT-TEST-COMMAND-HERE'
Using nuget:

dotnet test
⬆ Return
