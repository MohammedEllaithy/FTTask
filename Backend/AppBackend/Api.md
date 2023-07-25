#Application API Documentation
 
- [Buber Breakfast API](#buber-breakfast-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
  

## Auth

### Register

```js
POST {{host}}/auth/register
```
#### Register Request

```json
{
    "firstName": "Mohamed",
    "lastName": "Ellaithy",
    "email": "m.ellaithy11@gmail.com",
    "password": "Abcd123"
}
```

### Register Response

```js
200 Ok
```
### Login
```yml
POST {{host}}/auth/login
```
#### Login Request

```json
{
    "email": "m.ellaithy11@gmail.com",
    "password": "Abcd123"
}
```
### Login Response
```json
{
    "id": "78c4dfee-2ec2-4df9-a1c1-37a09dee1a06",
    "firstName": "Mohamed",
    "lastName": "Ellaithy",
    "email": "m.ellaithy11@gmail.com",
    "token": "eyjhb.......Xoy"
}
```
