using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RawCAD.Core.Models;

namespace RawCAD.Core.Renders.Commands {
   public interface ICommandRenderer {
      Task Render(ICommandDto input, char[] buffer, Rectangle screen, CancellationToken cancellationToken);
   }
}
