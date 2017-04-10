EH Project Exercise
============================================

## Project exercise
Project Description:
Design and implement a production ready application for maintaining contact information.
Expected functionality:<br />
		- add a contact<br />
		- list contacts<br />
		- edit contact<br />
		- delete contact<br />
		<br />
		Required Contact model:<br />
		- First Name<br />
		- Last Name<br />
		- Email<br />
		- Phone Number<br />
		- Status (Possible values: Active/Inactive)<br />

## To Run the application:
* Visual Studio 2015
* SQL Server
* .NET Framework 4.6.1
* ASP.NET MVC 5

	1. Open EHSolution.sln in Visual Studio 2015
	2. Open SQL Server and Create new database
	3. In Visual Studio 2015, Open folder called App_Data in project MaintainContacts.Main and copy content on SqlScript.txt
	4. In SQL Server, Execute copied content on newly created database in step 2
	5. In Visual Studio 2015,Update connection string (name=DbContactsContext) in web.config file of root folder in project MaintainContacts.Main

**Note:** Please review Logs folder for any application error. Used Log4Net for logging.

**For Demo:** http://test.softwaredeveloper.tech
