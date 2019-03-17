using System;
using System.Collections.Generic;
using System.Text;

namespace RawCAD.Core.Models.Commands {
   public class CanvasCommandDto : ICommandDto {
      public int Width { get; set; }
      public int Height { get; set; }
   }
}
