Jellemző: ApiRequests
	Fejlesztőként szükségem van egy osztályra, amin keresztül elérem az API felületet.

Forgatókönyv vázlat: GetDataWithCoordinateAndLanguage
	Adott egy API kapcsolat '<ApiKulcs>' '<Város>' és '<Nyelv>' adatokkal
	Ha lekérdezem az időjárási adatokat
	Akkor a válasz <Érvényes> lesz
Példák: 
| tesztnév | ApiKulcs                         | Város             | Nyelv | Érvényes |
| Bp-hu    | 2f4659626fb968a85a5ff22561962711 | 47.49801,19.03991 | hu    | true     |