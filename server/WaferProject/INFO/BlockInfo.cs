using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaferProject.INFO
{
    class BlockInfo
    {
        private string blockId;
        private string ingotId;
        private string blockCreate;

        public BlockInfo() { }
        public BlockInfo(string blockId, string ingotId, string blockCreate)
        {
            this.blockId = blockId;
            this.ingotId = ingotId;
            this.blockCreate = blockCreate;
        }
        public void setBlockCreate(string blockCreate)
        {
            this.blockCreate = blockCreate;
        }
        public string getBlockCreate()
        {
            return blockCreate;
        }
        public void setIngotId(string ingotId)
        {
            this.ingotId = ingotId;
        }
        public string getIngotId()
        {
            return ingotId;
        }
        public void setBlockId(string blockId)
        {
            this.blockId = blockId;
        }
        public string getBlockId()
        {
            return blockId;
        }
    }
}
