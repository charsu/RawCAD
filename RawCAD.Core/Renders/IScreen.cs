using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RawCAD.Core.Renders {
   public interface IScreen {
      Task Render(CancellationToken cancellationToken);
   }
}
