# ContactInventory
.NET REST API For Contact Inventory

Created one repository for the Contact Inventory Web API. Please follow below steps while cheching the Qeb APis.

1) Execute the SQL file Named "CreateContact_DB_Script".

2) There are two project one is for Adding Repository,Factory Pattern,Entity Framework,
   for Add/Delete/Update/Find the contact from the DB. Please check the code in "ContactInventory.Repository" Class Library for this.

3) There is one MVC/WEBAPI project(ContactInventory.API) also, were we have created the WEBAPI.We have restricted the result in JSON format and disable the XML format.We have already added the validations for validate all the fields.  Please find below details ABout Web API.
 
	1)  Contact Inventory having below Fields
		ID,FirstName,LastName,Email,PhoneNumber,Status(Active(1)/Inactive(0))
	

	2) User can Insert the Contact into the Database using below WEBAPI using POST 		Verb. Just need to pass the Contact details in JSON Format. For Status 		        We are stoing 1	(Active) and 0 (InActive).

	API : http://localhost:58864/api/contacts
	VERB : POST
	Json : 
		{
		"firstname":"test",
		"lastname":"test",
		"email":"test@gmail.com",
		"phonenumber":"9696965895",
		"status":1,
		}

	3) User can update the Contact into the Database using below WEBAPI using PUT 		Verb. Just need to pass the Contact details in JSON Format.

	API : http://localhost:58864/api/contacts
	VERB : PUT
	Json : 
		{
		"ID":1
		"firstname":"test",
		"lastname":"test",
		"email":"test@gmail.com",
		"phonenumber":"9696965895",
		"status":1,
		}

	2) User can Get all the Contacts using below API using GET Verb

	API:   http://localhost:58864/api/contacts
	VERB : GET

	3)  User can Get the particular contact details using below API. We need to 	            pass the Contact ID for this using GET Verb.
	
	API:   http://localhost:58864/api/contacts/1
	VERB : GET
	

	4)  User can Delete the particular contact details using below API. We need to 	    		pass the Contact ID for this using DELETE Verb

	API:   http://localhost:58864/api/contacts/1
	VERB : GET

