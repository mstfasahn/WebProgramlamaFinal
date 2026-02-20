# Web Programming Final Project

## 📖 About The Project
This repository contains the backend implementation of a comprehensive web application, developed as the final assignment for my Web Programming course. The primary focus of this project is to build a robust, scalable, and secure backend infrastructure.

To maintain a strict focus on backend design patterns, database architecture, and business logic implementation, the frontend UI was generated with AI assistance.

> **Note:** The payment processing module is currently under development (WIP).

## 🚀 Technologies & Patterns Used

**Core & Data**
* .NET Core (ASP.NET Core MVC)
* Entity Framework Core (Code-First Approach)
* AutoMapper (DTO - Entity mapping)

**Architecture & Patterns**
* N-Layered Architecture
* Dependency Injection (DI)
* Asynchronous Programming (`async`/`await`)

**Security & Utilities**
* Custom Authentication & Authorization via Session (`AuthN` & `AuthZ`)
* Custom Permission Attributes for Endpoint Security
* Custom Logging Middleware
* Data Annotations & Model Binding

## 🏗️ Project Structure
The solution follows an **N-Tier Architecture** for strict separation of concerns:

* **`WPF.Models`**: Domain Entities, Data Transfer Objects (DTOs), and core constants. Acts as the data transmission layer.
* **`WPF.DataAccess`**: Houses the `DbContext` and manages all direct database transactions.
* **`WPF.Services`**: Contains business logic, service implementations, and interfaces (contracts).
* **`WepProgramlamaFinal`**: The main ASP.NET Core MVC presentation layer, controllers, and views.
