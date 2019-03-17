using System;
using System.Collections.Generic;
using System.Text;

namespace RawCAD.Core.Models {
   public class LineCommandDto : ICommandDto {
      public int X1 { get; set; }
      public int Y1 { get; set; }
      public int X2 { get; set; }
      public int Y2 { get; set; }
   }
}
