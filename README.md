# Operating-System-Simulator
Simulates operating system roles for educational purposes

There are several rules for the assembly-like language:
1. The supported instractions are: mov, add, sub, push, pop, memalloc, inc, dec, DATASEG, CODSEG

2. The interrupt int 21 is supported for input and output. You should put 1 in ax for input and 2 for output.

  Example of output:
  mov dx,3
  mov ax,2
  int 21
  
  The output would be 3, dx is printed.
  
  Example of input:
  mov ax,3
  sub ax,2
  int 21
  
  The input will be in ax.

3. a loop can be written only in the following form:
  mov cx,3
  Example:
  ...
  ...
  loop Example
  
  Of course you may change the number of iterations, the label and the code lines in the loop.
  However, the line mov cx,(iterations number) must come directly before the label.
  
4. Between to operands in the instractions mov, sub, add must be only a comma, without space.
  For instance: mov ax,4
