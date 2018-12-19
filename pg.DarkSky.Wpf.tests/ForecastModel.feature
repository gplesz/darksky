Jellemző: ForecastModel
	Fejlesztőként szükségem van egy adatmodellre, ami tartalmazza az előrejelzési adatokat.
	Ezen kívül szükségem van egy szolgáltatóra, ami az adatokat hozzáférhatővé teszi. Ez most egy repository lesz.
	A repository azért lehet értelmes megoldás, mert később többféle kérést is ki tud szolgálni, és 
	a már lekérd adatok gyorsítótárazását is rá lehet bízni.

Forgatókönyv vázlat: GetForcastFromRepository
	Adott egy ForecastRepository felparaméterezve  '<ApiKulcs>' paraméterrel
	Ha meghívom az előrejelzés kérését '<Város>' és '<Nyelv>' adatokkal
	Akkor megkapom a megfelelő adatokat ezzel az eredménnyel:  '<Érvényes>'
Példák: 
| tesztnév          | ApiKulcs                         | Város             | Nyelv | Érvényes |
| Bp-hu             | 2f4659626fb968a85a5ff22561962711 | 47.49801,19.03991 | hu    | true     |
| Bp-hu-wrongapikey | wrongapikey                      | 47.49801,19.03991 | hu    | false    |
