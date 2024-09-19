Project Summary
Hello everyone, thank you for joining me today! I’m excited to share the backend architecture of my Hotel Booking application. This project allows users to log in, book hotels, and comment on hotel articles. While the backend is still in progress as I continue to add features, I’m eager to discuss the technologies and structure I've implemented so far.

Why ASP.NET Core?
I chose ASP.NET Core for this project because it offers a powerful framework for building robust and scalable web APIs. Its features such as built-in dependency injection, routing, and middleware support streamline development and enhance performance. Moreover, ASP.NET Core is well-suited for creating RESTful services, making it an ideal choice for my application, which requires seamless communication between the frontend and backend.

Microservices Architecture
To promote modularity and scalability, I adopted a microservices architecture by separating my solution into four distinct projects: API, Domain, Data, and Infra. This separation allows each service to operate independently, facilitating easier maintenance and updates.

API Project: This is the main project where all the controllers reside. It acts as the service component for the business logic, handling HTTP requests and responses. The API project is responsible for defining the endpoints that users interact with, ensuring a clean and structured approach to data handling.

Domain Project: This class library contains the core business logic, models, commands, and generic handlers for the application. By isolating the business rules and logic from other components, I ensure that changes to business requirements can be managed independently without affecting the overall architecture.

Data Project: This project manages database access and includes the AppDbContext for handling the database entities and migrations. By centralizing data access, it simplifies interactions with the database and enables easier modifications to the data schema as new features are added.

Infra Project: This project contains the implementation of the repositories and any infrastructure-related services. By separating infrastructure concerns, I can focus on implementing data access patterns and services without cluttering the core business logic.

Benefits of Microservices Structure
Using a microservices architecture provides several benefits:

Decoupling: Each component operates independently, making it easier to maintain, test, and scale different parts of the application. This independence allows for rapid development and deployment cycles.

Modularity: Organizing code into modules like handlers, commands, and queries helps maintain a clean codebase. New features or updates can be integrated without disrupting the entire system.

Scalability: Since each service is independent, I can scale them based on demand. For instance, if the booking service needs to handle more traffic, it can be scaled without impacting other services.

Database per Service: Each service can manage its own database schema, allowing tailored migrations and updates. This design choice enhances data integrity and separation of concerns.

As I continue to enhance this Hotel Booking application by adding new tables and endpoints, I look forward to sharing more updates. Thank you for your attention, and I hope you enjoy the walkthrough of this project!