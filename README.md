### **Smart Healthcare System (Full Stack Project - V2)**

## **Overview**
A comprehensive **full-stack** web application designed for managing healthcare-related data, including users, reviews, nurses, doctors, medical centers, diseases, departments, bookings, and awareness videos. This version extends the previous Web API (V1) by integrating a **React-based frontend**, offering an intuitive user interface for interacting with the system.

## **Key Features**

### **🔒 Authentication & Authorization:**
- Secure user authentication with **JWT tokens**.
- Role-based access control to ensure secure API usage.

### **👥 User Management:**
- User registration, login, and password reset functionalities.
- Fetch, update, and delete user information.

### **🏥 Healthcare Professional Management:**
- Manage **doctors, nurses, and their profiles**.
- Appointment booking system for both doctors and nurses.

### **🏢 Medical Center & Department Management:**
- Create and manage medical centers and their respective departments.

### **⭐ Review System:**
- Users can submit reviews for healthcare services.
- Retrieve and manage user feedback efficiently.

### **🩺 Disease & Symptom Management:**
- Create and track diseases and symptoms.
- Link symptoms to diseases for a comprehensive medical dataset.

### **📅 Booking System:**
- Manage appointments for doctors and nurses with scheduling features.

### **🖥️ Full Frontend Integration:**
- **Interactive React UI** for seamless interaction with the API.
- **Responsive Design** using **HTML, CSS, and JavaScript**.
- **Fetch API / Axios** for consuming backend services.
- **User-friendly navigation and authentication forms**.

### **📑 API Documentation:**
- Detailed **Swagger** and **Postman** documentation for easy testing.

## **Technologies Used**

### **Backend:**
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- System.Text.Json
- Swagger / Postman for API Documentation

### **Frontend:**
- React.js (JSX & Components)
- HTML, CSS (Responsive UI)
- JavaScript (Fetch API / Axios for API communication)
- React Router for navigation
- Bootstrap / Tailwind CSS for styling


## **Endpoints Overview**  

### **User Management**  
- `POST: api/Users/register` – Register a new user.  
- `POST: api/Users/login` – Authenticate and return JWT token.  
- `POST: api/Users/SendTokenToEmail` – Send a reset token via email.  
- `POST: api/Users/ResetPassword` – Reset user password.  
- `POST: api/Users/VerifyToken` – Verify reset token.  
- `POST: api/Users/CheckToken` – Check token validity (**Authorized**).  
- `GET: api/Users/GetAll` – Retrieve all users.  
- `GET: api/Users/{id}` – Retrieve user details by ID.  
- `GET: api/Users/me` – Retrieve the currently logged-in user (**Authorized**).  
- `PUT: api/Users` – Update user details (**Authorized**).  

### **Review Management**  
- `GET: api/Reviews/GetAll` – Retrieve all reviews.  
- `GET: api/Reviews/{id}` – Retrieve a review by ID.  
- `GET: api/Reviews/reviews/{doctorId}` – Retrieve reviews for a specific doctor.  
- `POST: api/Reviews/Create` – Add a new review.  

### **Healthcare Professional Management**  
- **Doctors**:  
  - `POST: api/Doctors/Create` – Add a new doctor.  
  - `GET: api/Doctors/GetAll` – Retrieve all doctors.  
  - `GET: api/Doctors/{id}` – Retrieve doctor details by ID.  
  - `GET: api/Doctors/by-department/{departmentId}` – Retrieve doctors by department.  

- **Nurses**:  
  - `POST: api/Nurses/Create` – Add a new nurse.  
  - `GET: api/Nurses/GetAll` – Retrieve all nurses.  
  - `GET: api/Nurses/{id}` – Retrieve nurse details by ID.  

### **Medical Center & Department Management**  
- **Medical Centers**:  
  - `GET: api/MedicalCenters/GetAll` – Retrieve all medical centers.  
  - `GET: api/MedicalCenters/{id}` – Retrieve medical center details by ID.  
  - `POST: api/MedicalCenters/Create` – Add a new medical center.  

- **Departments**:  
  - `GET: api/Departments/GetAll` – Retrieve all departments.  
  - `GET: api/Departments/{id}` – Retrieve department details by ID.  
  - `POST: api/Departments/Create` – Add a new department.  

### **Disease & Symptom Management**  
- `POST: api/Diseases/CreateDisease` – Create a new disease.  
- `POST: api/Diseases/CreateSymptom` – Create a new symptom.  
- `POST: api/Diseases/CreateDiseaseSymptom` – Link a disease to a symptom.  
- `GET: api/Diseases/GetAllDisease` – Retrieve all diseases.  

### **Booking Management**  
- **Doctor Bookings**:  
  - `GET: api/Bookings/GetAllBookingsForDoctor` – Retrieve all bookings for a doctor.  
  - `POST: api/Bookings/CreateBookingForDoctor` – Create a new booking for a doctor.  

- **Nurse Bookings**:  
  - `GET: api/Bookings/GetAllBookingsForNurse` – Retrieve all bookings for a nurse.  
  - `POST: api/Bookings/CreateBookingForNurse` – Create a new booking for a nurse.  

- **User-Specific Bookings**:  
  - `GET: api/Bookings/User` – Retrieve all bookings for the logged-in user (**Authorized**).  
  - `DELETE: api/Bookings/{id}` – Delete a booking for the user.  
  - `DELETE: api/Bookings/deleteNurse/{id}` – Delete a nurse booking for the user.  

---

## **Frontend Features & Components**
- **Authentication Pages** (Login, Register, Password Reset)
- **Dashboard** (Displays statistics and available services)
- **User Profile Page** (Manage account details)
- **Doctor & Nurse Listings** (Search and book appointments)
- **Review System UI** (Submit and view reviews)
- **Booking Page** (Schedule and manage bookings)
- **Awareness Videos Section** (Educational videos display)
- **Mobile-friendly design** for better accessibility

## **Security & Validation**

### **🔐 Authentication:**
- Secure **JWT-based authentication** for all endpoints.

### **🔒 Authorization:**
- Ensures that only **authenticated users** can access restricted features.

### **📊 Input Validation:**
- Ensures **accurate and structured data submission**.

### **⚠️ Error Handling:**
- Provides clear **error messages** for debugging and user guidance.

## **🌍 Live Demo & Deployment**
- **Frontend (React):** [Deployed Link]
- **Backend API:** [Deployed API Link]

## **🎯 Outcome**
A fully functional **full-stack** system that provides **secure authentication, comprehensive healthcare management, booking capabilities, and an interactive user interface**. With **React.js frontend and ASP.NET Core backend**, this project delivers a scalable and efficient solution for healthcare operations.
