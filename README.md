# How to reproduce the bug?
Start the application and send a PATCH request to:  
Destination: `/api/example`  
`Content-type: application/json-patch+json`

Payload:  
`[ { } ]`


Expected result:  
4XX with an error description that the payload is malformed.

Actual behavior:  
5XX because the `patchDocument.Apply()` method throws an exception.