# StartingFundsAndHP

-> id = 62286d7c-7cc1-4b2a-bbbb-322a6d4f4ade
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2019-02-28T04:10:59.4701678Z
-> tags = 

[ADD2InitialFundsAndHP]
|> GivenClass className=Fighter
|> CheckHP lowBound=1, highBound=10
|> CheckFunds lowBound=50, highBound=200
|> GivenClass className=Paladin
|> CheckHP lowBound=1, highBound=10
|> CheckFunds lowBound=50, highBound=200
|> GivenClass className=Ranger
|> CheckHP lowBound=1, highBound=10
|> CheckFunds lowBound=50, highBound=200
|> GivenClass className=Mage
|> CheckHP lowBound=1, highBound=4
|> CheckFunds lowBound=20, highBound=50
|> GivenClass className=Thief
|> CheckHP lowBound=1, highBound=6
|> CheckFunds lowBound=20, highBound=120
|> GivenClass className=Bard
|> CheckHP lowBound=1, highBound=6
|> CheckFunds lowBound=20, highBound=120
|> GivenClass className=Cleric
|> CheckHP lowBound=1, highBound=8
|> CheckFunds lowBound=30, highBound=180
|> GivenClass className=Druid
|> CheckHP lowBound=1, highBound=8
|> CheckFunds lowBound=30, highBound=180
~~~
