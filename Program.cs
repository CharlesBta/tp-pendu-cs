using TP_Pendu;


List<string> listeMots = ["bonjour","cheval","abricot","cantine","bus","maison","ordinateur","junia","zogo","dossier","fleur","acheter","longeur",
"cocher","vieux","batterie","pluie","heureux","pertinant","chat","piment","herbe","vache","lunettes","verre","geek","python","porte","salle","adimaker",
"isen","cir"];

Random random = new Random();

Pendu pendu = new Pendu(listeMots[random.Next(0,listeMots.Count-1)]);


Jeu.Play(pendu);