**IASS  Web API : Version 1 **
========
IASS's API is a powerful, Restful style API that exposes all of IASS's core features to API clients. All of a IASS's core functionality(everything you can do with the web interface and more) can be used by external code that calls the IASS API.

-------
**Version**
-------

/IASS/v1/

-------
**Resources**
-------
- Datasets
- Categories
- Tags
- Notify methods
- Notification
- Events
- Conditions

-------

**Status codes**
-------
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

-------

##**Datasets**
Description
```
A data set is a collection of data. It corresponds to the contents of a single database table, or a single statistical data matrix, where every column of the table represents a particular variable, and each row corresponds to a given member of the data set in question[6]. 
```


###List datasets
List all the data sets which IASS is capable to monitor.
```
GET /datasets
```

Parameters

- `none`

Response body

>```
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
>```


###Specify by data ID

Specify a dataset by its ID, and list inner information (records) of the dataset who has the ID.
```
GET /datasets/[dataset_ID]
```
```
GET /datasets/1
```

Parameters

-  `dataset_ID` : (required) the identify number of a dataset.


Sample response
>```
{
    "success": true,
    "status": 200,
    "encode":"BIG5"
    "datasetID": 1,
    "description": null,
	"public": false,
	"visibilityLevel": 1,
	"webURL": "http://central.weather.bureau",
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
	"lastUpdatedDate": "2014-10-24T11: 48: 02Z",
	"updateFrequency": 1800,
	"expirationDate": "2014-10-24T12: 18: 02Z",
    "metadata": {
        "recordSet": {
            "count": 300,
            "offset": 0,
            "limit":50
        }
    },
    "record":[
        {
        "id":1,
        "vaildPeriod":1800,
        "sitName":"吉林國小",
        "siteID":"wr0102",
        "county":"新北市",
        "township":"貢寮區",
        "latitude":24.9875,
        "longitude":121.8794,
        "10MinRainfall":0,
        "1HourRainfall":0,
        "3HourRainfall":1,        
        "6HourRainfall":23,
        "12HourRainfall":0,
        "24HourRainfall":0,
        "dailyRainfall":23,
        "unit":"第一河川局",
        "publishTime": "2014-10-24T11: 48: 02Z",
        }
    ]
}
>```


-------

##**Categories**
Description
```
catagories are 
```

###List categories

```
GET /catagories
```
Parameters

- `none`

Sample response
>```
{
    "success": true
    "status": 200
	"lastUpdatedDate": "2014-10-24T11: 48: 02Z"
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
>```

-------
##**Tags**
Description
```
Tags are 
```

###List tags

```
GET /tags
```
Parameters

- `none`

Sample response
>```
{
    "success": true
    "status": 200
    "lastUpdatedDate": "2014-10-24T11: 48: 02Z"
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
>```

###Specify by data tags
Specify datasets by their tags, and list all datasets which have the specified tags
```
GET /datasets/[tag]
```
```
GET /datasets/?tag=climate,weather
```

Parameters

- `tag`: (required)  a string array which is used describe datasets

Sample response
>```
{
    "success": true
    "status": 200
    "metadata": {
        "resultSet": {
            "count": 3,
            "offset": 0,
        }
    },
    "results": [
        {
            "id": 1,
            "description": null,
        	"public": false,
        	"visibilityLevel": 1,
        	"webURL": "http://central.weather.bureau",
        	"organization": {
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
        	"lastUpdatedDate":  "2014-10-24T11: 48: 02Z",
        	"updateFrequency": 1800,
        	"expirationDate": "2014-10-24T12: 18: 02Z",
        },
    ]
}
>```

-------
##**Notify methods**

Description
```
Notify methods are 
```

###List all notify methods
```
GET /notify_Methods
```
Parameters

* `none`

Request body

