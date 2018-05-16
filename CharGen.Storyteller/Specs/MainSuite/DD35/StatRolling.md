# StatRolling

-> id = b2562d3c-f9f4-4fab-83b8-0ece69b50329
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-16T03:59:01.9166700Z
-> tags = 

[DD35StatRolls]
|> RollStats
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4
|> CheckValuesOfDieRolls lower=4, higher=24
~~~
