using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Stats_Gained { get; set; } = 0;
        public int Stats_Lost { get; set; } = 0;
        public Items_Slot Slot { get; set; } = new Items_Slot();
        public bool IsBound { get; set; } = false;
        public Character Belongs_To { get; set; } = new Character();

    }
}
