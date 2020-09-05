using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEdit
{
    class Tag
    {
        public Tag(byte slot, Item item)
        {
            Slot = slot;
            Item = item;
            JeInvSlot = true;
        }
        public Tag(Item item)
        {
            Item = item;
            JeInvSlot = false;
        }

        internal byte Slot
        {
            get;
            private set;
        }

        internal Item Item
        {
            get;
            set;
        }

        internal bool JeInvSlot
        {
            get;
            private set;
        }
    }
}
