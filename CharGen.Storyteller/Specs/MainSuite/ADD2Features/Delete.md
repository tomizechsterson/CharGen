# Delete

-> id = e57789ce-016e-432d-b741-adce53c741f0
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-20T04:58:54.4916662Z
-> tags = 

[ADD2Character]
|> Initialize
|> GetAll returnValue=3
|> DeleteCharacter id=3
|> GetAll returnValue=2
|> EmptyDatabase
~~~
