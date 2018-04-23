# Create

-> id = fb0a27e4-d07f-490d-b3c1-1e4e4044baba
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T04:37:38.4322901Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> AddCharacter name=NewCharacter, playedBy=New Person
|> GetAll returnValue=4
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=NewCharacter
|> GetRetrievedPlayedBy returnValue=New Person
|> EmptyDatabase
~~~
