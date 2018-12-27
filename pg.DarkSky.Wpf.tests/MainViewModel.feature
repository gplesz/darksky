Jellemző: MainViewModel
	Fejlesztőként szükségem van egy viewmodell-re, ami adakötéssel megjeleníthető a főablakban.

Forgatókönyv vázlat: INotifyPropertyChanged
	Adott egy '<típusnév>' viewmodel
	Ha a '<tulajdonság>' értékét beállítom erre az '<érték>'-re
	Akkor a '<tulajdonság>' értéke ez lesz: '<érték>'
	És a megfelelő esemény megérkezik: '<tulajdonság>'
Példák: 
	| tesztnév                              | típusnév          | tulajdonság         | érték                      |
	| MainViewModel HasSuccess              | MainViewModel     | HasSuccess          | true                       |
	| MainViewModel IsBusy                  | MainViewModel     | IsBusy              | true                       |
	| MainViewModel ForecastApiCalls        | MainViewModel     | ForecastApiCalls    | 5                          |
	| MainViewModel SelectedLanguage        | MainViewModel     | SelectedLanguage    | hu                         |
	| MainViewModel SelectedCity            | MainViewModel     | SelectedCity        | Budapest                   |
	| ForecastViewModel Time                | ForecastViewModel | Time                | 12/27/2018 10:00:00 +01:00 |
	| ForecastViewModel Summary             | ForecastViewModel | Summary             | summary                    |
	| ForecastViewModel Icon                | ForecastViewModel | Icon                | icon                       |
	| ForecastViewModel Temperature         | ForecastViewModel | Temperature         | 5.5                        |
	| ForecastViewModel ApparentTemperature | ForecastViewModel | ApparentTemperature | 5.5                        |
	| ForecastViewModel AtmosphericPressure | ForecastViewModel | AtmosphericPressure | 5.5                        |
	| ForecastViewModel WindSpeed           | ForecastViewModel | WindSpeed           | 5.5                        |
	| ForecastViewModel Humidity            | ForecastViewModel | Humidity            | 5.5                        |
	| ForecastViewModel UvIndex             | ForecastViewModel | UvIndex             | 15                         |

Forgatókönyv vázlat: Current INotifyPropertyChanged
	Adott egy '<típusnév>' viewmodel
	Ha a '<tulajdonság>' értékét beállítom a Current tulajdonságon erre az '<érték>'-re
	Akkor a '<tulajdonság>' a Current tulajdonságon az értéke ez lesz: '<érték>'
	És nem érkezik esemény
Példák: 
	| tesztnév                                  | típusnév      | tulajdonság         | érték                      |
	| MainViewModel Current.Time                | MainViewModel | Time                | 12/27/2018 10:00:00 +01:00 |
	| MainViewModel Current.Summary             | MainViewModel | Summary             | summary                    |
	| MainViewModel Current.Icon                | MainViewModel | Icon                | icon                       |
	| MainViewModel Current.Temperature         | MainViewModel | Temperature         | 5.5                        |
	| MainViewModel Current.ApparentTemperature | MainViewModel | ApparentTemperature | 5.5                        |
	| MainViewModel Current.AtmosphericPressure | MainViewModel | AtmosphericPressure | 5.5                        |
	| MainViewModel Current.WindSpeed           | MainViewModel | WindSpeed           | 5.5                        |
	| MainViewModel Current.Humidity            | MainViewModel | Humidity            | 5.5                        |
	| MainViewModel Current.UvIndex             | MainViewModel | UvIndex             | 15                         |
