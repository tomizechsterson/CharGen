# Upsert

-> id = 6411b8c5-98ed-40cf-a2e5-42830d6b32d9
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-20T04:58:24.1532924Z
-> tags = 

[ADD2Character]
|> Initialize
|> GetAll returnValue=3
|> UpdateCharacter id=4, name=newToon, playedBy=PersonMan
|> GetAll returnValue=4
|> GetNameWithId id=4, returnValue=newToon
|> EmptyDatabase
~~~
