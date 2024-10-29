from functools import lru_cache

@lru_cache(maxsize=None)
def knapsack_funkcyjna(pojemnosc, index, przedmioty):

    if index == 0 or pojemnosc == 0:
        return 0, []

    wartosc, waga = przedmioty[index - 1]


    if waga > pojemnosc:
        return knapsack_funkcyjna(pojemnosc, index - 1, przedmioty)


    bez_przedmiotu = knapsack_funkcyjna(pojemnosc, index - 1, przedmioty)
    z_przedmiotem = knapsack_funkcyjna(pojemnosc - waga, index - 1, przedmioty)


    z_przedmiotem_wartosc = z_przedmiotem[0] + wartosc


    if z_przedmiotem_wartosc > bez_przedmiotu[0]:
        return z_przedmiotem_wartosc, z_przedmiotem[1] + [przedmioty[index - 1]]
    else:
        return bez_przedmiotu


przedmioty = [(60, 10), (100, 20), (120, 30)]  #(wartość, waga)
pojemnosc = 50

maks_wartosc_funkcyjnie, wybrane_przedmioty_funkcyjnie = knapsack_funkcyjna(pojemnosc, len(przedmioty), tuple(przedmioty))
print("Maksymalna wartość:", maks_wartosc_funkcyjnie)
print("Wybrane przedmioty:", wybrane_przedmioty_funkcyjnie)
