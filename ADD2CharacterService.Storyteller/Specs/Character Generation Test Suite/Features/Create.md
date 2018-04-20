# Create

-> id = fb0a27e4-d07f-490d-b3c1-1e4e4044baba
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-20T04:58:49.9804773Z
-> tags = 

[ADD2Character]
|> Initialize
|> GetAll returnValue=3
|> AddCharacter name=NewCharacter, playedBy=A Person
|> GetAll returnValue=4
|> EmptyDatabase
~~~
