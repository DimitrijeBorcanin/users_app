using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_app.Application
{
    public interface IUseCaseLogger
    {
        void Log(IAppActor actor, IUseCase useCase, object request);
    }
}
