ImportfromSharePointEGTask
==========================

This is a c# custom task that can be added to SAS Enterprise guide that allows a user to download a SharePoint list and create a SAS Dataset from it. 
Instructions and setup information are located in the "Import Data from SharePoint List".pdf file.

Change History

Version 1.0
	- Created for SAS Global Forum 2014

Version 1.1
	- Added option to remove html from text fields when present
	- Truncate fields in the cards4 statement to be same length as the informat length to avoid 32k byte line length error
	- remove \n characters from multiline text fields so they don't create new rows in the output dataset
	- checked project into github
