# ADD2SmokeTests

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-21T06:23:58.2276408Z
-> tags = 

[ADD2Datastore]
|> GetAll returnValue=0
|> Initialize
|> GetAll returnValue=3
|> GetNameWithId id=1, returnValue=Test1
|> GetNameWithId id=4, returnValue=EMPTY
|> AddCharacter name=Character, playedBy=Human
|> GetNameWithId id=4, returnValue=Character
|> GetPlayedByWithId id=4, returnValue=Human
|> GetNameWithId id=3, returnValue=Person
|> UpdateCharacter id=3, name=NewPerson, playedBy=Random Person
|> GetNameWithId id=3, returnValue=NewPerson
|> GetPlayedByWithId id=3, returnValue=Random Person
|> DeleteCharacter id=3
|> GetNameWithId id=3, returnValue=EMPTY
|> GetNameWithId id=5, returnValue=EMPTY
|> UpdateCharacter id=5, name=Upserted, playedBy=Generic McRando
|> GetNameWithId id=5, returnValue=Upserted
|> GetPlayedByWithId id=5, returnValue=Generic McRando
|> EmptyDatabase
~~~
