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
* Conditions

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
Format
------
function description
```
HTTP verb/ URL(API name/Version/plular nouns.format)?key1=value & key2=value
```

Parameters

* 
`
key1
`
(required/optional) The description of this parameter; if the name is "none", there is not parameter in this function.

Sample request
```
[
    {
        "key": "value"
        "...": "..."
    }
]
```

Sample response
```
{
    "status = 200
    "metadata": {
        "resultset": {
            "count": 227,
            "offset": 25,
            "limit": 25
        }
    },
    "results": [
        {....}
        {....}
        {....}
    ]
}
```


Example Data
--------
1. Water Resources Agency, water level
2. Central Weather Bureau, rainfall
3. City Goveronment, water gates



Datasets
-----------
List datasets

```
GET /IASS/v1/datasets
```
Parameters

* 

`
none
`

Sample response

```
{
    "success": true
    "status": 200
    "metadata": {
        "resultset": {
            "count": 3,
            "offset": 0,
        }
    },
    "results": [
        {
            "id": 1,
        	"description": null,
        	"public": false,
        	"visibility_Level": 1,
            "encode":"BIG5"
        	"web_URL": "http://central.weather.bureau",
        	"organization": {
        	    "id": 1,
        	    "name": "Central Weather Bureau",
        	}
            "catalogs":{
                "organizations":[
                    "Water Resources Agency",
                ]
                "disasters":[
                    "typhoon",
                    "downpour",
                    "debris flow",
                ]
                "tags":[
                    "climate",
                    "weather",
                    "dangerous",
                    "river",
                ]
            }
        	"last_Updated_Date": "2014-10-24T11: 48: 02Z",
        	"update_Frequency": 1800,
        	"expiration_Date": "2014-10-24T12: 18: 02Z",
        },
    ]
}
```

Categories
-----------
List categories

```
GET /IASS/v1/catagories
```
Parameters

* 

`
none
`

Sample response
```
{
    "success": true
    "status": 200
	"last_Updated_Date": "2014-10-24T11: 48: 02Z"
    "metadata": {
        "organizations": {
            "count": 3,
            "offset": 0,
        }
        "disasters": {
            "count": 5,
            "offset": 0,
        }
        "tags": {
            "count": 5,
            "offset": 0,
        }

    },
    "organizations":[
        "Water Resources Agency",
        "Central Weather Bureau",
        "City Goveronment",
    ]
    "disasters":[
        "typhoon",
        "downpour",
        "debris flow",
        "earthquake",
        "virus",
        
    ]
    "tags":[
        "climate",
        "weather",
        "dangerous",
        "river",
        "medical",
    ]
}
```

Tags
-----------
List tags

```
GET /IASS/v1/tags
```
Parameters

* 

`
none
`

Sample response
```
{
    "success": true
    "status": 200
    "last_Updated_Date": "2014-10-24T11: 48: 02Z"
    "metadata": {
        "resultset": {
            "count": 5,
            "offset": 0,
        }
    },
    "result":[
        "climate",
        "weather",
        "dangerous",
        "river",
        "medical",
    ]
}
```

Specify by data tags
-----------
Specify datasets by their tags, and list all datasets which have the specified tags
```
GET /IASS/v1/datasets/[tag]
```
```
GET /IASS/v1/datasets/?tag=climate
```
Parameters

* 

`
tag
`
: (required)  a string which is used describe datasets

Sample response
```
{
    "success": true
    "status": 200
    "metadata": {
        "resultset": {
            "count": 3,
            "offset": 0,
        }
    },
    "results": [
        {
            “id”: 1,
            “description”: null,
        	“public”: false,
        	"visibility_Level": 1,
        	“web_URL”: "http://central.weather.bureau",
        	“organization”: {
        	    "id": 1,
        	    "name": "Central Weather Bureau",
        	}
            "catalogs":{
                "organizations":[
                    "Central Weather Bureau",
                ]
                "disasters":[
                    "typhoon",
                    "downpour",
                    "debris flow",
                ]
                "tags":[
                    "climate",
                    "weather",
                    "dangerous",
                    "river",
                ]
            }
        	“last_Updated_Date”: "2014-10-24T11: 48: 02Z",
        	“update_Frequency ”: 1800,
        	“expiration_Date”: "2014-10-24T12: 18: 02Z",
        },
    ]
}
```
Specify by data ID
-----------
Specify a dataset by its ID, and list inner information (records) of the dataset who has the ID.
```
GET /IASS/v1/datasets/[dataset_ID]
```
```
GET /IASS/v1/datasets/1
```


Parameters

* 

`
dataset_ID
`
: (required) the identify number of a dataset.


