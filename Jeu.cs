using System;
using System.Runtime.CompilerServices;

namespace TP_Pendu
{
    public static class Jeu
    {
        public static void Play(Pendu pendu)
        {
            Console.Clear();
            while (pendu.NbEssai < pendu.NbEssaiMax && pendu.VerificationWin() == 1)
            {
                pendu.AfficherPendu();
                System.Console.Write("Enter: ");
                string? saisie = Console.ReadLine();
                try
                {
                    Console.Clear();
                    if (saisie is not null)
                    {
                        char lettreProposee = char.Parse(saisie.ToUpper());
                        if (lettreProposee >= 'A' && lettreProposee <= 'Z')
                        {
                            Console.WriteLine($"lettre proposée: {lettreProposee}");
                            pendu.VerificationLettre(lettreProposee);
                        }
                        else
                        {
                            System.Console.WriteLine("error wrong value");
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    System.Console.WriteLine("error wrong value");
                }
            }
            System.Console.Write("Le mot était: ");
            System.Console.WriteLine(pendu.MotATrouver.ToArray());
            pendu.AfficherPendu();
        }
    }
}
