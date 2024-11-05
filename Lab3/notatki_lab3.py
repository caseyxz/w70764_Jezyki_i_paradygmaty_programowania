from abc import ABC, abstractmethod

class Samochod:
    def  __init__(self, marka, model, rok_produkcji, cena):
        self.__marka = marka # atrybut prywatny
        self._model = model  # atrybut wewnętrzny (chroniony)
        self.rok_produkcji = rok_produkcji # atrybut publiczny
        self.cena = cena
        
    def wypisz(self):
        return f"Marka: {self.marka}, Model: {self.model}, Rok: {self.rok_produkcji}"

wozik = Samochod("a", "a1", 2000)
print(wozik.wypisz)

class Pojazd(Samochod): # jest wielodziedziczenie
    def __init__(self, marka, model, rok_produkcji, cena, a):
        super.__init__(marka, model, rok_produkcji, cena)
        self.a = a;


class Zwierze(ABC):
    @abstractmethod
    def mów(self):  
        pass

class Kot(Zwierze):
    def mów(self):
        return "Meow"

class Pies(Zwierze):
    def mów(self):
        return "Bark"