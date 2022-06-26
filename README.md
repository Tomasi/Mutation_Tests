# Teste de Mutação com Stryker C#

Primeiramente pegamos um projeto com testes unitários desenvolvidos.

Passa a passo feito para o teste de mutação (vídeo gravado e updado no OneDrive).
https://1drv.ms/v/s!AsMFpzmd1T2Tg_FHAdyY8LR6kg5HZQ?e=377iiX

Comando de inicialização da análise, após configuração do ambiente.

* donet stryker

Após a ferramenta aplicar mutação no código fonte, o mesmo gera automáticamente um arquivo para análise dos resultados. Em nosso exemplo, foi realizado 31 mutações no projeto e 26 "sobreviveram", algo que não deveria acontecer, sendo o cenario ideal nenhum teste unitário sobreviver, análisando os resultados dos testes, iniciamos então a correção para avitar que tal cenário prejudique o teste unitário.

1° Mutação: Alteração para condição que testava "< 0", a alteração feita com a ferramenta para "<= 0" fez com que ainda sim o teste unitário sobrevivesse.

if antigo:

if (amount < 0){
      throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
  }

Solução: Criamos uma variável 

zeroValue = 0;

e mudamos a condição para

if(Math.Max(zeroValue, amout) == zeroValue){
      throw new ArgumentOutOfRangeException(nameof(amount), amount, DebitAmountExceedsBalanceMessage);
  }

isso vai nos dar o mesmo resultado porem nao tera um problema mesmo com a mutação.

2° Caso No metodo debit

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


