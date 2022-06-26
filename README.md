# Mutation_Tests
Primeiramente  pegamos um projeto que ja tinhamos usados para fazer os testes unitarios.


Comando para iniciar ele:
donet stryker
Depois que ele rodar ele vai criar um arquivo que vai ser o resultado do teste de mutação.
de 31 mutações no nosso projeto 26 reprovaram, o cenario ideal seriam 31.
Ai gente pode ir no brownser com o link que ele da do resultado, 
temos 3 filtros para ver que são que as que foram mortas pelo teste as que sobreviveral e sem cobertura.
A gente tem que olhar as que sobreviveram para corrigir em cima delas.


1°-Caso ele alterando a condição para menor ou igual a zero, essa função é feita para que o valor que for passado para o 
depositAmount nao seja negativo.

if antigo:

if (amount < 0){
      throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
  }

Ai vamos nesse metodo, e criamos uma variavel 

zeroValue = 0;

e mudamos o if para 

if(Math.Max(zeroValue, amout) == zeroValue){
      throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
  }

isso vai nos dar o mesmo resultado porem nao tera um problema mesmo com a mutação.

2° -Caso No metodo debit

aqui ele verifica se o meu valor no debito é maior que eu tenho saldo entao nao pode ser feito o debito,
então fazemos praticamente a mesma coisa no 1° caso, criamos uma variavel e mudamos o modo de como ele verifica o caso.

variavel nova:

var maxValue = m_balance;

if antigo:

if (amount > m_balance){
    throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
}

e mudamos o if para :

if(Math.Max(maxValue, amount) == amount){
        throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
     }

3° -Caso ele ta verificando se o meu debito é menor que zero. fazemos o mesmo passo a passo criamos uma variavel e e mudamos a forma do if tambem.

A variavel criada:

var zeroValue = 0;

o if antigo :

if(amount < 0){
  throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountLessThanZeroMessage);
            }

4° -Caso esse é na nosso metodo de credit e vamos corrigir tbm para outra forma nosso if criando uma variavel tbm.

variavel nova:

var zeroValue = 0;

if antigo:

    if (amount < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
    }
    
Novo if:

    if (Math.Max(zeroValue, amount) == zeroValue)
    {
        throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountLessThanZeroMessage);
    }
    
5°- Caso Se ele é maior que o meu limite de credito e ai ele retorna uma excção da mensagem trow ai vamos defenir outra variavel e mudar o if.

variavel nova: 

var maxLimitValue = m_limitAccount;

if antigo:

     if (amount > m_limitAccount) {
        throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountExceedsLimitsAccount);
      }
if novo:

     if (Math.Max(maxLimitValue, amount) == amount) {
        throw new ArgumentOutOfRangeException(nameof(amount), amount, CreditAmountExceedsLimitsAccount);
      }

Depois de corrigirmos os 5 erros rodamos os teste novamente e vemos que funcionou, e rodamos novamente o donet só para confirmar que ele mataria todos os teste.


