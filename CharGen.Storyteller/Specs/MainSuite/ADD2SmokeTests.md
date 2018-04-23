# ADD2SmokeTests

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T04:40:32.2905881Z
-> tags = 

[ADD2Datastore]
|> GetAll returnValue=0
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=1
|> GetRetrievedName returnValue=Test1
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=EMPTY
|> AddCharacter name=Character, playedBy=Human
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=Character
|> GetRetrievedPlayedBy returnValue=Human
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> UpdateCharacter id=3, name=NewPerson, playedBy=Random Person
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=NewPerson
|> GetRetrievedPlayedBy returnValue=Random Person
|> DeleteCharacter id=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=EMPTY
|> RetrieveCharacter id=5
|> GetRetrievedName returnValue=EMPTY
|> UpdateCharacter id=5, name=Upserted, playedBy=Generic McRando
|> RetrieveCharacter id=5
|> GetRetrievedName returnValue=Upserted
|> GetRetrievedPlayedBy returnValue=Generic McRando
|> EmptyDatabase
~~~
