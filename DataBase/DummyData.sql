

/* Inserções de pessoa */
INSERT INTO `ProjetoBanking`.`Pessoa` (`Pessoa_id`, `Pessoa_cpf`, `Pessoa_nome`) VALUES (1, '000.111.222-33', 'Fulano');
INSERT INTO `ProjetoBanking`.`Pessoa` (`Pessoa_id`, `Pessoa_cpf`, `Pessoa_nome`) VALUES (2, '000.121.222-44', 'Beltrano');

/*Inserção de Contas Contabeis*/
INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (1, 0);
INSERT INTO `ProjetoBanking`.`Conta_Contabil_Investimento` (`Conta_Conta_Contabil_Investimento_id`) VALUES (1);

INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (2, 0);
INSERT INTO `ProjetoBanking`.`Conta_Contabil_Emprestimo` (`Conta_Conta_Contabil_Emprestimo_id`) VALUES (2);

/*Inserção de Conta Corrente */
INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (3, 0);
INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`, `Pessoa_Pessoa_cpf`) VALUES (3, 1000, '000.111.222-33');

INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (4, 0);
INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`, `Pessoa_Pessoa_cpf`) VALUES (4, 10000, '000.121.222-44');