Projeto Para Publicar Postagem, Este projeto Não Precisa de realizar o Login
Banco de Dados utilizado SQL SERVER

CREATE TABLE [dbo].[NOTICIAS] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [DATA_REGISTRO]       DATE           NOT NULL,
    [USUARIO]       VARCHAR (100) NOT NULL,
	[TITULO]       VARCHAR (100) NOT NULL,
	[ARQUIVO]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_NOTICIAS] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[POSTAGEM] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [DATA_REGISTRO] DATE          NOT NULL,
    [USUARIO]       VARCHAR (100) NOT NULL,
    [TITULO]        VARCHAR (500) NOT NULL,
    [ARQUIVO]       VARCHAR (MAX) NOT NULL,
    [CURTIDA]       INT           NOT NULL,
    [DESCRICAO]     VARCHAR (500) NOT NULL,
    [TIPO]          VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_POSTAGEM] PRIMARY KEY CLUSTERED ([ID] ASC)
);






