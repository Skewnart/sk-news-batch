using sk_news_batch.Exception;

namespace sk_news_batch.Module.Lifecycle
{
    public class HelpLifecycle : Lifecycle
    {
        public void CheckArgs(string[] args)
        {
            if (args?.Length > 0) throw new CantHaveArgsException("Helper lifecycle");
        }

        /// <summary>
        /// Here, logs are printed.
        /// </summary>
        public void Execute()
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
        }

        public void Init(string[] args) { }
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
