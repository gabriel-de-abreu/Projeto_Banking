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
 `Conta_Corrente_senha`) VALUES (3, 10000, '000.111.222-33', "81dc9bdb52d04dc20036dbd8313ed055");

INSERT INTO `ProjetoBanking`.`Conta` (`Conta_id`, `Conta_saldo`) VALUES (4, 0);
INSERT INTO `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`, `Conta_Corrente_limite`,
`Pessoa_Pessoa_cpf`, `Conta_Corrente_senha`) VALUES (4, 20000, '000.121.222-44', "81dc9bdb52d04dc20036dbd8313ed055");

/* Inserção de Taxa */
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (1, "Juros Perfil 1", 4);
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (2, "Juros Perfil 2", 8);
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (3,"Juros Perfil 3", 12);
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (4,"Imposto de Renda", 17.5);
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (5,"IOF", 20);
INSERT INTO `ProjetoBanking`.`Taxa` (`Taxa_id`, `Taxa_nome`, `Taxa_valor`) VALUES (6,"Taxa Poupança", 0.01);

/* Inserção de Investimentos */
INSERT INTO `projetobanking`.`investimento`
(`Investimento_id`,
`Investimento_nome`,
`Investimento_rentabilidade`,
`Taxa_Taxa_id`)
VALUES
(1, "Renda Fixa", 4, 4);

INSERT INTO `projetobanking`.`investimento`
(`Investimento_id`,
`Investimento_nome`,
`Investimento_rentabilidade`,
`Taxa_Taxa_id`)
VALUES
(2, "Tesouro Direto", 2, 5);

INSERT INTO `projetobanking`.`investimento`
(`Investimento_id`,
`Investimento_nome`,
`Investimento_rentabilidade`,
`Taxa_Taxa_id`)
VALUES
(3, "Poupança", 1, 6);

INSERT INTO `ProjetoBanking`.`Gerente` (`Gerente_id`, `Gerente_login`, `Gerente_senha`) VALUES (1, 'gerente', '81dc9bdb52d04dc20036dbd8313ed055');