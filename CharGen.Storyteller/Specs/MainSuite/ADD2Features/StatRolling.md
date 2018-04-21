# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-21T06:34:16.7372725Z
-> tags = 

[ADD2StatRolling]
|> RollOnce
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
~~~

[ADD2StatRolling]
|> RollTwice
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
~~~

[ADD2StatRolling]
|> Assignment
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
~~~

[ADD2StatRolling]
|> DoubleAssignment
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
~~~

[ADD2StatRolling]
|> RollFour
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4, returnValue=True
~~~

[ADD2StatRolling]
|> AddSevenDice
|> CheckNumberOfRolls returnValue=7
|> CheckNumberOfDiceRolled number=1, returnValue=True
~~~
