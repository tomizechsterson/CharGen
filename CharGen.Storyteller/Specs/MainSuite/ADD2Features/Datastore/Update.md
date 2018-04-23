# Update

-> id = 7168a2c6-8cc5-4587-9163-7e428f24c8b1
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T04:37:38.4322901Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> GetRetrievedPlayedBy returnValue=A Person
|> UpdateCharacter id=3, name=ModifiedPerson, playedBy=SomeoneElse
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=ModifiedPerson
|> GetRetrievedPlayedBy returnValue=SomeoneElse
|> EmptyDatabase
~~~
