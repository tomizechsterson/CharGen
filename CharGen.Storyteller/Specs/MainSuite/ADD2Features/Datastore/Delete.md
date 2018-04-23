# Delete

-> id = e57789ce-016e-432d-b741-adce53c741f0
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-23T04:37:58.3146113Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> DeleteCharacter id=3
|> GetAll returnValue=2
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=EMPTY
|> EmptyDatabase
~~~
