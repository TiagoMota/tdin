SushiOrder

Esta � uma solu��o VS 2012 contendo 5 projetos. Cont�m uma aplica��o web que chama um m�todo remoto num objeto servido por um outro processo consola.

Common
======
Projeto contendo a defini��o da interface do objeto remoto e de um objeto seriaz�vel para transporte de informa��o entre clientes e objeto remoto.

Orders
======
Objeto remoto contendo um m�todo que retorna encomendas feitas de um utilizador (com uma entrada introduzida no construtor).

Server
======
Aplica��o consola servidora do objeto remoto.

Client
======
Cliente consola que chama (e apresenta resultados) o m�todo remoto disponibilizado pelo objeto remoto.

SushiOrder
==========
Projeto de um website ASP.NET (colocar no subdiret�rio WebSites do VS2012 (criar se n�o existir)). Este website referencia o objeto remoto, construindo um proxy (ver Web.config e c�digo do site), e chamando o seu m�todo remoto no handler do bot�o (quando de um postback). O resultado da chamada � apresentado num controlo de interface do tipo GridView, dispon�vel em ASP.NET.
