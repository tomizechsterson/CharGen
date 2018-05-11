## Post-Mortem

### Bad
1. Following SQL-speaking objects dogmatically does, in fact, lead to very low efficiency with database calls. Don't need to follow it to its very end. It's also very, very awkward
    * Decrease the extreme to which this is followed and re-evaluate
2. Asserting facts with inputs requires {returnValue} and a bool return value, which generates a checkbox on every step??? WTF!?!?!?!
    * Discovered the use of StorytellerAssertionException that can be used for this, and eliminates the superfluous check boxes.
3. One controller with all methods. Clear SRP violation
    * Split service into multiple controllers and re-evaluate
4. Seeding database test data in db creation script was a very bad idea
    * DON'T DO THIS - the acceptance/unit tests can take care of this themselves
5. Don't think data such as height/weight/age, saving throws should be in code
    * Try storing this info in the database the re-evaluate
    
### Good
1. Storyteller good for acceptance tests/executable specifications
2. SQLite - convenient and lightweight
    * Attack in-memory option for tests again. Try allowing tests to get connection object out of datastore (optional parameter on constructor?)
3. Postman good replacement for API smoke tests, since we're dealing strictly with data

### Notes
* Datastore acceptance tests will have large update spec since that reflects the use of the final application
* Consider TestServer for integration tests. Maybe replace storyteller? Will this allow the use of IActionResult from controller methods without acceptance test issues?
    * [link](https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing?view=aspnetcore-2.1)
    * [link](https://www.infoworld.com/article/3258813/web-development/how-to-do-integration-testing-in-aspnet-core.html)
    * [link](http://www.dotnetcurry.com/aspnet-core/1420/integration-testing-aspnet-core)