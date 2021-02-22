###### *This challenge was made as the final project of [RE_Start Developer](https://pt.primaverabss.com/pt/formacao-2/acoes-em-destaque/restart/)'s OOP module. It's an academic project made with no real intent.*

# Challenge Description
The intent of the project was the creation of a console application in C# (PolynomialApp) that allows the manipulation of polynomials using lists.

## The polynomial expression

In mathematics, a polynomial expression is a **function P** that can be written in the following way:

    P(x) = ax^n + bx^(n-1) + cx^(n-2) + ... + kx^1 + lx^0

* It's the sum of several terms, in which *n* is an non-negative integer (exponent/degree) and the number a, b, c, ..., k, l are constants (coefficients).

* The function P(x) with just one term is known as a monomial expression, binomial for 2 and trinomial for 3. If it has more than 3 terms, it’s called a polynomial expression.

* The degree of a polynomial is a non-null value given by the term with the higher degree.  

* A polynomial expression can be complete or incomplete. Complete if all its coefficients are non-null and incomplete if any of them is zero.

Complete 4th degree polynomial expression:

    P(x) = 7x^4 - 3x^3 + 1x^2 + 3x - 10

Incomplete 5th degree polynomial expression:

    P(x) = -2x^5 + 2x^2 - 5

## Computationally

There are some strategies to represent and handle polynomial expressions, being the most common the use of arrays to store the different coefficients of the polynomial. The previous polynomial expression could have the following computational representation using arrays.

Index   |   0   |   1   |   2   |   3   |   4   |   5   |   6
:-----: |  :-:  |  :-:  |  :-:  |  :-:  |  :-:  |  :-:  |  :-:
`Pa(x)` | `-10` | ` 3 ` | ` 1 ` | ` -3` | ` 7 ` |       |
`Pb(x)` | ` -5` |       | ` 2 ` |       |       | ` -2` |

This strategy has the advantage of an easy determination of the coefficient of a given term. However, for non-complete polynomial expressions, the array has unused indexes (they have a coefficient of zero). 

For example: given a polynomial expression with degree 15 with just two terms (4x^15 – 5x^3), we will have an array with 16 positions in which only two will have significant values for the polynomial expression.

As an alternative to arrays, we can have lists to represent polynomial expressions computationally.

## Goal

The purpose of this project was the development of an application to work with polynomial expressions based on lists of terms to represent them. It also had to possibilitate operations with N terms with coefficients and degrees of type integer.

&nbsp;

# The Polynomial App

#### O projeto é composto por 3 partes distintas:

* **PART I**: [The development of the Polynomial class](#part-i--development-of-the-polynomial-class)
* **PART II**: [Tests project](#part-ii--tests-project)
* **PART III**: [CLI (Command Line Interface) development](#part-iii--cli-command-line-interface-development)

&nbsp;

## PART I · Development of the Polynomial class

Desenvolva a class Polynomial com os seguintes construtores, propriedades e métodos:

* [Constructors](#constructors)
* [Properties](#properties)
* [Methods](#methods)

> Poderão ser criados métodos adicionais para criar o código mais limpo e legível.

### Contructors

Constructor                            | Action
:------------------------------------- | :-----
`Polynomial()`                         | Default constructor.
`public Polynomial(params int[] coef)` | Creates a new instance of the Polynomial object with the coefficients as parameters.<br>O grau de cada termo será o respetivo índice no vetor coef recebido como argumento.<br>No Polinómio não deverão existir nunca termos com coeficiente = 0 (zero)

### Properties

Property                 | Action
:----------------------- | :-----
`public int Degree`      | Gets the polynomial degree.
`public int NumTerms`    | Gets the number of terms of the polynomial.
`public bool IsComplete` | Gets wheter the polynomial is complete or not.

### Methods

Method                                                               | Action
:------------------------------------------------------------------- | :-----
`public void AddTerm(int degree, int coef)`                          | Adds a new term to the polynomial.<br>Não podem existir dois termos com o mesmo grau.
`public void RemoveTerm(int grau)`                                   | Método que retira do polinómio o termo de grau igual ao passado por argumento.
`public double Value(double x)`                                      | Método que calcula o valor real do polinómio para o argumento recebido.
`public override string ToString()`                                  | Método que devolve o polinómio na forma de string de acordo com o seguinte formato: `-2x^5 + 3x^2 – x + 6`.<br>Use o símbolo `^` para indicar expoente; expoente `^1` não deve aparecer na string, tal como o texto `x^0`.
`public Polynomial ConvertFrom(string strPolynomial)`                | Converte uma string num polinómio. O método deve lançar uma exceção caso não consiga converter a string num polinómio.
`public Polynomial Clone()`                                          | Método que cria uma “cópia” do Polinómio.<br>Terá que se criado um novo polinómio, não uma referência para o polinómio.existente.
`public static Polynomial operator + (Polynomial p1, Polynomial p2)` | Realiza a operação de soma de polinómios, devolvendo o resultado como um novo Polinómio.
`public static Polynomial operator - (Polynomial p1, Polynomial p2)` | Realiza a operação de subtração de polinómios, devolvendo o resultado como um novo Polinómio.
`public static Polynomial operator * (Polynomial p1, Polynomial p2)` | Realiza a operação de multiplicação de polinómios, devolvendo o resultado como um novo Polinómio.
`public static Polynomial operator * (Polynomial p1, int escalar)`   | Realiza a operação de multiplicação entre um polinómio e um valor inteiro, devolvendo o resultado como um novo Polinómio.    

> Os erros devem ser tratados de forma a garantir que a aplicação não termina de forma abrupta.

&nbsp;

## PART II · Tests project

Crie um projeto de testes que permita testar cada uma das funcionalidades implementadas na classe Polynomial. Deverá haver pelo menos um teste para cada construtor, propriedade e método. Poderá usar a package `Fluent Assertions` juntamente com o `xUnit`.

&nbsp;

## PART III · CLI (Command Line Interface) development

O projeto deverá disponibilizar uma CLI para fazer as operações implementadas anteriormente e outras que estão listadas na tabela abaixo.

Uma CLI apresenta uma grande flexibilidade de efetuar comandos. Apesar de não ser inicialmente tão fácil como os menus, são mais rápidos e intuitivos de utilizar quando o utilizador domina os comandos e os seus argumentos.

Command                                   | Action
:---------------------------------------- | :-----
`add -name {nome do polinómio} polinómio` | O nome do polinómio é opcional. Se não colocar, o sistema deve dar um nome por omissão, começando por `p1`, `p2` e assim sucessivamente, não podendo haver nomes iguais.<br>**Exemplos**:<br>`add -name poli 3x^3+2` – Cria o polinómio `3x^3+2` com o nome `poli`<br>`add 4x^2-3x` – Cria o polinómio `4x^2-3x` com o nome `p1`
`remove -name {nome do polinómio}`        | O nome do polinómio é obrigatório. Remove o polinómio com um determinado nome.
`list` | Lista todos os polinómios criados até ao momento.<br>**Exemplo**:<br>`poli: 4x^2-3x`<br>`p1: 12x^5-9x^4+8x^2-6x`<br>`p2: 9 x^6 - 3 x^5 + 10 x^2 - 5`
`save -d {caminho do ficheiro}`           | `-d` – parâmetro opcional<br>Permite gravar os polinómios no caminho denominado no parâmetro `d`. Se não for passado um caminho para o ficheiro, deverá ser utilizado um por omissão.
`read -d {caminho do ficheiro}`           | Permite ler os polinómios previamente gravados no caminho especificado ou no caminho por omissão caso o parâmetro `-d` não tenha sido passado.
`help`                                    | Lista todos os comandos disponíveis com uma breve descrição sobre o que eles fazem.
`clear`                                   | Limpa a consola.
`exit`                                    | Sai da aplicação.
Operation                                 | 
`p1 + p2`                                 | Soma o polinómio p1 ao polinómio p2.<br>**Example**:<br>`(3x^3+2) + (4x^2-3x) = 3x^3+4x^2-3x+2`
`p1 - p2`                                 | Subtrai o polinómio p2 ao polinómio p1.<br>**Exemplo**:<br>`(3x^3+2) - (4x^2-3x) = 3x^3-4x^2+3x+2`
`p1 * p2`                                 | `(3x^3+2) * (4x^2-3x) = 12x^5-9x^4+8x^2-6x`
`p1 * 2`                                  | `3x^3+2) * 2 = 6x^3+6``
`compute -name {nome do polinómio } -value {valor de x}` | Calcula o resultado do polinómio, substituindo o valor de x pelo valor passado no parâmetro `-value`.<br>Faz uso do método `Value(int x)` da classe Polinomio.

> Crie as classes necessárias para melhor organizar o código.

> Sempre que o comando estiver errado ou incompleto, deverá ser apresentada uma mensagem informativa que ajude o utilizador a resolver o problema.
>
> Por exemplo: se o utilizador escrever o comando save `-d` e não passar o caminho do ficheiro, deverá apresentar uma mensagem similar a: O comando `save` está incompleto. Deverá passar o caminho associado ao parâmetro `-d` ou usar o comando `save` sem qualquer parâmetro.

> Se não conseguir decifrar o que o utilizador deseja, deverá ser apresentada a mensagem: Comando não é reconhecido como um comando válido. Digite `help` para visualizar a lista de comandos possíveis.

&nbsp;

## Dicas e sugestões para a resolução

* O enunciado do projeto permite que comece a desenvolver o mesmo iterativamente, podendo começar com as funcionalidades mais simples, testando e avançando para as demais. Foque-se em pequenas tarefas que cumulativamente lhe permitam ganhar confiança para as operações mais complexas.
* Se já desenvolveu algumas funcionalidades da Parte I, alterne e faça testes para garantir que o código que está a fazer está correto.
* Poderá começar por estruturar o programa (PolinomioApp) com os respetivos projetos de código e testes.
* Utilize o site [WolframAlpha](https://www.wolframalpha.com/) para validar os seus resultados e implementar os testes.
* Antes de passar para a implementação, certifique-se que entende o que é para fazer, esclarecendo as suas dúvidas.
* Utilize `try..catch` para o tratamento de erros.

&nbsp;

## Checklist

### PART I · Development of the Polynomial class
#### Constructors
- [ ] `Polynomial()`
- [ ] `public Polynomial(params int[] coef)`
#### Properties
- [ ] `public int Degree`
- [ ] `public int NumTerms`
- [ ] `public bool IsComplete`
#### Methods
- [ ] `public void AddTerm(int degree, int coef)`
- [ ] `public void RemoveTerm(int grau)`
- [ ] `public double Value(double x)`
- [ ] `public override string ToString()`
- [ ] `public Polynomial ConvertFrom(string strPolynomial)`
- [ ] `public Polynomial Clone()`
- [ ] `public static Polynomial operator + (Polynomial p1, Polynomial p2)`
- [ ] `public static Polynomial operator - (Polynomial p1, Polynomial p2)`
- [ ] `public static Polynomial operator * (Polynomial p1, Polynomial p2)`
- [ ] `public static Polynomial operator * (Polynomial p1, int scalar)`

### PART II · Tests project
- [ ] task

### PART III · CLI (Command Line Interface) development
- [ ] task