Sample response
```
{
    "success": true,
    "status": 200,
    "encode":"BIG5"
    "dataset_ID": 1,
    "description": null,
	"public": false,
	"visibility_Level": 1,
	"web_URL": "http://central.weather.bureau",
	"organization": {
	    "id": 1,
	    "name": "Central Weather Bureau",
	}
    "catalogs":{
        "organizations":[
            "Water Resources Agency",
        ]
        "disasters":[
            "typhoon",
            "downpour",
            "debris flow",
        ]
        "tags":[
            "climate",
            "weather",
            "dangerous",
            "river",
        ]
    }
	"last_Updated_Date": "2014-10-24T11: 48: 02Z",
	"update_Frequency": 1800,
	"expiration_Date": "2014-10-24T12: 18: 02Z",
    "metadata": {
        "record_Set": {
            "count": 3,
            "offset": 0,
        }
    },
    "record":[
        {
        "record_ID":1,
        "vaild_period":1800,
        "sit_Name":"吉林國小",
        "site_ID":"wr0102",
        "county":"新北市",
        "township":"貢寮區",
        "latitude":24.9875,
        "longitude":121.8794,
        "10_Min_Rainfall":0,
        "1_Hour_Rainfall":0,
        "3_Hour_Rainfall":1,        
        "6_Hour_Rainfall":23,
        "12_Hour_Rainfall":0,
        "24_Hour_Rainfall":0,
        "daily_Rainfall":23,
        "unit":"第一河川局",
        "publish_Time": "2014-10-24T11: 48: 02Z",
        }
    ]
    

}
```

Notify
-------
List all notify methods
```
GET /IASS/v1/notify_Methods
```
Parameters

* 

`
none
`

Request body
```
{
    "success": true,
    "status": 200,
    "user_ID":1,
	"last_Updated_Date": "2014-10-24T11: 48: 02Z",
    "metadata": {
        "method_Set": {
            "count": 2,
            "offset": 0,
        }
    },
    "method":[
        {
        "method_ID":1,
        "description":"Push information to assigned URL."
        "needed_Info":"This notify method needs a specific URL and the reciver's name."
        "address_Format":"http://xxxx.xxxx.xxxx"
        }
        {
        "method_ID":2,
        "description":"send an email to an App. messages will follow the CAP format"
        "needed_Info":"This notify method needs a specific email address and the reciver's name."
        "address_Format":"XXXX@yyyyyyyyyyy"
        }

    ]
}
```


Request a event
-------
Specidy the monitor event information.

```
POST /IASS/v1/datasets/[dataset_ID]/[record_ID]/key & event_Operator & event_Value
```
```
POST /IASS/v1/datasets/1/1/key=daily_Rainfall & operator=> & value=100
```
Parameters

* 

`
dataset_ID
`
: (required)  the identify number of a dataset.

* 
`
record_ID
`
: (required) the identify number of a record in a specific dataset.

* 
`
key_Name
`
: (required) the key of a variable which application developer wants to monitor.

* 
`
event_Operator
`
: (required) a mathmetic operator, which represents the relationship between monitored value and its condition. Here, we offer 1. larger than ">",  2. smaler than "<", and equal to "="

* 
`
event_Value
`
: (required) a value is used as the condition value.

Request body
```
[
    {
        "user_ID":1,
        "dataset_ID":1,
        "record_ID":1,
        "key_Name":"daily_Rainfall",
        "event_Operator":">",
        "event_Value":100,
    }
]
```
Notify information
-------
Specidy the notify information.

```
POST /IASS/v1/notify
```
Parameters

* 

`
none
`

Request body
```
[
    {
        "user_ID":1,
        "notify_Method"=1,
        "reciver_Name":"App in Taipei pumping station",
        "App_URL":"http://140.114.xx.xx/asdf1234",
        "mail_Address":"",
        "phone_number":"",
    }
]
```


Notification list
-------
List all notification-reciver information which are registerd by the current user.
```
GET /IASS/v1/notifications
```
Parameters

* 

`
none
`

Request body
```
{
    "success": true,
    "status": 200,
    "user_ID":1,
	"last_Updated_Date": "2014-10-24T11: 48: 02Z",
    "metadata": {
        "reciver_Set": {
            "count": 3,
            "offset": 0,
        }
    },
    "reciver":[
        {
        "id"=1,
        "notify_Method"=1,
        "reciver_Name":"App in Taipei pumping station",
        "App_URL":"http://140.114.xx.xx/asdf1234",
        "mail_Address":"",
        "phone_number":"",
        }
        {
        "id":2,
        "notify_Method"=2,
        "reciver_Name":"App in Taipei pumping station",
        "App_URL":"",
        "mail_Address":"taipei@pumping.com",
        "phone_number":"",
        }

    ]
}
```

