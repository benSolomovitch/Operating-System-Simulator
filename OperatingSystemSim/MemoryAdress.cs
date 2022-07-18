using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystemSim
{
    class MemoryAdress
    {
        private int ownerID;
        private bool allocated;
        private bool released;

        public MemoryAdress()
        {
            this.ownerID = -1;
            this.allocated = false;
            this.released = true;
        }

        public void SetOwnerID(int ownerID)
        {
            this.ownerID = ownerID;
        }

        public void SetAllocated(bool allocated)
        {
            this.allocated = allocated;
        }

        public void SetReleased(bool released)
        {
            this.released = released;
        }


        public int GetOwnerID()
        {
            return this.ownerID;
        }

        public bool GetAllocated()
        {
            return this.allocated;
        }

        public bool GetReleased()
        {
            return this.released;
        }
    }
}
