# InitialFunds

-> id = b0b4cf83-dabb-4d2b-843c-e34eb202a4e2
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-10T06:22:46.0028540Z
-> tags = 

[ADD2InitialFunds]
|> GetFunds className=Fighter, low=50, high=200, returnValue=True
|> GetFunds className=Ranger, low=50, high=200, returnValue=True
|> GetFunds className=Paladin, low=50, high=200, returnValue=True
|> GetFunds className=Mage, low=20, high=50, returnValue=True
|> GetFunds className=Thief, low=20, high=120, returnValue=True
|> GetFunds className=Bard, low=20, high=120, returnValue=True
|> GetFunds className=Cleric, low=30, high=180, returnValue=True
|> GetFunds className=Druid, low=30, high=180, returnValue=True
~~~
