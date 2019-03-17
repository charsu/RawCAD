using System;
using System.Collections.Generic;
using System.Text;
using RawCAD.Core.Parsers;
using RawCAD.Core.Parsers.Commands;
using RawCAD.Core.Renders;

namespace RawCAD.Core.IoC {

   /// <summary>
   /// RAW dependency injection setup 
   /// </summary>
   public class Container {
      public static T Get<T>() where T : class, IEngine
         => new Engine(
            // command parsers 
            new CommandEngine(new List<ICommandParser>() {
               new QuitCommandParser()
            }),
            // the screen setup and make sure we account for the reserved space for the command prompt
            new Screen(Console.WindowWidth, Console.WindowHeight - 2)

            ) as T;
   }
}
