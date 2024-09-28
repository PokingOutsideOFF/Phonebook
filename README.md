## Project Overview:
The Phone book console app allows user to store store contacts with their name, phone number and email address, and also to edit or delete a contact
The app also allows to segragate contacts into different categories.
The app also allows to send email and sms to the specified contact.

## Setup Instructions:
1.Set the following environment variables on your local machine or replace them with required values:
   - `DB_SERVER`: Your SQL Server instance name
   - `DB_NAME`: Your database name

2. Modify the configuration file to use these environment variables:
   ```xml
   <configuration>
       <appSettings>
           <add key = "FlashcardsDBConnection" value = "Data Source=${DB_SERVER};Initial Catalog=${DB_NAME};Integrated Security=True;" />
       </appSettings >
   </configuration >
   ```
3. Set up user secrets for following value or replace them with required values:
   - `SENDER_EMAIL`: Required for sending emails
   - `PASSWORD`: Sender email password required for sending emails
   - `Twilio_SID`: Required for sending SMS via Twilio
   - `Twilio_Auth_Token`: Required for sending SMS via Twilio
   - `SENDER_NUMBER`: Required for sending SMS (Twilio Trial Number)
   - `COUNTRY_CODE`: Set up according to specific country's SMS receiver number

4. Set up user secrets in the following manner:
   ```
   dotnet user-secrets "SENDER_EMAIL" your_email_id
   ```
   
5. Perform migrations to create the table
   ```
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
     
## Packages Installed
1. Microsoft.EntityFrameworkCore: It is used to map database with the c# app
2. Microsoft.Extensions.Configuration.UserSecrets: It is used to store sensitive data variable values like email id and password
3. Twilio: It used for sending SMS to specified contact
4. Spectre.Console: It is used for beautification of console App
5. System.Configuration: It is used to get connection string from App.config

## Project Workflow
1. Models
   Contains Contact class which stores the contact name, phone number and email id

2. PhonebookContext:
   This class creates a database context using EF Core and Contact model which is used by Phonebook Repository class for database operations

3. UserInput
   This class takes input from user for performing CRUD operations or for sending mail/SMS.

4. PhonebookService
   This class takes the user input and sends to it the PhonebookRepo class based on the user choice for performing CRUD operation.
   It performs the function of sending mail and sms based on user choice

5. PhonebookRepo
   This class performs CRUD operations using the user inputs
