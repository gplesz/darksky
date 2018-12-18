Jellemző: ForecastModel
	Fejlesztőként szükségem van egy adatmodellre, ami szolgáltatja az előrejelzési adatokat

Forgatókönyv vázlat: GetForcast
	Adott egy ForecastModel felparaméterezve  '<ApiKulcs>' '<Város>' és '<Nyelv>' adatokkal
	Ha meghívom az előrejelzés kérését
	Akkor megkapom a megfelelő adatokat ezzel az eredménnyel:  '<Érvényes>'
Példák: 
| tesztnév          | ApiKulcs                         | Város             | Nyelv | Érvényes |
| Bp-hu             | 2f4659626fb968a85a5ff22561962711 | 47.49801,19.03991 | hu    | true     |
| Bp-hu-wrongapikey | wrongapikey                      | 47.49801,19.03991 | hu    | false    |
