using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_01
{
    public class Team
    {
        private static Random rnd = new Random();
        private static int workerCounter = 1;

        public IWorker[] team { private set; get; }

        public Team()
        {
            team = new IWorker[6];
            team[0] = new TeamLeader();

            for (int i = 1; i < team.Length; i++)
            {
                team[i] = new Worker(String.Format("_{0}", workerCounter++));
            }
        }

        public IWorker GetRandomWorker()
        {
            return team[rnd.Next(0, 5)];
        }

    }
}
