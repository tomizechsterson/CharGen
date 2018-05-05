#### Ongoing Questions/Insights

1. (bad) Following SQL-speaking objects dogmatically does, in fact, lead to very low efficiency with database calls. Don't need to follow it to its very end. It's also very, very awkward
    * Can most likely follow it to a bit lesser degree for good OO and efficiency middle-ground
2. (good) Acceptance tests w/storyteller helpful
3. (bad) Asserting facts with inputs requires {returnValue} and a bool return value, which generates a checkbox on every step??? WTF!?!?!?!
4. One controller with all methods. Good or bad??
    * Split for next one, then evaluate
5. Data such as height/weight/age tables, better stored in the database?
    * Try relying mostly on database next time, then evaluate
6. (bad) Seeding database data in creation script. Move this to acceptance/unit tests and let creation script only create db
    * Do not allow creation script to insert test data
    * DOING THIS WAS A TERRIBLE IDEA!!! #neverAgain
7. Datastore acceptance tests, specifically updates. Necessary to have them this way?
8. (good) Sqlite; very convenient and lightweight
9. Consider TestServer for integration tests, etc. Maybe replace storyteller? See [this](https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing?view=aspnetcore-2.1) [this](https://www.infoworld.com/article/3258813/web-development/how-to-do-integration-testing-in-aspnet-core.html) [this](http://www.dotnetcurry.com/aspnet-core/1420/integration-testing-aspnet-core)
    * Will this allow the use of IActionResult from controller methods without integration/acceptance test issues?