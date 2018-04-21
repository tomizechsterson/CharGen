# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-21T05:33:11.0831357Z
-> tags = 

[ADD2StatRolling]
|> RollOnce
|> CheckNumberOfRolls returnValue=6
|> RollTwice
|> CheckNumberOfRolls returnValue=12
|> Assignment
|> CheckNumberOfRolls returnValue=6
|> DoubleAssignment
|> CheckNumberOfRolls returnValue=12
|> RollFour
|> CheckNumberOfRolls returnValue=6
|> AddSevenDice
|> CheckNumberOfRolls returnValue=7
~~~
