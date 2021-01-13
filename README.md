# one-tap-golf

Prototyp gry One Tap Golf:

1. Na ekranie znajduje się piłka i losowo (w płaszczyźnie X) umieszczona w prawej części ekranu choragiewka z dołkiem oraz licznik punktów (na początku 0).
2. W momencie wciśnięcia i przytrzymania przycisku zaczyna narastać parabola pokazująca ruch jaki wykona piłka. Zwiększa się jej zasięg (ogległość i wysokość). 
3. W momencie puszczenia przycisku następuje wyrzut piłki zgodny z parabolą. Jeśli piłka upadła w dołku doliczany jest punkt, generowany jest kolejny level z inaczej umieszczoną chorągiewką.
Na kolejnym levelu prędkość narastania paraboli jest nieco większa niż na poprzednim.
Jeśli gracz nie puści przycisku a parabola dojdzie do końca ekranu automatycznie wyrzucana jest piłka z tą maksymalną parabolą lotu.

Jeśli piłka nie trafiła do dołka pojawia się okienko GAME OVER z bieżącym wynikiem SCORE: X BEST: Y (BEST oznacza najlepszy dotychczas uzyskany wynik) i przyciskiem umożliwiającym restart gry. Po jego wciśnięciu zaczynamy z wyzerowanym licznikiem punktów.
