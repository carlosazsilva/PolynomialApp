###### *This challenge was made as the final project of [RE_Start Developer](https://pt.primaverabss.com/pt/formacao-2/acoes-em-destaque/restart/)'s OOP module.*

# Challenge Description
It's intended the creation of a program in C# (PolynomialApp) that allows the development of a calculator of polynomials using lists.

## The polynomial expression

Em matemática, uma função polinomial (de uma variável/incógnita) é uma **função P** que pode ser expressa da seguinte forma.

    P(x) = ax^n + bx^(n-1) + cx^(n-2) + ... + kx^1 + lx^0

* É uma soma de vários termos, em que n é um número inteiro não negativo (expoente/grau) e os números a, b, c, ..., k, l são constantes (coeficientes).

* Uma função P(x) com apenas um termo é também conhecida como monómio, se tiver 2 será um binómio e trinómio se tiver 3 termos. Se tiver 3 ou mais termos, diz-se apenas polinómio.

* Grau de um polinómio: O grau de um polinómio, não nulo, é dado em função do seu termo de maior grau.

* Um polinómio pode ser completo ou incompleto: Completo se todos os coeficientes que os constituem são não nulos e incompleto se algum dos coeficientes for zero.

Polinómio de grau 4 completo:

    P(x) = 7x^4 - 3x^3 + 1x^2 + 3x - 10

Polinómio de grau 5 incompleto:

    P(x) = -2x^5 + 2x^2 - 5

Computacionalmente, existem algumas estratégias para a representação e manuseamento de polinómios, sendo a mais conhecida o uso de vetores, para armazenar diferentes coeficientes do polinómio. Os polinómios representados anteriormente, poderiam ter a seguinte representação computacional (usando vetores).

Index | 0 | 1 | 2 | 3 | 4 | 5 | 6
----- | - | - | - | - | - | - | -
Pa(x) | -10 | 3 | 1 | -3 | 7 | |
Pb(x) | -5 | - | 2 | - | - | -2 |

Esta estratégia tem a vantagem de facilmente se conseguir determinar qual o coeficiente de um determinado termo. No entanto, para polinómios não completos leva a que sejam desperdiçadas posições do vetor que não são usadas (são usadas com coeficiente 0).

Por exemplo: para um polinómio de grau 15 com apenas dois termos (4x^15 – 5x^3) teremos de ter um vetor com 16 posições em que apenas duas vão ter valores significativos para o polinómio.

Uma alternativa aos vetores, é o uso de listas para a representação computacional de polinómios.

Pretende-se com este projeto que os formandos desenvolvam uma alicação para trabalhar com polinómios com base em listas de termos para representar os polinómios. E que sejam realizadas diversas operações com polinómios de N termos com coeficientes e graus do tipo inteiro.

&nbsp;

# Polynomial App

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

&nbsp;

### Contructors

Constructor                            | Action
-------------------------------------- | ------
`Polynomial()`                         | Default constructor.
`public Polynomial(params int[] coef)` | Creates a new instance of the Polynomial object with the coefficients as parameters.<br>O grau de cada termo será o respetivo índice no vetor coef recebido como argumento.<br>No Polinómio não deverão existir nunca termos com coeficiente = 0 (zero)

&nbsp;

### Properties

Property                 | Action
------------------------ | ------
`public int Degree`      | Gets the polynomial degree.
`public int NumTerms`    | Gets the number of terms of the polynomial.
`public bool IsComplete` | Gets wheter the polynomial is complete or not.

&nbsp;

### Methods

Method                                                               | Action
-------------------------------------------------------------------- | ------
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

Crie um projeto de testes que permita testar cada uma das funcionalidades implementadas na classe Polynomial. Deverá haver pelo menos um teste para cada construtor, propriedade e método. Poderá usar a package Fluent Assertions juntamente com o xUnit.

&nbsp;

## PART III · CLI (Command Line Interface) development

O projeto deverá disponibilizar uma CLI para fazer as operações implementadas anteriormente e outras que estão listadas na tabela abaixo.

Uma CLI apresenta uma grande flexibilidade de efetuar comandos. Apesar de não ser inicialmente tão fácil como os menus, são mais rápidos e intuitivos de utilizar quando o utilizador domina os comandos e os seus argumentos.

Command | Action
------- | ------
`add -name {nome do polinómio} polinómio` | O nome do polinómio é opcional. Se não colocar, o sistema deve dar um nome por omissão, começando por `p1`, `p2` e assim sucessivamente, não podendo haver nomes iguais.<br>**Exemplos**:<br>`add -name poli 3x^3+2` – Cria o polinómio `3x^3+2` com o nome `poli`<br>`add 4x^2-3x` – Cria o polinómio `4x^2-3x` com o nome `p1`
`remove -name {nome do polinómio}` | O nome do polinómio é obrigatório. Remove o polinómio com um determinado nome.
`list` | Lista todos os polinómios criados até ao momento.<br>**Exemplo**:<br>`poli: 4x^2-3x`<br>`p1: 12x^5-9x^4+8x^2-6x`<br>`p2: 9 x^6 - 3 x^5 + 10 x^2 - 5`
`save -d {caminho do ficheiro}`| `-d` – parâmetro opcional<br>Permite gravar os polinómios no caminho denominado no parâmetro `d`. Se não for passado um caminho para o ficheiro, deverá ser utilizado um por omissão.
`read -d {caminho do ficheiro}` | Permite ler os polinómios previamente gravados no caminho especificado ou no caminho por omissão caso o parâmetro `-d` não tenha sido passado.
`help`| Lista todos os comandos disponíveis com uma breve descrição sobre o que eles fazem.
`clear`| Limpa a consola.
`exit` | Sai da aplicação.

> Crie as classes necessárias para melhor organizar o código.

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

<!-- Unordered and ordered list -->
<!-- * ul -->
<!-- 1. ol -->

<!-- ![GitHub Logo](/images/logo.png) -->
<!-- Format: ![Alt Text](url) -->

<!-- http://github.com - automatic! -->
<!-- [GitHub](http://github.com) -->

<!-- Quote -->
<!-- > We're living the future so -->
<!-- > the present is our past. -->

<!-- Code -->
<!-- `<addr>` element here instead. -->