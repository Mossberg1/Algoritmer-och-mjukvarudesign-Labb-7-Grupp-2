namespace Labb_7_Uppgift_1_Grupp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = BuildTree();
            PreOrder(root, 0);
        }

        private static TreeNode BuildTree() 
        {
            var root = new TreeNode("Sjukhus", "Falu lasarett");

            // Definera barn till root.
            var emergency = new TreeNode("Avdelning", "Akuten");
            root.FirstChild = emergency;

            // Ange syskon till Medicinavdelningen.
            var medical = new TreeNode("Avdelning", "Medicinavdelningen");
            emergency.NextSibling = medical;

            // Ange barn till akuten
            var room101 = new TreeNode("Rum", "Rum 101");
            emergency.FirstChild = room101;

            // Ange syskon till rum 101
            var room102 = new TreeNode("Rum", "Rum 102");
            room101.NextSibling = room102;

            // Ange barn till medicin avdelningen
            var room201 = new TreeNode("Rum", "Rum 201");
            medical.FirstChild = room201;

            // Ange barn till rum 101.
            var anna = new TreeNode("Patient", "Anna Svensson");
            room101.FirstChild = anna;

            // Ange syskon till anna
            var erik = new TreeNode("Patient", "Erik Karlsson");
            anna.NextSibling = erik;

            // Ange barn till 102
            var stina = new TreeNode("Patient", "Stina Larsson");
            room102.FirstChild = stina;

            // Ange barn till 201
            var lisa = new TreeNode("Patient", "Lisa Nilsson");
            room201.FirstChild = lisa;

            return root;
        }

        private static void PreOrder(TreeNode node, int level) 
        {
            Console.WriteLine(new string('-', 2 * level) + node);

            // Gå igenom barn
            if (node.FirstChild != null)
            {
                PreOrder(node.FirstChild, level + 1);
            }

            // Gå igenom syskon
            if (node.NextSibling != null)
            {
                PreOrder(node.NextSibling, level);
            }

            return;
        }
    }
}