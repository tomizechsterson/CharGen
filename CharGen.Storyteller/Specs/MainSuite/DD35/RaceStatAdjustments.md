# RaceStatAdjustments

-> id = f7f673ab-2101-4da2-96cd-11eebe994e27
-> lifecycle = Acceptance
-> max-retries = 0
-> last-updated = 2018-05-16T04:32:56.8500615Z
-> tags = 

[DD35RaceClass]
|> GetStatAdjustments race=Dwarf
|> AdjustmentCount returnValue=2
|> Adjustment stat=con, adjustment=2
|> Adjustment stat=chr, adjustment=-2
|> GetStatAdjustments race=Elf
|> AdjustmentCount returnValue=2
|> Adjustment stat=dex, adjustment=2
|> Adjustment stat=con, adjustment=-2
|> GetStatAdjustments race=Gnome
|> AdjustmentCount returnValue=2
|> Adjustment stat=con, adjustment=2
|> Adjustment stat=str, adjustment=-2
|> GetStatAdjustments race=Halfling
|> AdjustmentCount returnValue=2
|> Adjustment stat=dex, adjustment=2
|> Adjustment stat=str, adjustment=-2
|> GetStatAdjustments race=Half-Elf
|> AdjustmentCount returnValue=0
|> GetStatAdjustments race=Half-Orc
|> AdjustmentCount returnValue=3
|> Adjustment stat=str, adjustment=2
|> Adjustment stat=int, adjustment=-2
|> Adjustment stat=chr, adjustment=-2
|> GetStatAdjustments race=Human
|> AdjustmentCount returnValue=0
~~~