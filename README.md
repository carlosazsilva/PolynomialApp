###### *This challenge was made as the final project of [RE_Start Developer](https://pt.primaverabss.com/pt/formacao-2/acoes-em-destaque/restart/)'s OOP module. It's an academic project made with no real world application.*

# Challenge Description
The intent of the project is the creation of a console application in C# (**PolynomialApp**) that allows the manipulation of polynomials expressions using lists.

## The polynomial expression

*In mathematics*, a polynomial expression is a ***function P*** that can be written in the following way:

    P(x) = ax^n + bx^(n-1) + cx^(n-2) + ... + kx^1 + lx^0

* It's the sum of several terms, in which ***n*** is an non-negative integer (exponent/degree) and the number ***a***, ***b***, ***c***, ..., ***k***, ***l*** are constants (coefficients).

* The ***function P(x)*** with just one term is known as a monomial expression, binomial for 2 and trinomial for 3. If it has more than 3 terms, it’s called a polynomial expression.

* The degree of a polynomial is a non-null value given by the term with the higher degree.  

* A polynomial expression can be complete or incomplete. Complete if all its coefficients are non-null and incomplete if any of them is zero.

*Complete 4th degree polynomial expression:*

    P(x) = 7x^4 - 3x^3 + 1x^2 + 3x - 10

*Incomplete 5th degree polynomial expression:*

    P(x) = -2x^5 + 2x^2 - 5

## Computationally

There are some strategies to represent and handle polynomial expressions, being the most common the use of arrays to store the different coefficients of the polynomial. The previous polynomial expression could have the following computational representation using arrays.

Index   |   0   |   1   |   2   |   3   |   4   |   5   |   6
:-----: |  :-:  |  :-:  |  :-:  |  :-:  |  :-:  |  :-:  |  :-:
`Pa(x)` | `-10` | ` 3 ` | ` 1 ` | ` -3` | ` 7 ` |       |
`Pb(x)` | ` -5` |       | ` 2 ` |       |       | ` -2` |

This strategy has the advantage of an easy determination of the coefficient of a given term. However, for non-complete polynomial expressions, the array has unused indexes (they have a coefficient of zero). 

*For example*: given a polynomial expression with degree 15 with just two terms (4x^15 – 5x^3), we will have an array with 16 positions in which only two will have significant values for the polynomial expression.

As an alternative to arrays, we can have lists to represent polynomial expressions computationally.

## Goal

The purpose of this project is the development of an application to work with polynomial expressions based on lists of terms to represent them. It also had to possibilitate operations with `n` terms with coefficients and degrees of type integer.

&nbsp;

# The Polynomial App

This project is made up of three different parts:

