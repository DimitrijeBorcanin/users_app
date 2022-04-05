using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace users_app.Application.Exceptions
{
    public class ActionNotAuthorizedException : Exception
    {
        public ActionNotAuthorizedException(IUseCase useCase, IAppActor actor)
            : base($"({DateTime.Now}) - User {actor.Identity} with an ID of {actor.Id} attempted unauthorized action: {useCase.Name}")
        {

        }
    }
}
