# loan-solution

API was found in 
`https://LOCAL_HOST/api/loan POST`


payload
```
{
    "FirstName": "hiep",
    "LastName": "Lam",
    "EmailAddress": "hiep@gmail.com",
    "PhoneNumber": "0312345678",
    "BusinessNumber": "12345678901",
    "LoanAmount": 11000,
    "CitizenshipStatus": "permanent resident",
    "TimeTrading": 2,
    "CountryCode": "AU",
    "Industry": "industry3"
}
```

Config was set at `appsettings.json` and stronged-typeed in `LoadConfig.cs`

Test can be seperated per validator which not effect to any current code