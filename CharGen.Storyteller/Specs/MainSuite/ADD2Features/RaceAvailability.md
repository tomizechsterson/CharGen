# RaceAvailability

-> id = 2d930a0c-b2d4-469f-b5bb-867fa76b1b80
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-04-24T05:32:25.9437394Z
-> tags = 

[RaceAvailability]

Restrictions with minimums

|> RacesAvailableForStats str=8, dex=7, con=11, int=8, wis=3, chr=8
``` returnValue
Dwarf, Elf, Gnome, Half-Elf, Halfling, Human
```

|> RacesAvailableForStats str=8, dex=7, con=10, int=8, wis=3, chr=8
``` returnValue
Elf, Gnome, Half-Elf, Halfling, Human
```

|> RacesAvailableForStats str=8, dex=7, con=11, int=5, wis=3, chr=8
``` returnValue
Dwarf, Half-Elf, Human
```

|> RacesAvailableForStats str=8, dex=5, con=11, int=8, wis=3, chr=8
``` returnValue
Dwarf, Gnome, Human
```

|> RacesAvailableForStats str=8, dex=5, con=11, int=3, wis=3, chr=8
``` returnValue
Dwarf, Human
```

~~~

[RaceAvailability]

Restrictions with maximums

|> RacesAvailableForStats str=17, dex=17, con=17, int=17, wis=17, chr=17
``` returnValue
Dwarf, Elf, Gnome, Half-Elf, Halfling, Human
```

|> RacesAvailableForStats str=18, dex=18, con=18, int=18, wis=18, chr=18
``` returnValue
Elf, Gnome, Half-Elf, Human
```

|> RacesAvailableForStats str=18, dex=18, con=18, int=18, wis=17, chr=18
``` returnValue
Elf, Gnome, Half-Elf, Halfling, Human
```

|> RacesAvailableForStats str=18, dex=17, con=18, int=18, wis=18, chr=17
``` returnValue
Dwarf, Elf, Gnome, Half-Elf, Human
```

~~~
