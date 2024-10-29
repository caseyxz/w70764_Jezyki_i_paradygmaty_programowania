from functools import reduce

def harmonogram_funkcyjny(zadania):
    zadania_posortowane = sorted(zadania, key=lambda x: x[1])

    
    def wybierz_zadania(acc, zadanie):
        wybrane, ostatnie_zakonczenie, suma_nagrod = acc
        start, koniec, nagroda = zadanie
        if start >= ostatnie_zakonczenie:
            return wybrane + [zadanie], koniec, suma_nagrod + nagroda
        return wybrane, ostatnie_zakonczenie, suma_nagrod

    optymalny_harmonogram, _, maks_nagroda = reduce(wybierz_zadania, zadania_posortowane, ([], 0, 0))

    return maks_nagroda, optymalny_harmonogram

zadania = [(1, 4, 50), (3, 5, 20), (0, 6, 60), (5, 7, 30), (5, 9, 50), (7, 8, 10)]

maks_nagroda_funkcyjnie, optymalny_harmonogram_funkcyjnie = harmonogram_funkcyjny(zadania)
print("Maksymalna nagroda:", maks_nagroda_funkcyjnie)
print("Optymalny harmonogram:", optymalny_harmonogram_funkcyjnie)
