using sk_news_batch.Exception;

namespace sk_news_batch.Module.Lifecycle
{
    public class LifecycleChooser
    {
        //Commande pour check la conf ou les flux       check -> conf ou flux, verbeux ou non               ' -C {-c|-f} [-v] '
        //Commande pour check la version                version                                             ' -V '
        // //Commande pour print les logs                  logs -> nombre de lignes                            ' -L [xxx] '
        // //Commande pour lancer les TU/TI                u -> unitaires, i -> intégration, verb ou non       ' -T {-u|-i} [-v] '
        //Commande pour afficher l'helper               helper                                              ' -H '

        /// <summary>
        /// Find out specific Lifecycle to engage it, with help of given arguments.
        /// </summary>
        /// <param name="args">Given arguments</param>
        /// <returns>The one. Lifecyle that fit with all arguments</returns>
        /// <exception cref="MissingLifecycleException">When given arguments are wrong enough not to find the wanted command</exception>
        public static Lifecycle Choose(string[] args)
        {
            string command = args.FirstOrDefault();
            string[] extracted_args = args.Skip(1).ToArray();

            Lifecycle? chosen = null;
            switch (command)
            {
                case null:
                    //Default behavior
                    chosen = new ParseRSSStreamLifecycle();
                    break;
                case "-V":
                    chosen = new VersionLifecycle();
                    break;
                case "-C":
                    chosen = new CheckLifecycle();
                    break;
                //case "-T":
                //    chosen = new TestLifecycle();
                //    break;
                case "-H":
                    chosen = new HelpLifecycle();
                    break;
                default :
                    throw new MissingLifecycleException();
            }

            chosen.CheckArgs(extracted_args);
            chosen.Init(extracted_args);
            return chosen;
        }
    }
}
