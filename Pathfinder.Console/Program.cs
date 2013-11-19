using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pathfinder.Data;
using Pathfinder.Domain;
using Pathfinder.Domain.Tiles;

namespace Pathfinder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainContext.Instance.RepositoryFactory = new RepositoryFactory();

            var s = DomainContext.Instance.RepositoryFactory.GetMapRepository().Load(1);

            System.Console.Clear();

            for (int row = 0; row < s.Height; row++)
            {
                System.Console.WriteLine();
                for (int col = 0; col < s.Width; col++)
                {
                    System.Console.Write("{0, -2}", s.Tiles[row, col].Cost != int.MaxValue ? s.Tiles[row, col].Cost.ToString() : string.Empty);
                }
            }
            System.Console.ReadLine();
            System.Console.Clear();
            for (int row = 0; row < s.Height; row++)
            {
                System.Console.WriteLine();
                for (int col = 0; col < s.Width; col++)
                {
                    System.Console.Write("{0, -2}", s.Tiles[row, col] is ArtifactTile ? ((ArtifactTile)s.Tiles[row, col]).ArtifactId.ToString() : string.Empty);
                }
            }
            System.Console.ReadLine();
            System.Console.Clear();
            for (int row = 0; row < s.Height; row++)
            {
                System.Console.WriteLine();
                for (int col = 0; col < s.Width; col++)
                {
                    System.Console.Write("{0, -2}", s.Tiles[row, col] is NavigationTile ? ((int)((NavigationTile)s.Tiles[row, col]).Spot).ToString() : string.Empty);
                }
            }
            System.Console.ReadLine();
        }
    }
}
