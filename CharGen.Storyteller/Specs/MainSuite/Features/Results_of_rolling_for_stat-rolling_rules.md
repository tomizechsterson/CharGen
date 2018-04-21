# Results of rolling for stat-rolling rules

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-21T01:35:41.6771099Z
-> tags = 

[StatRolling]
|> RollOnce
|> CheckNumberOfRolls returnValue=6
|> RollTwice
|> CheckNumberOfRolls returnValue=12
~~~
