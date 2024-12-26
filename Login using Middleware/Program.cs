using Login_using_Middleware.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Without Model (Direct Access)
app.MapPost("/login", (HttpContext context) =>
{
	var query = context.Request.Query;
	var email = query["email"];
	var password = query["password"];

	if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
	{
		return Results.BadRequest("Email and Password are required");
	}
	return Results.Ok($"Loggin successful with Email: {email}");
});

//With Model Class
app.MapPost("/login1", (HttpContext context) =>
{
	var query = context.Request.Query;
	var loginRequest = new LoginRequest
	{
		Email = query["email"],
		Password = query["password"]
	};
	if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
	{
		return Results.BadRequest("Email and Password are required");
	}
	return Results.Ok($"Login successful with Email: {loginRequest.Email}");

});

app.Run();
  /* for future reference
   * How It Works:
Results.BadRequest("message") – Returns a 400 status code with the provided message.
Results.Ok("message") – Returns a 200 status code with the provided message.
Results.NotFound() – Returns a 404 status code.
  */