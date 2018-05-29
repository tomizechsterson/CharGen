# Delete

-> id = b623297f-3415-46c7-beee-9b9f947fab43
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-28T23:30:30.3716734Z
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
