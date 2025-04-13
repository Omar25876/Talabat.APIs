
![Logo](https://yt3.ggpht.com/a/AATXAJx7O3_C65qqhJHU5m_0_2AxBp81p-FaVzeSCg=s900-c-k-c0xffffffff-no-rj-mo)

 
### Talabat API Project

### Overview
A scalable e-commerce platform built with modern architectural patterns and best practices. This platform leverages Entity Framework, LINQ, and follows Clean Architecture principles to provide a robust solution for e-commerce needs.

This is a Talabat Clone Project built in in Onion Architecture Based on the following Design Patterns:
<blockquote>
 
- Repository Design Pattern.
- Specification Design Pattern.
- UnitOfWork Design Pattern.
- Builder Design Pattern.
</blockquote>


 <h2 align='center'>⭐ Authors ⭐ </h2>
<!-- readme: collaborators -start -->
<table align='center'> 
<tr>
    <td align="center">
        <a href="https://github.com/Omar25876">
            <img src="https://avatars.githubusercontent.com/u/113053935?v=4" width="100;" alt="yousefosama654"/>
            <br />
            <sub><b>Omar Mohamed</b></sub>
        </a>
    </td></tr>
</table>

- [@Omar Mohamed Ibrahim](https://www.linkedin.com/in/omar-mohamed-ibrahim-015ab31ba/)


  
### API Documentation
- API documentation available at `https://localhost:7132/swagger/index.html`
- Detailed endpoint documentation in the `Talabat.APIs` project
- Postman documentation available [here](https://documenter.getpostman.com/view/30192696/2sB2cYeMM3)

    

### Project Structure Explanation
- **Talabat.APIs**: Contains API controllers, filters, and configuration
- **Talabat.Core**: Houses domain entities, interfaces, and core business logic
- **Talabat.Repository**: Implements data access patterns and database operations
- **Talabat.Services**: Contains business service implementations and external integrations

### Features
- **Onion Architecture**: Separation of concerns and maintainability.
- **Repository Pattern**: Abstraction of the data access layer and consistent interface for querying the database.
- **Unit of Work Pattern**: Management of the context and transaction of the Entity Framework.
- **Specification Pattern**: Building complex queries in a composable and maintainable way.
- **Stripe Payment Gateway**: Integration with Stripe for payment processing.
 
  ## Libraries Used And Packages
<blockquote>
 
- StackExchange.Redis.
- Microsoft.EntityFrameworkCore.Tools.
- Microsoft.EntityFrameworkCore.SqlServer.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore.
- AutoMapper.Extensions.Microsoft.DependencyInjection. 
- Microsoft.AspNetCore.Authentication.JwtBearer.
- Stripe.net.
</blockquote>
 
 ## Databases
 
 <blockquote>
 
 - TalabatAPIs.
 - TalabatIdentityAPIs.
 - Redis (open source, in-memory database).
 
 </blockquote>
 
 ## Installation

```bash
  Just clone the project
  Run on Visual Studio
  Test endpoints on Postman 
```    
 
<h2 href="#Structure">Project Structure</h2>
 <div> 
  <pre>
├── Talabat APIs
|    ├──Controllers
|    |   ├──AccountController.cs
|    |   ├──BaseAPIController.cs
|    |   ├──BasketController.cs
|    |   ├──ProductsController.cs
|    |   ├──OrdersController.cs
|    |   └──PaymentsController.cs
|    ├──Dtos
|    |   ├──LoginDto.cs
|    |   ├──ProductDto.cs
|    |   ├──RegisterDto.cs
|    |   ├──UserDto.cs
|    |   ├──AddressDto.cs
|    |   ├──BasketItemDto.cs
|    |   ├──CustomerBasketDto.cs
|    |   ├──OrderDto.cs
|    |   ├──OrderToReturnDto.cs
|    |   └──OrderItemDto.cs
|    ├──Errors
|    |   ├──ApiExceptionError.cs
|    |   ├──ApiResponse.cs
|    |   └──ApiValidationErrorResponse.cs
|    ├──Extensions
|    |   ├──AppServicesExtension.cs
|    |   ├──IdentityServicesExtension.cs
|    |   ├──SwaggerServicesExtension.cs
|    |   └──UserManagerExtensions
|    ├──Helpers
|    |   ├──MappingProfiles.cs
|    |   ├──Pagination.cs
|    |   ├──ProductPictureUrlResolver.cs
|    |   └──CachedAttribute.cs
|    ├──Middlewares
|    |   └──ExceptionMiddleware.cs
|    ├──appsettings.json
|    ├──Program.cs
|    └──Startup.cs
├── Talabat.Core
|    ├──Entities
|    |   ├──Identity
|    |   |   ├──Address.cs
|    |   |   └──AppUser.cs
|    |   ├──BaseEntity.cs
|    |   ├──BasketItem.cs
|    |   ├──CustomerBasket.cs
|    |   ├──Product.cs
|    |   ├──ProductBrand.cs
|    |   ├──ProductType.cs
|    |   ├──Order Aggregate
|    |   |   ├──Address.cs
|    |   |   ├──DeliveryMethod.cs
|    |   |   ├──Order.cs
|    |   |   ├──OrderItem.cs
|    |   |   ├──OrderStatus.cs
|    |   |   └──ProductItemOrdered.cs
|    ├──Repositories
|    |   ├──IBasketRepository.cs
|    |   ├──IGenericRepository.cs
|    |   └──IUnitOfWork.cs
|    ├──Servicecs
|    |   ├──ITokenService.cs
|    |   ├──IOrderService.cs
|    |   ├──IPaymentService.cs
|    |   └──IResponseCacheService.cs
|    ├──Specification
|    |   ├──BaseSpecification.cs
|    |   ├──ISpecification.cs
|    |   ├──ProductSpecificationFilterCount.cs
|    |   ├──ProductsSpecParams.cs
|    |   ├──ProductWithBrandAndTypeSpecification.cs
|    |   ├──OrderWithItemsAndDeliveryMethodsSpecification.cs
|    |   └──OrderByPaymentIntentIdSpecification
├── Talabat.Repository
|    ├──Data
|    |   ├──Config
|    |   |   ├──ProductConfiguration.cs
|    |   |   ├──OrderConfiguration.cs
|    |   |   ├──OrderItemConfiguration.cs
|    |   |   └──DeliveryMethodConfiguration.cs
|    |   ├──Migrations
|    |   ├──SpecificationEvaluator.cs
|    |   ├──StoreContext.cs
|    |   ├──StoreContextSeed.cs
|    ├──DataSeed
|    |   ├──brands.json
|    |   ├──products.json
|    |   ├──types.json
|    |   └──delivery.json
|    ├──Identity
|    |   ├──Migrations
|    |   ├──AppIdentityContext.cs
|    |   └──AppIdentityContextSeed.cs
|    ├──BasketRepository.cs
|    ├──GenericRepository.cs
|    ├──UnitOfWork.cs
├── Talabat.Service
|    ├──TokenService.cs
|    ├──OrderService.cs
|    ├──PaymentService.cs
|    └──ResponseCacheService.cs
    </pre>
</div>

#### Running with Docker
1. Clone the repository:
    ```bash
    git clone https://github.com/Omar25876/Talabat.APIs.git
    cd Talabat-APIs
    ```



#### Local Development
1. Update the connection strings in `appsettings.json`:
    ```json
 {
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "DefaultConnection": "Server=DESKTOP-EPS264S\\MSSQLSERVER01;Database=Talabat.API;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;",
        "IdentityConnection": "Server=DESKTOP-EPS264S\\MSSQLSERVER01;Database=Talabat.Identity.API;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;",
        "RedisConnection": "localhost"
    },
    "ApiBaseUrl": "https://localhost:7132/",

    "JWT": {
        "Key": "b10d31eb5d79c426140eeec7f479598e85d8beca467577741d8416",
        "ValidIssuer": "https://localhost:7132",
        "ValidAudience": "MySecureUsers",
        "DurationInDays": "10"

    },
    "StripeKeys": {
        "SecretKey": "sk_test_51RBm59Clvq9GnclW1lSWwsjIMJwFLpvbYXPZ9GSFTgjMATdf6gIrqCvXHrOUxxVcotLHaUIIDIf1rpJDCbN90XFd00neAKYC3X",
        "PublishableKey": "pk_test_51RBm59Clvq9GnclWrNOow6rfUNefHJ7dAi20VgIzcGRHJiPrlPbSY50cAJdW9esdlZ54fNlVDVevG0O4Ko5jJgSW007XHI4vQg"
    },
    "FrontBaseUrl": "https://localhost:4200"


}

    ```

## What are the Layers of the Onion Architecture?
 - Onion Architecture uses the concept of layers, but they are different from 3-tier and n-tier architecture layers. Let’s see what each of these layers represents and should contain.


 - `Domain Layer`
   - At the center part of the Onion Architecture, the domain layer exists; this layer represents the business and behavior objects. The idea is to have all of your domain objects at this core. It holds all application domain objects. Besides the domain objects, you also could have domain interfaces. These domain entities don’t have any dependencies. Domain objects are also flat as they should be, without any heavy code or dependencies
 - `Repository Layer`
   - This layer creates an abstraction between the domain entities and business logic of an application. In this layer, we typically add interfaces that provide object saving and retrieving behavior typically by involving a database. This layer consists of the data access pattern, which is a more loosely coupled approach to data access. We also create a generic repository, and add queries to retrieve data from the source, map the data from data source to a business entity, and persist changes in the business entity to the data source.
 - `Service Layer`
   - The Service layer holds interfaces with common operations, such as Add, Save, Edit, and Delete. Also, this layer is used to communicate between the UI layer and repository layer. The Service layer also could hold business logic for an entity. In this layer, service interfaces are kept separate from its implementation, keeping loose coupling and separation of concerns in mind.
- `Presentation Layer`
   - It’s the outer-most layer, and keeps peripheral concerns like UI and tests. For a Web application, it represents the Web API or Unit Test project. This layer has an implementation of the dependency injection principle so that the application builds a loosely coupled structure and can communicate to the internal layer via interfaces.


### Endpoints

**AccountController**
- `POST /api/account/login`: Login a user
- `POST /api/account/register`: Register a new user
- `GET /api/account`: Get the current user
- `GET /api/account/address`: Get the user's address
- `PUT /api/account/address`: Update the user's address
- `GET /api/account/emailexists`: Check if an email exists
- `PUT /api/account/update`: Update the user's information
- `PUT /api/account/updatepassword`: Update the user's password

**BasketController**
- `GET /api/basket`: Get a basket by ID
- `POST /api/basket`: Update a basket
- `DELETE /api/basket/id`: Delete a basket by ID

**ErrorsController**
- `GET /errors/{code}`: Handle errors

**OrderController**
- `POST /api/order`: Create a new order
- `GET /api/order`: Get orders for the current user
- `GET /api/order/{id}`: Get an order by ID
- `GET /api/order/deliveryMethods`: Get delivery methods

**ProductsController**
- `GET /api/products`: Get a list of products
- `GET /api/products/{id}`: Get a product by ID
- `GET /api/products/brands`: Get a list of product brands
- `GET /api/products/categories`: Get a list of product categories



### Monitoring and Logging
- Health checks available at `/health`
- Logs are written to console and can be viewed using `docker-compose logs`

### Mock Configuration Files

#### appsettings.json
For local development and testing, you can use the following mock configuration:

```json
 
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
        "commandName": "Project",
        "dotnetRunMessages": true,
        "launchBrowser": true,
        "applicationUrl": "http://localhost:5111",
        "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
        },
        "launchUrl": "swagger"
    },
    "https": {
        "commandName": "Project",
        "dotnetRunMessages": true,
        "launchBrowser": true,
        "applicationUrl": "https://localhost:7132;http://localhost:5111",
        "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
        },
        "launchUrl": "swagger"
    }
  }
}

```
 

## ProductsController

#### Get All Products Brands

```http
GET /api/Products/Brands
```

#### Get All Products Types  


```http
GET /api/Products/Types
```

#### Get All Products

```http
GET /api/Products?sort=${price}&TypeId=${TypeId}&BrandId=${BrandId}&PageSize=${PageSize}&PageIndex=${PageIndex}&search=${Name}
```

| Parameter | Type     | Status     | Description                       |
| :-------- | :------- | :-------   | :-------------------------------- |
| `sort`    | `string` | **Not Required**| Sort the products by price or name descending or ascending  order|
| `TypeId`  | `int` | **Not Required**| Id of Type to fetch.|
| `BrandId` | `int` | **Not Required**| Id of Brand to fetch.|
| `PageSize`| `int` | **Not Required**| To determine tge page size of products (Pagination).|
| `PageIndex`| `int` | **Not Required**| To get specific page index. |
| `Name`    | `string` | **Not Required**|To search for all prducts that include this word in their Name. |



## BasketController
#### Get Basket By Id
 
```http
GET /api/Basket?Id=${id}
```

| Parameter | Type     |  Status   | Description                       |
| :-------- | :------- | :-------  | :-------------------------------- |
| `Id`    | `string` | **Required**|.Id of Basket to fetch.|

#### Create OR Update Basket

```http
POST /api/Basket
```


```json
{
    "id": "basket1",
    "items": [
        {
            "id": 4,
            "Name": ".NET Black & White Mug",
            "price": 100,
            "quantity": 10,
            "pictureUrl": "https://localhost:7132/images/products/2.png",
            "brand": ".NET",
            "type": "USB Memory Stick"
        }
    ],
        "deliveryMethodId": 1
}

```



#### Delete Basket By Id

```http
DELETE /api/Basket?Id=${id}
```

| Parameter | Type     | Status   |     Description                       |
| :-------- | :------- | :------- | :--------------------------------     |
| `Id`    | `string` | **Required**| Id of Basket to be deleted.|




## AccountController

#### Login
 
```http
POST /api/Account/login
```

```json
{
    "Email": "Omar@gmail.com",
    "Password": "Omar223*"
}
```

#### Register
 
```http
POST /api/Account/register
```

```json
{
    "DisplayName":"Omar",
    "Email": "Omar@gmail.com",
    "Password": "Omar223*",
    "PhoneNumber": "001090465758"
}
```

#### Get Current User
 
```http
GET /api/Account/GetCurrentUser
```


#### Get Current User Address
 
```http
GET /api/Account/Address
```

#### Update Current User Address
 
```http
PUT /api/Account/UpdateCurrentUserAddress
```

```json
{
    "FirstName": "Omar ",
    "LastName": "Mohamed ",
    "street": "55 street",
    "city": "October",
    "country": "Egypt new"
}
```


## OrdersController

#### Get All Avaliable Delivery Methods


```http
GET /api/Orders/DeliveryMethods
```

#### Get All Orders For Current User
```http
GET /api/Orders
```

#### Get Order By ID For Current User
```http
GET /api/Orders/1
```


#### Create an Order For Current User

```http
POST /api/Orders
```
```json
{
    "basketId": "basket1",
    "deliveryMethodId": 1,
    "shippingaddress": {
        "FirstName": "Omar ",
        "LastName": "Mohamed",
        "street": "10 street",
        "city": "Cairo",
        "country": "Egypt"
    }
}
```


## PaymentsController

### Confirm Payment

- To Confirm Payment with the Gateway and handling stripe Events with success or fail.

```http
POST /Payments/webhook
```

### Create Or Update PaymentIntent

```http
POST /api/Payments?basketId=${basketId}
```

| Parameter | Type     | Status   |     Description                       |
| :-------- | :------- | :------- | :--------------------------------     |
| `Id`    | `string` | **Required**| Id of Basket to be Ordered.|



## Responses

Many API endpoints return the JSON representation of the resources created or edited. However, if an invalid request is submitted, or some other error occurs, Talabat returns a JSON response in the following format:

```javascript
{
  "message" : string,
  "statusCode" : int,
  "Details"    : string
}
```

The `message` attribute contains a message commonly used to indicate errors.

The `statusCode` attribute describes the code of the response due to the follwing Status Codes Table.

The `Details` attribute contains error message only in developing env and in case of internal server error(500).

## Status Codes

Talabat returns the following status codes in its API:

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 400 | `BAD REQUEST` |
| 401 | `UNAUTHORIZED` |
| 404 | `NOT FOUND` |
| 500 | `INTERNAL SERVER ERROR` |


## FAQ

<details>
  <summary>How To Pay Through Application ?</summary>

 You should enter any future date and any valid three numbers for `CVC` and the card number can be got by
 `Stripe PaymentGateway`.
</details>

<details>
  <summary>What About Perfomance For High Traffic Requests ?</summary>

 The caching is done for only 10 minutes for products loaded before. 
</details>


<details>
 <summary>How To Connect To Redis ?</summary>

- First Install Redis Software.
- Open the Command prompt and type this command `redis-server`.


</details>

 <h2 align='center'>⭐ Authors ⭐ </h2>
<!-- readme: collaborators -start -->
<table align='center'> 
<tr>
    <td align="center">
        <a href="https://github.com/Omar25876">
            <img src="https://avatars.githubusercontent.com/u/113053935?v=4" width="100;" alt="yousefosama654"/>
            <br />
            <sub><b>Omar Mohamed</b></sub>
        </a>
    </td></tr>
</table>
<!-- readme: collaborators -end -->
<h2 align='center'>Thank You. 💖 </h2>



