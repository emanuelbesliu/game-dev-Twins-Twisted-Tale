# Game_Dev_Coursework

# Ideas
-  Game type: Puzzle Game
-  Stories to be considered: Tom Thumb, Snow White and Rose Red

RO: Tom Thumb sau Snow White and Rose Red care pot sa ia la inceput 2 drumuri, ori sa ramana in prezentul lor, adica cu animale si personaje mitologice sau sa o ia pe o cale moderna in care trec de la tehnologie la tehnologie, sa-i ajute în completarea puzzle-ului.  Ma gandeam ca ori putem să facem un path cu personaje din basemele noastre cunoscute, in care puterile lor devin ori mai slabe ori mai mari si depinde ce ai ales pana atunci sa te ajute foarte mult sau sa nu te ajute mai deloc in level-ul ala, sau să meargă pe un path in merge prin evoluția tehnologiei de la electricitate până la chestii din Star Wars si Space. [EMI]

- Snow White and Rose Red, level 1 ursul, level 2, 3, ... obstacole si sa ajute animale, animalele ajutate o sa le ajute pe parcurs si pe ele, ursul e necesar pentru ultimul level, altfel o sa treaca foarte foarte greu.[EMI]

NEW

Poveste:

Snow White si Rose Red sunt in padure si se odihnesc langa un loc al lor pentru ca mama lor le-a spus ca daca se lasa intunericul sa nu vina acasa (sintagma preluata din povestea originala). Cand se zareste lumina atunci ele pleaca catre casa, de aceasta daca pleaca putin mai devreme decat de obicei iar soarele inca nu a aparut insa putina lumina exista, nu e complet seara. Atunci cand pleaca personajele, initial urmeaza ruta bine stiuta insa din cauza intunericului gresesc un path [1]. De aici incepe jocul si deciziile lor vor influenta povestea. Primul nivel va contine primul personaj din poveste, ursul aflat undeva pe la jumatatea grid-ului care este prins intr-o capcana si este ranit[2]. Pana sa ajunga la urs personajele trebuie introduse in partea mecanicilor de baza [3]. Dupa ce trec de urs, personajele vor avea un dialog intre ele in care din nou se decid in ce directie dintre cele doua, una in sus si una in partea dreapta, sa continue. De aceasta data decizia este la noi si putem sa evidentiem frumos cele doua decizii asociindu-le cu personajele, sa continue cu decizia fetitei rosii sau cu cea a celei verzi. Aici poveste se imparte in doua lumi [SPACE] si [FOREST]


[1] ar trebui sa mentionam in tranzitia dintre main menu si level 1, cu animatii, text si audio daca putem face cumva. Ele se intreaba una pe alta pe care drum era traseul cunoscut, una dintre ele propune un drum, cealalta sugereaza altul, una dintre ele se increde in cealalta si asa ajung pe drumul gresit.

[2] o sa fie un text box in care ursul cere ajutorul iar daca personajele interactioneaza cu el atunci vor avea o optiune sa il ajute si sa il elibereze din capcana si sa ii bandajeze rana. Ulterior ursul le multumeste si le spune ca gestul lor nu va fi uitat.

[3] vor fi afisate pe grid cu saturatie mica atat pentru a fi vazute clar, dimensiune mare, dar sa apartina de background.


[FOREST]
- Level 2

