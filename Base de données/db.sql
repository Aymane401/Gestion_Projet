drop database if exists hotel;
create database hotel;
use hotel;


/***********************************************************
	Table "CLIENT"
***********************************************************/

CREATE TABLE client
(
    noCli   char(5)     NOT NULL,
    nom     varchar(25) NULL,
    rue     varchar(25) NULL,
    email   varchar(25) NULL,
    tel     char(10)    NULL,
    PRIMARY KEY (noCli)
)
ENGINE=INNODB;



/***********************************************************
	Table "chambre"
***********************************************************/

CREATE TABLE chambre
(

	 noChambre    char(6)          NOT NULL,
     capacité     char(2)          NULL,
     typec        varchar(25)      NULL,
    PRIMARY KEY(noChambre)
  
)
ENGINE=INNODB;



/***********************************************************
	Table "reservation"
***********************************************************/

CREATE TABLE reservation
(
     noCli       char(5)        NOT NULL,
	 noReserv    char(6)        NOT NULL,
     montant     decimal(15,2)  NULL,
     datentre    date           NULL,
     datesortie  date           NULL,
     payee       varchar(3)     NULL,	 
	 noChambre   char(4)        NOT NULL,
    PRIMARY KEY(noReserv),
    FOREIGN KEY(noCli) REFERENCES client(noCli),
	FOREIGN KEY(noChambre) REFERENCES chambre(noChambre)
)
ENGINE=INNODB;



CREATE TABLE prix
(

	 noChambre    char(6)          NOT NULL,
     prix         char(6)          NULL,
     jour         date             NULL,
    FOREIGN KEY(noChambre) REFERENCES chambre(noChambre)
  
)
ENGINE=INNODB;