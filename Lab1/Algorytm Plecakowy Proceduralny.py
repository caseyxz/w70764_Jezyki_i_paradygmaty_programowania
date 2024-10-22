
def knapsack_proceduralna(przedmioty, pojemnosc):
    n = len(przedmioty)
    dp = [[0 for _ in range(pojemnosc + 1)] for _ in range(n + 1)]

    for i in range(1, n + 1):
        wartosc, waga = przedmioty[i - 1]
        for w in range(pojemnosc + 1):
            if waga <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - waga] + wartosc)
            else:
                dp[i][w] = dp[i - 1][w]

    wynik = []
    w = pojemnosc
    for i in range(n, 0, -1):
        if dp[i][w] != dp[i - 1][w]:
            wynik.append(przedmioty[i - 1])
            w -= przedmioty[i - 1][1]

    return dp[n][pojemnosc], wynik

przedmioty = [(60, 10), (100, 20), (120, 30)]  # (wartość, waga)
pojemnosc = 50

maks_wartosc, wybrane_przedmioty = knapsack_proceduralna(przedmioty, pojemnosc)
print("Maksymalna wartość:", maks_wartosc)
print("Wybrane przedmioty:", wybrane_przedmioty)
