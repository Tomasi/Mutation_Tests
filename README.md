# Teste de Mutação com Stryker C#

Católica de Santa Catarina

Alunos: Igor Tomasi e Khauê Souza

## Stryker

A ferramenta Stryker apresenta suporte para as linguagens C# e JavaScript, oferecendo a possibilidade de aplicar testes de mutação para seu código fonte, permitindo testar temporariamente, aplicando bugs temporários.

## Passo a Passo

### Link do vídeo gravado com *aplicação prática*.

https://1drv.ms/v/s!AsMFpzmd1T2Tg_FHAdyY8LR6kg5HZQ?e=377iiX

### Funcionamento da Ferramenta

Após a ferramenta aplicar mutação no código fonte, o mesmo gera automáticamente um arquivo para análise dos resultados. Em nosso exemplo, foi realizado 31 mutações no projeto e 26 "sobreviveram", algo que não deveria acontecer, sendo o cenário ideal todos os testes unitários reprovarem. Análisandos os resultados dos testes de mutação, podemos verificar quais alterações geradas fizeram os testes unitários sobreviverem.

### 1º Mutação

![image](https://user-images.githubusercontent.com/61890715/176048202-126231d0-ffd2-48c8-9fe2-8a099518ded4.png)

### Resolução

![image](https://user-images.githubusercontent.com/61890715/176049703-b8be3135-6176-4583-9898-03c930c9e853.png)

### 2º e 3º Mutação

![image](https://user-images.githubusercontent.com/61890715/176048457-4e5504cf-a8ff-4b3c-98fe-083b842f344f.png)

![image](https://user-images.githubusercontent.com/61890715/176048665-bb332c98-9fd0-4006-ab13-1b5c3ad5ae17.png)

### Resolução

![image](https://user-images.githubusercontent.com/61890715/176049792-8ab3dd62-5e4e-401c-af98-2e88121d2f7c.png)

### 4ª e 5ª

![image](https://user-images.githubusercontent.com/61890715/176049019-eae11fba-1401-42a9-bdbf-fba89b063dfe.png)

![image](https://user-images.githubusercontent.com/61890715/176049215-89b66c1a-da12-40ee-82d0-9f1f7b4671f6.png)

## Resolução

![image](https://user-images.githubusercontent.com/61890715/176049950-9f38fa10-cf1d-42a0-8e7d-c41bcf065a2f.png)



