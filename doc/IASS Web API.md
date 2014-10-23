IASS Web API
=========

IASS's API is a powerful, Restful style API that exposes all of IASS's core features to API clients. All of a IASS's core functionality(everything you can do with the web interface and more) can be used by external code that calls the IASS API.

Version
----

1.0

Resources
----
* Datasets
* Categories
* Tags
* Notification
* Events

Status codes
------------

The API is designed to return different status codes according to context and action. In this way if a request results in an error the caller is able to get insight into what went wrong, e.g. status code 400 Bad Request is returned if a required attribute is missing from the request. The following list gives an overview of how the API functions generally behave.

API request types:

- GET requests access one or more resources and return the result as JSON
- POST requests return 201 Created if the resource is successfully created and return the newly created resource as JSON
- GET, PUT and DELETE return 200 OK if the resource is accessed, modified or deleted successfully, the (modified) result is returned as JSON
- DELETE requests are designed to be idempotent, meaning a request a resource still returns 200 OK even it was deleted before or is not available. The reasoning behind it is the user is not really interested if the resource existed before or not.

The following list shows the possible return codes for API requests.

Return values:
```
200 OK - The GET, PUT or DELETE request was successful, the resource(s) itself is returned as JSON
201 Created - The POST request was successful and the resource is returned as JSON
400 Bad Request - A required attribute of the API request is missing, e.g. the title of an issue is not given
401 Unauthorized - The user is not authenticated, a valid user token is necessary, see above
403 Forbidden - The request is not allowed, e.g. the user is not allowed to delete a project
404 Not Found - A resource could not be accessed, e.g. an ID for a resource could not be found
405 Method Not Allowed - The request is not supported
409 Conflict - A conflicting resource already exists, e.g. creating a project with a name that already exists
500 Server Error - While handling the request something went wrong on the server side
```

Datasets
-----------

List datasets

```
GET /datasets
```

```
[
   {
	“id”: Integer datasetID
	“description”: String dataDescription
	“public”: Boolean isPublic
	“webURL”: String webAddress
	“organization”: String organizationName
	“tags”: String[ ] tagString 
	“lastUpdateDate”: Time lastTime
	“updateFrequency ”: integer  updateTime
	“expirationDate”: Time expiration
   }
]
```

Categories
-----------

List Categories

```
GET /Categories
```

```
[
	{
	“catalogTitle”: String catalogName
	“keyWord”: {
			“keyword1”
			 “keyword2”
			 “keyword3”
			“……”
		        }
	}
]

```
