# HeightWeightAge

-> id = d00a2eaa-c2f8-461e-8364-00ee0e33add2
-> lifecycle = Regression
-> max-retries = 0
-> last-updated = 2018-05-05T05:56:39.1077249Z
-> tags = 

[ADD2HWA]
|> GivenRaceAndGender race=Dwarf, gender=Female
|> CheckHeight lowBound=42, highBound=51, returnValue=True
|> CheckWeight lowBound=109, highBound=145, returnValue=True
|> GivenRaceAndGender race=Dwarf, gender=Male
|> CheckHeight lowBound=44, highBound=53, returnValue=True
|> CheckWeight lowBound=134, highBound=170, returnValue=True
|> CheckAge lowBound=45, highBound=70, returnValue=True
~~~

[ADD2HWA]
|> GivenRaceAndGender race=Elf, gender=Male
|> CheckHeight lowBound=56, highBound=65, returnValue=True
|> CheckWeight lowBound=93, highBound=120, returnValue=True
|> GivenRaceAndGender race=Elf, gender=Female
|> CheckHeight lowBound=51, highBound=60, returnValue=True
|> CheckWeight lowBound=73, highBound=100, returnValue=True
|> CheckAge lowBound=105, highBound=130, returnValue=True
~~~

[ADD2HWA]
|> GivenRaceAndGender race=Gnome, gender=Female
|> CheckHeight lowBound=37, highBound=42, returnValue=True
|> CheckWeight lowBound=73, highBound=88, returnValue=True
|> GivenRaceAndGender race=Gnome, gender=Male
|> CheckHeight lowBound=39, highBound=44, returnValue=True
|> CheckWeight lowBound=77, highBound=92, returnValue=True
|> CheckAge lowBound=63, highBound=96, returnValue=True
~~~

[ADD2HWA]
|> GivenRaceAndGender race=Half-elf, gender=Male
|> CheckHeight lowBound=62, highBound=72, returnValue=True
|> CheckWeight lowBound=113, highBound=146, returnValue=True
|> GivenRaceAndGender race=half-elf, gender=Female
|> CheckHeight lowBound=60, highBound=70, returnValue=True
|> CheckWeight lowBound=88, highBound=121, returnValue=True
|> CheckAge lowBound=16, highBound=21, returnValue=True
~~~

[ADD2HWA]
|> GivenRaceAndGender race=halfling, gender=Female
|> CheckHeight lowBound=32, highBound=46, returnValue=True
|> CheckWeight lowBound=53, highBound=68, returnValue=True
|> GivenRaceAndGender race=halfling, gender=Male
|> CheckHeight lowBound=34, highBound=48, returnValue=True
|> CheckWeight lowBound=57, highBound=72, returnValue=True
|> CheckAge lowBound=23, highBound=32, returnValue=True
~~~

[ADD2HWA]
|> GivenRaceAndGender race=human, gender=Male
|> CheckHeight lowBound=62, highBound=80, returnValue=True
|> CheckWeight lowBound=146, highBound=200, returnValue=True
|> GivenRaceAndGender race=human, gender=Female
|> CheckHeight lowBound=61, highBound=79, returnValue=True
|> CheckWeight lowBound=106, highBound=160, returnValue=True
|> CheckAge lowBound=16, highBound=19, returnValue=True
~~~
