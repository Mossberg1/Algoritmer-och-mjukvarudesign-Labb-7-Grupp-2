namespace Labb_7_Uppgift_3_Grupp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Diagnos-Boten");
            Console.WriteLine("----------------------------");

            var decisionTree = BuildDecisionTree();

            var conclusion = AskQuestions(decisionTree);

            Console.WriteLine($"REKOMMENDATION: {conclusion}");
        }

        static DecisionNode BuildDecisionTree() 
        {
            var fever = new DecisionNode("Är din feber över 39°?", true);

            // Om feber
            var breathing = new DecisionNode("Svårt att andas?", true);
            fever.Yes = breathing;

            // Om inte feber.
            var throat = new DecisionNode("Har du ont i halsen?", true);
            fever.No = throat;

            // Om svårt att andas
            var call = new DecisionNode("RING 112 AKUT", false);
            breathing.Yes = call;

            // Om inte svårt att andas.
            var hospital = new DecisionNode("SÖK VÅRD IMORGON", false);
            breathing.No = hospital;

            // Om ont i halsen
            var rest = new DecisionNode("VILA OCH DRICK VATTEN", false);
            throat.Yes = rest;

            // Om inte ont i halsen
            var work = new DecisionNode("GÅ OCH JOBBA", false);
            throat.No = work;

            return fever;
        }

        static Answer GetAnswer(DecisionNode node) 
        {
            if (node == null || !node.IsQuestion)
            {
                throw new ArgumentException("Nod måste vara en fråga");
            }

            var answer = "";

            while (answer != "j" && answer != "n") // Vänta på ett svar så länge svaret är ogiltigt.
            {
                Console.Write($"{node} (j/n): ");
                answer = Console.ReadLine()?.ToLower().Trim() ?? string.Empty;
            }

            return answer == "j" ? Answer.Yes : Answer.No;
        }

        static DecisionNode AskQuestions(DecisionNode node) 
        {
            while (node.Yes != null && node.No != null) // Fortsätt ställ frågor så länge det finns frågor kvar
            {
                if (node.IsQuestion) // Om noden är en fråga, ställ den.
                {
                    var answer = GetAnswer(node);
                    if (answer == Answer.Yes)
                    {
                        node = node.Yes;
                    }
                    else
                    {
                        node = node.No;
                    }
                }
            }

            return node;
        }
    }
}
