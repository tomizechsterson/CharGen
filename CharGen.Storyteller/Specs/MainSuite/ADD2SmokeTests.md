# ADD2SmokeTests

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T05:07:39.5431145Z
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
|> GetRetrievedStats str=0, dex=0, con=0, int=0, wis=0, chr=0
|> UpdateCharacter id=3, name=NewPerson, playedBy=Random Person
|> UpdateStats id=3, str=7, dex=7, con=7, int=7, wis=7, chr=7
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=NewPerson
|> GetRetrievedPlayedBy returnValue=Random Person
|> GetRetrievedStats str=7, dex=7, con=7, int=7, wis=7, chr=7
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
