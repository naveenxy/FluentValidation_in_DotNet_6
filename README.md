# FluentValidation_in_DotNet_6
Using Fluent Validation in .Net Core Web API 6

ASP.NET Core
FluentValidation can be used within ASP.NET Core web applications to validate incoming models. There are two main approaches for doing this:

Manual validation
Automatic validation
With manual validation, you inject the validator into your controller (or api endpoint), invoke the validator and act upon the result. This is the most straightforward and reliable approach.

With automatic validation, FluentValidation plugs into the validation pipeline that’s part of ASP.NET Core MVC and allows models to be validated before a controller action is invoked (during model-binding). This approach to validation is more seamless but has several downsides:

Auto validation is not asynchronous: If your validator contains asynchronous rules then your validator will not be able to run. You will receive an exception at runtime if you attempt to use an asynchronous validator with auto-validation.
Auto validation is MVC-only: Auto-validation only works with MVC Controllers and Razor Pages. It does not work with the more modern parts of ASP.NET such as Minimal APIs or Blazor.
Auto validation is hard to debug: The ‘magic’ nature of auto-validation makes it hard to debug/troubleshoot if something goes wrong as so much is done behind the scenes.
We do not generally recommend using auto validation for new projects, but it is still available for legacy implementations.



/**
With the manual validation approach, you’ll inject the validator into your controller (or Razor page) and invoke it against the model.


Request Body for Post Customer
{
 
  "firstName": "Naveen",
"lastName" :"Kumar",
  "email": "naveenxy14@gmail.com",
  "phone": "7338980569",
  "age": 22,
  "url": "https://github.com/naveenxy",
  "status": 1,
  "password": "Naveen@2000",
  "confirmPassword": "Naveen@2000",
  "creditCard": "4015610013636381"
}
