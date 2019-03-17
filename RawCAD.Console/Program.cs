using System;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core;

namespace RawCAD.Console {
   class Program {
      static void Main(string[] args) {
         MainAsync(args).GetAwaiter().GetResult();
      }

      static async Task MainAsync(string[] args) {
         var engine = new Engine();
         await engine.Run(CancellationToken.None);
      }
   }
}
