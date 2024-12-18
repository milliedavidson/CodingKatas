# Coding Katas

## User Story 1

You work for a bank, which has recently purchased a spiffy
machine to assist in reading letters and faxes sent in by
branch offices. The machine scans the paper documents, and
produces a file with a number of entries which each look like
this:

```
  _  _     _  _ _  _  _
| _| _||_||_ |_  ||_||_|
||_  _|  | _||_| ||_| _|

```

Each entry is 4 lines long, and each line has 27 characters. The
first 3 lines of each entry contain an account number written
using pipes and underscores, and the fourth line is blank. Each
account number should have 9 digits, all of which should be
in the range 0-9. A normal file contains around 500 entries.

Your first task is to write a program that can take this file and
parse it into actual account numbers.

---

### Sample file:

```
 _  _  _  _  _  _  _  _  _ 
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|
                           
                           
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                           
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
                           
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|
                           
                       
|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |
                           
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|
                           
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
|_||_||_||_||_||_||_||_||_|
                           
 _  _  _  _  _  _  _  _  _ 
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|
                           
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|
                           
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
```

---

### Test cases with expected results:

```
 _  _  _  _  _  _  _  _  _ 
| || || || || || || || || |
|_||_||_||_||_||_||_||_||_|
                           
=> 000000000
                           
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                           
=> 111111111
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
                           
=> 222222222
 _  _  _  _  _  _  _  _  _ 
 _| _| _| _| _| _| _| _| _|
 _| _| _| _| _| _| _| _| _|
                           
=> 333333333
                           
|_||_||_||_||_||_||_||_||_|
  |  |  |  |  |  |  |  |  |
                           
=> 444444444
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
 _| _| _| _| _| _| _| _| _|
                           
=> 555555555
 _  _  _  _  _  _  _  _  _ 
|_ |_ |_ |_ |_ |_ |_ |_ |_ 
|_||_||_||_||_||_||_||_||_|
                           
=> 666666666
 _  _  _  _  _  _  _  _  _ 
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
                           
=> 777777777
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
|_||_||_||_||_||_||_||_||_|
                           
=> 888888888
 _  _  _  _  _  _  _  _  _ 
|_||_||_||_||_||_||_||_||_|
 _| _| _| _| _| _| _| _| _|
                           
=> 999999999
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
                           
=> 123456789
```

---

## User Story 2

Having done that, you quickly realize that the ingenious machine
is not in fact infallible. Sometimes it goes wrong in its scanning.
The next step therefore is to validate that the numbers you read 
are in fact valid account numbers. A valid account number has a 
valid checksum. 

This can be calculated as follows:

account number:  3  4  5  8  8  2  8  6  5
position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1

checksum calculation:
(d1+2*d2+3*d3+...+9*d9) mod 11 = 0

So now you should also write some code that calculates the checksum
for a given number, and identifies if it is a valid account number.

---

## User Story 3

Your boss is keen to see your results. He asks you to write out a file
of your findings, one for each input file, in this format:

457508000
664371495 ERR
86110??36 ILL

ie the file has one account number per row. If some characters are 
illegible, they are replaced by a ?. In the case of a wrong checksum,
or illegible number, this is noted in a second column indicating status.

Now, we have provided you some example data and expected output. However,
we haven't provided you with the input file that will generate the 
expected output. So first, using code you will need to generate the input 
file. When you have this you can then generate the expected output and 
verify.

---

### Example of illegible numbers

```
    _  _  _  _  _  _     _ 
|_||_|| || ||_   |  |  | _ 
  | _||_||_||_|  |  |  | _|
                           
=> 49006771? ILL
    _  _     _  _  _  _  _ 
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ 
                           
=> 1234?678? ILL
```

---

### Expected output

```
123456789
345882865
457508000
664371495 ERR
86110??36 ILL
987654321 ERR
000000051
123456788 ERR
49006771? ILL
1234?678? ILL
```

---


