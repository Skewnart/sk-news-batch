namespace sk_news_batch.Module.Lifecycle
{
    public class LifecycleChooser
    {
        //Commande pour check la conf ou les flux       check -> conf ou flux, verbeux ou non               ' -C {-c|-f} [-v] '
        //Commande pour check la version                version                                             ' -V '
        //Commande pour print les logs                  logs -> nombre de lignes                            ' -L [xxx] '
        // //Commande pour lancer les TU/TI                u -> unitaires, i -> intégration, verb ou non       ' -T {-u|-i} [-v] '
        //Commande pour afficher l'helper               helper                                              ' -H '

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
                case "-L":
                    chosen = new LogLifecycle();
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
                    throw new Exception("No lifecycle choosen");
            }

            chosen.CheckArgs(extracted_args);
            chosen.Init(extracted_args);
            return chosen;
        }
    }
}
