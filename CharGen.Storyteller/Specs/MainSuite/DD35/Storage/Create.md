# Create

-> id = f279b9c3-7636-4ad1-a7d2-31658ce3fe76
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-29T03:22:47.2728186Z
-> tags = 

[DD35Storage]
|> Get id=1
|> CheckName returnValue=none
|> Create name=test
|> Get id=1
|> CheckName returnValue=test
|> CreateDup name=test
|> Delete id=1
~~~
