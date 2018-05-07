# ClassAvailability

-> id = 36bf4342-a0c7-4d32-ace1-47e10b87c536
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-05T05:56:47.0311781Z
-> tags = 

[ADD2Class]
|> ClassAbilityMinimums str=9, dex=3, con=3, int=3, wis=3, chr=3, returnValue=Fighter
|> ClassAbilityMinimums str=12, dex=3, con=9, int=3, wis=13, chr=17
``` returnValue
Fighter,Paladin,Cleric,Druid
```

|> ClassAbilityMinimums str=13, dex=13, con=14, int=3, wis=14, chr=3
``` returnValue
Fighter, Ranger,Cleric, Thief
```

|> ClassAbilityMinimums str=3, dex=3, con=3, int=9, wis=3, chr=3, returnValue=Mage
|> ClassAbilityMinimums str=3, dex=3, con=3, int=3, wis=9, chr=3, returnValue=Cleric
|> ClassAbilityMinimums str=3, dex=3, con=3, int=3, wis=12, chr=15
``` returnValue
Cleric, Druid
```

|> ClassAbilityMinimums str=3, dex=9, con=3, int=3, wis=3, chr=3, returnValue=Thief
|> ClassAbilityMinimums str=3, dex=12, con=3, int=13, wis=3, chr=15
``` returnValue
Mage, Thief, Bard
```

~~~

[ADD2Class]
|> AvailableClassesForRace race=Dwarf
``` returnValue
Fighter, Cleric, Thief, Fighter/Thief, Fighter/Cleric
```

|> AvailableClassesForRace race=Elf
``` returnValue
Fighter, Ranger, Mage, Cleric, Thief, Fighter/Mage, Fighter/Thief, Mage/Thief, Fighter/Mage/Thief
```

|> AvailableClassesForRace race=Gnome
``` returnValue
Fighter, Cleric, Thief, Fighter/Cleric, Fighter/Thief, Cleric/Thief
```

|> AvailableClassesForRace race=Half-Elf
``` returnValue
Fighter, Ranger, Mage, Cleric, Druid, Thief, Bard, Fighter/Cleric, Fighter/Thief, Fighter/Druid, Fighter/Mage, Cleric/Ranger, Cleric/Mage, Thief/Mage, Fighter/Mage/Cleric, Fighter/Mage/Thief
```

|> AvailableClassesForRace race=Halfling
``` returnValue
Fighter, Cleric, Thief, Fighter/Thief
```

|> AvailableClassesForRace race=Human
``` returnValue
Fighter, Paladin, Ranger, Mage, Cleric, Druid, Thief, Bard
```

~~~

[ADD2Class]
|> AvailableClasses race=Human, str=9, dex=12, con=3, int=13, wis=3, chr=15
``` returnValue
Fighter, Mage, Thief, Bard
```

|> AvailableClasses race=Halfling, str=8, dex=9, con=3, int=3, wis=9, chr=3
``` returnValue
Cleric, Thief
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
