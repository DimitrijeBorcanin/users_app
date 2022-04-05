using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application;

namespace users_app.Implementation.Loggers
{
    public class Logger : IUseCaseLogger
    {
        public void Log(IAppActor actor, IUseCase useCase, object request)
        {
            throw new NotImplementedException();
        }
    }
}
