using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users_app.Application;

namespace users_app.Implementation.Loggers
{
    public class Logger : IUseCaseLogger
    {
        public async void Log(IAppActor actor, IUseCase useCase, object request)
        {
            using StreamWriter file = new("Log.txt", append: true);
            await file.WriteLineAsync($"{actor.Id}\t{useCase.Name}\t{DateTime.UtcNow}\t{JsonConvert.SerializeObject(request)}");
        }
    }
}
