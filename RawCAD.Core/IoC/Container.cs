using System;
using System.Collections.Generic;
using System.Text;
using RawCAD.Core.Parsers;
using RawCAD.Core.Parsers.Commands;
using RawCAD.Core.Renders;
using RawCAD.Core.Renders.Commands;

namespace RawCAD.Core.IoC {

   /// <summary>
   /// RAW dependency injection setup 
   /// </summary>
   public class Container {
      public static T Get<T>() where T : class, IEngine
         => new Engine(
            // command parsers (order matters !!!)
            new CommandEngine(new List<ICommandParser>() {
               new QuitCommandParser(),
               new CanvasCommandParser(),
               new LineCommandParser(),
               new SquareCommandParser(),
               new FillCommandParser()
            }),
            // the screen setup and make sure we account for the reserved space for the command prompt
            new Screen(
               /*width*/ Console.WindowWidth,
               /*height*/ Console.WindowHeight - 2,
               /*renderers (order matters !!!) */
               new List<ICommandRenderer>() {
                     new CanvasRenderer(),
                     new LineRenderer(),
                     new SquareRenderer(),
                     new FillRenderer()
                  })
            ) as T;
   }
}
