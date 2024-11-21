Contract Monthly Claim System (CMCS)

Overview

The Contract Monthly Claim System (CMCS) is a web-based application developed using ASP.NET Core MVC. It simplifies the process of submitting, tracking, and approving claims for Independent Contractor (IC) lecturers. The system streamlines the workflow for lecturers, coordinators, and managers, ensuring efficiency, transparency, and accountability. Through a role-based structure, CMCS provides distinct functionalities for each user type, ensuring a seamless claim management process.

Lecturers can submit claims with attached supporting documents, track the status of their submissions, and view their claim history. Coordinators and managers are responsible for reviewing, approving, or rejecting these claims, ensuring their accuracy and completeness. The system reduces administrative overhead, allowing users to focus on more strategic activities.

Lecturer Functions

As the primary users, lecturers play a crucial role in initiating the claim process by submitting claims that reflect their work accurately. The system provides several features to support lecturers:

1. Submit Claims with Supporting Documents
Lecturers can create and submit claims by providing essential details such as hours worked and the applicable hourly rate. Each submission requires a supporting document (PDF, DOCX, or XLSX) to validate the claim. The system enforces a 5 MB file size limit to ensure manageable uploads.

2. Track Claim Status
The system provides lecturers with real-time access to the status of their submitted claims. Each claim can have one of three statuses: Pending, Approved, or Rejected, promoting transparency.

3. View Claim History
Lecturers can view a detailed history of all submitted claims, including their status and any feedback provided. This feature ensures that lecturers remain informed about their submissions and can resubmit rejected claims with corrections if necessary.

4. Create Multiple Claims
Lecturers are not limited in the number of claims they can submit. This feature supports lecturers managing multiple projects, allowing them to document all their work comprehensively.

Coordinator and Manager Functions
Coordinators and managers share the responsibility of ensuring claim accuracy by reviewing, approving, or rejecting claims. Their actions ensure fair compensation and accountability in the system.

1. View Pending Claims
Coordinators and managers can view a list of all pending claims awaiting review. Claims are organized by submission date, ensuring that no claim is missed, and reviews can be prioritized effectively.

2. Approve Claims
After verifying the hours worked and the attached supporting documents, coordinators and managers can approve valid claims. Approved claims are updated with a status of Approved, and the lecturer is notified of the approval.

3. Reject Claims
If discrepancies are found in a claim, such as incorrect hours or missing documents, coordinators and managers can reject it. The system allows them to provide feedback, helping the lecturer make the necessary corrections and resubmit the claim.

Technical Overview

The CMCS is developed using ASP.NET Core MVC, leveraging C# for backend functionality. It features role-based authentication, ensuring secure access to specific pages based on user roles (Lecturer, Coordinator, Manager). For the development phase, the system uses an in-memory database to store claims and user information. This can be replaced with an Azure SQL Database or SQL Server in a production environment.

All uploaded documents are stored under the /wwwroot/uploads directory, making them easily accessible for review and reference.

User Interface Overview
CMCS offers a clean, role-specific interface that enhances usability. Each role—Lecturer, Coordinator, and Manager—has unique pages tailored to their needs, ensuring efficient task completion.

1. Homepage
The homepage provides an overview of the system with login options for lecturers, coordinators, and managers. Upon logging in, users are redirected to their respective dashboards based on their role.

2. Submit Claim Page
Lecturers can submit new claims from this page. It includes real-time validation to ensure uploaded documents meet the size and file type requirements, minimizing submission errors.

3. Pending Claims Page
Coordinators and managers can access this page to view all pending claims. Each claim is displayed with the necessary details, allowing them to approve or reject submissions efficiently.

4. Claims History Page
Lecturers can view their complete claim history, including submission dates, statuses, and feedback. They can also download previously uploaded documents for review or resubmission.

Workflow Summary
The CMCS system ensures smooth collaboration between lecturers, coordinators, and managers. Below is a summary of the workflow:

Lecturer:

Submit claims with supporting documents.
Track claim statuses in real-time.
Review rejected claims and resubmit corrections.

Coordinator/Manager:

Review and approve valid claims.
Reject invalid claims with feedback.
Ensure that the claim process is transparent and efficient.
This workflow ensures that every claim is processed accurately and efficiently, maintaining accountability throughout the process.

Error Handling and Validation

To ensure a reliable user experience, CMCS includes comprehensive error handling and validation mechanisms:

File Validation: Uploaded documents must be in PDF, DOCX, or XLSX format and must not exceed 5 MB in size.
Authentication: Role-based authentication ensures only authorized users can access specific pages.
Error Pages: If an error occurs (e.g., missing documents or unauthorized access), the system provides user-friendly error messages to guide users.
Benefits of the CMCS System
The CMCS offers several advantages, including:

Streamlined Workflows: Automated processes minimize manual effort and reduce administrative overhead.
Improved Accuracy: Coordinators and managers can easily verify claims with supporting documents.
Real-time Tracking: Users can monitor the status of claims and receive timely feedback on rejections.
User-Friendly Interface: Role-specific pages ensure that users can efficiently perform their tasks.
By automating repetitive tasks, CMCS allows users to focus on more strategic activities. The system promotes continuous improvement by providing feedback on rejected claims, helping lecturers learn from mistakes and submit better claims.

Conclusion
The Contract Monthly Claim System (CMCS) provides an efficient solution for managing monthly claims for Independent Contractor lecturers. Through role-based access, automated workflows, and real-time tracking, CMCS ensures that claims are processed with accuracy and accountability.

The system not only simplifies administrative tasks but also promotes continuous learning and improvement through feedback on rejected claims. Whether you're a lecturer tracking your claim status or a manager reviewing submissions, CMCS makes the process seamless and intuitive.

With hands-on interaction, users gain practical experience in ASP.NET Core MVC development and learn to apply best practices in software design. CMCS equips users with the skills needed to tackle real-world challenges in software development.
