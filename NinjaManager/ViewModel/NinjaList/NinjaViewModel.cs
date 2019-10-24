using NinjaManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaManager.ViewModel.NinjaList
{
    public class NinjaViewModel
    {
        //Wordt nog niet gebruikt
        private Ninja ninja;


        public NinjaViewModel()
        {
            ninja = new Ninja();
        }

        public NinjaViewModel(Ninja ninja)
        {
            this.ninja = ninja;
        }

        public string Name {
            get { return ninja.Name; }
            set {
                ninja.Name = value;
            }
        }

        public int Gold {
            get { return ninja.Gold; }
            set {
                ninja.Gold = value;
            }
        }

        public int Id {
            get { return ninja.Id; }
        }

        public Ninja ToModel()
        {
            return ninja;
        }
    }
}
