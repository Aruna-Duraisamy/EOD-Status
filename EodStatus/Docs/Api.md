# EOD Status API

- [EOD Status API](#eod-status-api)
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
    "firstName":"Sheldon",
    "lastName":"Cooper",
    "email":"SheldonCooper@email.com",
    "password":"BaZ!nga123"
}
```

#### Register Response
```js
200 OK
```

```json
{
    "id": "f29d3fc6-a4dc-4ac1-bdeb-32e24e64a11d",
    "firstName": "Sheldon",
    "lastName":"Cooper",
    "email":"SheldonCooper@email.com",
    "token":"abcDE...uvWxYZ"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email":"SheldonCooper@email.com",
    "password":"BaZ!nga123"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id": "f29d3fc6-a4dc-4ac1-bdeb-32e24e64a11d",
    "firstName": "Sheldon",
    "lastName":"Cooper",
    "email":"SheldonCooper@email.com",
    "token":"abcDE...uvWxYZ"
}
```