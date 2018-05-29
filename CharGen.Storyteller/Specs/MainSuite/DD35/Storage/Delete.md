# Delete

-> id = b623297f-3415-46c7-beee-9b9f947fab43
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-29T04:19:25.5191872Z
-> tags = 

[DD35Storage]
|> Get id=1
|> CheckName returnValue=none
|> Create name=testDelete
|> Get id=1
|> CheckName returnValue=testDelete
|> Delete id=1
|> Get id=1
|> CheckName returnValue=none
~~~
