# AD&D 2nd Edition

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-03-22T05:12:13.7674293Z
-> tags = 

[ADD2Character]
|> GetAll returnValue=0
|> Initialize
|> GetAll returnValue=3
|> GetNameWithId id=1, returnValue=Test1
|> GetNameWithId id=4, returnValue=EMPTY
|> AddCharacter name=Someone, playedBy=A Person
|> GetNameWithId id=4, returnValue=Someone
|> GetPlayedByWithId id=4, returnValue=A Person
|> GetNameWithId id=3, returnValue=Person
|> UpdateCharacter id=3, name=NewPerson
|> GetNameWithId id=3, returnValue=NewPerson
|> DeleteCharacter id=3
|> GetNameWithId id=3, returnValue=EMPTY
|> EmptyDatabase
~~~