* **PART I**: [The development of the Polynomial class](#part-i--development-of-the-polynomial-class)
* **PART II**: [Tests project](#part-ii--tests-project)
* **PART III**: [CLI (Command Line Interface) development](#part-iii--cli-command-line-interface-development)

&nbsp;

## PART I · Development of the Polynomial class

Development of the Polynomial class with the following constructors, properties and methods:

* [Constructors](#constructors)
* [Properties](#properties)
* [Methods](#methods)

> Additional methods can be created to make the code cleaner and more readable.

### Contructors

Constructor                            | Action
:------------------------------------- | :-----
`Polynomial()`                         | Default constructor.
`public Polynomial(params int[] coef)` | Creates a new instance of the Polynomial class the parameters as its coefficients.<br>The degree of each term is given by its respective index in the array.<br>Terms with 0 valued coefficients are not allowed.
`public Polynomial(string polynomial)` | Creates a new instance of the Polynomial class based on a string.

### Properties

Property                 | Action
:----------------------- | :-----
`public int Degree`      | Gets the polynomial degree.
`public int NumTerms`    | Gets the number of terms of the polynomial.
`public bool IsComplete` | Gets whether the polynomial is complete or not.

### Methods

Method                                                               | Action
:------------------------------------------------------------------- | :-----
`public void AddTerm(int degree, int coef)`                          | Adds a new term to the polynomial.<br>There cannot be two terms with the same degree.
`public void RemoveTerm(int grau)`                                   | Removes from the polynomial expression the term with the degree that is equal to the argument.
`public double Value(double x)`                                      | Calculates the real value of the expression for the received argument.
`public override string ToString()`                                  | Returns the polynomial expression in a string like this: `-2x^5 + 3x^2 – x + 6`.<br>Use `^` to indicate exponent; The exponent `^1` shouldn’t appear in the string, as well as the text `x^0`.
`public Polynomial Clone()`                                          | Creates a copy – a new expression, not a reference – of a polynomial expression.
`public static Polynomial operator + (Polynomial p1, Polynomial p2)` | Adds two polynomial expressions, returning the result as a new polynomial expression.
`public static Polynomial operator - (Polynomial p1, Polynomial p2)` | Subtracts two polynomial expressions, returning the result as a new polynomial expression.
`public static Polynomial operator * (Polynomial p1, Polynomial p2)` | Multiplies two polynomial expressions, returning the result as a new polynomial expression.
`public static Polynomial operator * (Polynomial p1, int escalar)`   | Multiplies a polynomial expression with an integer, returning the result as a new polynomial expression.    

> Errors must be handled to ensure the application doesn’t close abruptly.

&nbsp;

## PART II · Tests project

Create a tests project that allows testing each one of the functionalities implemented in the Polynomial class. There should be at least one test for each constructor, property and method. You can use the `Fluent Assertions` in conjunction with the `xUnit` package.

&nbsp;

## PART III · CLI (Command-line Interface) development

The project must present a command-line interface to the user to interact with the previously implemented operations and others, listed below.

A CLI offers great flexibility in performing commands. Although as first not as easy to interact with as menus, CLIs are faster and more intuitive when the user masters the commands and its arguments.

Command                                   | Action
:---------------------------------------- | :-----
`add` `-name` `{name}` `{polynomial expression}` | The name paramenter is optional. If not provided, the app should name the expression by default, starting with `p1`, `p2` and so on, without repetition. **Examples**:<br>`add -name poli 3x^3+2` – adds the polynomial `3x^3+2` with the name `poli`<br>`add 4x^2-3x` – adds the polynomial `4x^2-3x` with the name `p1`
`remove` `-name` `{name}`                        | The name of the polynomial expression is requires. Removes the expression from the list.
`list`                                           | Lists all polynomial expression create up until this moment. **Example**:<br>`poli: 4x^2-3x`<br>`p1: 12x^5-9x^4+8x^2-6x`<br>`p2: 9x^6-3x^5+10x^2-5`
`save` `-d` `{file path}`                        | Saves the list of polynomial expressions on a specific path or, in case of the omission of the `-d` parameter, on the default path `/bin/Debug/net5.0/polynomials.json`.
`read` `-d` `{caminho do ficheiro}`              | Reads a list of polynomial expressions from a file on a specific path or, in case of the omission of the `-d` parameter, on the default path.
`help`                                           | List all available commands with a brief description of their functionality.
`clear`                                          | Clears the console.
`exit`                                           | Closes the application.
`p1 + p2`                                        | Adds the polynomial expressions p1 and p2. **Example**:<br>`(3x^3+2) + (4x^2-3x) = 3x^3+4x^2-3x+2`
`p1 - p2`                                        | Subtracts the polynomial expressions p1 and p2. **Example**:<br>`(3x^3+2) - (4x^2-3x) = 3x^3-4x^2+3x+2`
`p1 * p2`                                        | Multiplies the polynomial expressions p1 and p2. **Example**:<br>`(3x^3+2) * (4x^2-3x) = 12x^5-9x^4+8x^2-6x`
`p1 * 2`                                         | Multiplies the polynomial expression p1 by an integer. **Example**:<br>`3x^3+2) * 2 = 6x^3+6`
`compute` `-name` `{name}` `-value` `{x}`        | Resolves the polynomial expression, replacing the value of x with the value passed in the `-value` parameter. Uses the `Value(int x)` method of the Polynomial class.

* Create the required classes to better organize the code.

* Whenever a command is wrong or incomplete, you should present an informative message that helps the user solve the problem.

* *For example*: if the user writes the command `save -d` and doesn’t provide a path, a message similar to this, should be presentes: “The command `save` is incomplete. You should associate a path to the parameter `-d`or just type `save` without any parameter."

* If the user intents are not evident, a message should be displayed: “Command not recognized. Type help for the available parameters.”

* Use the website [WolframAlpha](https://www.wolframalpha.com/) to validate results and to implement the tests.