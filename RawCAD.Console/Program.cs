using System;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core;

namespace RawCAD.Console {
   class Program {
      static void Main(string[] args) {
         MainAsync(args).GetAwaiter().GetResult();
      }

      static readonly CancellationToken cancellationToken = new CancellationToken();

      static async Task MainAsync(string[] args) {
         using (var engine = Core.IoC.Container.Get<IEngine>()) {
            await engine.Run(cancellationToken);
         }
      }
   }
}
