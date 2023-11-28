using sk_news_batch.Exception;

namespace sk_news_batch.Module.Lifecycle
{
    public class HelpLifecycle : Lifecycle
    {
        public void CheckArgs(string[] args)
        {
            if (args?.Length > 0) throw new ProhibitedArgsException("Helper lifecycle");
        }

        public void Execute() { }

        /// <summary>
        /// Here, logs are printed.
        /// </summary>
        /// <param name="args"></param>
        public void Init(string[] args)
        {
            Console.Write(
@"CHECK : -C {-c|-f} [-v]
	-C : Vérifie les configurations
	-c : structure de la configuration
	-f : l'appel, la réception et le parsing des flux configurés
	-v : mode verbeux

VERSION : -V
	-V : Affiche la version

HELP : -H
	-H : Affiche l'aide");

/*
LOGS : -L [xxx]
	-L : Affiche les logs
	[xxx] : Les xxx dernières lignes
*/

/*
@"TESTS : -T {-u|-i} [-v]
	-T : Exécute les tests
	-u : unitaires
	-i : d'intégration
	-v : mode verbeux"
*/
        }
    }
}
