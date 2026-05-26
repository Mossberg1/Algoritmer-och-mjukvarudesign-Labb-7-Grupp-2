using System.Runtime.CompilerServices;

namespace Labb_7_Uppgift_2_Grupp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddBalanced();
            AddUnbalanced();
        }

        static void AddBalanced() 
        {
            var erik = new BookingNode(new DateTime(2026, 5, 25, 9, 0, 0), "Erik Karlsson");

            // Bygg träd.
            Insert(erik, new DateTime(2026, 5, 25, 8, 0, 0), "Maria Lind");
            Insert(erik, new DateTime(2026, 5, 25, 10, 30, 0), "Johan Andersson");
            Insert(erik, new DateTime(2026, 5, 25, 9, 45, 0), "Lisa Nilsson");
            Insert(erik, new DateTime(2026, 5, 25, 8, 30, 0), "Anna Svensson");

            Console.WriteLine("Tidsbokningar i kronologisk ordning: (balanserad)");

            TraverseInOrder(erik);
        }

        static void AddUnbalanced() 
        {
            var maria = new BookingNode(new DateTime(2026, 5, 25, 8, 0, 0), "Maria Lind");

            // Bygg träd
            Insert(maria, new DateTime(2026, 5, 25, 8, 30, 0), "Anna Svensson");
            Insert(maria, new DateTime(2026, 5, 25, 9, 0, 0), "Erik Karlsson");
            Insert(maria, new DateTime(2026, 5, 25, 9, 45, 0), "Lisa Nilsson");
            Insert(maria, new DateTime(2026, 5, 25, 10, 30, 0), "Johan Andersson");

            Console.WriteLine("Tidsbokningar i kronologisk ordning: (obalanserad)");

            TraverseInOrder(maria);
        }

        static BookingNode Insert(BookingNode node, DateTime time, string patientName) 
        {
            var newNode = new BookingNode(time, patientName);

            if (node == null)
            {
                return newNode;
            }

            if (newNode.Time.CompareTo(node.Time) == 0)
            {
                throw new InvalidOperationException("Två tidsbokningar kan inte ha samma tid.");
            }

            if (newNode.Time.CompareTo(node.Time) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = newNode;
                }
                else
                {
                    Insert(node.Left, time, patientName);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = newNode;
                }
                else
                {
                    Insert(node.Right, time, patientName);
                }
            }

            return node;
        }

        static void TraverseInOrder(BookingNode node) 
        {
            if (node.Left != null)
            {
                TraverseInOrder(node.Left);
            }

            Console.WriteLine(node);

            if (node.Right != null)
            {
                TraverseInOrder(node.Right);
            }
        }
    }
}
