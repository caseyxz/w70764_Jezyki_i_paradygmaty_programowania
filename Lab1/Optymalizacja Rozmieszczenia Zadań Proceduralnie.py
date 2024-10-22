

def optymalizacja_proceduralna(zadania):

    zadania.sort(key=lambda x: x[0])

    calkowity_czas_oczekiwania = 0
    aktualny_czas = 0
    
    for czas, nagroda in zadania:
        calkowity_czas_oczekiwania += aktualny_czas
        aktualny_czas += czas

    return zadania, calkowity_czas_oczekiwania


zadania = [(3, 50), (1, 20), (2, 40), (4, 30)] #czas, nagroda

optymalna_kolejnosc, calkowity_czas = optymalizacja_proceduralna(zadania)
print("Optymalna kolejność zadań (proceduralnie):", optymalna_kolejnosc)
print("Całkowity czas oczekiwania (proceduralnie):", calkowity_czas)
