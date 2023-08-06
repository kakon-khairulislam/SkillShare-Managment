using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepo<CLASS, ID, RET>
    {
        List<CLASS> GetALL();
        CLASS Get(ID id);
        RET Create(CLASS obj);
        bool Delete(ID id);
        RET Update(CLASS obj);
    }
}
