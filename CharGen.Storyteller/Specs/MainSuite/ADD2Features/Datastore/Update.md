# Update

-> id = 7168a2c6-8cc5-4587-9163-7e428f24c8b1
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T05:05:13.5125703Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> GetRetrievedPlayedBy returnValue=A Person
|> GetRetrievedStats str=0, dex=0, con=0, int=0, wis=0, chr=0
|> UpdateCharacter id=3, name=ModifiedPerson, playedBy=SomeoneElse
|> UpdateStats id=3, str=3, dex=4, con=5, int=6, wis=7, chr=8
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=ModifiedPerson
|> GetRetrievedPlayedBy returnValue=SomeoneElse
|> GetRetrievedStats str=3, dex=4, con=5, int=6, wis=7, chr=8
|> EmptyDatabase
~~~
