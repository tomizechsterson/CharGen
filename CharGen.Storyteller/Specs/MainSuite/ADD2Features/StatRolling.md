# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-21T06:09:03.1162788Z
-> tags = 

[ADD2StatRolling]
|> RollOnce
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> RollTwice
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> Assignment
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> DoubleAssignment
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> RollFour
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4, returnValue=True
|> AddSevenDice
|> CheckNumberOfRolls returnValue=7
|> CheckNumberOfDiceRolled number=1, returnValue=True
~~~
