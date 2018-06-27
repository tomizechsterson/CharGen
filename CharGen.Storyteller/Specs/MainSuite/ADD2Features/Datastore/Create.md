# Create

-> id = fb0a27e4-d07f-490d-b3c1-1e4e4044baba
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-06-27T17:48:44.9425231Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> AddCharacter name=NewCharacter, playedBy=New Person
|> GetAll returnValue=4
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=NewCharacter
|> EmptyDatabase
~~~
