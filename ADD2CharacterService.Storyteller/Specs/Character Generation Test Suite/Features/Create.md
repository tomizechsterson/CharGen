# Create

-> id = fb0a27e4-d07f-490d-b3c1-1e4e4044baba
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-20T02:50:18.1955213Z
-> tags = 

[ADD2Character]
|> Initialize
|> GetAll returnValue=3
|> AddCharacter name=NewCharacter, playedBy=A Person
|> GetAll returnValue=4
|> EmptyDatabase
~~~
