# Create

-> id = f279b9c3-7636-4ad1-a7d2-31658ce3fe76
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-29T04:19:20.4708984Z
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
