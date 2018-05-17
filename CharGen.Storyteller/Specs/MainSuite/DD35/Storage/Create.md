# Create

-> id = f279b9c3-7636-4ad1-a7d2-31658ce3fe76
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-17T03:52:53.1169642Z
-> tags = 

[DD35Storage]
|> Get id=1
|> CheckName returnValue=EMPTY
|> Create name=test
|> Get id=1
|> CheckName returnValue=test
~~~
