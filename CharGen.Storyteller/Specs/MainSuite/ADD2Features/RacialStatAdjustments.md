# RacialStatAdjustments

-> id = 1423a9dd-9d3c-45ef-836a-e52dd56127a9
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-04-29T23:41:12.9740257Z
-> tags = 

[RaceSelection]
|> GetStatAdjustments race=Dwarf
|> AdjustmentCount returnValue=2
|> Adjustments stat1=con, adj1=1, stat2=chr, adj2=-1
|> GetStatAdjustments race=Elf
|> AdjustmentCount returnValue=2
|> Adjustments stat1=dex, adj1=1, stat2=con, adj2=-1
|> GetStatAdjustments race=Gnome
|> AdjustmentCount returnValue=2
|> Adjustments stat1=int, adj1=1, stat2=wis, adj2=-1
|> GetStatAdjustments race=Half-Elf
|> AdjustmentCount returnValue=0
|> GetStatAdjustments race=Halfling
|> AdjustmentCount returnValue=2
|> Adjustments stat1=dex, adj1=1, stat2=str, adj2=-1
|> GetStatAdjustments race=Human
|> AdjustmentCount returnValue=0
~~~
