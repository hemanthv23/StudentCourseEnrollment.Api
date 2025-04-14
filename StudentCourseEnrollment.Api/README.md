# 🎓 Student Course Enrollment System – Backend API

A robust backend API built using **ASP.NET Core 9** and **SQL Server** that manages student enrollment workflows with secure **JWT-based authentication**.

---

## ✨ What You’ll Find in This Project

✅ Admin and Student role-based authentication  
✅ User Registration & Secure Login using JWT  
✅ Refresh Token mechanism for session management using **HttpOnly cookies**  
✅ Full Course CRUD Operations (Create, Read, Update, Delete)  
✅ Course Enrollment features for students  
✅ Clean code with Repository Pattern  
✅ Tested via Postman with real-time user examples  
✅ Organized structure for maintainability

---

## 🔐 Authentication & Authorization

- Role-based access (Admin 👨‍🏫 & Student 👨‍🎓)
- JWT Token generation upon login
- **Refresh Token** implementation using **secure HttpOnly cookies**
- Password hashing using SHA256
- Secure user management via `AuthController`

---

## 🏗️ Technologies Used

| Tech                | Purpose                               |
|---------------------|---------------------------------------|
| .NET 9              | Backend Framework                     |
| SQL Server          | Database                              |
| Entity Framework    | ORM for DB interaction                |
| JWT                 | Authentication / Authorization        |
| Visual Studio 2022  | Development Environment               |
| Postman             | API Testing                           |

---

## 📂 Folder Structure

StudentCourseEnrollment.Api  
├── Controllers/             # All API controllers (User, Course, Enrollment)  
├── Models/                  # Domain models (User, Course, Enrollment)  
├── Repositories/            # Interfaces and logic for data access  
├── Data/                    # ApplicationDbContext (EF Core setup)  
├── DTOs/                    # Data Transfer Objects (UserDto, CourseDto, EnrollmentDto)   
├── Program.cs               # Main app configuration  
├── appsettings.json         # DB connection string & JWT settings  
├── StudentCourseEnrollment.Api.csproj  
└── README.md

---

## 📦 INSTALL NECESSARY PACKAGES NEEDED

The following NuGet packages are required for the project:

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package Microsoft.OpenApi.Models
dotnet add package AutoMapper


## 🚀 How to Get Started

1. **Clone the Repository**

   ```bash
   git clone https://github.com/hemanthv23/StudentCourseEnrollment.Api.git
