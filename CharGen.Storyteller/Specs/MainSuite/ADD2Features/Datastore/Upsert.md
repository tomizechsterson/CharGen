# Upsert

-> id = 6411b8c5-98ed-40cf-a2e5-42830d6b32d9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T04:38:24.1120206Z
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
|> GetRetrievedPlayedBy returnValue=PersonMan
|> EmptyDatabase
~~~
