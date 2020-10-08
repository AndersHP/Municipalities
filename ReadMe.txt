Jeg har fokuseret mod at lave selve funktionalitet med tests dertil.

Jeg har taget en noget kompliceret tolkning af reglerne for
taxperiods som jeg ikke tror var den der var ment, og i en virkelig situation ville jeg have diskuteret dette med PO og team inden jeg gik igang, men det var ikke muligt her

For at kunne læse og skrive til filer ville jeg bare lave en
serializable DTO klasse for at gøre så domænet kan ændres og stadig
hente fra gamle filer. 
Siden der skulle være et API ville jeg benytte samme format som API'et til filerne.

Jeg vile gerne have lavet et hurtigt WebAPI til at have en applikation der kan køre hele vejen rundt. 
Desværre ville templaten fra Rider ikke arbejde sammen med mig, så det fik mjeg ikke til at virke inden for de 6 timer.