# Upsert

-> id = 6411b8c5-98ed-40cf-a2e5-42830d6b32d9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-21T06:28:05.2202762Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> GetNameWithId id=4, returnValue=EMPTY
|> UpdateCharacter id=4, name=newToon, playedBy=PersonMan
|> GetAll returnValue=4
|> GetNameWithId id=4, returnValue=newToon
|> GetPlayedByWithId id=4, returnValue=PersonMan
|> EmptyDatabase
~~~
