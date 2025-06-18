
# CxNone API Service 
Save data in CxNone system

## Project structure

```
CxNone.ApiService/
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
http://localhost:57606/TicketData

Body:
{
  "ticketId": "string",
  "subject": "string",
  "description": "string",
  "created": "2025-06-18T05:44:31.050Z",
  "priority": "string",
  "tags": [
    "string"
  ]
}
```
### Response
```
Status code 200
```