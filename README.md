# EntityCompiledModelGenerator
Generates compiled model of EF Core computed model

The purpose of this project is to reduce cold start time of EF Core. In my case of use EF Core works with ASP.NET on AWS Lambda.
It takes 4.5 seconds on first call. Cause of 2.5 seconds is EF Core. This project aims to save computed model as classes. 
It will lead to reduce cold start time of EF Core

It is NOT working yet.
