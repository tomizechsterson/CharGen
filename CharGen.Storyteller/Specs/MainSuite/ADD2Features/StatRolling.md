# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-21T02:05:23.5387759Z
-> tags = 

[ADD2StatRolling]
|> RollOnce
|> CheckNumberOfRolls returnValue=6
|> RollTwice
|> CheckNumberOfRolls returnValue=12
~~~
