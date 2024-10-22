from functools import reduce


def optymalizacja_funkcyjna(zadania):
    zadania_posortowane = sorted(zadania, key=lambda x: x[0])

    czasy_oczekiwania = list(map(lambda x: sum(task[0] for task in zadania_posortowane[:x]), range(len(zadania_posortowane))))
    calkowity_czas_oczekiwania = reduce(lambda acc, x: acc + x, czasy_oczekiwania)

    return zadania_posortowane, calkowity_czas_oczekiwania


zadania = [(3, 50), (1, 20), (2, 40), (4, 30)]

optymalna_kolejnosc, calkowity_czas = optymalizacja_funkcyjna(zadania)
print("Optymalna kolejność zadań:", optymalna_kolejnosc)
print("Całkowity czas oczekiwania:", calkowity_czas)
