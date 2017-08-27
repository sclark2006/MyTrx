
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using Rhino.Mocks;
using MyTrx.BusinessLogic.Services;

namespace MyTrx.Test.BusinessLogic.Services
{
    [Subject(typeof(QifImportService))]
    public class QifImportServiceSpec
    {
        public abstract class concern : Observes<IQifImportService>
        {
            Establish context = () => {
            };
        }
    }
}
