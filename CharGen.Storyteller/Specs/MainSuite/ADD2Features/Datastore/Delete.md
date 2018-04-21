# Delete

-> id = e57789ce-016e-432d-b741-adce53c741f0
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-21T06:20:58.3963304Z
-> tags = 

[ADD2Datastore]
|> Initialize
|> GetAll returnValue=3
|> DeleteCharacter id=3
|> GetAll returnValue=2
|> GetNameWithId id=3, returnValue=EMPTY
|> EmptyDatabase
~~~
