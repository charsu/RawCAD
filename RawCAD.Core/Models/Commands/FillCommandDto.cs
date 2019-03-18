using System;
using System.Collections.Generic;
using System.Text;

namespace RawCAD.Core.Models.Commands {
   public class FillCommandDto : ICommandDto {
      public int X { get; set; }
      public int Y { get; set; }
      public char Color { get; set; }
   }
}
