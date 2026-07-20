# ERD to Relational Mapping Solution

Batch: Spark to Code 2026  
Sprint: Sprint 3 - Database Fundamentals

## 1. Airline Information System

### AIRPORT

- <u>AirportCode</u> [PK]
- Name
- City
- State

### AIRPLANE_TYPE

- <u>TypeName</u> [PK]
- Company
- MaxSeats

### AIRPORT_AIRPLANE_TYPE

- <u>AirportCode</u> [PK, FK -> AIRPORT.AirportCode]
- <u>TypeName</u> [PK, FK -> AIRPLANE_TYPE.TypeName]

This junction table maps the M:N `ALLOWS_LANDING` relationship.

### AIRPLANE

- <u>AirplaneID</u> [PK]
- TotalSeats
- TypeName [FK -> AIRPLANE_TYPE.TypeName, NOT NULL]

### FLIGHT

- <u>FlightNo</u> [PK]
- Airline
- Restrictions

### FLIGHT_WEEKDAY

- <u>FlightNo</u> [PK, FK -> FLIGHT.FlightNo]
- <u>Weekday</u> [PK]

`Weekdays` is multivalued, so it is stored in a separate table.

### FLIGHT_LEG

- <u>LegNo</u> [PK]
- FlightNo [FK -> FLIGHT.FlightNo, NOT NULL]
- DepartureAirportCode [FK -> AIRPORT.AirportCode, NOT NULL]
- ArrivalAirportCode [FK -> AIRPORT.AirportCode, NOT NULL]
- ScheduledDepartureTime
- ScheduledArrivalTime

The two airport foreign keys map the `DEPARTS_FROM` and `ARRIVES_AT` relationships.

### LEG_INSTANCE

- <u>LegNo</u> [PK, FK -> FLIGHT_LEG.LegNo]
- <u>InstanceDate</u> [PK, partial key]
- AirplaneID [FK -> AIRPLANE.AirplaneID, NOT NULL]
- ActualDepartureTime
- ActualArrivalTime
- AvailableSeats

`LEG_INSTANCE` is weak and is identified by `(LegNo, InstanceDate)`.

### FARE

- <u>FlightNo</u> [PK, FK -> FLIGHT.FlightNo]
- <u>FareCode</u> [PK, partial key]
- Amount

`FARE` is identified by `(FlightNo, FareCode)`.

### RESERVATION

- <u>LegNo</u> [PK]
- <u>InstanceDate</u> [PK]
- <u>SeatNo</u> [PK, partial key]
- CustomerName
- CustomerPhone
- [FK (LegNo, InstanceDate) -> LEG_INSTANCE(LegNo, InstanceDate)]

`RESERVATION` is identified by `(LegNo, InstanceDate, SeatNo)`.

## 2. College Management System

### DEPARTMENT

- <u>DepartmentID</u> [PK]
- DName

### FACULTY

- <u>FacultyID</u> [PK]
- Name
- MobileNo
- Salary
- DepartmentID [FK -> DEPARTMENT.DepartmentID]

### STUDENT

- <u>StudentID</u> [PK]
- FName
- LName
- PhoneNo
- DOB
- DepartmentID [FK -> DEPARTMENT.DepartmentID, NOT NULL]
- HostelID [FK -> HOSTEL.HostelID, NULL allowed]

The composite `Name` attribute is flattened into `FName` and `LName`. `Age` is derived from `DOB`, so it is not stored.

### HOSTEL

- <u>HostelID</u> [PK]
- HostelName
- Address
- City
- State
- PinCode
- NoOfSeats

The address details are stored as individual columns.

### COURSE

- <u>CourseID</u> [PK]
- CourseName
- Duration
- DepartmentID [FK -> DEPARTMENT.DepartmentID, NOT NULL]

### SUBJECT

- <u>SubjectID</u> [PK]
- SubjectName

### EXAM

- <u>ExamCode</u> [PK]
- ExamDate
- ExamTime
- Room
- DepartmentID [FK -> DEPARTMENT.DepartmentID, NOT NULL]

### FACULTY_STUDENT

- <u>FacultyID</u> [PK, FK -> FACULTY.FacultyID]
- <u>StudentID</u> [PK, FK -> STUDENT.StudentID]

Maps the M:N teaching relationship between faculty and students.

### FACULTY_SUBJECT

- <u>FacultyID</u> [PK, FK -> FACULTY.FacultyID]
- <u>SubjectID</u> [PK, FK -> SUBJECT.SubjectID]

### STUDENT_COURSE

- <u>StudentID</u> [PK, FK -> STUDENT.StudentID]
- <u>CourseID</u> [PK, FK -> COURSE.CourseID]

Maps the M:N `ENROLLS_IN` relationship.

### STUDENT_SUBJECT

- <u>StudentID</u> [PK, FK -> STUDENT.StudentID]
- <u>SubjectID</u> [PK, FK -> SUBJECT.SubjectID]

### STUDENT_EXAM

- <u>StudentID</u> [PK, FK -> STUDENT.StudentID]
- <u>ExamCode</u> [PK, FK -> EXAM.ExamCode]

## 3. Company Database

### EMPLOYEE

- <u>SSN</u> [PK]
- FName
- Minit
- LName
- Address
- Sex
- BDate
- Salary
- DepartmentName [FK -> DEPARTMENT.DepartmentName, NOT NULL]
- StartDate
- SupervisorSSN [FK -> EMPLOYEE.SSN, NULL allowed]

The composite `Name` is flattened. `SupervisorSSN` maps the recursive `SUPERVISES` relationship. `StartDate` belongs to `WORKS_FOR` and is stored on the many side.

### DEPARTMENT

- <u>DepartmentName</u> [PK]
- DepartmentNumber [AK, UNIQUE]
- ManagerSSN [FK -> EMPLOYEE.SSN, UNIQUE, NOT NULL]

`ManagerSSN` is placed on `DEPARTMENT` because the department has total participation in the 1:1 `MANAGES` relationship. `NumberOfEmployees` is derived and is not stored.

### DEPARTMENT_LOCATION

- <u>DepartmentName</u> [PK, FK -> DEPARTMENT.DepartmentName]
- <u>Location</u> [PK]

`Locations` is multivalued, so it is mapped to a separate table.

### PROJECT

- <u>ProjectName</u> [PK]
- <u>ProjectNumber</u> [PK]
- Location
- DepartmentName [FK -> DEPARTMENT.DepartmentName, NOT NULL]

The department foreign key maps the 1:N `CONTROLS` relationship.

### WORKS_ON

- <u>EmployeeSSN</u> [PK, FK -> EMPLOYEE.SSN]
- <u>ProjectName</u> [PK]
- <u>ProjectNumber</u> [PK]
- Hours
- [FK (ProjectName, ProjectNumber) -> PROJECT(ProjectName, ProjectNumber)]

This junction table maps the M:N relationship and stores its `Hours` attribute.

### DEPENDENT

- <u>EmployeeSSN</u> [PK, FK -> EMPLOYEE.SSN]
- <u>DependentName</u> [PK, partial key]
- Sex
- BirthDate
- Relationship

`DEPENDENT` is weak and is identified by `(EmployeeSSN, DependentName)`.
