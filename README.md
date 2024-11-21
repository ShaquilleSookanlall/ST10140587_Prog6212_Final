Contract Monthly Claim System (CMCS)
Overview
The Contract Monthly Claim System (CMCS) is a web-based application built using ASP.NET Core MVC. It streamlines the process of submitting, tracking, and approving claims for Independent Contractor (IC) lecturers. With distinct, role-based functionalities for Lecturers, Coordinators, and Managers, CMCS ensures efficiency, transparency, and accountability throughout the claim management process.

The system includes features like automated validation of claims based on predefined rules, real-time salary calculation for claims, and comprehensive reporting options. It promotes administrative efficiency by automating repetitive tasks and enabling a seamless user experience.

Features by Role
Lecturer Functions
As primary users of the system, lecturers initiate the claim submission process. The system provides the following features for lecturers:

Submit Claims with Real-Time Salary Calculation

Lecturers can create claims by entering hours worked and hourly rate, while the system automatically calculates and displays the total salary in real time.
Supporting documents (PDF, DOCX, XLSX) are mandatory, with a 5 MB file size limit enforced for uploads.
Automated Claim Validation

Claims exceeding 150 hours worked or an hourly rate above $150 are automatically rejected.
Valid claims are submitted with a "Pending" status for further review by coordinators or managers.
Track Claim Status

Lecturers can monitor the status of submitted claims (Pending, Approved, Rejected) in real time, ensuring transparency.
View Claim History

A detailed history of all claims, including statuses and feedback on rejected claims, helps lecturers resubmit with corrections.
Submit Multiple Claims

Lecturers can document and manage work across multiple projects by submitting multiple claims.
Coordinator and Manager Functions
Coordinators and managers oversee claim reviews, ensuring fairness and accountability. Their features include:

View Pending Claims

Access a list of all pending claims for review, prioritized by submission date.
Approve or Reject Claims

Approve valid claims to update their status to "Approved."
Reject invalid claims and provide feedback to help lecturers make necessary corrections.
Access Detailed Claim History

Coordinators and managers can view the full history of all claims for auditing and tracking purposes.
HR Functions
The system also provides features for HR personnel to handle claim processing and reporting:

Generate Reports

Generate PDF or Excel reports of approved claims for payroll processing or record-keeping.
Manage Lecturer Data

HR personnel can update lecturer profiles and view consolidated claim information.
Technical Overview
CMCS is developed using ASP.NET Core MVC with C# for back-end logic. It leverages the Entity Framework for database interactions and includes role-based authentication and authorization. Key features of the technical implementation include:

Authentication and Authorization

Role-based access control ensures secure access for Lecturers, Coordinators, Managers, and HR personnel.
File Storage

Supporting documents are uploaded and stored in the database as binary data, ensuring secure storage and easy retrieval.
Automated Validation

Claims are automatically validated against predefined rules for hours worked and hourly rate, improving accuracy and reducing manual errors.
Responsive Design

The system uses a modern dark-themed interface for accessibility and user comfort.
Error Handling and Validation

Robust error handling ensures that users receive helpful feedback when errors occur (e.g., invalid file type or missing data).
Data Reporting

Built-in report generation allows users to export approved claims in PDF or Excel formats.
User Interface Overview
Key Pages:
Login Page

Users are directed to the login page upon application access or logout.
Submit Claim Page (Lecturer)

Real-time salary calculation is displayed based on hours worked and hourly rate entered by the lecturer.
Includes file validation for supporting documents.
Pending Claims Page (Coordinator/Manager)

Displays a list of claims awaiting review, with options to approve or reject.
Claims History Page (Lecturer)

Displays all submitted claims with statuses and feedback, allowing lecturers to view details or download supporting documents.
Approved Claims Report Page (HR)

HR personnel can view all approved claims and download PDF or Excel reports.
Workflow Summary
Lecturer Workflow:
Submit claims with supporting documents.
View real-time salary calculations.
Track claim statuses.
Resubmit rejected claims after corrections.
Coordinator/Manager Workflow:
Review pending claims.
Approve or reject claims.
Provide feedback on rejected claims.
HR Workflow:
View approved claims.
Generate payroll reports in PDF or Excel formats.
Benefits of CMCS
Automation

Automated validation and salary calculations reduce human error and administrative overhead.
Real-Time Tracking

Users can monitor claim statuses and receive timely feedback on rejections.
Enhanced Security

Role-based access ensures that only authorized users can perform specific actions.
Efficient Reporting

HR can generate reports quickly, streamlining payroll processing.
User-Friendly Interface

The intuitive, responsive design ensures a seamless experience across all roles.
Conclusion
The Contract Monthly Claim System (CMCS) is an efficient and reliable solution for managing claims submitted by Independent Contractor lecturers. By leveraging automation, role-based access, and a user-friendly interface, CMCS ensures that all claims are processed with accuracy, transparency, and accountability.

The project not only simplifies administrative workflows but also provides hands-on experience in ASP.NET Core MVC development and best practices in modern software design.
