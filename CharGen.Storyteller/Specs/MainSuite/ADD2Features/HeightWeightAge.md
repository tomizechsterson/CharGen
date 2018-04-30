# HeightWeightAge

-> id = d00a2eaa-c2f8-461e-8364-00ee0e33add2
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-30T05:41:58.3021814Z
-> tags = 

[HeightWeightAge]
|> StoreRaceAndGender race=Dwarf, gender=F
|> CheckHeight lowBound=42, highBound=51, returnValue=True
|> CheckWeight lowBound=109, highBound=145, returnValue=True
|> StoreRaceAndGender race=Dwarf, gender=m
|> CheckHeight lowBound=44, highBound=53, returnValue=True
|> CheckWeight lowBound=134, highBound=170, returnValue=True
|> CheckAge lowBound=45, highBound=70, returnValue=True
~~~

[HeightWeightAge]
|> StoreRaceAndGender race=Elf, gender=M
|> CheckHeight lowBound=56, highBound=65, returnValue=True
|> CheckWeight lowBound=93, highBound=120, returnValue=True
|> StoreRaceAndGender race=Elf, gender=f
|> CheckHeight lowBound=51, highBound=60, returnValue=True
|> CheckWeight lowBound=73, highBound=100, returnValue=True
|> CheckAge lowBound=105, highBound=130, returnValue=True
~~~

[HeightWeightAge]
|> StoreRaceAndGender race=Gnome, gender=F
|> CheckHeight lowBound=37, highBound=42, returnValue=True
|> CheckWeight lowBound=73, highBound=88, returnValue=True
|> StoreRaceAndGender race=Gnome, gender=m
|> CheckHeight lowBound=39, highBound=44, returnValue=True
|> CheckWeight lowBound=77, highBound=92, returnValue=True
|> CheckAge lowBound=63, highBound=96, returnValue=True
~~~

[HeightWeightAge]
|> StoreRaceAndGender race=Half-elf, gender=M
|> CheckHeight lowBound=62, highBound=72, returnValue=True
|> CheckWeight lowBound=113, highBound=146, returnValue=True
|> StoreRaceAndGender race=half-elf, gender=f
|> CheckHeight lowBound=60, highBound=70, returnValue=True
|> CheckWeight lowBound=88, highBound=121, returnValue=True
|> CheckAge lowBound=16, highBound=21, returnValue=True
~~~

[HeightWeightAge]
|> StoreRaceAndGender race=halfling, gender=F
|> CheckHeight lowBound=32, highBound=46, returnValue=True
|> CheckWeight lowBound=53, highBound=68, returnValue=True
|> StoreRaceAndGender race=halfling, gender=m
|> CheckHeight lowBound=34, highBound=48, returnValue=True
|> CheckWeight lowBound=57, highBound=72, returnValue=True
|> CheckAge lowBound=23, highBound=32, returnValue=True
~~~

[HeightWeightAge]
|> StoreRaceAndGender race=human, gender=M
|> CheckHeight lowBound=62, highBound=80, returnValue=True
|> CheckWeight lowBound=146, highBound=200, returnValue=True
|> StoreRaceAndGender race=human, gender=f
|> CheckHeight lowBound=61, highBound=79, returnValue=True
|> CheckWeight lowBound=106, highBound=160, returnValue=True
|> CheckAge lowBound=16, highBound=19, returnValue=True
~~~
