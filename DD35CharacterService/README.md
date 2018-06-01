## Post-Mortem

### Good
1. Dialing back the SQL-speaking objects a bit made reasoning about data-storage-related objects a bit easier 
2. Not seeding database data made db-related tests much easier to manage. Very glad I learned my lesson here
3. StorytellerAssertionException is quite useful for asserting simple facts in Storyteller tests
4. Still liking the use of Storyteller to capture requirements and create executable specifications
5. Still diggin' the Sqlite approach
    * Could maybe look into trying NoSQL to see what that's all about
6. Postman still incredibly helpful for API development

### Bad
1. Still had one controller with all methods. Really should split this up for any projects going forward
2. Could still consider putting more data in the data store for querying as opposed to in the code (e.g. height/weight/age, etc.)

### Notes
* Not quite sold on the TestServer idea. This didn't really come up as a need for this service. Maybe for more complex projects?