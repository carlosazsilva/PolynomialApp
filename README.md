*This challenge was made as the final project of [RE_Start Developer](https://pt.primaverabss.com/pt/formacao-2/acoes-em-destaque/restart/)'s OOP module.*

## Challenge Description
It's intended the creation of a program in C# (PolynomialApp) that allows the development of a calculator of polynomials using lists.

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

### O projeto é composto por 3 partes distintas:

1. Desenvolvimento da classe Polinómio
1. Projeto de Testes
1. CLI (Command Line Interface Desenvovimento) desenvolvimento de comandos numa aplicação de consola para interagir com múltiplos polinómios, permitindo efetuar operações entre eles e não só.

## 1. Desenvolvimento do classe Polinómio

Desenvolva a class Polinomio com os seguintes construtores, propriedades e métodos.

###### Nota: Poderão ser criados métodos adicionais para criar o código mais limpo e legível.
###### Nota 1: o grau de cada termo será o respetivo índice no vetor coef recebido como argumento.
###### Nota 2: No Polinómio não deverão existir nunca termos com coeficiente = 0 (zero)

Contructors                         | Actions
----------------------------------- | -------
Polynomial() | Default constructor
public Polinomio(params int[] coef) | Construtor que cria um objeto do tipo Polinómio com os coeficientes passados por argumento.

Methods                                  | Actions
---------------------------------------- | -------
public void AddTermo(int grau, int coef) | Método que permite acrescentar um novo termo ao polinómio. Nota: não podem existir dois termos com o mesmo grau.

<!-- # h1 -->
<!-- ## h2 -->
<!-- ### h3 -->
<!-- #### h4 -->
<!-- ##### h5 -->
<!-- ###### h6 -->

<!-- Bold and italic -->
<!-- *italic* || _italic_ -->
<!-- **bold** || __bold__ -->

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