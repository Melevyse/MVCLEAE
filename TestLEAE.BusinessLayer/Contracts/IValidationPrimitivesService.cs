using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLEAE.DataLayer;

namespace TestLEAE.BusinessLayer;

public interface IValidationPrimitivesService
{
    void BeValidInn(long inn);

    void BeValidDateTime(DateTime date);

    void BeValidClientType(ClientType name);
}
