# RoomReservationMicroServices

## Overview
This microservices project consists of three services: CustomerService, RoomService, and ReservationService. The project follows a microservices architecture pattern and utilizes 
Azure Bus Queue for inter-service communication. Each service has its own database, and an API gateway, Ocelot, is used to handle communication between the services.

## Service Descriptions
### CustomerService
The CustomerService manages customer information and provides endpoints for customer-related operations.
#### API Endpoints
- GET /customers - Retrieves a list of all customers.
- GET /customers/{id} - Retrieves details of a specific customer.
- POST /customers - Creates a new customer.


### ReservationService
The BookingService manages the booking process. When a customer books a room, a message is sent to Azure Bus Queue for further processing.

#### API Endpoints
- GET /bookings - Retrieves a list of all bookings.

### RoomService
The RoomService handles room-related operations and provides endpoints for managing rooms.

#### API Endpoints
- GET /rooms - Retrieves a list of all rooms.
- GET /rooms/{id} - Retrieves details of a specific room.
- POST /rooms - Creates a new room.
- PUT /rooms/{id} - Updates an existing room.
- DELETE /rooms/{id} - Deletes a room.

## Inter-Service Communication
To handle communication between services, Ocelot is used as an Api gateway. This api gateway acts as the entry point for external clients 
and routes requests to the appropriate microservice. It provides load balancing and routing capabilities.

## Azure Bus Queue Integration
When a customer books a room, a message is sent to Azure Bus Queue. The ReservationService is responsible for retrieving messages from the queue and saving them in the database.
## Database Configuration
Each service in this project uses a separate SQL Server database to store its data. The specific database configuration details for each service are as follows:

- CustomerService uses a SQL Server database. The connection string can be configured in the appsettings.json file.
- RoomService uses a SQL Server database. The connection string can be configured in the appsettings.json file.
- BookingService uses a SQL Server database. The connection string can be configured in the appsettings.json file.



