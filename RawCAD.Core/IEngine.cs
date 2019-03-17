using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RawCAD.Core {
   public interface IEngine : IDisposable {
      Task Run(CancellationToken cancellationToken);
   }
}
