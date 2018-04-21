# Update

-> id = 7168a2c6-8cc5-4587-9163-7e428f24c8b1
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-20T04:58:57.6834306Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> GetNameWithId id=3, returnValue=Person
|> UpdateCharacter id=3, name=ModifiedPerson, playedBy=SomeoneElse
|> GetNameWithId id=3, returnValue=ModifiedPerson
|> EmptyDatabase
~~~
