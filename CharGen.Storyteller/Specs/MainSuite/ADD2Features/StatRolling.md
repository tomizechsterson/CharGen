# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-04T21:46:02.9143202Z
-> tags = 

[ADD2StatRolling]
|> RollStats rule=RollOnce
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=2, higher=19, returnValue=True
~~~

[ADD2StatRolling]
|> RollStats rule=RollTwice
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=2, higher=19, returnValue=True
~~~

[ADD2StatRolling]
|> RollStats rule=Assignment
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=2, higher=19, returnValue=True
~~~

[ADD2StatRolling]
|> RollStats rule=AssignmentDouble
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=2, higher=19, returnValue=True
~~~

[ADD2StatRolling]
|> RollStats rule=RollFour
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=25, returnValue=True
~~~

[ADD2StatRolling]
|> RollStats rule=AddSevenDice
|> CheckNumberOfRolls returnValue=7
|> CheckNumberOfDiceRolled number=1, returnValue=True
|> CheckValuesOfDieRolls lower=0, higher=7, returnValue=True
~~~
