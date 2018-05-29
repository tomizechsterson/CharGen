# GetAll

-> id = fe3890c2-8ac4-492e-be2e-775ea6cbc0dc
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-29T04:06:34.8171055Z
-> tags = 

[DD35Storage]
|> Get id=1
|> CheckName returnValue=none
|> Get id=2
|> CheckName returnValue=none
|> Create name=first
|> Create name=second
|> GetAll returnValue=2
|> Get id=1
|> CheckName returnValue=first
|> Get id=2
|> CheckName returnValue=second
|> Delete id=1
|> Delete id=2
~~~
