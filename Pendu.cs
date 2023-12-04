using System;
using System.Dynamic;

namespace TP_Pendu
{
    public class Pendu
    {
        public string MotATrouver { get; set; }
        public int NbEssai { get; set; }
        public int NbEssaiMax { get; set; }
        public List<char> LettresTrouvee = new List<char>();
        public List<char> lettresFausses = new List<char>();
        public bool win { get; set; }

        public Pendu(string motATrouver)
        {
            MotATrouver = motATrouver.ToUpper();
            NbEssai = 0;
            NbEssaiMax = 7;
            foreach (var item in motATrouver)
            {
                LettresTrouvee.Add('-');
            }
            win = false;
        }

        public int VerificationWin()
        {
            for (int i = 0; i < MotATrouver.Length; i++)
            {
                if (LettresTrouvee[i] != MotATrouver[i])
                {
                    return 1;
                }
            }
            return 0;
        }
        public void VerificationLettre(char lettreProposee)
        {
            bool trouve = false;
            foreach (char lettre in MotATrouver)
            {
                if (lettre == lettreProposee)
                {
                    for (int i = 0; i < LettresTrouvee.Count; i++)
                    {
                        if (lettreProposee == MotATrouver[i])
                        {
                            trouve = true;
                            if (LettresTrouvee[i] == '-')
                            {
                                LettresTrouvee[i] = lettreProposee;
                            }
                        }

                    }
                }
            }
            if (!trouve)
            {
                NbEssai++;
                bool inside = false;
                foreach (var item in lettresFausses)
                {
                    if (item == lettreProposee)
                    {
                        inside = true;
                    }
                }
                if (!inside)
                {
                    lettresFausses.Add(lettreProposee);
                }
            }
        }
        public void AfficherMot()
        {

        }
        public void AfficherPendu()
        {
            System.Console.Write("    |");
            System.Console.Write(LettresTrouvee.ToArray());
            System.Console.WriteLine("|");

            if (lettresFausses.Count != 0)
            {
                System.Console.Write("Lettre fausses: ");
                System.Console.WriteLine(lettresFausses.ToArray());
            }

            var template = "  --------------     " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |       2 2'      " + Environment.NewLine +
                             "    |       2'2¤2      " + Environment.NewLine +
                             "    |      44355     " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |       6 7      " + Environment.NewLine +
                            @"   /|\     6   7     " + Environment.NewLine +
                            @"  / | \              " + Environment.NewLine +
                            @" /  |  \             ";
            for (int i = 1; i <= NbEssaiMax; i++)
            {
                if (NbEssai >= i)
                {
                    if (i != 2)
                    {
                        template = template.Replace(i.ToString(), i switch
                        {
                            1 => "|",
                            3 => "|",
                            4 => "-",
                            5 => "-",
                            6 => "/",
                            7 => "\\",
                            _ => ""
                        });
                    }
                    else
                    {
                        template = template
                            .Replace("2'", "\\")
                            .Replace("2¤", "_")
                            .Replace("2", "/");
                    }
                }
                else
                {
                    template = template.Replace(i.ToString(), i switch
                    {
                        4 => " ",
                        _ => ""
                    })
                    .Replace("'", "").Replace("¤", "");
                }

            }
            Console.Write(template);
            Console.WriteLine();
        }
    }
}