In tranzitia dintre Level 1 si Level 2 unul dintre personaje se pierde de celalat si levelul incepe cu secventa "Te vad. Cum ai ajuns acolo?" iar unul dintre personaje se afla pe mapa de puzzle la mijlocul mapei iar celalalt se afla la inceputul ei. Aici introducem o noua mecanica [4]. Primul personaj se misca pe grid si incearca sa ajunga la sora ei, insa pe drum se gaseste un alt caracter si anume un stup de albine care este in pericol sa fie acoperit de apa deoarece un izvor a crescut ca si nivel si si-a dezvoltat o alta ramura catre stupul albinelor. Cand trece pe langa stup regina albinelor ii cere ajutorul personajului. El va fi presat de a lua o decizie, sa le ajute pe albine [1] sau sa ajunga cat mai repede la sora ei care tot striga "Mai repede, aud sunete si imi e frica, cred ca este cineva prin tufisuri". Daca personajul alege sa nu le ajute pe albine va ajunge la o prapastie (cateva tile-uri vor cadea in calea lui exact cand ajunge aproape de celalalt personaj) si acesta va fi introdus in mecanica [1] de a colecta blocuri de piatra si sa ajunga la sora ei. Acum intervine alta mecanica si anume poate pune numai un bloc pentru ca pe orizontala este diferenta de doua griduri [O][X][X][O] si nu poate calca pe X daca amblele X-uri nu sunt acoperite cu blocuri de piatra. Celalalt bloc se afla de partea cealalta, acum o sa introducem controlul al personajului pierdut [2]. Dupa ce personajul celalat pune celalt bloc ele se intalnesc si isi continua drumul. Acest nivel ar trebui sa fie usor pentru a introduce mecanicile.

[1] aici introducem o noua mecanica si anume sa colecteze doua blocuri de piatra de pe mapa [5] si sa le puna in calea apei pentru a salva albinele, urmand ca acestea sa ii multumeasca si spunandu-i ca gestul lui nu va fi uitat.

[2] aici o sa ii dam posibilitatea de a alege, sa controleze primul personaj cu sageti (sa colecteze cu SPACE) si al doilea cu w,a,s,d (sa colecteze cu ALT) sau vice versa. Aceste modificari sa ramane pe parcusul jocului fiind posibila doar reafisarea lor dintr-un meniu sau pe mapa fade ca si prezentarea mecanicilor ([3] din povestea de mai sus). Aici ar fi bine sa poate da switch intre ele fara ca atunci cand controleaza un personaj sa-l poata controla pe al doilea, altfel ar putea face greseli. Deci o sa blocam controlul personajului pe care nu il controleaza momentan.

- Level 3

In tranzitia dintre Level 2 si Level 3 celalalt personaj se pierde si ajunge intr-o zona unde sunt plante carnivore, acelasi mesaj text va fi afisate, "Te vad. Cum ai ajuns acolo?". Personajul care trebuie sa il ajute pe celalalt incepe din stanga si va trebui sa mute cateva blocuri pentru a putea continua sa mearga, urmatorul caracter ar fi furnicile care sunt sub un copac care da sa cada, trebuie culese cateva bete de pe harta pentru a putea sustine copacul, aici introducem timpul care il preseaza pe jucator sa se miste repede si in cazul in care acesta nu mai are timp sa renunte la a le mai ajuta pe furnici, sa-si ajuta sora. [Nu stiu daca e o idee buna asta cu timpul dar ma gandesc ca trebuie sa ii influentam putin alegerea, altfel natural al alege sa ajute pe toata lumea] Timpul va fi suficient cat sa le ajute pe furnici si sa ajunga la celalalt personaj doar ca trebuie sa se miste repede, altfel sora sa va fi mancata de plantele carnivore. Dupa ce le ajuta pe furnici sau nu, ajunge la plantele carnivore unde are doar cateva posibilitati de a trece. Prima si cea mai usoara dintre ele ar fi, daca a ajutat albinele sa le cheme in ajutor si acestea vor zbura deasupra lor si le vor distrage atentia iar personajul poate trece destul de usor, doar colectand un bloc de piatra, schimband personajul colectand si acesta doua blocuri si trecand cu ajutorul albinelor completand tile-urile lipsa din mapa. Celalat path ar fi atunci cand nu le-au ajutat pe albine si trebuie sa se fereasca de atacul plantelor carnivore, ceea ce este mai greu mai ales cand trebuie sa controleze doua caractere si sa se uite la timp. Dupa ce doua personaje s-au intalnit sa isi continue drumul.

[1] plantele ataca pe grid sus, jos, stanga, dreapta la un interval de timp

- Level 4

