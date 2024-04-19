# Improvements for the Demo API

## Storing Data
The dates are stored as string in the database. Would be good to stere them as a datetime element for easier manual filtering

## Requests
### Update Tag
Endpoint will update the 3 fields: TagId, Name, Unit, even though some of them are not passed. Should update only the fields provided.

### Create site
Would be nice to have the option of creating the Site and the tags for it at the same time. Saves traffic by reducing the number of calls

### Create tag
Since a site can have multiple tags, would be good to have the option of creating multiple tags at once. Currently, the endpoint supports only one tag at a time.

### Get site paginated
A bit troublesome to convert the cursor to Base 62 during manual debugging, but I am not familiar with pagination in GraphQL, so this might be the only preferable way. 

### API run
Running the API from VisualStudio opens Swagger, but swagger doesn't seem to be configured.

## Tests
### Missing endpoint tests
There are no Endpoint Tests (Unit or Integration)
