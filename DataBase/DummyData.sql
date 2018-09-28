
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
INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`, `Pessoa_Pessoa_cpf`,
 `Conta_Corrente_senha`) VALUES (3, 1000, '000.111.222-33', "1234");

INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (4, 0);
INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`,
`Pessoa_Pessoa_cpf`, `Conta_Corrente_senha`) VALUES (4, 10000, '000.121.222-44', "1234");

/* Inserção de Taxa */
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (1, "SELIC", 4);

/*Inserção de Empréstimo */
INSERT INTO `ProjetoBanking`.`Emprestimo` (`Emprestimo_id`, `Emprestimo_valor`, `Emprestimo_parcelas`, `Taxa_Taxa_id`, 
`Conta_Corrente_Conta_Conta_Corrente_id`, `Emprestimo_Inicio`) VALUES (1,1000, 10, 1, 3,'2017-8-09');