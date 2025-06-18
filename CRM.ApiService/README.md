
# CRM API Service
Get data from the CRM system

## Project structure

```
CRM.ApiService/
   ├── Dockerfile
   ├── Program.cs
   ├── Controllers/
   ├── Logs/
   ├── Midleware/
   ├── Models/
   └── appsetings.json

```
## Example
### Request
```
http://localhost:57607/TicketData/GetTickets
```
### Response
```
[
  {
    "id": "TCK-001",
    "subject": "Login issue",
    "description": "User cannot log in to the system.",
    "created": "2025-06-16T05:38:34.393457Z",
    "priority": "High",
    "tags": [
      "login",
      "auth",
      "urgent"
    ]
  },
  {
    "id": "TCK-002",
    "subject": "Payment failed",
    "description": "Customer's payment did not go through.",
    "created": "2025-06-17T05:38:34.3934596Z",
    "priority": "Medium",
    "tags": [
      "payment",
      "checkout"
    ]
  }
 ]
```

