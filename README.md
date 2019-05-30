# RawCAD

You're given the task of writing a simple console version of a drawing program. The functionality of the
program is quite limited but should be extensible. The program should work as follows:
1. create a new canvas.
2. start drawing on the canvas by issuing various commands.
3. quit.
The program should support the following commands:
Command Description
C w h Should create a new canvas of width w and height h.
L x1 y1 x2 y2
Should create a new line from (x1,y1) to (x2,y2) . Currently only
horizontal or vertical lines are supported. Horizontal and vertical lines will be
drawn using the x character.
R x1 y1 x2 y2
Should create a new rectangle, whose upper left corner is (x1,y1) and
lower right corner is (x2,y2) . Horizontal and vertical lines will be drawn
using the x character.
B x y c Should fill the entire area connected to (x,y) with colour 'c' . The
behaviour of this is the same as that of the "bucket fill" tool in paint programs.
Q Should quit the program.
Below is a sample of the output your program should produce. User input is prefixed with
enter command: .

Sample I/O
```
enter command: C 20 4
----------------------
| |
| |
| |
| |
----------------------
enter command: L 1 2 6 2
----------------------
| |
|xxxxxx |
| |
| |
----------------------
enter command: L 6 3 6 4
----------------------
| |
|xxxxxx |
| x |
| x |
----------------------
enter command: R 16 1 20 3
----------------------
| xxxxx|
|xxxxxx x x|
| x xxxxx|
| x |
----------------------
enter command: B 10 3 o
----------------------
|oooooooooooooooxxxxx|
|xxxxxxooooooooox x|
| xoooooooooxxxxx|
| xoooooooooooooo|
----------------------
enter command: Q
```

## Current Status

- Design based on DI and a raw DI has favored to not add extra setup 
- The design is task based so that it complies with current (modern) design practices
- The design is scalable 
- Implemented parsers and renderers for: 
   - Line with handling of drawing from any point to any point (not only vertical / horizontal)
   - Rectangle - draws a rectangle 
   - Fill: allows to fill an area 

- unit tests : 
While the code was not fully written in a TDD manner (for the most part) basic unit tests were added.
In the case of the fill, which proved to be a little more difficult to test (due to setup) TDD was favored.

Note: 
   - More unit tests cases should have been added but due to time constrains they were neglected.
   - The git pattern should have followed branch for feature, but without a visual repository (eg github)
and no other contributors it was decided to go with straight commits to master branch.

## Future work ?

1. as probably noticed the project is missing validations, it assumes that the input is following 
the expected order (eg points start from the top left) and most importantly it should check for canvas 
bounds and crop.

2. in the engine we should have added a step to draw / write a message to inform the user of 
any errors or why a command was not used. 

