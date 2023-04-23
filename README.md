Para fazer o teste do projeto será necessário criar uma instância de banco de dados Sql Server local ou em nuvem. Crie um banco chamado Todo e altere a string de conexão no arquivos Constants.cs. 
Logo após a criação do banco, crie uma tabela com as seguintes colunas:
-id (int, não nulo) como identidade +1
-title (varchar(50), não nulo
-description (varchar(max), possivelmente nulo)
-priority (bit, não nulo)
-status (bit, não nulo)
dataStart (date, não nulo)
dataEnd (date. nulo)
