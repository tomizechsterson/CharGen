# Upsert

-> id = 6411b8c5-98ed-40cf-a2e5-42830d6b32d9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-06-27T17:49:19.5549840Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=EMPTY
|> UpdateCharacter id=4, name=newToon, playedBy=PersonMan
|> GetAll returnValue=4
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=newToon
|> EmptyDatabase
~~~
