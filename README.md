**2020-01-30 Update: Problem is resolved in GraphQL.NET version 3.5 prerelease**

## Purpose

* Demonstrate this GraphQL.NET bug: https://stackoverflow.com/q/59971333/188740
* Examples for this bug report: https://github.com/graphql-dotnet/graphql-dotnet/issues/1516

## Description
Even though return type is defined as non-nullable, GraphQL.Net returns null when there's an exception.

## Steps to reproduce:
1) Run this project
2) Go to GraphQL Playground: https://localhost:44340/ui/playground
3) Try these 3 examples

## Example 1:

### Request
```
{
  exception{
    id
  }
}
```

### Response
```
{
  "data": {
    "exception": null
  },
  "errors": [
    {
      "message": "Something went wrong!",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "exception"
      ]
    }
  ]
}
```

## Example 2:

### Request
```
{
  null{
    id
  }
}
```

### Response
```
{
  "data": {
    "null": null
  },
  "errors": [
    {
      "message": "Cannot return null for non-null type. Field: null, Type: WidgetType!.",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "null"
      ]
    }
  ]
}
```

## Example 3:

### Request
```
{
  errorAndNull{
    id
  }
}
```

### Response
```
{
  "data": {
    "errorAndNull": null
  },
  "errors": [
    {
      "message": "Something went wrong!"
    },
    {
      "message": "Cannot return null for non-null type. Field: errorAndNull, Type: WidgetType!.",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "errorAndNull"
      ]
    }
  ]
}
```