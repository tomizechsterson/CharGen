#### Ongoing Questions/Insights

1. (bad) Following SQL-speaking objects dogmatically does, in fact, lead to very low efficiency with database calls. Don't need to follow it to its very end
    * Can most likely follow it to a bit lesser degree for good OO and efficiency middle-ground
2. (good) Acceptance tests w/storyteller helpful
3. (bad) Asserting facts with inputs requires {returnValue} and a bool return value, which generates a checkbox on every step??? WTF!?!?!?!
4. One controller with all methods. Good or bad??
5. Data such as height/weight/age tables, better stored in the database?
6. Seeding database in creation script. Most likely bad. Move to acceptance/unit tests and let creation script only create db
7. Datastore acceptance tests, specifically updates. Necessary to have them this way?
8. (good) Sqlite; very convenient and lightweight 