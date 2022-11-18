# Hoe ga je te werk

**Maak een fork van deze repo én een aparte branch waarin je aan de oplossing voor de opdracht kan werken. Wanneer je de opdracht gemaakt hebt kun je een pull-request maken naar de main branch. Tijdens het gesprek zul je samen met developers door deze pull-request heen gaan.**

Er staat alvast een methode klaar in **Algorithm.cs**: **ShortestPath**(Graph graph, Node from, Node to). De bedoeling is dat je deze methode invulling gaat geven met het algoritme.

# "De kortste route"-algoritme

Een gewogen graaf is een graaf waarvan aan de verbindingslijnen getallen zijn verbonden. Je zou het kunnen zien als de afstanden in kilometers.
Een interessante vraagt is dan natuurlijk **"Wat is de kortste afstand tussen A en B?"**

Het algoritme werkt als volgt:

A. Geef de beginknoop voorlopig afstand 0 (dat noemen we de <font color="red">huidige knoop</font>) en alle andere knopen voorlopige afstand ∞ (die noemen we <font color="red">niet-bezochte knopen</font>).

B. Bekijk alle directe buren van de huidige knoop. Voor elk van die knopen kun je twee afstanden vinden:

1.  de voorlopige afstand die er al bij staat
2.  de voorlopige afstand van de huidige knoop plus de lengte van de verbindingslijn vanaf de huidige knoop naar deze

Kies de kortste afstand van beiden. Dat wordt de nieuwe voorlopige afstand van deze knoop.

C. Als je alle buurknopen hebt gehad wordt de huidige knoop nu een <font color="red">bezochte knoop.</font>
Kies als nieuwe huidige knoop de knoop met de kleinste voorlopige afstand.
Ga weer naar stap B.

---

### _Voorbeeld:_

![](example.jpg)

In deze plaatjes 1 t/m 10 zie je hoe je het in zijn werk gaat. De groene knoop is de huidige, de rode zijn bezochte knopen, de zwarte zijn niet-bezochte knopen. De blauwe getallen geven de lengte van de verbindingslijn, de rode getallen geven de voorlopige kortste afstand tot de knoop.

1. Kies A als startknoop, geef die afstand <font color="red">0</font>, en alle anderen afstand <font color="red">∞</font>
2. De buren B, C, D krijgen afstanden <font color="red">6, 5, 4</font>.
3. A wordt een bezochte knoop, D wordt de huidige knoop. E wordt <font color="red">4</font> + <font color="blue">4</font> = <font color="red">8</font>. C zou <font color="red">4</font> + <font color="blue">2</font> = <font color="red">6</font> worden, maar dat is meer dan <font color="red">5</font> dus C blijft <font color="red">5</font>.
4. D wordt een bezochte knoop, C wordt de huidige knoop. G wordt <font color="red">5</font> + <font color="blue">5</font> = <font color="red">10</font>, F wordt <font color="red">5</font> + <font color="blue">4</font> = <font color="red">9</font>, B zou <font color="red">5</font> + <font color="blue">3</font> = <font color="red">8</font> worden, maar is al <font color="red">6</font>, dus blijft <font color="red">6</font>.
5. C wordt een bezochte knoop, B wordt de huidige knoop. F wordt <font color="red">6</font> + <font color="blue">2</font> = <font color="red">8</font>, H wordt <font color="red">6</font> + <font color="blue">7</font> = <font color="red">13</font>
6. B wordt bezochte knoop, E wordt de huidige knoop. I wordt <font color="red">8</font> + <font color="blue">7</font> = <font color="red">15</font>. G zou <font color="red">8</font> + <font color="blue">3</font> = <font color="red">11</font> worden, maar is al <font color="red">10</font> dus blijft <font color="red">10</font>.
7. E wordt bezochte knoop, F wordt huidige knoop. H wordt <font color="red">8</font> + <font color="blue">4</font> = <font color="red">12</font>. G zou <font color="red">8</font> + <font color="blue">3</font> = <font color="red">11</font> worden, maar is al <font color="red">10</font> dus blijft <font color="red">10</font>.
8. F wordt bezochte knoop, G wordt huidige knoop. I wordt <font color="red">10</font> + <font color="blue">3</font> = <font color="red">13</font>. H zou <font color="red">10</font> + <font color="blue">5</font> = <font color="red">15</font> worden, maar is al <font color="red">12</font>, dus blijft <font color="red">12</font>.
9. G wordt bezochte knoop, H wordt huidige knoop. I zou <font color="red">12</font> + <font color="blue">8</font> = <font color="red">18</font> worden, maar is al <font color="red">13</font>, dus blijft <font color="red">13</font>.
10. KLAAR!

![](example2.jpg)

Op deze manier vind je van alle andere knopen de minimale afstand tot knoop A. Merk nog even op dat je niet vindt welke route die afstand oplevert. Als je die "beste routes" ook wilt weten kun je elke keer dat je het getal van een knoop verandert bijhouden vanaf welke knoop je tot die kortere afstand bent gekomen.
Hieronder geeft dat de groene optimale routes.
