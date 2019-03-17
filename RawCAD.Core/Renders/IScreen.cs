using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;

namespace RawCAD.Core.Renders {
   public interface IScreen {
      Task Render(CancellationToken cancellationToken);
      Task Update(CommandParserOutputDto input, CancellationToken cancellationToken);
   }
}
