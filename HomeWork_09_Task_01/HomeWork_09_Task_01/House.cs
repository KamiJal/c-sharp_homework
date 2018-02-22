using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09_Task_01
{
    public class House
    {
        public Basement basement { private set; get; }
        public Wall[] walls { private set; get; }
        public Door door { private set; get; }
        public Window[] windows { private set; get; }
        public Roof roof { private set; get; }
        
        public bool IsReady = false;

        public House()
        {
            this.basement = null;
            this.walls = new Wall[4];
            this.door = null;
            this.windows = new Window[4];
            this.roof = null;
        }

        public string AddNewPart()
        {
            //строим basement
            if (basement == null)
            {
                basement = new Basement();
                return basement.GetPartName();
            }

            //строим каждую стену отдельно
            for (int i = 0; i < walls.Length; i++)
            {
                if (walls[i] == null)
                {
                    walls[i] = new Wall();
                    return walls[i].GetPartName();
                }        
            }

            //строим дверь
            if (door == null)
            {
                door = new Door();
                return door.GetPartName();
            }

            //строим каждое окно отдельно
            for (int i = 0; i < windows.Length; i++)
            {
                if (windows[i] == null)
                {
                    windows[i] = new Window();
                    return windows[i].GetPartName();
                }
            }

            //строим крышу
            if (roof == null)
                roof = new Roof();

            //дом готов
            IsReady = true;
            return roof.GetPartName();
        }

    }
}
