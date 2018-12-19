Jellemző: Automapper
	      Fejlesztőként szükségem van egy adattranszformációra
		  ami stabilan működik a különböző típusú adatok között

Forgatókönyv: Automapper configuration check
	Adott egy felparaméterezett mapper
	Ha ellenőrzöm a konfigurációt
	Akkor a végeredmény azt jelzi, hogy minden rendben

Forgatókönyv: map CurrentDataPoint to ForecastModelDataPoint
	Adott egy felparaméterezett mapper
	Ha egy CurrentDataPoint példányt transzformálok ForecastModelDataPoint típusra
	Akkor a ForecastDataPoint példány jól van kitöltve

Forgatókönyv: map DailyDataPoint to ForecastModelDataPoint
	Adott egy felparaméterezett mapper
	Ha egy DailyDataPoint példányt transzformálok ForecastModelDataPoint típusra
	Akkor a ForecastDataPoint példány jól van kitöltve

Forgatókönyv: map ListOfDailyDataPoint to ListOfForecastModelDataPoint
	Adott egy felparaméterezett mapper
	Ha egy ListOfDailyDataPoint példányt transzformálok ListOfForecastModelDataPoint típusra
	Akkor a ListOfForecastModelDataPoint példány jól van kitöltve

Forgatókönyv: map ApiResult to ForecastModel
	Adott egy felparaméterezett mapper
	Ha egy ApiResult példányt transzformálok ForecastModel típusra
	Akkor a ForecastModel példány jól van kitöltve