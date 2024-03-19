# rickandmorty-umbraco
Umbraco project containing dashboard to load Rick and Morty characters from https://rickandmortyapi.com/.

To run the project:

In Visual Studio: Open the .sln file and run the project in IIS Express.

In VS Code: Open the project in a workspace and generate a launch.json file to run the project as a ".NET Core Launch (web)" type.

The project will run on localhost in a browser, please navigate to "localhost:<port>/umbraco" to open the backoffice.

Please sign in as admin with the email: mjvhudson<span>@</span>outlook.com and password: SecurePassword!

An AllCharacters document should already exist. Please open the Rick And Morty Characters dashboard. Upon opening this dashboard, the characters will begin being imported into content nodes. (As this is not asyncronous, the dashboard UI will not load until the import has finished.)
Please open the AllCharacters document in the content menu. This should now be populated with Character nodes (as shown).
![Characters](https://github.com/mjvhudson/rickandmorty-umbraco/assets/72444915/4f4ab202-d287-4ba8-92e5-6eee3a56574d)

Notes:

The dashboard user input does not properly function (as I could not work this out for razor pages!), so the import is run upon page loading. Because of this, to re-run the import the project must be restarted.
Similarly, there exists a second dashboard with (Angular) in the name, written to use Angular instead. However, I ran out of time before I could get this to work properly.

Considerations:

Images: Currently, the image URl of a character is stored as a string. This could possibly be done by also creating a child node of a media type - but I am not sure if umbraco allows this from a URL!

Existing Content: I decided to have the my code check for existing content, based on the characters generated content node name, and just update any existing character in order to handle any changes to their status, location etc..

User Feedback: Due to issues with the UI in my dashboards I did not successfully implement any user feedback, although did attempt to show the number of characters imported in the Angular dashboard.
I also noticed there is a notification service, perhaps this could be used to display to the user when nodes have been created?
