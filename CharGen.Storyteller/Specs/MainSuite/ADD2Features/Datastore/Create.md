# Create

-> id = fb0a27e4-d07f-490d-b3c1-1e4e4044baba
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-21T06:27:16.7585043Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> AddCharacter name=NewCharacter, playedBy=New Person
|> GetAll returnValue=4
|> GetNameWithId id=4, returnValue=NewCharacter
|> GetPlayedByWithId id=4, returnValue=New Person
|> EmptyDatabase
~~~
