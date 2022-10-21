using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Zathura.Domain.Model
{
    public enum Slots {head,torso,back,wrist,hand,legs,belt,trinket,mainhand,offhand }
    public class Items_Slot
    {
        public int SlotID { get; set; }
        public Slots SlotName { get; set; }
        public bool IsOccupied { get; set; } = false;
    }
}
