﻿insert into Resultaat (wedstrijdID,puntenThuisTeam,puntenUitTeam) values (1,15,3) insert into Wedstrijd (ResultaatWedstrijdID,ThuisTeamID,UitTeamID) values (1,1,2)
--select wedstrijdID,puntenThuisTeam,puntenUitTeam,ThuisTeamID,UitTeamID from Resultaat inner join Wedstrijd on Resultaat.wedstrijdID = Wedstrijd.ResultaatWedstrijdID
--select puntenThuisTeam,puntenUitTeam,ThuisTeamID,UitTeamID from Resultaat,Wedstrijd