import re
from collections import Counter


STOP_WORDS = {"i", "a", "the", "and", "to", "of", "in", "it", "is", "that", "on", "for", "with", "as", "was", "at", "by"}

def analiza_tekstu(tekst):
    tekst_czysty = re.sub(r'[^\w\s\.\!\?]', '', tekst)

    slowa = tekst_czysty.split()
    liczba_slow = len(slowa)

    liczba_zdan = len(re.findall(r'[.!?]', tekst))

    liczba_akapitow = tekst.count('\n\n') + 1

    slowa_filtr = [slowo.lower() for slowo in slowa if slowo.lower() not in STOP_WORDS]
    liczba_slow_popularnych = Counter(slowa_filtr).most_common(5)

    transformowane_slowa = map(lambda slowo: slowo[::-1] if slowo.lower().startswith('a') else slowo, slowa)
    tekst_transformowany = ' '.join(transformowane_slowa)

    return {
        "liczba_slow": liczba_slow,
        "liczba_zdan": liczba_zdan,
        "liczba_akapitow": liczba_akapitow,
        "najczestsze_slowa": liczba_slow_popularnych,
        "tekst_transformowany": tekst_transformowany
    }

tekst = """
High School Musical (2006)
Main article: High School Musical
Filmed in Utah,[4][5] High School Musical was released on January 20, 2006 as a Disney Channel Original Movie (DCOM), and was the highest-rated DCOM to that point,[6] watched by 7.7 million viewers for its premiere broadcast in the United States,[7] and by 789,000 viewers for its UK premiere. It was the first DCOM ever to be aired by BBC, broadcast on December 29, 2006, and has been viewed by over 225 million people worldwide.[8] The first film's leads were Zac Efron, Vanessa Hudgens, Ashley Tisdale and Lucas Grabeel, who sang most of the songs.

The film follows basketball star Troy Bolton (Zac Efron) and shy, smart Gabriella Montez (Vanessa Hudgens). After a chance meeting on winter break, Gabriella reconnects with Troy after transferring to East High School in Albuquerque. Drama queen Sharpay Evans (Ashley Tisdale), seeking to eliminate her competition for the Winter Musical, convinces Taylor McKessie (Monique Coleman) to invite Gabriella to the Scholastic Decathlon team. Troy's best friend Chad Danforth (Corbin Bleu) is concerned that Troy is distracted from basketball.

After Sharpay and her twin brother Ryan (Lucas Grabeel) perform a flashy audition for the musical, Troy and Gabriella manage to give their own performance and receive a callback. When the school finds out Troy and Gabriella have auditioned, everyone fears the status quo of the school is drastically changing, frustrating Sharpay, Chad and Taylor, afraid their respective teams will fail, try to intervene, leading Gabriella to believe Troy does not care about her. While Sharpay is satisfied, Chad and Taylor's teams feel guilty and attempt to fix what they have done.

Sharpay and Ryan convince drama teacher Ms. Darbus to change callbacks to the same date as the basketball championship and the Decathlon. Chad and Taylor stage a school-wide computer glitch that forces the school to stop the game and the Decathlon, and lead all the students into the auditorium. Troy and Gabriella arrive in the nick of time and are awarded the lead roles, while Sharpay and Ryan are understudies. The film ends as the entire school gathers in the gym to celebrate East High's basketball victory."""

wynik = analiza_tekstu(tekst)

print("Liczba słów:", wynik["liczba_slow"])
print("Liczba zdań:", wynik["liczba_zdan"])
print("Liczba akapitów:", wynik["liczba_akapitow"])
print("Najczęstsze słowa (bez stop words):", wynik["najczestsze_slowa"])
print("\nTekst po transformacji:\n", wynik["tekst_transformowany"])
