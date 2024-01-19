/* BANCO DE DADOS DO CAMPO MINADO */

DROP DATABASE IF EXISTS campo_minado;

CREATE DATABASE campo_minado;

USE campo_minado;


CREATE TABLE scores(
	scoreId int(3) AUTO_INCREMENT,
	nomePlayer VARCHAR(200),
	tempoBomba VARCHAR(200),
	tempoJogado VARCHAR(200),
	dificuldade VARCHAR(200),
	tamanhoCampo VARCHAR(100),
	quantidadeBombas VARCHAR(100));
	
DROP USER IF EXISTS'campo_minado'@'localhost';

CREATE USER 'campo_minado'@'localhost' IDENTIFIED BY 'campMine@25';

GRANT SELECT, INSERT ON *. * TO 'campo_minado'@'localhost';

FLUSH PRIVILEGES;

	