In tranzitia dintre Level 3 si Level 4 se pierde din nou unul dintre personaje, evocand faptul ca pierderea asta constanta este datorata faptului ca ei nu stiu drumul foarte bine si ca constant se despart pe arii mici sa caute o carare cunoscuta lor catre drumul spre casa. De aceasta data putem vedea ca unul dintre personaje se aflta iar in stanga mapei iar cel de al doilea se afla dupa un morman de pamand la care nu ai cum ajunge decat prin doua modalitati. Una simpla in care daca ai reusit sa ajuti furnicile din levelul anterior ele te vor ajuta si vor indeparta pamantul in timp ce tu trebuie sa colectezi de pe mapa atat bete cat si bucati de piatra pentru a putea continua dupa ce furnicile indeparteaza mormanul de pamant. Cealalta varianta ar fi cea in are trebuie sa blochezi o apa curgatoare ca sa poti trece, ajutandu-se de celalt personaj, apoi sa treaca peste o prapastie, ideea e ca pe intregul path trebuie sa te feresti de un nou inamic, o reptila care se plimba si ataca. Daca personajul a ajutat furnicile atunci ii va fi mult mai usor trecand de multe obstacole, totusi va avea de controlat ambele caractere si de a colecta diferite lucruri de pe mapa. Dupa ce se intalneste cu personajul pierdut continua catre urmatorul nivel.

[1] reptila o sa atace doar din fata ei si o sa mearga constant pe mapa
[2] un feature bun aici ar fi colectarea unor chestii care sa iti dea timp in plus, puse in locuri cheie care sa iti ia putin sa le colectezi dar daca o faci o sa ai un avantaj mai mare

- Level 5

In tranzitia dintre Level 4 si Level 5, care este ultimul nivel, nu se mai pierde nimeni pentru ca au ajuns deja foarte aproape si drumul catre casa le este cunoscut. In aceasta tranzitie introducem personajul din povestea originala, anume piticul care isi cara sacul cu pietrele pretioase, temandu-se ca fetele ar putea sa ii fure comoara pentru ca se afla exact la intrarea pesterii lui, atunci acesta le vorbeste urat si cheama toti inamicii din celelalte level-uri sa captureze sau sa le distruga pe fete pentru a nu mai cunoaste nimeni ascunzatoarea lui si sa ii fure pietrele. Aici personajele trebuie sa foloseasca tot ce au invatat inainte si sa controleze ambele caractere pentru a distrage inamicii avand de colectat atat blocuri de piatra cat si crengi pentru a nu cadea anumiti copaci (o sa aiba un health bar care scade constant). Dupa ce trec de primele obstacole personajele trebuie sa se infrunte si cu piticul care ii ataca iar ei au de ales intre doua optiune. Prima si ce mai usoara optiune ar fi sa cheme ursul pe care l-au ajutat in primul nivel, daca au facut-o, iar acesta se va ocupa de pitic insa si ei trebuie sa il ajute punandu-i blocuri de piatra pentru ca ursul sa ajunga la pitic, in acelasi timp personajele trebuie sa se fereasca de pitic. Cel de al doilea drum ar fi unul greu in care cele doua personaje trebuie sa se fereasca de pitic in timp ce isi construiesc drumul catre casa contra timp, situatia fiind foarte greu de manevrat avand doua caractere in care dai switch si timpul mai scurt cu posibilitatea de a colecta mai mult timp. Personajele nu trebuie sa distruga piticul, trebuie doar sa supravietuiasca, scopul lor nu este de a fura pietre pretioase, din potriva este ajunga acasa in siguranta.

[1] inamicii o sa fie plantele carnivore si reptilele
[2] obstacolele vor fi copaci care au health si o sa cada, prapastii si rauri care trebuie oprite din curge cu pietre

[SPACE]

# Main platform

2D OR 3D? 

Preffer 2D [EMI]

# Mechanics
[1] move left, right, un and down using both arrows keys and w,a,s,d. 

[2] interact button [i]

[3] text box suggesting that we should meet our twin and then continue the path, but the twin can be controlled as well when the proper moment appears

[4] we can use space

[5] have an inventory with collected items and switch between them using number buttons, correspoinding with item's position in inventory (1,2,3,4,5,...)

No idea yet [EMI]

# Sketches

@ make some models [EMI]
