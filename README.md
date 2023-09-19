# Learn how to integrate Azure Services into your .NET 6 projects

## Embracing New Horizons 

I'm Kevoy Walters, an admirer of C# and .NET. I currently have four(4) years of professional expereince using ASP.NET, .NET Core and .NET Framework to create large scale enterprise projects. While I've always had a deep love for traditional software development, I recently embarked on an exciting journey that led me into the realms of cloud development and DevOps. The dynamic and ever-evolving nature of these fields intrigued me, and I decided to dive headfirst into learning more about how to inetgrate them in my daily taks.

## Sample Project

This project was a chance for me to immerse myself in cloud concepts. I intentionally designed the project in a way that forced me to utilize these principles, pushing me out of my comfort zone and into uncharted territory of cloud espcecailly containerization and DevOps.
The point of this project is not focus on its features but how those features are deployed, hosted and managed in the Cloud through Microsoft Azure.

Tech Stack:
1. .NET 6

Cloud Services used:
1. **Azure App Configuration** 
4. **Storage Accounts (Azure Table Storage)**
10. **Azure CLI**
11. **Managed Identitiy / (C# DefaultAzureCredential class)**
12. **Azure Container Registry**
13. **Azure Container Apps**
14. **Docker**
15. **Github Actions for Continuous Deployment**

## 💡 What to Expect in This Repository

In this GitHub repository, you'll find the result of my endeavors and the demonstration of the skills I acquired while completing this project. I've documented my journey, sharing insights, challenges, and solutions that I encountered along the way. You'll find code snippets, deployment scripts, Infrastructure as Code as I navigated through cloud services, containerization, continuous integration, and more. The goal of this project is to demonstrate my knowledge and practical experience with working in Azure Cloud. 

## Run locally

> Download and install the .NET 6 SDK
#### Check if everything was installed correctly
Once you've installed, open a new terminal and run the following command: `dotnet`  

> Clone this github project
#### Download a copy of the project  
Open the terminal and run the following command: `git clone https://github.com/kevgeowalt/url-shortener-on-cloud-steroids.git`  
Once the command finish executing, take a look through the folder structure and read through the files  

> Run the backend service
In your terminal run the command: `dotnet run --project "backend/shortapi.csproj"`

At this point, your terminal should be filled with errors realating to missing envriomental variables and aunauthroized access to azure resources. Dont worry! We will fix them in the next steps.

## Run in a Dockerized Environment
