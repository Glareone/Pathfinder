using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pathfinder.Core;
using Pathfinder.Data;
using Pathfinder.Data.SqlServer;
using Pathfinder.Domain;
using Pathfinder.Domain.Tiles;

namespace Pathfinder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainContext.Instance.RepositoryFactory = new SqlServerRepositoryFactory();

            var map1 = DomainContext.Instance.RepositoryFactory.GetMapRepository().Load(1);

            var workflowArguments = new Dictionary<string, object>
                                        {
                                            { "gameEngineParameters", new GameEngineParameters
                                                                          {
                                                                              Map = map1,
                                                                              Players = new[]
                                                                                            {
                                                                                                new GamePlayer(), 
                                                                                                new GamePlayer()
                                                                                            }
                                                                          }}
                                        };

            var workflowInvoker = new WorkflowInvoker(new GameEngine());
            workflowInvoker.Invoke(workflowArguments);
            System.Console.ReadLine();
        }
    }
}
