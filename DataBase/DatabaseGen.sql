-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ProjetoBanking
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `ProjetoBanking` ;

-- -----------------------------------------------------
-- Schema ProjetoBanking
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ProjetoBanking` DEFAULT CHARACTER SET utf8 ;
USE `ProjetoBanking` ;

-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Pessoa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Pessoa` (
  `Pessoa_id` INT NOT NULL AUTO_INCREMENT,
  `Pessoa_cpf` VARCHAR(45) NOT NULL,
  `Pessoa_nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Pessoa_cpf`),
  UNIQUE INDEX `idPessoa_UNIQUE` (`Pessoa_id` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Conta` (
  `Conta_id` INT NOT NULL AUTO_INCREMENT,
  `Conta_saldo` FLOAT NOT NULL,
  PRIMARY KEY (`Conta_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Conta_Contabil_Investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Conta_Contabil_Investimento` (
  `Conta_Conta_Contabil_Investimento_id` INT NOT NULL,
  PRIMARY KEY (`Conta_Conta_Contabil_Investimento_id`),
  CONSTRAINT `fk_Conta_Contabil_Investimento_Conta1`
    FOREIGN KEY (`Conta_Conta_Contabil_Investimento_id`)
    REFERENCES `ProjetoBanking`.`Conta` (`Conta_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Conta_Contabil_Emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Conta_Contabil_Emprestimo` (
  `Conta_Conta_Contabil_Emprestimo_id` INT NOT NULL,
  PRIMARY KEY (`Conta_Conta_Contabil_Emprestimo_id`),
  CONSTRAINT `fk_Conta_Contabil_Emprestimo_Conta`
    FOREIGN KEY (`Conta_Conta_Contabil_Emprestimo_id`)
    REFERENCES `ProjetoBanking`.`Conta` (`Conta_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Conta_Corrente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Conta_Corrente` (
  `Conta_Conta_Corrente_id` INT NOT NULL,
  `Conta_Corrente_limite` FLOAT NOT NULL,
  `Pessoa_Pessoa_cpf` VARCHAR(45) NOT NULL,
  `Conta_Corrente_senha` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Conta_Conta_Corrente_id`, `Pessoa_Pessoa_cpf`),
  INDEX `fk_Conta_Corrente_Pessoa1_idx` (`Pessoa_Pessoa_cpf` ASC) ,
  CONSTRAINT `fk_Conta_Corrente_Conta1`
    FOREIGN KEY (`Conta_Conta_Corrente_id`)
    REFERENCES `ProjetoBanking`.`Conta` (`Conta_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Conta_Corrente_Pessoa1`
    FOREIGN KEY (`Pessoa_Pessoa_cpf`)
    REFERENCES `ProjetoBanking`.`Pessoa` (`Pessoa_cpf`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Taxa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Taxa` (
  `Taxa_id` INT NOT NULL AUTO_INCREMENT,
  `Taxa_nome` VARCHAR(45) NOT NULL,
  `Taxa_valor` FLOAT NOT NULL,
  PRIMARY KEY (`Taxa_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Emprestimo` (
  `Emprestimo_id` INT NOT NULL AUTO_INCREMENT,
  `Emprestimo_valor` FLOAT NOT NULL,
  `Emprestimo_parcelas` INT NOT NULL,
  `Taxa_Taxa_id` INT NOT NULL,
  `Conta_Corrente_Conta_Conta_Corrente_id` INT NOT NULL,
  `Emprestimo_Inicio` DATE NOT NULL,
  PRIMARY KEY (`Emprestimo_id`),
  INDEX `fk_Emprestimo_Taxa1_idx` (`Taxa_Taxa_id` ASC) ,
  INDEX `fk_Emprestimo_Conta_Corrente1_idx` (`Conta_Corrente_Conta_Conta_Corrente_id` ASC) ,
  CONSTRAINT `fk_Emprestimo_Taxa1`
    FOREIGN KEY (`Taxa_Taxa_id`)
    REFERENCES `ProjetoBanking`.`Taxa` (`Taxa_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Emprestimo_Conta_Corrente1`
    FOREIGN KEY (`Conta_Corrente_Conta_Conta_Corrente_id`)
    REFERENCES `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Pagamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Pagamento` (
  `Pagamento_id` INT NOT NULL AUTO_INCREMENT,
  `Pagamento_data` DATE NOT NULL,
  `Emprestimo_Emprestimo_id` INT NOT NULL,
  `Pagamento_Valor` FLOAT NOT NULL,
  `Pagamento_Pago` TINYINT NOT NULL DEFAULT 0,
  PRIMARY KEY (`Pagamento_id`),
  INDEX `fk_Pagamento_Emprestimo1_idx` (`Emprestimo_Emprestimo_id` ASC) ,
  CONSTRAINT `fk_Pagamento_Emprestimo1`
    FOREIGN KEY (`Emprestimo_Emprestimo_id`)
    REFERENCES `ProjetoBanking`.`Emprestimo` (`Emprestimo_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Pagamento_Conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Pagamento_Conta` (
  `Pagamento_Pagamento_id` INT NOT NULL,
  PRIMARY KEY (`Pagamento_Pagamento_id`),
  CONSTRAINT `fk_Pagamento_Conta_Pagamento1`
    FOREIGN KEY (`Pagamento_Pagamento_id`)
    REFERENCES `ProjetoBanking`.`Pagamento` (`Pagamento_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Pagamento_Boleto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Pagamento_Boleto` (
  `Pagamento_Pagamento_Boleto_id` INT NOT NULL,
  `Pagamento_Boleto_codigo` VARCHAR(45) NOT NULL,
  `Pagamento_Boleto_vencimento` DATE NOT NULL,
  PRIMARY KEY (`Pagamento_Pagamento_Boleto_id`),
  UNIQUE INDEX `Pagamento_Boleto_Codigo_UNIQUE` (`Pagamento_Boleto_codigo` ASC) ,
  CONSTRAINT `fk_Pagamento_Boleto_Pagamento1`
    FOREIGN KEY (`Pagamento_Pagamento_Boleto_id`)
    REFERENCES `ProjetoBanking`.`Pagamento` (`Pagamento_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Movimentacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Movimentacao` (
  `Movimentacao_id` INT NOT NULL AUTO_INCREMENT,
  `Conta_Movimentacao_origem_id` INT NULL,
  `Conta_Movimetacao_destino` INT NOT NULL,
  `Movimentacao_valor` FLOAT NOT NULL,
  `Movimentacao_descricao` VARCHAR(45) NOT NULL,
  `Movimentacao_data` DATE NOT NULL,
  PRIMARY KEY (`Movimentacao_id`),
  INDEX `fk_Movimentacao_Conta1_idx` (`Conta_Movimentacao_origem_id` ASC) ,
  INDEX `fk_Movimentacao_Conta2_idx` (`Conta_Movimetacao_destino` ASC) ,
  CONSTRAINT `fk_Movimentacao_Conta1`
    FOREIGN KEY (`Conta_Movimentacao_origem_id`)
    REFERENCES `ProjetoBanking`.`Conta` (`Conta_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Movimentacao_Conta2`
    FOREIGN KEY (`Conta_Movimetacao_destino`)
    REFERENCES `ProjetoBanking`.`Conta` (`Conta_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Investimento` (
  `Investimento_id` INT NOT NULL AUTO_INCREMENT,
  `Investimento_nome` VARCHAR(45) NOT NULL,
  `Investimento_rentabilidade` FLOAT NULL DEFAULT 0,
  `Taxa_Taxa_id` INT NOT NULL,
  PRIMARY KEY (`Investimento_id`),
  INDEX `fk_Investimento_Taxa1_idx` (`Taxa_Taxa_id` ASC) ,
  UNIQUE INDEX `Investimento_nome_UNIQUE` (`Investimento_nome` ASC) ,
  CONSTRAINT `fk_Investimento_Taxa1`
    FOREIGN KEY (`Taxa_Taxa_id`)
    REFERENCES `ProjetoBanking`.`Taxa` (`Taxa_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Investimento_Conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Investimento_Conta` (
  `Investimento_Conta_Id` INT NOT NULL AUTO_INCREMENT,
  `Investimento_Investimento_id` INT NOT NULL,
  `Conta_Corrente_Conta_Conta_Corrente_id` INT NOT NULL,
  `Investimento_Conta_Valor` FLOAT NOT NULL,
  `Investimento_Inicio` DATE NOT NULL,
  `Investimento_Fim` DATE NULL,
  `Investimento_Resgate` DATE NULL DEFAULT NULL,
  `Investimento_Valor_Resgate` FLOAT NULL DEFAULT NULL,
  PRIMARY KEY (`Investimento_Conta_Id`),
  INDEX `fk_Investimento_has_Conta_Corrente_Conta_Corrente1_idx` (`Conta_Corrente_Conta_Conta_Corrente_id` ASC) ,
  INDEX `fk_Investimento_has_Conta_Corrente_Investimento1_idx` (`Investimento_Investimento_id` ASC) ,
  CONSTRAINT `fk_Investimento_has_Conta_Corrente_Investimento1`
    FOREIGN KEY (`Investimento_Investimento_id`)
    REFERENCES `ProjetoBanking`.`Investimento` (`Investimento_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Investimento_has_Conta_Corrente_Conta_Corrente1`
    FOREIGN KEY (`Conta_Corrente_Conta_Conta_Corrente_id`)
    REFERENCES `ProjetoBanking`.`Conta_Corrente` (`Conta_Conta_Corrente_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProjetoBanking`.`Gerente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ProjetoBanking`.`Gerente` (
  `Gerente_id` INT NOT NULL AUTO_INCREMENT,
  `Gerente_login` VARCHAR(45) NOT NULL,
  `Gerente_senha` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Gerente_login`),
  UNIQUE INDEX `Gerente_id_UNIQUE` (`Gerente_id` ASC) )
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