>```
{
    "success": true,
    "status": 200,
    "userID":1,
	"lastUpdatedDate": "2014-10-24T11: 48: 02Z",
    "metadata": {
        "methodSet": {
            "count": 2,
            "offset": 0,
        }
    },
    "method":[
        {
        "id":1,
        "description":"Push information to assigned URL."
        "neededInfo":"This notify method needs a specific URL and the reciver's name."
        "addressFormat":"http://xxxx.xxxx.xxxx"
        }
        {
        "id":2,
        "description":"send an email to an App. messages will follow the CAP format"
        "neededInfo":"This notify method needs a specific email address and the reciver's name."
        "addressFormat":"XXXX@yyyyyyyyyyy"
        }
    ]
}
>```

----------

##**Notification**

Description
```
conditions are 
```

###Specidy the notify information.

```
POST /notify
```
Parameters

- `none`

Request body
```
[
    {
        "userID":1,
        "notifyMethod"=1,
        "reciverName":"App in Taipei pumping station",
        "AppURL":"http://140.114.xx.xx/asdf1234",
        "mailAddress":"",
        "phoneNumber":"",
    }
]
```

###List all notification-reciver information which are registerd by the current user.
```
GET /notifications
```
Parameters

- `none`

Request body
>```
{
    "success": true,
    "status": 200,
    "userID":1,
	"lastUpdatedDate": "2014-10-24T11: 48: 02Z",
    "metadata": {
        "reciver_Set": {
            "count": 3,
            "offset": 0,
        }
    },
    "reciver":[
        {
        "id"=1,
        "notifyMethod"=1,
        "reciverName":"App in Taipei pumping station",
        "AppURL":"http://140.114.xx.xx/asdf1234",
        "mailAddress":"",
        "phoneNumber":"",
        }
        {
        "id":2,
        "notifyMethod"=2,
        "reciverName":"App in Taipei pumping station",
        "AppURL":"",
        "mailAddress":"taipei@pumping.com",
        "phoneNumber":"",
        }
    ]
}
>```


----------

##**Events**

Description
```
conditions are 
```

###Request a event
Specify the monitor event information.

```
POST /datasets/[dataset_ID]/[record_ID]/?key&event_Operator& event_Value
```
```
POST /datasets/1/1/key=daily_Rainfall & operator=> & value=100
```
Parameters

-  `dataset_ID`: (required)  the identify number of a dataset.

- `record_ID`: (required) the identify number of a record in a specific dataset.

- `key_Name`: (required) the key of a variable which application developer wants to monitor.

- `event_Operator`: (required) a mathmetic operator, which represents the relationship between monitored value and its condition. Here, we offer 1. larger than ">",  2. smaler than "<", and equal to "="

- `event_Value`: (required) a value is used as the condition value.

Request body
>```
[
    {
        "userID":1,
        "datasetID":1,
        "recordID":1,
        "keyName":"daily_Rainfall",
        "eventOperator":">",
        "eventValue":100,
    }
]
>```

------------
##**Conditions**
Description
```
conditions are 
```

###Specify in which condition receivers should be notified.

```
POST /condition
```
```
POST /condition/?[event]&[notification]
```
```
POST /condition/?event=1,2&notification=1,2
```

Parameters

- `none`

Request body
>```
[
    {
        "userID":1,
        "events":[
            {"id":1,},
            {"id":2,},
        ]
        "notifications":[
	        {"id":1,},
	        {"id":2,},
        ]
    }
]
>```

------

**Reference**
-----
[1] key's name inside Json. http://stackoverflow.com/questions/5543490/json-naming-convention

[2] web API standards. https://github.com/WhiteHouse/api-standards#http-verbs

[3] Ckan 2.2 documentation. http://docs.ckan.org/en/ckan-2.2/api.

[4] Error handling. https://developers.google.com/maps/documentation/directions/#ErrorMessages

[5] Using REST. https://cloud.google.com/translate/v2/using_rest?hl=zh-TW

[6] Definition of data set. http://en.wikipedia.org/wiki/Data_set
