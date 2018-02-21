# AD&D 2nd Ed Character Service

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-02-21T03:57:11.7350593Z
-> tags = 

[ADD2Character]
|> GetAll returnValue=0
|> Initialize
|> GetAll returnValue=3
|> GetWithId id=1, returnValue=Test1
|> GetWithId id=4, returnValue=EMPTY
|> AddCharacter name=Someone
|> GetWithId id=4, returnValue=Someone
|> GetWithId id=3, returnValue=Person
|> UpdateCharacter id=3, name=NewPerson
|> GetWithId id=3, returnValue=NewPerson
|> DeleteCharacter id=3
|> GetWithId id=3, returnValue=EMPTY
|> EmptyDatabase
~~~
