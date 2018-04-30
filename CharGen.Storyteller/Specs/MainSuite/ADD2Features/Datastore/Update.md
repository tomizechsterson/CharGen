# Update

-> id = 7168a2c6-8cc5-4587-9163-7e428f24c8b1
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-30T03:20:08.5313406Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> GetRetrievedPlayedBy returnValue=A Person
|> GetRetrievedRace returnValue=none
|> GetRetrievedGender returnValue=n
|> GetRetrievedStats str=0, dex=0, con=0, int=0, wis=0, chr=0
|> UpdateCharacter id=3, name=ModifiedPerson, playedBy=SomeoneElse
|> UpdateStats id=3, str=3, dex=4, con=5, int=6, wis=7, chr=8
|> UpdateRace id=3, race=Dwarf
|> UpdateGender id=3, gender=M
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=ModifiedPerson
|> GetRetrievedPlayedBy returnValue=SomeoneElse
|> GetRetrievedStats str=3, dex=4, con=5, int=6, wis=7, chr=8
|> GetRetrievedRace returnValue=Dwarf
|> GetRetrievedGender returnValue=M
|> EmptyDatabase
~~~
