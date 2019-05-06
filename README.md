# icd0009-2018

Selgitus seoses DTO-de kokkupaneku küsimusega:
Eesmärk on saata kliendile välja selline JSON, kus on kokku koondatud toote nimi (ProductName), sellega seotud firma
(ProductCompany), toote määratlus (ProductClassification) ja manustamisviis (RouteOfAdministration) ehk see on ühe 
vaate andmed. Selleks on loodud DTO ProductOverview (ja täpsemate andmetega variant ProductDetails), mida kantakse
läbi terve projekti kaasa (hetkel ei muutu seal sees iseenesest midagi). Sellist andmetekomplekti ei sisalda ükski 
andmebaasi tabel üksinda, neid tuleb koguda kokku üle mitme tabeli (vt andmebaasi skeemi).

Probleem seisneb alumistes kihtides, kui on soov saada ühendus andmebaasiga ja sealt andmeid pärida (mida siis 
tagasi ülesse suunata). Hetkel suhtlevad andmebaasiga Repository klassid DAL.App.EF.Repositories kaustas. 

Kui soovida nt teha meetodi DAL.App.EF.Repositories.ProductRepository.cs klassi, mis kogub kokku kõik vajaliku 
ProductOverview DTO jaoks, siis seda ei õnnestu teha, sest see pärineb BaseRepository klassist, mis dikteerib, et
see soovib lisaks DTO-le sellele vastava domeeni-objekti, mida antud juhul ei eksisteeri.

Küsimus: kuidas oleks õigem teha?
1. Leida võimalus vastava DTO täitmiseks läbi olemasoleva Repository-süsteemi, mis võib tähendada, et tuleb teha eraldi
Repository, mis ei pärine BaseRepost.
2. Loobuda sellest DTOst täielikult ja teha andmebaasist lihtsalt selle võrra rohkem päringuid (ehk kliendi poolepealt
panna erinevatest DTO-dest tulnud andmed kokku ühesse vaatesse).

Muud ei mõtle hetkel välja.


Maie Palmeos<br>
DK31
<br><br>
HW1 done.<br>
HW2 done.<br>
HW3: done:<br>
User story 1: see all companies and their registered functions.<br>
User story 2: see all substances and how they have been classified.<br>
User story 3: see product complete view.<br>
HW4: done (all previous user stories have been implemented in rest server via BLL/services).

This is my project for Distributed Systems II Spring 2019.<br>
Explanation of project is given in the accompanying PDF file, which will be updated during development.
