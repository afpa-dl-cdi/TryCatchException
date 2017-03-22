using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchException
{
    class Program
    {
        static int stock = 0;

        static void Main(string[] args)
        {

            /* CAS SANS TRY CATCH */
            int nombreA = 5;
            int nombreB = 0;
            //double resultat = divide(nombreA, nombreB); // appel sans try catch faisant planter l'application 


            /* CAS AVEC TRY CATCH */
            try
            {
                double resultat = divideWithExc(nombreA, nombreB);

            }
            catch(DivideByZeroException dbze)
            {
                Console.WriteLine("Erreur sur la division : {0}", dbze.Message);

            }
            catch (Exception e)
            {
                //s'il ne s'agit pas d'une erreur de division par zéro, cette exception générique sera appelée
                Console.WriteLine("un erreur s'est produite : {0}", e.Message);
                Console.WriteLine("Pile d'appel : {0}", e.StackTrace);
                Console.WriteLine("De type : {0}", e.GetType());
            }


            /* CAS TRY CATCH FINALLY */
            try
            {
                Console.WriteLine("suppression d'un article");
                retirerArticle();
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (StockVideException sve )
            {
                Console.WriteLine(sve.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("De toute façon, vous passerez quand même par Finally");
            }
        }



        /// <summary>
        /// Divise un nombre sans se soucier du risque de division par zéro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="diviseur"></param>
        /// <returns>produit de la division</returns>
        static double divide (int nombre, int diviseur)
        {
            return nombre / diviseur;
        }

        /// <summary>
        /// Divise avec création d'une exception
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="diviseur"></param>
        /// <returns></returns>
        static double divideWithExc(int nombre, int diviseur)
        {
            double res;
            if (diviseur == 0)
            {
                throw new DivideByZeroException("Votre diviseur est à zéro"); // contiendra un message que sera récupérable dans le catch
            }
            return nombre / diviseur;  
        }

        /// <summary>
        /// Retire un article 
        /// </summary>
        /// <remarks>La méthode n'est pas complétement implémentée et contient juste un appel à une méthode contenant une exception</remarks>
        private static void retirerArticle()
        {
            try
            {
                int dix = Convert.ToInt32("dix");
            }
            catch (FormatException fe)
            {
                //throw fe;     // l'exception est propagée mais bloquera l'exception suivante
                Console.WriteLine(fe.Message);
            }
            catch (Exception e)
            {
                throw e;
            }

            verificationDuStock();
        }

        /// <summary>
        /// Vérifie l'état du stock
        /// </summary>
        static void verificationDuStock()
        {
            if (stock <= 0)
            {
                throw new StockVideException("Votre stock est à vide!");
            }
        }


    }
}
