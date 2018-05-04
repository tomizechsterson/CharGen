# ADD2SmokeTests

-> id = 593f7d0c-1272-4dc8-81d4-b647d2ab5dd9
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-04T22:08:17.0373202Z
-> tags = 

[ADD2Datastore]
|> GetAll returnValue=0
|> Initialize
|> GetAll returnValue=3
|> RetrieveCharacter id=1
|> GetRetrievedName returnValue=Test1
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=EMPTY
|> AddCharacter name=Character, playedBy=Human
|> RetrieveCharacter id=4
|> GetRetrievedName returnValue=Character
|> GetRetrievedPlayedBy returnValue=Human
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=Person
|> GetRetrievedStats str=0, dex=0, con=0, int=0, wis=0, chr=0
|> GetRetrievedRace returnValue=none
|> GetRetrievedGender returnValue=n
|> GetRetrievedHeightWeightAge height=0, weight=0, age=0
|> UpdateCharacter id=3, name=NewPerson, playedBy=Random Person
|> UpdateStats id=3, str=7, dex=7, con=7, int=7, wis=7, chr=7
|> UpdateRace id=3, race=Elf
|> UpdateGender id=3, gender=F
|> UpdateHeightWeightAge id=3, height=60, weight=100, age=100
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=NewPerson
|> GetRetrievedPlayedBy returnValue=Random Person
|> GetRetrievedStats str=7, dex=7, con=7, int=7, wis=7, chr=7
|> GetRetrievedRace returnValue=Elf
|> GetRetrievedGender returnValue=F
|> GetRetrievedHeightWeightAge height=60, weight=100, age=100
|> DeleteCharacter id=3
|> RetrieveCharacter id=3
|> GetRetrievedName returnValue=EMPTY
|> RetrieveCharacter id=5
|> GetRetrievedName returnValue=EMPTY
|> UpdateCharacter id=5, name=Upserted, playedBy=Generic McRando
|> RetrieveCharacter id=5
|> GetRetrievedName returnValue=Upserted
|> GetRetrievedPlayedBy returnValue=Generic McRando
|> EmptyDatabase
~~~

[ADD2StatRolling]
|> RollStats rule=RollOnce
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=3, returnValue=True
|> CheckValuesOfDieRolls lower=2, higher=19, returnValue=True
|> RollStats rule=RollFour
|> CheckNumberOfRolls returnValue=6
|> CheckNumberOfDiceRolled number=4, returnValue=True
|> CheckValuesOfDieRolls lower=3, higher=25, returnValue=True
|> RollStats rule=AddSevenDice
|> CheckNumberOfRolls returnValue=7
|> CheckNumberOfDiceRolled number=1, returnValue=True
|> CheckValuesOfDieRolls lower=0, higher=7, returnValue=True
|> RollStatsWithInvalidRule
~~~

[RaceSelection]
|> RacesAvailableForStats str=8, dex=5, con=11, int=3, wis=3, chr=8
``` returnValue
Dwarf, Human
```

|> RacesAvailableForStats str=18, dex=18, con=18, int=18, wis=18, chr=18
``` returnValue
Elf, Gnome, Half-Elf, Human
```

|> GetStatAdjustments race=Dwarf
|> AdjustmentCount returnValue=2
|> Adjustments stat1=con, adj1=1, stat2=chr, adj2=-1
|> GetStatAdjustments race=Human
|> AdjustmentCount returnValue=0
~~~

[HeightWeightAge]
|> GivenRaceAndGender race=dwarf, gender=m
|> CheckHeight lowBound=44, highBound=53, returnValue=True
|> CheckWeight lowBound=134, highBound=170, returnValue=True
|> CheckAge lowBound=45, highBound=70, returnValue=True
|> GivenRaceAndGender race=half-elf, gender=f
|> CheckHeight lowBound=60, highBound=70, returnValue=True
|> CheckWeight lowBound=88, highBound=121, returnValue=True
|> CheckAge lowBound=16, highBound=21, returnValue=True
~~~

[ADD2ClassSelection]
|> AvailableClasses race=Half-Elf, str=13, dex=13, con=14, int=3, wis=14, chr=15
``` returnValue
Fighter, Ranger, Cleric, Druid, Thief, Fighter/Cleric, Fighter/Thief, Fighter/Druid, Cleric/Ranger
```

|> AvailableClasses race=Human, str=9, dex=12, con=3, int=13, wis=3, chr=15
``` returnValue
Fighter, Mage, Thief, Bard
```

|> AvailableClasses race=Elf, str=9, dex=9, con=3, int=9, wis=3, chr=3
``` returnValue
Fighter, Mage, Thief, Fighter/Mage, Fighter/Thief, Mage/Thief, Fighter/Mage/Thief
```

|> AvailableClasses race=Gnome, str=8, dex=18, con=10, int=13, wis=18, chr=9
``` returnValue
Cleric, Thief, Cleric/Thief
```

~~~
