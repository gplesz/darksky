Jellemző: MainViewModel
	Fejlesztőként szükségem van egy viewmodell-re, ami adakötéssel megjeleníthető a főablakban.

Forgatókönyv vázlat: INotifyPropertyChanged
	Adott egy '<típusnév>' viewmodel
	Ha a '<tulajdonság>' értékét beállítom erre az '<érték>'-re
	Akkor a '<tulajdonság>' értéke ez lesz: '<érték>'
	És a megfelelő esemény megérkezik: '<esemény>'
Példák: 
	| tesztnév                              | típusnév          | tulajdonság         | esemény                                     | érték                      |
	| MainViewModel HasSuccess              | MainViewModel     | HasSuccess          | HasSuccess                                  | true                       |
	| MainViewModel IsBusy                  | MainViewModel     | IsBusy              | IsBusy                                      | true                       |
	| MainViewModel ForecastApiCalls        | MainViewModel     | ForecastApiCalls    | ForecastApiCalls                            | 5                          |
	| MainViewModel ErrorMessage            | MainViewModel     | ErrorMessage        | ErrorMessage                                | Hiba történt!!!            |
	| ForecastViewModel Time                | ForecastViewModel | Time                | Time                                        | 12/27/2018 10:00:00 +01:00 |
	| ForecastViewModel Summary             | ForecastViewModel | Summary             | Summary                                     | summary                    |
	| ForecastViewModel Icon                | ForecastViewModel | Icon                | Icon                                        | icon                       |
	| ForecastViewModel Temperature         | ForecastViewModel | Temperature         | Temperature                                 | 5.5                        |
	| ForecastViewModel ApparentTemperature | ForecastViewModel | ApparentTemperature | ApparentTemperature                         | 5.5                        |
	| ForecastViewModel AtmosphericPressure | ForecastViewModel | AtmosphericPressure | AtmosphericPressure,AtmosphericPressureText | 5.5                        |
	| ForecastViewModel WindSpeed           | ForecastViewModel | WindSpeed           | WindSpeed,WindSpeedText                     | 5.5                        |
	| ForecastViewModel Humidity            | ForecastViewModel | Humidity            | Humidity,HumidityText                       | 5.5                        |
	| ForecastViewModel UvIndex             | ForecastViewModel | UvIndex             | UvIndex                                     | 15                         |

# Ezeket kiveszem, mert megváltozott a típusa a property-knek sima szövegről dto-ra, így saját tesztet kéne írni rá
#| MainViewModel SelectedLanguage | MainViewModel       | SelectedLanguage    | SelectedLanguage           | hu |
#| MainViewModel SelectedCity     | MainViewModel       | SelectedCity        | SelectedCity               | Budapest |

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
