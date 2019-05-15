#!/bin/sh

#publish all the package files
#nuget push -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
# -Source https://api.nuget.org/v3/index.json ee.itcollege.mpalmeos**Release/ee.itcollege.mpalmeos*.nupkg 

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.BLL.Base/bin/Release/ee.itcollege.mpalmeos.BLL.Base.1.0.0.nupkg

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.Contracts.Base/bin/Release/ee.itcollege.mpalmeos.Contracts.Base.1.0.0.nupkg

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.Contracts.BLL.Base/bin/Release/ee.itcollege.mpalmeos.Contracts.BLL.Base.1.0.0.nupkg

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.Contracts.DAL.Base/bin/Release/ee.itcollege.mpalmeos.Contracts.DAL.Base.1.0.0.nupkg

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.DAL.Base.EF/bin/Release/ee.itcollege.mpalmeos.DAL.Base.EF.1.0.0.nupkg

nuget push -Source https://api.nuget.org/v3/index.json -ApiKey oy2oth6pm3i2gswyvteakzhah4ynn7yejdmoljdvlvzqme \
C:/Users/Maie/Desktop/VõrguRakendused_II/icd0009-2018/ee.itcollege.mpalmeos/ee.itcollege.mpalmeos.Identity/bin/Release/ee.itcollege.mpalmeos.Identity.1.0.0.nupkg