using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTrx.BusinessLogic.Services
{
    public interface IQifImportService
    {
        bool Import();
    }

    public class QifImportService : IQifImportService
    {
        public bool Import()
        {
            return true;
        }
    }
}
