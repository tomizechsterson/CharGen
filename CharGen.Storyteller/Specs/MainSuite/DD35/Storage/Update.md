# Update

-> id = b91af484-90e0-426b-9ba2-df423adf7924
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-28T23:31:02.9285356Z
-> tags = 

[DD35Storage]
|> Create name=testUpdate
|> Get id=1
|> CheckName returnValue=testUpdate
|> Update id=1, name=updated
|> Get id=1
|> CheckName returnValue=updated
|> Delete id=1
~~~
