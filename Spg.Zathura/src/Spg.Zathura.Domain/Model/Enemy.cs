using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Enemy : Character
    {
        public Enemy(int _id, string _name, int _level) : base(_id, _name, _level)
        {
        }
    }
}
