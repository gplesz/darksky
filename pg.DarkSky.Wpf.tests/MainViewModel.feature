Jellemző: MainViewModel
	Fejlesztőként szükségem van egy viewmodell-re, ami adakötéssel megjeleníthető a főablakban.


Forgatókönyv vázlat: INotifyPropertyChanged
	Adott egy '<típusnév>' viewmodel
	Ha a '<tulajdonság>' értékét beállítom erre az '<érték>'-re
	Akkor a '<tulajdonság>' értéke ez lesz: '<érték>'
	És a megfelelő esemény megérkezik: '<tulajdonság>'
Példák: 
	| tesztnév                 | típusnév      | tulajdonság | érték |
	| MainViewModel HasSuccess | MainViewModel | HasSuccess  | true  |
	| MainViewModel IsBusy     | MainViewModel | IsBusy      | true  |
