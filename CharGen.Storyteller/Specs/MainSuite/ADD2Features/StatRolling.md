# StatRolling

-> id = bacf30b2-2683-48e6-b28f-e97afeade3ec
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-11T21:26:10.9742675Z
-> tags = 

[ADD2StatRolls]
|> RollStats rule=RollOnce
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=18, returnValue=True
~~~

[ADD2StatRolls]
|> RollStats rule=RollTwice
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=18, returnValue=True
~~~

[ADD2StatRolls]
|> RollStats rule=Assignment
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=18, returnValue=True
~~~

[ADD2StatRolls]
|> RollStats rule=AssignmentDouble
|> CheckNumberOfRolls returnValue=12
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=18, returnValue=True
~~~

[ADD2StatRolls]
|> RollStats rule=RollFour
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4, returnValue=True
|> CheckValuesOfDieRolls lower=4, higher=24, returnValue=True
~~~

[ADD2StatRolls]
|> RollStats rule=AddSevenDice
|> CheckNumberOfRolls returnValue=7
|> CheckNumberOfDiceRolled number=1, returnValue=True
|> CheckValuesOfDieRolls lower=1, higher=6, returnValue=True
~~~

[ADD2StatRolls]
|> RollStatsWithInvalidRule
~~~
