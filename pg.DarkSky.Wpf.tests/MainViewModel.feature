Jellemző: MainViewModel
	Fejlesztőként szükségem van egy viewmodell-re, ami adakötéssel megjeleníthető a főablakban.


Forgatókönyv vázlat: INotifyPropertyChanged
	Adott egy viewmodel
	Ha a <tulajdonság> értékét beállítom erre az <érték>-re
	Akkor a <tulajdonság> értéke ez lesz: <érték>
	És a megfelelő esemény megérkezik: <tulajdonság>
Példák: 
	| tulajdonság | érték |
	| HasSuccess  | true  |
	| IsBusy      | true  |