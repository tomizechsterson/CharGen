# Update

-> id = 7168a2c6-8cc5-4587-9163-7e428f24c8b1
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-07T06:30:40.8272215Z
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
|> GetRetrievedHeightWeightAge height=0, weight=0, age=0
|> GetRetrievedClass returnValue=none
|> GetRetrievedAlignment returnValue=none
|> GetRetrievedHP returnValue=0
|> UpdateCharacter id=3, name=ModifiedPerson, playedBy=SomeoneElse
|> UpdateStats id=3, str=3, dex=4, con=5, int=6, wis=7, chr=8
|> UpdateRace id=3, race=Dwarf
|> UpdateGender id=3, gender=M
|> UpdateHeightWeightAge id=3, height=60, weight=160, age=25
|> UpdateClass id=3, className=Fighter
|> UpdateAlignment id=3, alignment=Chaotic Good
|> UpdateHP id=3, hp=4
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=ModifiedPerson
|> GetRetrievedPlayedBy returnValue=SomeoneElse
|> GetRetrievedStats str=3, dex=4, con=5, int=6, wis=7, chr=8
|> GetRetrievedRace returnValue=Dwarf
|> GetRetrievedGender returnValue=M
|> GetRetrievedHeightWeightAge height=60, weight=160, age=25
|> GetRetrievedClass returnValue=Fighter
|> GetRetrievedAlignment returnValue=Chaotic Good
|> GetRetrievedHP returnValue=4
|> EmptyDatabase
~~~
